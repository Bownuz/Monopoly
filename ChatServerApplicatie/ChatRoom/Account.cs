using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatServerApplicatie.ChatRoom {
    internal class Account {
        public string name { get; }
        public byte[] passwdHash { get; }

        public Account(string name, byte[] passwdHash) {
            this.name = name;
            this.passwdHash = passwdHash;
        }

    }
}
