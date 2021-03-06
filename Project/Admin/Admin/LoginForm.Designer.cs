﻿namespace Backend.Admin
{
	partial class LoginForm
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
			this.connectionList = new System.Windows.Forms.ListBox();
			this.loginInfo = new Backend.Admin.LoginInfo();
			this.selectButton = new System.Windows.Forms.Button();
			this.addButton = new System.Windows.Forms.Button();
			this.deleteButton = new System.Windows.Forms.Button();
			this.editButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.connectButton = new System.Windows.Forms.Button();
			this.errorMessageLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// connectionList
			// 
			this.connectionList.FormattingEnabled = true;
			this.connectionList.Location = new System.Drawing.Point(291, 6);
			this.connectionList.Name = "connectionList";
			this.connectionList.Size = new System.Drawing.Size(192, 147);
			this.connectionList.TabIndex = 0;
			// 
			// loginInfo
			// 
			this.loginInfo.Location = new System.Drawing.Point(12, -23);
			this.loginInfo.MaximumSize = new System.Drawing.Size(273, 158);
			this.loginInfo.MinimumSize = new System.Drawing.Size(273, 158);
			this.loginInfo.Name = "loginInfo";
			this.loginInfo.Size = new System.Drawing.Size(273, 158);
			this.loginInfo.TabIndex = 1;
			// 
			// selectButton
			// 
			this.selectButton.Location = new System.Drawing.Point(291, 159);
			this.selectButton.Name = "selectButton";
			this.selectButton.Size = new System.Drawing.Size(48, 23);
			this.selectButton.TabIndex = 2;
			this.selectButton.Text = "&Select";
			this.selectButton.UseVisualStyleBackColor = true;
			this.selectButton.Click += new System.EventHandler(this.SelectButton_Click);
			// 
			// addButton
			// 
			this.addButton.Location = new System.Drawing.Point(397, 159);
			this.addButton.Name = "addButton";
			this.addButton.Size = new System.Drawing.Size(34, 23);
			this.addButton.TabIndex = 3;
			this.addButton.Text = "&Add";
			this.addButton.UseVisualStyleBackColor = true;
			this.addButton.Click += new System.EventHandler(this.AddButton_Click);
			// 
			// deleteButton
			// 
			this.deleteButton.Location = new System.Drawing.Point(437, 159);
			this.deleteButton.Name = "deleteButton";
			this.deleteButton.Size = new System.Drawing.Size(46, 23);
			this.deleteButton.TabIndex = 4;
			this.deleteButton.Text = "&Delete";
			this.deleteButton.UseVisualStyleBackColor = true;
			this.deleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
			// 
			// editButton
			// 
			this.editButton.Location = new System.Drawing.Point(345, 159);
			this.editButton.Name = "editButton";
			this.editButton.Size = new System.Drawing.Size(46, 23);
			this.editButton.TabIndex = 5;
			this.editButton.Text = "&Edit";
			this.editButton.UseVisualStyleBackColor = true;
			this.editButton.Click += new System.EventHandler(this.EditButton_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.Location = new System.Drawing.Point(12, 159);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 6;
			this.cancelButton.Text = "Cance&l";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
			// 
			// connectButton
			// 
			this.connectButton.Location = new System.Drawing.Point(93, 159);
			this.connectButton.Name = "connectButton";
			this.connectButton.Size = new System.Drawing.Size(75, 23);
			this.connectButton.TabIndex = 7;
			this.connectButton.Text = "&Connect";
			this.connectButton.UseVisualStyleBackColor = true;
			this.connectButton.Click += new System.EventHandler(this.ConnectButton_Click);
			// 
			// errorMessageLabel
			// 
			this.errorMessageLabel.AutoSize = true;
			this.errorMessageLabel.ForeColor = System.Drawing.Color.Red;
			this.errorMessageLabel.Location = new System.Drawing.Point(12, 138);
			this.errorMessageLabel.Name = "errorMessageLabel";
			this.errorMessageLabel.Size = new System.Drawing.Size(72, 13);
			this.errorMessageLabel.TabIndex = 8;
			this.errorMessageLabel.Text = "ErrorMessage";
			// 
			// LoginForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(500, 188);
			this.Controls.Add(this.errorMessageLabel);
			this.Controls.Add(this.connectButton);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.editButton);
			this.Controls.Add(this.deleteButton);
			this.Controls.Add(this.addButton);
			this.Controls.Add(this.selectButton);
			this.Controls.Add(this.loginInfo);
			this.Controls.Add(this.connectionList);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "LoginForm";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Login";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListBox connectionList;
		private LoginInfo loginInfo;
		private System.Windows.Forms.Button selectButton;
		private System.Windows.Forms.Button addButton;
		private System.Windows.Forms.Button deleteButton;
		private System.Windows.Forms.Button editButton;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.Button connectButton;
		private System.Windows.Forms.Label errorMessageLabel;
	}
}