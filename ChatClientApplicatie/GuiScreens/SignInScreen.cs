using ChatClientApplicatie.GuiScreens;
using ChatClientApplicatie.State;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ChatClientApplicatie {
    public partial class SignInScreen : UserControl {
        private Socket clientSocket;
        private Handler handler;
        private bool createAccount = false;
        private ScreenManager screenManager;

        public SignInScreen(ScreenManager screenManager) {
            this.screenManager = screenManager;
            InitializeComponent();
            StartConnectionWithServerAsync();
        }

        private async Task StartConnectionWithServerAsync() {
            IPAddress ipAddr = IPAddress.Parse("127.0.0.1");
            IPEndPoint localEndPoint = new IPEndPoint(ipAddr, 7272);

            clientSocket = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            await clientSocket.ConnectAsync(localEndPoint);
            handler = new Handler(clientSocket, UsernameTextBox.Text, PasswordTextBox.Text, screenManager);

            await handler.HandleAsync();
        }

        private void SubmitButton_Click(object sender, EventArgs e) {
            if (!string.IsNullOrWhiteSpace(UsernameTextBox.Text) && !string.IsNullOrWhiteSpace(PasswordTextBox.Text)) {
                handler.UpdateClientInfo(UsernameTextBox.Text, PasswordTextBox.Text, createAccount);
            } else {
                MessageBox.Show("Please fill in all fields.");
            }
        }

        private void CreateAcount_Click_1(object sender, EventArgs e) {
            Console.WriteLine(createAccount);
            createAccount = !createAccount;
            if (createAccount) {
                UsernameLabel.Text = "Create username:";
                PasswordLabel.Text = "Create password:";
            } else {
                UsernameLabel.Text = "Username:";
                PasswordLabel.Text = "Password:";
            }
        }

        private void UsernameLabel_Click(object sender, EventArgs e) {

        }
    }
}
