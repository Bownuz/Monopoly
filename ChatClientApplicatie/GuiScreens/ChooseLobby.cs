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

namespace ChatClientApplicatie {
    public partial class ChooseLobby : UserControl {
        private Handler handler;
        public ChooseLobby(Handler handler) {
            InitializeComponent();
            this.handler = handler;
        }

        private void ChooseLobby_Load(object sender, EventArgs e) {
            lobbyListBox.Items.Add("Lobby 1");
            lobbyListBox.Items.Add("Lobby 2");
            lobbyListBox.Items.Add("Private Chat 1");
        }

        private void CreateLobbyButton_Click_1(object sender, EventArgs e) {
            string newLobbyName = CreateLobbyTextBox.Text.Trim();
            if (!string.IsNullOrWhiteSpace(newLobbyName)) {
                handler.UpdateLobbyInfo(newLobbyName);  // Stuur nieuwe lobbyinformatie naar de server
                handler.protocol.ChangeState(new Chat(handler.protocol, handler));
            } else {
                MessageBox.Show("Please enter a name for the new lobby.");
            }
        }

        private void JoinLobbyButton_Click_1(object sender, EventArgs e) {
            if (lobbyListBox.SelectedItem != null) {
                string selectedLobby = lobbyListBox.SelectedItem.ToString();
                handler.UpdateLobbyInfo(selectedLobby);  // Stuur lobbyinformatie naar de server
                // Verander naar de Chat state en GUI
                handler.protocol.ChangeState(new Chat(handler.protocol, handler));
            } else {
                MessageBox.Show("Please select a lobby to join.");
            }
        }
    }
}
