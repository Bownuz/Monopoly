using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatServerApplicatie.ProtocolState {
    public class DataProtocol {
        private ProtocolState state;

        public ProtocolState CurrentState => state;

        public DataProtocol() {
            this.state = new Login(this);
        }
        public String processInput(String input, Socket socket) {
            return state.CheckUserInput(input, socket);
        }

        public void ChangeState(ProtocolState newState) {
            this.state = newState;
        }
    }
}
