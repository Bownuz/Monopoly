using ChatClientApplicatie.State;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatClientApplicatie.GuiScreens {
    public partial class ChatScreen : UserControl {
        private Handler handler;

        public ChatScreen(Handler handler) {
            InitializeComponent();
            this.handler = handler;

            handler.NewMessage += OnNewMessageReceived;
        }

        public void ClearChatListBox() {
            ChatListBox.Invoke((MethodInvoker) delegate {
                ChatListBox.Items.Clear();
            });
        }

        private void OnNewMessageReceived(string message) {
            ChatListBox.Invoke((MethodInvoker)delegate {
                ChatListBox.Items.Add(message);

                ChatListBox.TopIndex = ChatListBox.Items.Count - 1;
            });
        }

        public List<string> GetChatMessages() {
            return ChatListBox.Items.Cast<string>().ToList();
        }

        private void SendButton_Click(object sender, EventArgs e) {
            string message = MessageTextBox.Text.Trim();
            if (!string.IsNullOrWhiteSpace(message)) {
                handler.SendChatMessage(message);
                MessageTextBox.Clear();
            }
        }

        private void ChatScreen_Load(object sender, EventArgs e) {
        }

        private void MessageTextBox_TextChanged(object sender, EventArgs e) {

        }

        private void BackButton_Click(object sender, EventArgs e) {
            MessageCommunication.SendMessage(handler.clientSocket, "Go back");
        }

        internal void ShowMessage(string input) {
            ChatListBox.Items.Add(input);
        }
    }
}
