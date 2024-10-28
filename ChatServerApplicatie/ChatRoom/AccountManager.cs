using ChatServerApplicatie.Chatroom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatServerApplicatie.ChatRoom {
    internal class AccountManager {
        public static Dictionary<string, byte[]> Accounts { get; set; } = new Dictionary<string, byte[]>();
    }
}
