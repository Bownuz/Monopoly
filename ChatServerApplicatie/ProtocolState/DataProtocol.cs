using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatServerApplicatie.ProtocolState {
    public class DataProtocol {
        private ProtocolState state;

        public DataProtocol() {
            this.state = new Login(this);
        }
        public String processInput(String input) {
            return state.CheckUserInput(input);
        }

        public void ChangeState(ProtocolState newState) {
            this.state = newState;
        }
    }
}
