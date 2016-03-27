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
        // todo : Form 이 Wizard 형식이면 더 좋을 것 같다.

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
                treeView1.Nodes[0].Expand();

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

                List<string> selectedCCFiles = new List<string>();
                AddSelectedDescendantsFilePath(treeView1.Nodes[0], selectedCCFiles);

                try
                {
                    new CCtoGit().Migrate(this.vobRootDir.ToString(), selectedCCFiles, this.repoRootDir.ToString());
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
            directoryNode.Name = directoryInfo.FullName;
            directoryNode.Checked = true;

            foreach (var directory in directoryInfo.GetDirectories())
            {
                directoryNode.Nodes.Add(this.CreateDirectoryNode(directory));
            }

            foreach (var file in directoryInfo.GetFiles())
            {
                TreeNode fileNode = new TreeNode(file.Name, 3, 3);
                fileNode.Name = file.FullName;
                fileNode.Checked = true;

                directoryNode.Nodes.Add(fileNode);
            }

            return directoryNode;
        }

        /// <summary>
        /// 주어진 노드의 자손 노드의 파일 경로를 주어진 문자열 리스트에 더합니다.
        /// </summary>
        private void AddSelectedDescendantsFilePath(TreeNode root,List<string> selectedFileList)
        {
            if (Directory.Exists(root.Name))
            {
                foreach (TreeNode node in root.Nodes)
                {
                    AddSelectedDescendantsFilePath(node, selectedFileList);
                }
            }
            else if (File.Exists(root.Name))
            {
                if (root.Checked)
                {
                    selectedFileList.Add(root.Name);
                }
            }
            else
            {
                throw new ArgumentException(root.Name + "은 폴더 또는 파일이 아닙니다.");
            }
        }

        // NOTE   This code can be added to the BeforeCheck event handler instead of the AfterCheck event.
        // After a tree node's Checked property is changed, all its child nodes are updated to the same value.
        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            // The code only executes if the user caused the checked state to change.
            if (e.Action != TreeViewAction.Unknown)
            {
                if (e.Node.Nodes.Count > 0)
                {
                    /* Calls the CheckAllChildNodes method, passing in the current 
                    Checked value of the TreeNode whose checked state changed. */
                    this.CheckAllChildNodes(e.Node, e.Node.Checked);
                }
            }
        }

        // Updates all child tree nodes recursively.
        private void CheckAllChildNodes(TreeNode treeNode, bool nodeChecked)
        {
            foreach (TreeNode node in treeNode.Nodes)
            {
                node.Checked = nodeChecked;
                if (node.Nodes.Count > 0)
                {
                    // If the current node has child nodes, call the CheckAllChildsNodes method recursively.
                    this.CheckAllChildNodes(node, nodeChecked);
                }
            }
        }
    }
}
