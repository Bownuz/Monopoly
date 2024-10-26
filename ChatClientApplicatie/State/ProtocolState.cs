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
            string patientData = null;
            if (input.Equals("Ready to recieve data")) {
                //patientData = handler.dataHandler.printDataAsJson();
                protocol.ChangeState(new ChatMessage(protocol, handler));
            }
            return patientData;
        }
    }

    public class ChatMessage : State {
        public ChatMessage(DataProtocol protocol, Handler handler) : base(protocol, handler) {
        }

        public override string CheckInput(string input) {
            string patientData = null;
            if (input.Equals("Ready to recieve data")) {
                //patientData = handler.dataHandler.printDataAsJson();
            }
            return patientData;
        }
    }

    public class Exit : State {
        public Exit(DataProtocol protocol, Handler handler) : base(protocol, handler) {
        }

        public override string CheckInput(string input) {
            return "";
        }
    }
}
