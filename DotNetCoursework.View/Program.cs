using System.Diagnostics.Eventing.Reader;

namespace DotNetCoursework.View
{
    internal static class Program
    {

        public static bool KeepRunning { get; set; }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        ///
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            KeepRunning = true;
            while (KeepRunning)
            {
                KeepRunning = false;
                Application.Run(new Form1());
            }
        }
    }
}