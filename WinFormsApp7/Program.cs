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
            Application.Run(new MainForm());

        }

        public static class AppConfig
        {
            // Where user-uploaded songs are stored
            public static string songCoverImg = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "SpotiEwan", "coverImg"
            );
            public static string SongsFolder = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "YourAppName", "songs"
            );

            // Where the 30 preset MP3s live (next to the .exe)
            public static string PresetsFolder = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory, "presets"
            );

            public static void Initialize()
            {
                Directory.CreateDirectory(SongsFolder);
            }

            // Returns the correct full path depending on preset or uploaded
            public static string ResolveSongPath(string fileName, bool isPreset)
            {
                if (isPreset)
                    return Path.Combine(PresetsFolder, fileName);
                else
                    return Path.Combine(SongsFolder, fileName);
            }
        }

    }
}