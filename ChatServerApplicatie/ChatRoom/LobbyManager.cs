using ChatServerApplicatie.Chatroom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatServerApplicatie.ChatRoom {
    internal static class LobbyManager {
        private static Dictionary<string, IChatroom> lobbies = new Dictionary<string, IChatroom>();

        public static IChatroom GetOrCreateLobby(string lobbyName) {
            if (!lobbies.ContainsKey(lobbyName)) {
                lobbies[lobbyName] = new PublicChatRoom(lobbyName);  
            }
            return lobbies[lobbyName];
        }
    }
}
