using ChatClientApplicatie.GuiScreens;
using SendableObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatClientApplicatie.State {
    public class Login : State {

        public Login(DataProtocol protocol, Handler handler) : base(protocol, handler) {
        }

        public override string CheckInput(string input) {
            string loginData = null;
            try {
                List<string> lobbyList = JsonSerializer.Deserialize<List<string>>(input);
                ChooseLobby chooseLobby = new ChooseLobby(handler);
                chooseLobby.UpdateLobbyList(lobbyList);
                handler.ChangeScreen(chooseLobby);
                protocol.ChangeState(new SearchLobby(protocol, handler));
            }
            catch {
                if (input.Equals("Send userName")) {
                    loginData = handler.GetClientInfoAsJson();
                } else if (input.Equals("Username or password incorrect")) {
                    MessageBox.Show(input);
                } else if (input.Equals("This name already exists")) {
                    MessageBox.Show(input);
                } else if (input.Equals("Account does not exist")) {
                    MessageBox.Show(input);
                }
            }
            return loginData;
        }
    }

    public class SearchLobby : State {
        public SearchLobby(DataProtocol protocol, Handler handler) : base(protocol, handler) {
        }

        public override string CheckInput(string input) {
            if (input.Equals("Lobby joined")) {
                handler.ChangeScreen(new ChatScreen(handler));
                protocol.ChangeState(new Chat(protocol, handler));
            } else if (input.Equals("Lobby not found")) {
                MessageBox.Show("Lobby not found");
            }
            return null;
        }
    }

    public class Chat : State {
        public Chat(DataProtocol protocol, Handler handler) : base(protocol, handler) {
        }

        public override string CheckInput(string input) {
            try {
                string pattern = @"\[\{.*?\}\]";
                Match match = Regex.Match(input, pattern);

                if (match.Success) {
                    string cleanedInput = match.Value;
                    List<ChatMessage> messageList = JsonSerializer.Deserialize<List<ChatMessage>>(cleanedInput);

                    foreach (ChatMessage message in messageList) {

                        handler.ReceiveMessage(message.Sender + ": " + JsonDocument.Parse(message.Message).RootElement.GetProperty("message").ToString());
                        //JsonSerializer.Deserialize<List<ChatMessage>>(Encoding.UTF8.GetString(message.Message)));
                    }
                }
            }
            catch {
                List<string> lobbyList = JsonSerializer.Deserialize<List<string>>(input);

                ChooseLobby chooseLobby = new ChooseLobby(handler);
                chooseLobby.UpdateLobbyList(lobbyList);
                handler.ChangeScreen(chooseLobby);
                protocol.ChangeState(new SearchLobby(protocol, handler));
            }
            return null;
        }
    }
}
