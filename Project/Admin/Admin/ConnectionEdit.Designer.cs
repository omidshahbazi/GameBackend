namespace Backend.Admin
{
	partial class ConnectionEdit
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
			this.loginInfo = new Backend.Admin.LoginInfo();
			this.cancelButton = new System.Windows.Forms.Button();
			this.saveButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// loginInfo
			// 
			this.loginInfo.Location = new System.Drawing.Point(12, 12);
			this.loginInfo.MaximumSize = new System.Drawing.Size(273, 158);
			this.loginInfo.MinimumSize = new System.Drawing.Size(273, 158);
			this.loginInfo.Name = "loginInfo";
			this.loginInfo.Size = new System.Drawing.Size(273, 158);
			this.loginInfo.TabIndex = 1;
			// 
			// cancelButton
			// 
			this.cancelButton.Location = new System.Drawing.Point(73, 176);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 6;
			this.cancelButton.Text = "Cance&l";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
			// 
			// saveButton
			// 
			this.saveButton.Location = new System.Drawing.Point(154, 176);
			this.saveButton.Name = "saveButton";
			this.saveButton.Size = new System.Drawing.Size(75, 23);
			this.saveButton.TabIndex = 7;
			this.saveButton.Text = "&Save";
			this.saveButton.UseVisualStyleBackColor = true;
			this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
			// 
			// ConnectionEdit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(298, 210);
			this.Controls.Add(this.saveButton);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.loginInfo);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "ConnectionEdit";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Connection";
			this.ResumeLayout(false);

		}

		#endregion
		private LoginInfo loginInfo;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.Button saveButton;
	}
}