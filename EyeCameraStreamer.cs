using DirectShowLib;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System.Diagnostics;


namespace EyeCameraStreamer
{
    public partial class EyeCameraStreamer : Form
    {
        private const string PreviewPausedText = "PREVIEW PAUSED";
        private const string CameraDisconnectedText = "DISCONNECTED";

        private VideoCapture capture;
        private bool isStreaming = false;
        private CancellationTokenSource cts;
        private byte[] latestLeftFrame;
        private byte[] latestRightFrame;
        private AutoResetEvent leftFrameReadyEvent = new AutoResetEvent(false);
        private AutoResetEvent rightFrameReadyEvent = new AutoResetEvent(false);
        private Streamer streamer = new();
        private EyeTrackVRExecute ETVR = new();
        private bool shouldPreview = true;
        private bool shouldNormalize = false;
        private bool shouldClahe = false;
        private int fps = 30;
        private int historyLength = 300;

        public EyeCameraStreamer()
        {
            InitializeComponent();
            LoadCameraList();
            ProcessTime.Text = string.Empty;

            Activated += (s, e) =>
            {
                shouldPreview = true;
                SetPreviewText(string.Empty);
            };

            Deactivate += (s, e) =>
            {
                shouldPreview = false;
                SetPreviewText(PreviewPausedText);
            };

            ckbNormalize.CheckedChanged += (s, e) => shouldNormalize = ckbNormalize.Checked;
            ckbClahe.CheckedChanged += (s, e) => shouldClahe = ckbClahe.Checked;
        }

        private void OnLoad(object sender, EventArgs e)
        {
            var autoStart = Properties.Settings.Default.AutoStart;

            comboBoxCameras.SelectedIndex = Properties.Settings.Default.CameraIndex;
            ckbAutoStart.Checked = autoStart;

            txtW.Text = Properties.Settings.Default.SizeW.ToString();
            txtH.Text = Properties.Settings.Default.SizeH.ToString();
            txtPortLeft.Text = Properties.Settings.Default.PortLeft.ToString();
            txtPortRight.Text = Properties.Settings.Default.PortRight.ToString();
            txtFps.Text = Properties.Settings.Default.TargetFps.ToString();

            ckbNormalize.Checked = Properties.Settings.Default.Normalize;
            ckbClahe.Checked = Properties.Settings.Default.Clahe;

            txtETVRPath.Text = Properties.Settings.Default.EyeTrackVRPath;
            ckbETVR.Checked = Properties.Settings.Default.EyeTrackVR;

            if (autoStart)
                StartAction();
        }

        private void OnClosing(object sender, FormClosingEventArgs e)
        {
            if (isStreaming) StopAction();

            Properties.Settings.Default.CameraIndex = comboBoxCameras.SelectedIndex;
            Properties.Settings.Default.AutoStart = ckbAutoStart.Checked;
            Properties.Settings.Default.SizeW = int.TryParse(txtW.Text, out int w) ? w : 800;
            Properties.Settings.Default.SizeH = int.TryParse(txtH.Text, out int h) ? h : 400;
            Properties.Settings.Default.PortLeft = int.TryParse(txtPortLeft.Text, out int portL) ? portL : 8080;
            Properties.Settings.Default.PortRight = int.TryParse(txtPortRight.Text, out int portR) ? portR : 808;
            Properties.Settings.Default.TargetFps = int.TryParse(txtFps.Text, out int fps) ? fps : 30;
            Properties.Settings.Default.Normalize = ckbNormalize.Checked;
            Properties.Settings.Default.Clahe = ckbClahe.Checked;
            Properties.Settings.Default.Save();
        }

        private void LoadCameraList()
        {
            var devices = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice);
            foreach (var d in devices) comboBoxCameras.Items.Add(d.Name);
            if (comboBoxCameras.Items.Count > 0) comboBoxCameras.SelectedIndex = 0;
        }

