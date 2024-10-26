using ChatClientApplicatie;

namespace ChatApplicatie {
    internal static class ClientMain {
        [STAThread]
        static void Main() {

            //ApplicationConfiguration.Initialize();
            //Application.Run(new Choose);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            StartGui();
        }

        public static void StartGui() {
            Form mainForm = new Form();
            SignInScreen userControl = new SignInScreen(mainForm);

            userControl.Dock = DockStyle.Fill;

            mainForm.WindowState = FormWindowState.Maximized;
            mainForm.Controls.Add(userControl);
            mainForm.Text = "Client Application";
            Application.Run(mainForm);
        }
    }
}