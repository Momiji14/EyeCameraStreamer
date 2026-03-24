
using OpenCvSharp;
using System.Diagnostics;

namespace EyeCameraStreamer
{
    internal class Core(EyeCameraStreamer form, EyeTrackVRExecute ETVR, Effect effect)
    {
        public bool isStreaming = false;
        public bool shouldClahe = false;
        public int fps = 30;

        private VideoCapture? capture;
        private CancellationTokenSource? cts;
        private byte[] latestLeftFrame = [];
        private byte[] latestRightFrame = [];
        private AutoResetEvent leftFrameReadyEvent = new AutoResetEvent(false);
        private AutoResetEvent rightFrameReadyEvent = new AutoResetEvent(false);
        private Streamer streamer = new();

        public async void StartAction()
        {
            ETVR.EnsureEyeTrackVRIsRunning();

            int cameraIndex = Properties.Settings.Default.CameraIndex;

            int sizeW = Properties.Settings.Default.SizeW;
            int sizeH = Properties.Settings.Default.SizeH;
            int portLeft = Properties.Settings.Default.PortLeft;
            int portRight = Properties.Settings.Default.PortRight;
            fps = Properties.Settings.Default.TargetFps;

            if (fps <= 0 || sizeW <= 0 || sizeH <= 0)
            {
                MessageBox.Show("Invalid Setting Value");
                return;
            }

            cts = new CancellationTokenSource();
            isStreaming = true;

            form.UpdateUI(true);
            form.SetAddressText($"localhost:{portLeft}", $"localhost:{portRight}");

            streamer.StartHttpServer(portLeft, () => latestLeftFrame, cts.Token, leftFrameReadyEvent);
            streamer.StartHttpServer(portRight, () => latestRightFrame, cts.Token, rightFrameReadyEvent);

            try
            {
                var size = new OpenCvSharp.Size(sizeW, sizeH);
                await Task.Run(() => StreamLoop(cameraIndex, size, cts.Token));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                StopAction();
            }
        }

        public void StopAction()
        {
            isStreaming = false;

            try
            {
                cts?.Cancel();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            form.UpdateUI(false);
            form.SetAddressText(string.Empty, string.Empty);
            form.ClearView();
        }

        private void SetCapture(int index, OpenCvSharp.Size size)
        {
            capture = new VideoCapture(index, VideoCaptureAPIs.DSHOW);
            capture.Set(VideoCaptureProperties.HwAcceleration, 1);
            capture.Set(VideoCaptureProperties.FourCC, FourCC.MJPG);
            capture.Set(VideoCaptureProperties.BufferSize, 1);
            capture.Set(VideoCaptureProperties.FrameWidth, size.Width);
            capture.Set(VideoCaptureProperties.FrameHeight, size.Height);
        }

        public async void StreamLoop(int index, OpenCvSharp.Size size, CancellationToken token)
        {

            SetCapture(index, size);

            if (capture == null)
            {
                MessageBox.Show("Camera Not Opened.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using var frame = new Mat();

            var sw = Stopwatch.StartNew();
            using var timer = new PeriodicTimer(TimeSpan.FromMilliseconds(1000.0 / fps));

            try
            {
                while (!token.IsCancellationRequested && await timer.WaitForNextTickAsync(token))
                {
                    sw.Restart();

                    if (capture.IsOpened() && capture.Read(frame) && !frame.Empty())
                    {
                        Cv2.CvtColor(frame, frame, ColorConversionCodes.BGR2GRAY);

                        if (shouldClahe)
                            effect.ProcessClahe(frame);

                        int halfW = frame.Width / 2;
                        using var left = new Mat(frame, new Rect(0, 0, halfW, frame.Height));
                        using var right = new Mat(frame, new Rect(halfW, 0, halfW, frame.Height));

                        latestLeftFrame = left.ToBytes(".jpg");
                        latestRightFrame = right.ToBytes(".jpg");
                        leftFrameReadyEvent.Set();
                        rightFrameReadyEvent.Set();

                        if (form.shouldPreview)
                            form.Preview(frame, sw);
                    }
                    else
                    {
                        capture.Dispose();
                        form.SetPreviewText(StaticText.CameraDisconnectedText);

                        Thread.Sleep(1000);
                        SetCapture(index, size);
                        if (capture.IsOpened())
                            form.SetPreviewText(form.shouldPreview ? string.Empty : StaticText.PreviewPausedText);
                    }
                }
            }
            catch (OperationCanceledException)
            {
                
            }
            finally
            {
                timer.Dispose();
                capture.Dispose();
            }
        }
    }
}
