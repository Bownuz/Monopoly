using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatClientApplicatie.State {
    public class DataProtocol {
        private State state;

        public DataProtocol(Handler handler) {
            this.state = new Login(this, handler);
        }

        public string processInput(string input) {
            return state.CheckInput(input);
        }

        public void ChangeState(State newState) {
            this.state = newState;
        }
    }
}
