using OpenCvSharp;

namespace EyeCameraStreamer
{
    public class Effect()
    {
        private readonly CLAHE clahe = Cv2.CreateCLAHE(tileGridSize: new OpenCvSharp.Size(8, 8));
        private Mat gammaLut = Mat.FromPixelData(1, 256, MatType.CV_8UC1, new byte[256]);

        public void ProcessGamma(Mat frame)
        {
            Cv2.LUT(frame, gammaLut, frame);
        }

        public void UpdateGamma()
        {
            double gamma = Properties.Settings.Default.GammaValue / 20f;

            byte[] lut = new byte[256];
            for (int i = 0; i < 256; i++)
            {
                lut[i] = (byte)(Math.Pow(i / 255.0, 1.0 / gamma) * 255.0);
            }

            gammaLut?.Dispose();
            gammaLut = Mat.FromPixelData(1, 256, MatType.CV_8UC1, lut);
        }

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
