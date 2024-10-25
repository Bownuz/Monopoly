namespace ChatApplicatie {
    internal static class ClientMain {
        [STAThread]
        static void Main() {
     
            ApplicationConfiguration.Initialize();
            Application.Run(new LoggingScreen());
        }
    }
}