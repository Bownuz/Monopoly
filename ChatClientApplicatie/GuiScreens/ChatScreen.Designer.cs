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
            ChatListBox = new ListBox();
            BackButton = new Button();
            SuspendLayout();
            // 
            // SendButton
            // 
            SendButton.Location = new Point(395, 395);
            SendButton.Name = "SendButton";
            SendButton.Size = new Size(75, 23);
            SendButton.TabIndex = 0;
            SendButton.Text = "Send";
            SendButton.UseVisualStyleBackColor = true;
            SendButton.Click += SendButton_Click;
            // 
            // MessageTextBox
            // 
            MessageTextBox.Location = new Point(170, 366);
            MessageTextBox.Name = "MessageTextBox";
            MessageTextBox.Size = new Size(300, 23);
            MessageTextBox.TabIndex = 1;
            MessageTextBox.TextChanged += MessageTextBox_TextChanged;
            // 
            // ChatListBox
            // 
            ChatListBox.FormattingEnabled = true;
            ChatListBox.ItemHeight = 15;
            ChatListBox.Location = new Point(170, 41);
            ChatListBox.Name = "ChatListBox";
            ChatListBox.Size = new Size(300, 319);
            ChatListBox.TabIndex = 3;
            // 
            // BackButton
            // 
            BackButton.Location = new Point(596, 69);
            BackButton.Name = "BackButton";
            BackButton.Size = new Size(75, 23);
            BackButton.TabIndex = 5;
            BackButton.Text = "Back";
            BackButton.UseVisualStyleBackColor = true;
            BackButton.Click += BackButton_Click;
            // 
            // ChatScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            Controls.Add(BackButton);
            Controls.Add(ChatListBox);
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
        private Button BackButton;
    }
}
