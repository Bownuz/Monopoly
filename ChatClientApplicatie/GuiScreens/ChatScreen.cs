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

        private void OnNewMessageReceived(string message) {
            ChatListBox.Invoke((MethodInvoker)delegate {
                ChatListBox.Items.Add(message);

                ChatListBox.TopIndex = ChatListBox.Items.Count - 1;
            });
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
    }
}
