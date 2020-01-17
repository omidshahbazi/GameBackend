using Backend.Base.Admin;
using Backend.Common.NetworkSystem;
using System.IO;
using System.Windows.Forms;

namespace Backend.Admin
{
	public partial class FileManager : UserControl
	{
		private struct UploadInfo
		{
			public string LocalPath;
			public string RemotePath;

			public override string ToString()
			{
				return LocalPath;
			}
		}

		private Connection connection = null;

		public FileManager()
		{
			InitializeComponent();
		}

		public void SetConnection(Connection Connection)
		{
			connection = Connection;

			UpdateData();
		}

		private void UpdateData()
		{
			deleteButton.Enabled = false;
			uploadButton.Enabled = false;
			connection.Send<FetchFilesReq, FetchFilesRes>(new FetchFilesReq(), HandleFeetchFiles);
		}

		private void HandleFeetchFiles(FetchFilesRes Data)
		{
			for (int i = 0; i < Data.FilePaths.Length; ++i)
				AddPath(Data.FilePaths[i], filesTree.Nodes);
		}

		private void ProcessUploadQueue()
		{
			if (uploadQueueList.Items.Count == 0)
			{
				UpdateData();

				return;
			}

			UploadInfo info = (UploadInfo)uploadQueueList.Items[0];

			if (!File.Exists(info.LocalPath))
			{
				uploadQueueList.Items.RemoveAt(0);
				ProcessUploadQueue();
				return;
			}

			connection.Send(new UploadFileReq() { FilePath = info.RemotePath, Content = File.ReadAllBytes(info.LocalPath) }, () =>
			{
				uploadQueueList.Items.RemoveAt(0);

				ProcessUploadQueue();
			});
		}

		private void AddPath(string Path, TreeNodeCollection Parent)
		{
			int index = Path.IndexOf('/');
			if (index == -1)
				index = Path.Length;
			else
				++index;
			string rootName = Path.Substring(0, index);

			TreeNode[] nodes = Parent.Find(rootName, false);
			TreeNode root = (nodes == null || nodes.Length == 0 ? null : nodes[0]);

			if (root == null)
				root = Parent.Add(rootName, rootName);

			if (index == Path.Length)
				return;

			AddPath(Path.Substring(index), root.Nodes);
		}

		private void DeleteButton_Click(object sender, System.EventArgs e)
		{

		}

		private void UploadButton_Click(object sender, System.EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.CheckPathExists = true;
			ofd.CheckFileExists = true;
			ofd.Multiselect = true;
			ofd.RestoreDirectory = true;

			if (ofd.ShowDialog() == DialogResult.Cancel)
				return;

			string remoteDir = GetSelectedRemoteDirectory();

			for (int i = 0; i < ofd.FileNames.Length; ++i)
			{
				string file = ofd.FileNames[i];

				uploadQueueList.Items.Add(new UploadInfo() { LocalPath = file, RemotePath = remoteDir + Path.GetFileName(file) });
			}

			ProcessUploadQueue();
		}

		private void FilesTree_AfterSelect(object sender, TreeViewEventArgs e)
		{
			uploadButton.Enabled = true;
			deleteButton.Enabled = true;
		}

		private string GetSelectedRemoteDirectory()
		{
			string dir = "";

			TreeNode node = filesTree.SelectedNode;
			while (node != null)
			{
				if (node.Name.EndsWith("/"))
					dir = node.Text + dir;

				node = node.Parent;
			}

			return dir;
		}
	}
}