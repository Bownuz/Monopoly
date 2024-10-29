using ChatClientApplicatie.GuiScreens;
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

        public void CreateLobbyButton_Click() {
            var lobbyName = CreateLobbyTextBox.Text;
            if (!string.IsNullOrWhiteSpace(lobbyName)) {
                handler.UpdateLobbyInfo(lobbyName);
                UpdateLobbyList(new List<string> { lobbyName });
            }
        }

        public List<string> GetLobbyList() {
            return lobbyListBox.Items.Cast<string>().ToList();
        }

        public string GetCreateLobbyText() {
            return CreateLobbyTextBox.Text;
        }

        private void CreateLobbyButton_Click_1(object sender, EventArgs e) {
            string newLobbyName = CreateLobbyTextBox.Text.Trim();
            if (!string.IsNullOrWhiteSpace(newLobbyName)) {
                handler.UpdateLobbyInfo(newLobbyName);
            } else {
                MessageBox.Show("Please enter a name for the new lobby.");
            }
        }

        public void UpdateLobbyList(List<string> lobbyList) {
            foreach (string name in lobbyList) {
                lobbyListBox.Items.Add(name);
            }
            lobbyListBox.Show();
        }

        private void JoinLobbyButton_Click_1(object sender, EventArgs e) {
            if (lobbyListBox.SelectedItem != null) {
                string selectedLobby = lobbyListBox.SelectedItem.ToString();
                handler.UpdateLobbyInfo(selectedLobby);
            } else {
                MessageBox.Show("Please select a lobby to join.");
            }
        }

        private void ChooseLobby_Load_1(object sender, EventArgs e) {

        }

        private void lobbyListBox_SelectedIndexChanged(object sender, EventArgs e) {

        }
    }
}
