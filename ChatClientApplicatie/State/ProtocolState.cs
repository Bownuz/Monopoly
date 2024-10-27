using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatClientApplicatie.State {
    public class Login : State {

        public Login(DataProtocol protocol, Handler handler) : base(protocol, handler) {
        }

        public override string CheckInput(string input) {
            string loginData = null;

            if (input.Equals("Send userName")) {
                loginData = handler.GetClientInfoAsJson();
            } else if (input.Equals("Username or password incorrect")) {
                MessageBox.Show(input);
            } else if (input.Equals("This name already exists")) {
                MessageBox.Show(input);
            } else if (input.Equals("Welcome")) {
                protocol.ChangeState(new SearchLobby(protocol, handler));
            }
            return loginData;
        }
    }

    public class SearchLobby : State {
        public SearchLobby(DataProtocol protocol, Handler handler) : base(protocol, handler) {
        }

        public override string CheckInput(string input) {
            if (input.Equals("Lobby selected")) {
                protocol.ChangeState(new Chat(protocol, handler)); 
            } else if (input.Equals("Create lobby failed")) {
                MessageBox.Show("Failed to create the lobby. Please try again.");
            } else if (input.Equals("Lobby created")) {
                protocol.ChangeState(new Chat(protocol, handler)); 
            }
            return null;
        }
    }

    public class Chat : State {
        public Chat(DataProtocol protocol, Handler handler) : base(protocol, handler) { }

        public override string CheckInput(string input) {
            if (input.Equals("New message received")) {
                handler.ReceiveMessage(input);
            }
            return null;
        }
    }
}
