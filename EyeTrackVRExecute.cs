namespace EyeCameraStreamer
{
    internal class EyeTrackVRExecute
    {
        public void EnsureEyeTrackVRIsRunning()
        {
            bool enabled = Properties.Settings.Default.EyeTrackVR;
            string exePath = Properties.Settings.Default.EyeTrackVRPath;

            if (!enabled || string.IsNullOrWhiteSpace(exePath) || !System.IO.File.Exists(exePath))
                return;

            string processName = System.IO.Path.GetFileNameWithoutExtension(exePath);

            var processes = System.Diagnostics.Process.GetProcessesByName(processName);
            if (processes.Length == 0)
            {
                try
                {
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = exePath,
                        UseShellExecute = true,
                        WorkingDirectory = System.IO.Path.GetDirectoryName(exePath) // 作業ディレクトリを指定
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"EyeTrackVRの起動に失敗しました:\n{ex.Message}");
                }
            }
        }
    }
}
