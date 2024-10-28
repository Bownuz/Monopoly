using ChatServerApplicatie.Chatroom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ChatServerApplicatie.ChatRoom {
    internal static class LobbyManager {
        private static Dictionary<string, PublicChatRoom> lobbies = new Dictionary<string, PublicChatRoom>();

        public static Dictionary<string, PublicChatRoom> GetLobbies() {
            return lobbies;
        }

        public static List<string> GetLobbyNames() {
            return lobbies.Keys.ToList();
        }

        public static void SetLobbies(Dictionary<string, PublicChatRoom> lobbydict) {
            lobbies = lobbydict;
        }

        public static IChatroom GetOrCreateLobby(string lobbyName) {
            if (!lobbies.ContainsKey(lobbyName)) {
                lobbies[lobbyName] = new PublicChatRoom(lobbyName);  
            }
            return lobbies[lobbyName];
        }
    }
}
