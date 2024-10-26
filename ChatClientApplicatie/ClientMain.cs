using ChatClientApplicatie;

namespace ChatApplicatie {
    internal static class ClientMain {
        [STAThread]
        static async Task Main() {

            //ApplicationConfiguration.Initialize();
            //Application.Run(new Choose);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            StartGui();
        }

        public static void StartGui() {
            Form mainForm = new Form();
            SignInScreen signInScreen = new SignInScreen(mainForm);

            signInScreen.Dock = DockStyle.Fill;

            mainForm.WindowState = FormWindowState.Maximized;
            mainForm.Controls.Add(signInScreen);
            mainForm.Text = "Client Application";
            Application.Run(mainForm);
        }
    }
}