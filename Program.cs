namespace EyeCameraStreamer
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            var mainForm = new EyeCameraStreamer();
            Application.Run(mainForm);
        }
    }
}