using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChatClientApplicatie.GuiScreens;
using ChatClientApplicatie.State;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Net.Sockets;

[TestClass]
public class ChatScreenTests {
    private Handler handler;
    private ChatScreen chatScreen;

    [TestInitialize]
    public void Setup() {
        handler = new Handler(new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp), "TestUser", "TestPassword", new ScreenManager(new Form()));
        chatScreen = new ChatScreen(handler);
    }

    [TestMethod]
    public void OnNewMessageReceived_ShouldAddMessageToChatListBox() {
        // Arrange
        string testMessage = "Test message";

        // Act
        chatScreen.ShowMessage(testMessage);

        // Assert
        var messages = chatScreen.GetChatMessages(); // Gebruik de nieuwe methode
        Assert.IsTrue(messages.Contains(testMessage), "ChatListBox should contain the new message.");
    }
}
