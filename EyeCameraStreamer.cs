using DirectShowLib;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System.Diagnostics;

namespace EyeCameraStreamer
{
    public partial class EyeCameraStreamer : Form
    {
        public bool shouldPreview = true;

        private readonly Core core;
        private readonly Effect effect = new();
        private EyeTrackVRExecute ETVR = new();
        private int previerwHistorySize = 30;

        public EyeCameraStreamer()
        {
            InitializeComponent();
            LoadCameraList();
            ProcessTime.Text = string.Empty;
            core = new(this, ETVR, effect);

            Activated += (s, e) =>
            {
                shouldPreview = true;
                SetPreviewText(string.Empty);
            };

            Deactivate += (s, e) =>
            {
                shouldPreview = false;
                SetPreviewText(StaticText.PreviewPausedText);
            };

            ckbClahe.CheckedChanged += (s, e) => core.shouldClahe = ckbClahe.Checked;
            ckbGamma.CheckedChanged += (s, e) => core.shouldGamma = ckbGamma.Checked;
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

            ckbGamma.Checked = Properties.Settings.Default.Gamma;
            sliderGamma.Value = Properties.Settings.Default.GammaValue;
            ckbClahe.Checked = Properties.Settings.Default.Clahe;
            sliderClahe.Value = Properties.Settings.Default.ClaheLimit;

            txtETVRPath.Text = Properties.Settings.Default.EyeTrackVRPath;
            ckbETVR.Checked = Properties.Settings.Default.EyeTrackVR;

            txtAffinity.Text = Properties.Settings.Default.Affinity;

            SetAffinity();
            effect.UpdateGamma();
            effect.UpdateClaheClipLimit();
            if (autoStart)
                core.StartAction();
        }

        private void OnClosing(object sender, FormClosingEventArgs e)
        {
            if (core.isStreaming) core.StopAction();
            SaveConfig();
        }

        private async void btnToggle_Click(object sender, EventArgs e)
        {
            if (!core.isStreaming)
            {
                SaveConfig();
                core.StartAction();
            }
            else
            {
                core.StopAction();
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
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

        private void btnAffinity_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Affinity = txtAffinity.Text.Trim();
            Properties.Settings.Default.Save();
            SetAffinity();
        }

        private void txtAffinity_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            string filtered = System.Text.RegularExpressions.Regex.Replace(tb.Text, "[^01]", "");

            if (tb.Text != filtered)
            {
                int cursorPosition = tb.SelectionStart;
                tb.Text = filtered;
                tb.SelectionStart = Math.Max(0, cursorPosition - 1);
            }
        }

        private void sliderClahe_Scroll(object sender, EventArgs e)
        {
            TrackBar slider = (TrackBar)sender;
            Properties.Settings.Default.ClaheLimit = slider.Value;
            effect.UpdateClaheClipLimit();
        }

        private void sliderGamma_Scroll(object sender, EventArgs e)
        {
            TrackBar slider = (TrackBar)sender;
            Properties.Settings.Default.GammaValue = slider.Value;
            effect.UpdateGamma();
        }

        private void SaveConfig()
        {
            Properties.Settings.Default.CameraIndex = comboBoxCameras.SelectedIndex;
            Properties.Settings.Default.AutoStart = ckbAutoStart.Checked;

            Properties.Settings.Default.SizeW = int.TryParse(txtW.Text, out int w) ? w : 800;
            Properties.Settings.Default.SizeH = int.TryParse(txtH.Text, out int h) ? h : 400;
            Properties.Settings.Default.PortLeft = int.TryParse(txtPortLeft.Text, out int portL) ? portL : 8080;
            Properties.Settings.Default.PortRight = int.TryParse(txtPortRight.Text, out int portR) ? portR : 808;
            Properties.Settings.Default.TargetFps = int.TryParse(txtFps.Text, out int fps) ? fps : 30;

            Properties.Settings.Default.Gamma = ckbGamma.Checked;
            Properties.Settings.Default.GammaValue = sliderGamma.Value;
            Properties.Settings.Default.Clahe = ckbClahe.Checked;
            Properties.Settings.Default.ClaheLimit = sliderClahe.Value;

            Properties.Settings.Default.EyeTrackVR = ckbETVR.Checked;

            Properties.Settings.Default.Save();
        }

        private void LoadCameraList()
        {
            var devices = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice);
            foreach (var d in devices) comboBoxCameras.Items.Add(d.Name);
            if (comboBoxCameras.Items.Count > 0) comboBoxCameras.SelectedIndex = 0;
        }

        public void UpdateUI(bool isStart)
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

        public void SetPreviewText(string text)
        {
            pictureBoxPreview.Invoke(() =>
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
            });    
        }

        public void SetAddressText(string left, string right)
        {
            LeftAddress.Text = left;
            RightAddress.Text = right;
        }

        public static void SetAffinity()
        {
            var binaryText = Properties.Settings.Default.Affinity;
            long maxMask = (1L << Environment.ProcessorCount) - 1;
            IntPtr affinityMask;
            if (string.IsNullOrEmpty(binaryText))
            {
                affinityMask = checked((IntPtr)maxMask);
            }
            else
            {
                long maskValue = Convert.ToInt64(binaryText, 2);

                if ((maskValue & ~maxMask) != 0)
                {
                    MessageBox.Show($"over CPU Cores ({Environment.ProcessorCount})");
                    return;
                }

                affinityMask = checked((IntPtr)maskValue);
            }
           
            try
            {
                Process.GetCurrentProcess().ProcessorAffinity = affinityMask;
            }
            catch (OverflowException)
            {
                MessageBox.Show("Invalid Affinity", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private readonly Queue<long> processTimeHistory = new();
        private readonly Queue<long> previewTimeHistory = new();
        public void Preview(Mat frame, Stopwatch sw)
        {
            processTimeHistory.Enqueue(sw.ElapsedMilliseconds);
            if (processTimeHistory.Count > previerwHistorySize) processTimeHistory.Dequeue();
            string processTimeText = $"Live: {processTimeHistory.Average():F2}ms";

            var bmp = frame.ToBitmap();
            pictureBoxPreview.Invoke(new Action(() =>
            {
                pictureBoxPreview.Image?.Dispose();
                pictureBoxPreview.Image = bmp;

                previewTimeHistory.Enqueue(sw.ElapsedMilliseconds);
                if (previewTimeHistory.Count > previerwHistorySize) previewTimeHistory.Dequeue();
                string previewTimeText = $"Preview: {previewTimeHistory.Average():F2}ms";
                
                ProcessTime.Text = $"{previewTimeText}    {processTimeText}";
            }));
        }

        public void ClearView()
        {
            pictureBoxPreview.Invoke(() =>
            {
                pictureBoxPreview.Image?.Dispose();
                pictureBoxPreview.Image = null;
                ProcessTime.Text = string.Empty;
            });
        }
    }
}
