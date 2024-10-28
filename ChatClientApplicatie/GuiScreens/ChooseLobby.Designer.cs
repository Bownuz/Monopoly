namespace ChatClientApplicatie {
    partial class ChooseLobby {
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
            lobbyListBox = new ListBox();
            CreateLobbyTextBox = new TextBox();
            CreateLobbyButton = new Button();
            JoinLobbyButton = new Button();
            SuspendLayout();
            // 
            // lobbyListBox
            // 
            lobbyListBox.FormattingEnabled = true;
            lobbyListBox.ItemHeight = 15;
            lobbyListBox.Location = new Point(207, 72);
            lobbyListBox.Name = "lobbyListBox";
            lobbyListBox.Size = new Size(297, 274);
            lobbyListBox.TabIndex = 0;
            lobbyListBox.SelectedIndexChanged += lobbyListBox_SelectedIndexChanged;
            // 
            // CreateLobbyTextBox
            // 
            CreateLobbyTextBox.Location = new Point(207, 348);
            CreateLobbyTextBox.Name = "CreateLobbyTextBox";
            CreateLobbyTextBox.Size = new Size(297, 23);
            CreateLobbyTextBox.TabIndex = 1;
            // 
            // CreateLobbyButton
            // 
            CreateLobbyButton.Location = new Point(207, 377);
            CreateLobbyButton.Name = "CreateLobbyButton";
            CreateLobbyButton.Size = new Size(163, 23);
            CreateLobbyButton.TabIndex = 2;
            CreateLobbyButton.Text = "Create Lobby";
            CreateLobbyButton.UseVisualStyleBackColor = true;
            CreateLobbyButton.Click += CreateLobbyButton_Click_1;
            // 
            // JoinLobbyButton
            // 
            JoinLobbyButton.Location = new Point(429, 377);
            JoinLobbyButton.Name = "JoinLobbyButton";
            JoinLobbyButton.Size = new Size(75, 23);
            JoinLobbyButton.TabIndex = 3;
            JoinLobbyButton.Text = "Join Lobby";
            JoinLobbyButton.UseVisualStyleBackColor = true;
            JoinLobbyButton.Click += JoinLobbyButton_Click_1;
            // 
            // ChooseLobby
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            Controls.Add(JoinLobbyButton);
            Controls.Add(CreateLobbyButton);
            Controls.Add(CreateLobbyTextBox);
            Controls.Add(lobbyListBox);
            Name = "ChooseLobby";
            Size = new Size(747, 505);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lobbyListBox;
        private TextBox CreateLobbyTextBox;
        private Button CreateLobbyButton;
        private Button JoinLobbyButton;
    }
}
