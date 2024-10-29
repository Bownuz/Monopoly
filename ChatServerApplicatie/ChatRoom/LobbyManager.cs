using ChatServerApplicatie.Chatroom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ChatServerApplicatie.ChatRoom {
    internal static class LobbyManager {
        private static Dictionary<string, PublicChatRoom> lobbies = new Dictionary<string, PublicChatRoom>();
        public static Dictionary<string, Socket> userSocket = new Dictionary<string, Socket>();

        public static Dictionary<string, PublicChatRoom> GetLobbies() {
            return lobbies;
        }

        public static List<string> GetLobbyNames() {
            return lobbies.Keys.ToList();
        }

        public static void ClearLobbies() {
            lobbies.Clear();
        }

        public static void AddUserToLobby(string lobbyName, string userName) {
            PublicChatRoom lobby = GetOrCreateLobby(lobbyName);
            lobby.AddMember(userName);
        }

        public static void RemoveUserFromLobby(string lobbyName, string userName) {
            if (lobbies.ContainsKey(lobbyName)) {
                lobbies[lobbyName].RemoveMember(userName);
            }
        }

        public static void SetLobbies(Dictionary<string, PublicChatRoom> lobbydict) {
            lobbies = lobbydict;
        }

        public static PublicChatRoom GetOrCreateLobby(string lobbyName) {
            if (!lobbies.ContainsKey(lobbyName)) {
                lobbies[lobbyName] = new PublicChatRoom(lobbyName);
            }
            return lobbies[lobbyName];
        }
    }
}