        private async void btnToggle_Click(object sender, EventArgs e)
        {
            if (!isStreaming)
            {
                StartAction();
            }
            else
            {
                StopAction();
            }
        }

        public void btnBrowse_Click(object sender, EventArgs e)
        {
            using OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Executable files (*.exe)|*.exe";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.EyeTrackVRPath = ofd.FileName;
                Properties.Settings.Default.EyeTrackVR = true;
                txtETVRPath.Text = ofd.FileName;
                ckbETVR.Checked = true;
                Properties.Settings.Default.Save();
                ETVR.EnsureEyeTrackVRIsRunning();
            }
        }

        private async void StartAction()
        {
            ETVR.EnsureEyeTrackVRIsRunning();

            int cameraIndex = comboBoxCameras.SelectedIndex;
            if (!int.TryParse(txtPortLeft.Text, out int portLeft) ||
                !int.TryParse(txtPortRight.Text, out int portRight) ||
                !int.TryParse(txtFps.Text, out fps) || fps <= 0 ||
                !int.TryParse(txtW.Text, out int sizeW) || sizeW <= 0 ||
                !int.TryParse(txtH.Text, out int sizeH) || sizeH <= 0)
            {
                MessageBox.Show("設定値を正しく入力してください。");
                return;
            }

            historyLength = fps * 10;
            cts = new CancellationTokenSource();
            isStreaming = true;
            UpdateUI(true);

            LeftAddress.Text = $"localhost:{portLeft}";
            RightAddress.Text = $"localhost:{portRight}";

            streamer.StartHttpServer(portLeft, () => latestLeftFrame, cts.Token, leftFrameReadyEvent);
            streamer.StartHttpServer(portRight, () => latestRightFrame, cts.Token, rightFrameReadyEvent);

            try
            {
                var size = new OpenCvSharp.Size(sizeW, sizeH);
                await Task.Run(() => StreamLoop(cameraIndex, size, cts.Token));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"エラー: {ex.Message}");
                StopAction();
            }
        }

        private void StopAction()
        {
            cts?.Cancel();
            isStreaming = false;
            capture?.Release();
            pictureBoxPreview.Image = null;
            LeftAddress.Text = string.Empty;
            RightAddress.Text = string.Empty;
            UpdateUI(false);
        }

        private void UpdateUI(bool isStart)
        {
            if (isStart)
            {
                btnToggle.Text = "Stop";
                btnToggle.BackColor = Color.DarkRed;
            }
            else
            {
                btnToggle.Text = "Start";
                btnToggle.BackColor = Color.DimGray;
                ProcessTime.Text = string.Empty;
            }

            var enabled = !isStart;
            comboBoxCameras.Enabled = enabled;
            txtW.Enabled = enabled;
            txtH.Enabled = enabled;
            txtPortLeft.Enabled = enabled;
            txtPortRight.Enabled = enabled;
            txtFps.Enabled = enabled;
        }

        private void SetPreviewText(string text)
        {
            if (text == string.Empty)
            {
                txtPreview.Text = string.Empty;
                txtPreview.Visible = false;
            }
            else
            {
                txtPreview.Text = text;
                txtPreview.Visible = true;
            }
            
        }

        public void SetCapture(int index, OpenCvSharp.Size size)
        {
            capture = new VideoCapture(index, VideoCaptureAPIs.DSHOW);
            capture.Set(VideoCaptureProperties.FourCC, FourCC.MJPG);
            capture.Set(VideoCaptureProperties.BufferSize, 1);
            capture.Set(VideoCaptureProperties.FrameWidth, size.Width);
            capture.Set(VideoCaptureProperties.FrameHeight, size.Height);
        }

        public async void StreamLoop(int index, OpenCvSharp.Size size, CancellationToken token)
        {
            SetCapture(index, size);
            using var frame = new Mat();

            var sw = Stopwatch.StartNew();
            using var timer = new PeriodicTimer(TimeSpan.FromMilliseconds(1000.0 / fps));

            while (!token.IsCancellationRequested && await timer.WaitForNextTickAsync(token))
            {
                sw.Restart();
                if (capture.IsOpened() && capture.Read(frame) && !frame.Empty())
                {
                    Cv2.CvtColor(frame, frame, ColorConversionCodes.BGR2GRAY);

                    if (shouldClahe)
                        ProcessClahe(frame);

                    if (shouldNormalize)
                        ProcessNormalize(frame);

                    int halfW = frame.Width / 2;
                    using var left = new Mat(frame, new Rect(0, 0, halfW, frame.Height));
                    using var right = new Mat(frame, new Rect(halfW, 0, halfW, frame.Height));

                    latestLeftFrame = left.ToBytes(".jpg");
                    latestRightFrame = right.ToBytes(".jpg");
                    leftFrameReadyEvent.Set();
                    rightFrameReadyEvent.Set();

                    if (shouldPreview)
                        Preview(frame, sw);
                }
                else
                {
                    capture.Dispose();

                    pictureBoxPreview.Invoke(() => SetPreviewText(CameraDisconnectedText));


                    Thread.Sleep(1000);
                    SetCapture(index, size);
                    if (capture.IsOpened())
                        pictureBoxPreview.Invoke(() => SetPreviewText(shouldPreview ? string.Empty : PreviewPausedText));
                }
            }
            capture.Dispose();
        }

        private Queue<double> brightnessHistory = new();
        private CLAHE clahe = Cv2.CreateCLAHE(clipLimit: 2.0, tileGridSize: new OpenCvSharp.Size(8, 8));
        private void ProcessClahe(Mat frame)
        {
            Scalar mean = Cv2.Mean(frame);
            brightnessHistory.Enqueue(mean.Val0);
            if (brightnessHistory.Count > historyLength) brightnessHistory.Dequeue();

            double avgBrightness = brightnessHistory.Average();
            clahe.ClipLimit = (avgBrightness < 50) ? 3.0 : 2.0;

            clahe.Apply(frame, frame);
        }

        private Queue<double> minHistory = new();
        private Queue<double> maxHistory = new();
        private void ProcessNormalize(Mat frame)
        {
            frame.MinMaxLoc(out double currentMin, out double currentMax);

            minHistory.Enqueue(currentMin);
            maxHistory.Enqueue(currentMax);

            if (minHistory.Count > historyLength) minHistory.Dequeue();
            if (maxHistory.Count > historyLength) maxHistory.Dequeue();

            double stableMin = minHistory.Min();
            double stableMax = maxHistory.Max();

            if (stableMax - stableMin > 1)
            {
                frame.ConvertTo(frame, MatType.CV_8U, 255.0 / (stableMax - stableMin), -stableMin * (255.0 / (stableMax - stableMin)));
            }
        }

        private Queue<long> processTimeHistory = new();
        private Queue<long> previewTimeHistory = new();
        private void Preview(Mat frame, Stopwatch sw)
        {
            int historySize = historyLength / 5;

            processTimeHistory.Enqueue(sw.ElapsedMilliseconds);
            if (processTimeHistory.Count > historySize) processTimeHistory.Dequeue();
            string processTimeText = $"Live: {processTimeHistory.Average():F2}ms";

            var bmp = frame.ToBitmap();
            pictureBoxPreview.Invoke(new Action(() =>
            {
                pictureBoxPreview.Image?.Dispose();
                pictureBoxPreview.Image = bmp;

                previewTimeHistory.Enqueue(sw.ElapsedMilliseconds);
                if (previewTimeHistory.Count > historySize) previewTimeHistory.Dequeue();
                string previewTimeText = $"Preview: {previewTimeHistory.Average():F2}ms";
                
                ProcessTime.Text = $"{previewTimeText}    {processTimeText}";
            }));
        }
    }
}
