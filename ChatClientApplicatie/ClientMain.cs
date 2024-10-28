using ChatClientApplicatie;
using ChatClientApplicatie.GuiScreens;

namespace ChatApplicatie {
    internal static class ClientMain {
        [STAThread]
        static async Task Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            await Task.Run(() => {
                StartGui();
            });
        }

        public static void StartGui() {
            Form mainForm = new Form {
                WindowState = FormWindowState.Maximized,
                Text = "Client Application"
            };
            ScreenManager screenManager = new ScreenManager(mainForm);

            screenManager.ChangeScreen(new SignInScreen(screenManager));
            Application.Run(mainForm);
        }
    }
}