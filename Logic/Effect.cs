using OpenCvSharp;

namespace EyeCameraStreamer
{
    public class Effect()
    {
        private readonly CLAHE clahe = Cv2.CreateCLAHE(tileGridSize: new OpenCvSharp.Size(8, 8));
        public void ProcessClahe(Mat frame)
        {
            clahe.Apply(frame, frame);
        }

        public void UpdateClaheClipLimit()
        {
            clahe.ClipLimit = Properties.Settings.Default.ClaheLimit / 5.0;
        }
    }
}
