using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChatServerApplicatie.ChatRoom;
using System.Text;
using ChatServerApplicatie.Chatroom;

[TestClass]
public class PublicChatRoomTests {
    [TestMethod]
    public void AddMessage_ShouldAddMessageToChatMessages() {
        // Arrange
        var chatRoom = new PublicChatRoom("TestRoom");
        var message = ChatMessage.Create("TestUser", Encoding.UTF8.GetBytes("Hello"));

        // Act
        chatRoom.AddMessage(message);

        // Assert
        Assert.AreEqual(1, chatRoom.ChatMessages.Count);
        Assert.AreEqual("TestUser", chatRoom.ChatMessages[0].Sender);
    }

    [TestMethod]
    public void AddMember_ShouldAddUserToMembersList() {
        // Arrange
        var chatRoom = new PublicChatRoom("TestRoom");
        var username = "NewUser";

        // Act
        chatRoom.AddMember(username);

        // Assert
        Assert.IsTrue(chatRoom.members.Contains(username));
    }
}
