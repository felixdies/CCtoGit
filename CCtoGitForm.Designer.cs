namespace CCtoGit
{
    partial class CCtoGitForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CCtoGitForm));
            this.MigrationButton = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.FilePicture = new System.Windows.Forms.PictureBox();
            this.SymLinkPicture = new System.Windows.Forms.PictureBox();
            this.FolderPicture = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.StatusDetailLabel = new System.Windows.Forms.Label();
            this.OpenVobButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.FilePicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SymLinkPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FolderPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // MigrationButton
            // 
            this.MigrationButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MigrationButton.Location = new System.Drawing.Point(10, 122);
            this.MigrationButton.Margin = new System.Windows.Forms.Padding(2);
            this.MigrationButton.Name = "MigrationButton";
            this.MigrationButton.Size = new System.Drawing.Size(121, 35);
            this.MigrationButton.TabIndex = 0;
            this.MigrationButton.Text = "Migrate to Git";
            this.MigrationButton.UseVisualStyleBackColor = true;
            this.MigrationButton.Click += new System.EventHandler(this.MigrationButton_Click);
            // 
            // treeView1
            // 
            this.treeView1.CheckBoxes = true;
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.Location = new System.Drawing.Point(158, 65);
            this.treeView1.Margin = new System.Windows.Forms.Padding(2);
            this.treeView1.Name = "treeView1";
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.Size = new System.Drawing.Size(563, 414);
            this.treeView1.TabIndex = 4;
            this.treeView1.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterCheck);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "default.png");
            this.imageList1.Images.SetKeyName(1, "folder.png");
            this.imageList1.Images.SetKeyName(2, "folder_link.png");
            this.imageList1.Images.SetKeyName(3, "file.png");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(470, 45);
            this.label1.TabIndex = 5;
            this.label1.Text = "\"Open Vob\" 버튼을 눌러 Git 으로 Migration 할 CC Vob 을 선택하세요.\r\n선택 후 \'Migrate to Git\' 버튼을 누" +
    "르세요.\r\n현재 Symbolic Link 는 지원 되지 않습니다.";
            // 
            // FilePicture
            // 
            this.FilePicture.Image = global::CCtoGit.Properties.Resources.file;
            this.FilePicture.Location = new System.Drawing.Point(10, 298);
            this.FilePicture.Margin = new System.Windows.Forms.Padding(2);
            this.FilePicture.Name = "FilePicture";
            this.FilePicture.Size = new System.Drawing.Size(40, 42);
            this.FilePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.FilePicture.TabIndex = 3;
            this.FilePicture.TabStop = false;
            // 
            // SymLinkPicture
            // 
            this.SymLinkPicture.Image = global::CCtoGit.Properties.Resources.folder_link;
            this.SymLinkPicture.InitialImage = null;
            this.SymLinkPicture.Location = new System.Drawing.Point(10, 252);
            this.SymLinkPicture.Margin = new System.Windows.Forms.Padding(2);
            this.SymLinkPicture.Name = "SymLinkPicture";
            this.SymLinkPicture.Size = new System.Drawing.Size(40, 42);
            this.SymLinkPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.SymLinkPicture.TabIndex = 2;
            this.SymLinkPicture.TabStop = false;
            // 
            // FolderPicture
            // 
            this.FolderPicture.Image = global::CCtoGit.Properties.Resources.folder;
            this.FolderPicture.InitialImage = null;
            this.FolderPicture.Location = new System.Drawing.Point(10, 205);
            this.FolderPicture.Margin = new System.Windows.Forms.Padding(2);
            this.FolderPicture.Name = "FolderPicture";
            this.FolderPicture.Size = new System.Drawing.Size(40, 42);
            this.FolderPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.FolderPicture.TabIndex = 1;
            this.FolderPicture.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 217);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Folder";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(54, 264);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Symbolic Link";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(54, 311);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "File";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 179);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "<아이콘 설명>";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(10, 517);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(2);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(711, 19);
            this.progressBar1.TabIndex = 10;
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Location = new System.Drawing.Point(7, 469);
            this.StatusLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(52, 15);
            this.StatusLabel.TabIndex = 11;
            this.StatusLabel.Text = "대기중";
            // 
            // StatusDetailLabel
            // 
            this.StatusDetailLabel.AutoSize = true;
            this.StatusDetailLabel.Location = new System.Drawing.Point(7, 492);
            this.StatusDetailLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.StatusDetailLabel.Name = "StatusDetailLabel";
            this.StatusDetailLabel.Size = new System.Drawing.Size(0, 15);
            this.StatusDetailLabel.TabIndex = 12;
            // 
            // OpenVobButton
            // 
            this.OpenVobButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.OpenVobButton.Location = new System.Drawing.Point(10, 73);
            this.OpenVobButton.Margin = new System.Windows.Forms.Padding(2);
            this.OpenVobButton.Name = "OpenVobButton";
            this.OpenVobButton.Size = new System.Drawing.Size(121, 35);
            this.OpenVobButton.TabIndex = 13;
            this.OpenVobButton.Text = "Open Vob";
            this.OpenVobButton.UseVisualStyleBackColor = true;
            this.OpenVobButton.Click += new System.EventHandler(this.OpenVobButton_Click);
            // 
            // CCtoGitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 546);
            this.Controls.Add(this.OpenVobButton);
            this.Controls.Add(this.StatusDetailLabel);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.FilePicture);
            this.Controls.Add(this.SymLinkPicture);
            this.Controls.Add(this.FolderPicture);
            this.Controls.Add(this.MigrationButton);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "CCtoGitForm";
            this.Text = "CCtoGit";
            this.Load += new System.EventHandler(this.CCtoGitForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.FilePicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SymLinkPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FolderPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button MigrationButton;
        private System.Windows.Forms.PictureBox FolderPicture;
        private System.Windows.Forms.PictureBox SymLinkPicture;
        private System.Windows.Forms.PictureBox FilePicture;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.Label StatusDetailLabel;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button OpenVobButton;
    }
}

