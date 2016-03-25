using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CCtoGit
{
    public partial class CCtoGitForm : Form
    {
        private DirectoryInfo vobRootDir = null;
        private DirectoryInfo repoRootDir = null;

        public CCtoGitForm()
        {
            InitializeComponent();
        }

        private void CCtoGitForm_Load(object sender, EventArgs e)
        {
        }

        private void OpenVobButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "Git 으로 Migration 할 CC Vob 을 선택하세요.";

            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                this.vobRootDir = new DirectoryInfo(dialog.SelectedPath);

                treeView1.Nodes.Clear();
                treeView1.Nodes.Add(this.CreateDirectoryNode(this.vobRootDir));

                StatusDetailLabel.Text = this.vobRootDir.ToString();
            }
        }

        private void MigrationButton_Click(object sender, EventArgs e)
        {
            if (this.vobRootDir == null)
            {
                MessageBox.Show("먼저 Git 으로 Migration 할 CC Vob 을 선택하세요.");
                return;
            }

            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "Migration 할 Git 저장소를 선택 하세요.";

            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                this.repoRootDir = new DirectoryInfo(dialog.SelectedPath);

                StatusDetailLabel.Text = this.repoRootDir.ToString();

                try
                {
                    new CCtoGit().Migrate(this.vobRootDir.ToString(), this.repoRootDir.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Migration 이 실패 하였습니다.\n오류 : " + ex.Message);
                }
            }
        }

        /// <summary>
        /// 하위 경로를 모두 포함하는 TreeNode 를 반환 합니다.
        /// </summary>
        private TreeNode CreateDirectoryNode(DirectoryInfo directoryInfo)
        {
            TreeNode directoryNode = new TreeNode(directoryInfo.Name, 1, 1);

            foreach (var directory in directoryInfo.GetDirectories())
            {
                directoryNode.Nodes.Add(this.CreateDirectoryNode(directory));
            }

            foreach (var file in directoryInfo.GetFiles())
            {
                directoryNode.Nodes.Add(new TreeNode(file.Name, 3, 3));
            }

            return directoryNode;
        }
    }
}
