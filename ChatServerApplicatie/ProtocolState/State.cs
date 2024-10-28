using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatServerApplicatie.ProtocolState {
    public abstract class ProtocolState {
        protected DataProtocol protocol;

        public ProtocolState(DataProtocol dataProtocol) { 
            protocol = dataProtocol;
        }

        public abstract String CheckUserInput(String input, Socket socket);
    }
}
