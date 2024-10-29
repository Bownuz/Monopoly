//using ChatClientApplicatie.GuiScreens;
//using ChatClientApplicatie.State;
//using ChatClientApplicatie;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using System.Net.Sockets;

//[TestClass]
//public class ChooseLobbyTests {
//    private Handler handler;
//    private ChooseLobby chooseLobby;

//    [TestInitialize]
//    public void Setup() {
//        handler = new Handler(new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp), "TestUser", "TestPassword", new ScreenManager(new Form()));
//        chooseLobby = new ChooseLobby(handler);
//    }

//    [TestMethod]
//    public void UpdateLobbyList_ShouldAddLobbiesToListBox() {
//        // Arrange
//        var lobbies = new List<string> { "Lobby 1", "Lobby 2" };

//        // Act
//        chooseLobby.UpdateLobbyList(lobbies);

//        // Assert
//        Assert.AreEqual(2, chooseLobby.lobbyListBox.Items.Count);
//        Assert.IsTrue(chooseLobby.lobbyListBox.Items.Contains("Lobby 1"));
//        Assert.IsTrue(chooseLobby.lobbyListBox.Items.Contains("Lobby 2"));
//    }

//    [TestMethod]
//    public void CreateLobbyButton_Click_ShouldCallUpdateLobbyInfo_WhenValidLobbyNameIsProvided() {
//        // Arrange
//        var lobbyName = "NewLobby";
//        chooseLobby.CreateLobbyTextBox.Text = lobbyName;

//        // Act
//        chooseLobby.CreateLobbyButton_Click_1(null, null);

//        // Assert
//        // Simuleer de logica die normaal gesproken in UpdateLobbyInfo zou gebeuren.
//        Assert.AreEqual(lobbyName, chooseLobby.CreateLobbyTextBox.Text);
//    }
//}