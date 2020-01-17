namespace Backend.Admin
{
	partial class FileManager
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.filesTree = new System.Windows.Forms.TreeView();
			this.uploadQueueList = new System.Windows.Forms.ListBox();
			this.uploadButton = new System.Windows.Forms.Button();
			this.deleteButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// filesTree
			// 
			this.filesTree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.filesTree.Location = new System.Drawing.Point(0, 0);
			this.filesTree.Name = "filesTree";
			this.filesTree.Size = new System.Drawing.Size(345, 352);
			this.filesTree.TabIndex = 0;
			this.filesTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.FilesTree_AfterSelect);
			// 
			// uploadQueueList
			// 
			this.uploadQueueList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.uploadQueueList.FormattingEnabled = true;
			this.uploadQueueList.Location = new System.Drawing.Point(351, 0);
			this.uploadQueueList.Name = "uploadQueueList";
			this.uploadQueueList.Size = new System.Drawing.Size(200, 342);
			this.uploadQueueList.TabIndex = 1;
			// 
			// uploadButton
			// 
			this.uploadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.uploadButton.Location = new System.Drawing.Point(351, 358);
			this.uploadButton.Name = "uploadButton";
			this.uploadButton.Size = new System.Drawing.Size(75, 23);
			this.uploadButton.TabIndex = 2;
			this.uploadButton.Text = "Upload";
			this.uploadButton.UseVisualStyleBackColor = true;
			this.uploadButton.Click += new System.EventHandler(this.UploadButton_Click);
			// 
			// deleteButton
			// 
			this.deleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.deleteButton.Location = new System.Drawing.Point(0, 358);
			this.deleteButton.Name = "deleteButton";
			this.deleteButton.Size = new System.Drawing.Size(75, 23);
			this.deleteButton.TabIndex = 3;
			this.deleteButton.Text = "Delete";
			this.deleteButton.UseVisualStyleBackColor = true;
			this.deleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
			// 
			// FileManager
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.deleteButton);
			this.Controls.Add(this.uploadButton);
			this.Controls.Add(this.uploadQueueList);
			this.Controls.Add(this.filesTree);
			this.Name = "FileManager";
			this.Size = new System.Drawing.Size(551, 381);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TreeView filesTree;
		private System.Windows.Forms.ListBox uploadQueueList;
		private System.Windows.Forms.Button uploadButton;
		private System.Windows.Forms.Button deleteButton;
	}
}
