using System.Windows.Forms;

namespace ChatClientApplicatie.GuiScreens {
    public class ScreenManager {
        private Form mainForm;
        public Form CurrentmainForm => mainForm;

        public ScreenManager(Form form) {
            this.mainForm = form;
        }

        public void ChangeScreen(UserControl newScreen) {
            mainForm.Controls.Clear();
            newScreen.Dock = DockStyle.Fill;
            mainForm.Controls.Clear();
            mainForm.Controls.Add(newScreen);
        }
    }
}
