namespace ChatClientApplicatie.GuiScreens {
    partial class ChatScreen {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            SendButton = new Button();
            MessageTextBox = new TextBox();
            ChatLogTextBox = new TextBox();
            ChatListBox = new ListBox();
            SuspendLayout();
            // 
            // SendButton
            // 
            SendButton.Location = new Point(226, 193);
            SendButton.Name = "SendButton";
            SendButton.Size = new Size(75, 23);
            SendButton.TabIndex = 0;
            SendButton.Text = "Send";
            SendButton.UseVisualStyleBackColor = true;
            SendButton.Click += SendButton_Click;
            // 
            // MessageTextBox
            // 
            MessageTextBox.Location = new Point(456, 271);
            MessageTextBox.Name = "MessageTextBox";
            MessageTextBox.Size = new Size(100, 23);
            MessageTextBox.TabIndex = 1;
            // 
            // ChatLogTextBox
            // 
            ChatLogTextBox.Location = new Point(349, 369);
            ChatLogTextBox.Name = "ChatLogTextBox";
            ChatLogTextBox.Size = new Size(100, 23);
            ChatLogTextBox.TabIndex = 2;
            // 
            // ChatListBox
            // 
            ChatListBox.FormattingEnabled = true;
            ChatListBox.ItemHeight = 15;
            ChatListBox.Location = new Point(181, 328);
            ChatListBox.Name = "ChatListBox";
            ChatListBox.Size = new Size(120, 94);
            ChatListBox.TabIndex = 3;
            // 
            // ChatScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(ChatListBox);
            Controls.Add(ChatLogTextBox);
            Controls.Add(MessageTextBox);
            Controls.Add(SendButton);
            Name = "ChatScreen";
            Size = new Size(765, 551);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button SendButton;
        private TextBox MessageTextBox;
        private TextBox ChatLogTextBox;
        private ListBox ChatListBox;
    }
}
