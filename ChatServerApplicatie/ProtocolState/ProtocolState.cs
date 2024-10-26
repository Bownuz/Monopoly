using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatServerApplicatie.ProtocolState {
    class Login : ProtocolState {
        public Login(DataProtocol dataProtocol) : base(dataProtocol) {
        }

        public override string CheckUserInput(string input) {
            throw new NotImplementedException();
        }
    }
    class SearchLobby : ProtocolState {
        public SearchLobby(DataProtocol dataProtocol) : base(dataProtocol) {
        }

        public override string CheckUserInput(string input) {
            throw new NotImplementedException();
        }
    }
    class ChatMessage : ProtocolState {
        public ChatMessage(DataProtocol dataProtocol) : base(dataProtocol) {
        }

        public override string CheckUserInput(string input) {
            throw new NotImplementedException();
        }
    }
    class Exit : ProtocolState {
        public Exit(DataProtocol dataProtocol) : base(dataProtocol) {
        }

        public override string CheckUserInput(string input) {
            throw new NotImplementedException();
        }
    }
}
