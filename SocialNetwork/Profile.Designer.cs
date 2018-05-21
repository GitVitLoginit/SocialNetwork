namespace SocialNetwork
{
    partial class Profile
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureMain = new System.Windows.Forms.PictureBox();
            this.textAboutMe = new System.Windows.Forms.TextBox();
            this.textName = new System.Windows.Forms.TextBox();
            this.textSurname = new System.Windows.Forms.TextBox();
            this.textBirthDate = new System.Windows.Forms.TextBox();
            this.listFriends = new System.Windows.Forms.ListBox();
            this.labelNoPhoto = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonChangePhoto = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonSaveChanges = new System.Windows.Forms.Button();
            this.buttonLook = new System.Windows.Forms.Button();
            this.buttonStartChat = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.textNewFriendId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureMain)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureMain
            // 
            this.pictureMain.Location = new System.Drawing.Point(25, 23);
            this.pictureMain.Name = "pictureMain";
            this.pictureMain.Size = new System.Drawing.Size(104, 99);
            this.pictureMain.TabIndex = 0;
            this.pictureMain.TabStop = false;
            // 
            // textAboutMe
            // 
            this.textAboutMe.Location = new System.Drawing.Point(25, 148);
            this.textAboutMe.Multiline = true;
            this.textAboutMe.Name = "textAboutMe";
            this.textAboutMe.ReadOnly = true;
            this.textAboutMe.Size = new System.Drawing.Size(279, 109);
            this.textAboutMe.TabIndex = 1;
            // 
            // textName
            // 
            this.textName.Location = new System.Drawing.Point(172, 23);
            this.textName.Name = "textName";
            this.textName.ReadOnly = true;
            this.textName.Size = new System.Drawing.Size(141, 20);
            this.textName.TabIndex = 2;
            // 
            // textSurname
            // 
            this.textSurname.Location = new System.Drawing.Point(172, 61);
            this.textSurname.Name = "textSurname";
            this.textSurname.ReadOnly = true;
            this.textSurname.Size = new System.Drawing.Size(141, 20);
            this.textSurname.TabIndex = 3;
            // 
            // textBirthDate
            // 
            this.textBirthDate.Location = new System.Drawing.Point(172, 102);
            this.textBirthDate.Name = "textBirthDate";
            this.textBirthDate.ReadOnly = true;
            this.textBirthDate.Size = new System.Drawing.Size(141, 20);
            this.textBirthDate.TabIndex = 4;
            // 
            // listFriends
            // 
            this.listFriends.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listFriends.FormattingEnabled = true;
            this.listFriends.ItemHeight = 20;
            this.listFriends.Location = new System.Drawing.Point(361, 43);
            this.listFriends.Name = "listFriends";
            this.listFriends.Size = new System.Drawing.Size(366, 284);
            this.listFriends.TabIndex = 5;
            // 
            // labelNoPhoto
            // 
            this.labelNoPhoto.AutoSize = true;
            this.labelNoPhoto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelNoPhoto.Location = new System.Drawing.Point(39, 59);
            this.labelNoPhoto.Name = "labelNoPhoto";
            this.labelNoPhoto.Size = new System.Drawing.Size(74, 20);
            this.labelNoPhoto.TabIndex = 6;
            this.labelNoPhoto.Text = "No photo";
            this.labelNoPhoto.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(357, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 22);
            this.label1.TabIndex = 7;
            this.label1.Text = "Frend list:";
            // 
            // buttonChangePhoto
            // 
            this.buttonChangePhoto.Location = new System.Drawing.Point(25, 119);
            this.buttonChangePhoto.Name = "buttonChangePhoto";
            this.buttonChangePhoto.Size = new System.Drawing.Size(104, 23);
            this.buttonChangePhoto.TabIndex = 8;
            this.buttonChangePhoto.Text = "Change photo";
            this.buttonChangePhoto.UseVisualStyleBackColor = true;
            this.buttonChangePhoto.Visible = false;
            this.buttonChangePhoto.Click += new System.EventHandler(this.buttonChangePhoto_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(25, 342);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(98, 23);
            this.buttonEdit.TabIndex = 9;
            this.buttonEdit.Text = "Edit profile";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonSaveChanges
            // 
            this.buttonSaveChanges.Location = new System.Drawing.Point(129, 342);
            this.buttonSaveChanges.Name = "buttonSaveChanges";
            this.buttonSaveChanges.Size = new System.Drawing.Size(98, 23);
            this.buttonSaveChanges.TabIndex = 10;
            this.buttonSaveChanges.Text = "Save changes";
            this.buttonSaveChanges.UseVisualStyleBackColor = true;
            this.buttonSaveChanges.Visible = false;
            this.buttonSaveChanges.Click += new System.EventHandler(this.buttonSaveChanges_Click);
            // 
            // buttonLook
            // 
            this.buttonLook.Location = new System.Drawing.Point(361, 342);
            this.buttonLook.Name = "buttonLook";
            this.buttonLook.Size = new System.Drawing.Size(85, 23);
            this.buttonLook.TabIndex = 11;
            this.buttonLook.Text = "Show profile";
            this.buttonLook.UseVisualStyleBackColor = true;
            this.buttonLook.Click += new System.EventHandler(this.buttonLook_Click);
            // 
            // buttonStartChat
            // 
            this.buttonStartChat.Location = new System.Drawing.Point(452, 342);
            this.buttonStartChat.Name = "buttonStartChat";
            this.buttonStartChat.Size = new System.Drawing.Size(86, 23);
            this.buttonStartChat.TabIndex = 12;
            this.buttonStartChat.Text = "Start chat";
            this.buttonStartChat.UseVisualStyleBackColor = true;
            this.buttonStartChat.Click += new System.EventHandler(this.buttonStartChat_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(544, 342);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(85, 23);
            this.buttonDelete.TabIndex = 13;
            this.buttonDelete.Text = "Delete friend";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(635, 342);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(92, 23);
            this.buttonAdd.TabIndex = 14;
            this.buttonAdd.Text = "Add friend";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // textNewFriendId
            // 
            this.textNewFriendId.Location = new System.Drawing.Point(635, 394);
            this.textNewFriendId.Name = "textNewFriendId";
            this.textNewFriendId.Size = new System.Drawing.Size(92, 20);
            this.textNewFriendId.TabIndex = 15;
            this.textNewFriendId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textNewFriendId_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(635, 378);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Friend ID";
            // 
            // Profile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textNewFriendId);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonStartChat);
            this.Controls.Add(this.buttonLook);
            this.Controls.Add(this.buttonSaveChanges);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.buttonChangePhoto);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelNoPhoto);
            this.Controls.Add(this.listFriends);
            this.Controls.Add(this.textBirthDate);
            this.Controls.Add(this.textSurname);
            this.Controls.Add(this.textName);
            this.Controls.Add(this.textAboutMe);
            this.Controls.Add(this.pictureMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Profile";
            this.Text = "Profile";
            this.Load += new System.EventHandler(this.Profile_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureMain;
        private System.Windows.Forms.TextBox textAboutMe;
        private System.Windows.Forms.TextBox textName;
        private System.Windows.Forms.TextBox textSurname;
        private System.Windows.Forms.TextBox textBirthDate;
        private System.Windows.Forms.ListBox listFriends;
        private System.Windows.Forms.Label labelNoPhoto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonChangePhoto;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonSaveChanges;
        private System.Windows.Forms.Button buttonLook;
        private System.Windows.Forms.Button buttonStartChat;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.TextBox textNewFriendId;
        private System.Windows.Forms.Label label2;
    }
}