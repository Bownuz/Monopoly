using ChatClientApplicatie.State;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ChatClientApplicatie {
    public partial class SignInScreen : UserControl {
        private TcpClient tcpClient;
        private Handler handler;
        private Boolean createAcount;
        private Socket client;
        public SignInScreen(Form mainform) {
            InitializeComponent();
            StartConnectionWithServer();
            this.createAcount = false;
        }

        public void StartConnectionWithServer() {
            //this.tcpClient = new TcpClient("localhost", 4789);
            this.handler = new Handler(tcpClient, UsernameTextBox.Text, PasswordTextBox.Text);
            Thread connectionThread = new Thread(() => handler.HandleThread());
            connectionThread.Start();

            IPAddress ipAddr = IPAddress.Parse("127.0.0.1");
            IPEndPoint localEndPoint = new IPEndPoint(ipAddr, 6666);

            client = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            client.Connect(localEndPoint);
        }

        private void label1_Click(object sender, EventArgs e) {
        }

        private void SubmitButton_Click(object sender, EventArgs e) {
            if (!string.IsNullOrWhiteSpace(UsernameTextBox.Text) && !string.IsNullOrWhiteSpace(PasswordTextBox.Text)) {
                handler.UpdateClientInfo(UsernameTextBox.Text, PasswordTextBox.Text, createAcount);
            } else {
                MessageBox.Show("You haven't filled everything in");
            }
        }

        private void CreateAcount_Click(object sender, EventArgs e) {
            if (createAcount) {
                UsernameLabel.Text = "Create username:";
                PasswordLabel.Text = "Create password:";
            } else {
                UsernameLabel.Text = "Username:";
                PasswordLabel.Text = "Password:";
            }
        }
    }
}
