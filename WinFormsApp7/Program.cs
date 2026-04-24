namespace WinFormsApp7
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            AppConfig.Initialize();
            Application.Run(new LoginForm());
        }

        public static class AppConfig
        {
            public static string SongsFolder = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "WinFormsApp7", "songs"
            );

            public static void Initialize()
            {
                Directory.CreateDirectory(SongsFolder); // Creates folder if it doesn't exist
            }
        }
    }
}