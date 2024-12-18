﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatClientApplicatie.State {
    public abstract class State {
        protected DataProtocol protocol;
        protected Handler handler;

        protected State(DataProtocol protocol, Handler handler) {
            this.protocol = protocol;
            this.handler = handler;
        }

        public abstract string CheckInput(string input);

    }
}
