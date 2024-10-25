using System.Net.Sockets;
using System.Net;
using System.Text;

namespace ChatApplicatie {
    public partial class LoggingScreen : Form {
        private Socket client;
        private NetworkStream stream;

        public LoggingScreen() {
            InitializeComponent();
        }

        private void Client_Load(object sender, EventArgs e) {
            IPAddress ipAddr = IPAddress.Parse("127.0.0.1");
            IPEndPoint localEndPoint = new IPEndPoint(ipAddr, 6666);

            client = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            client.Connect(localEndPoint);
        }

        private void ListenForMessages() {
            byte[] sizeIncomingPacket = new byte[4];

            while (true) {
                int byteSizeIncomingPacket = client.Receive(sizeIncomingPacket);
                int sizeMessage = BitConverter.ToInt32(sizeIncomingPacket);

                byte[] packet = new byte[sizeMessage];
                int bytePacket = client.Receive(packet);
            }
        }

        private void SendMessageButton_Click(object sender, EventArgs e) {
            string message = inputTextBox.Text;
            byte[] buffer = Encoding.UTF8.GetBytes(message);
            client.Send(buffer);
            inputTextBox.Clear();
        }
    }
}
