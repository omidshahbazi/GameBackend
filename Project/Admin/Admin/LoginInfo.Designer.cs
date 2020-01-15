namespace Backend.Admin
{
	partial class LoginInfo
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
			this.nameBox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.hostBox = new System.Windows.Forms.TextBox();
			this.protocolBox = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.portBox = new System.Windows.Forms.NumericUpDown();
			this.label5 = new System.Windows.Forms.Label();
			this.usernameBox = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.passwordBox = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.portBox)).BeginInit();
			this.SuspendLayout();
			// 
			// nameBox
			// 
			this.nameBox.Location = new System.Drawing.Point(67, 3);
			this.nameBox.Name = "nameBox";
			this.nameBox.Size = new System.Drawing.Size(200, 20);
			this.nameBox.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 6);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(38, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Name:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(3, 32);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(49, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Protocol:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(3, 59);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(32, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "Host:";
			// 
			// hostBox
			// 
			this.hostBox.Location = new System.Drawing.Point(67, 56);
			this.hostBox.Name = "hostBox";
			this.hostBox.Size = new System.Drawing.Size(200, 20);
			this.hostBox.TabIndex = 4;
			// 
			// protocolBox
			// 
			this.protocolBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.protocolBox.FormattingEnabled = true;
			this.protocolBox.Location = new System.Drawing.Point(67, 29);
			this.protocolBox.Name = "protocolBox";
			this.protocolBox.Size = new System.Drawing.Size(200, 21);
			this.protocolBox.TabIndex = 6;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(3, 84);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(29, 13);
			this.label4.TabIndex = 8;
			this.label4.Text = "Port:";
			// 
			// portBox
			// 
			this.portBox.Location = new System.Drawing.Point(67, 82);
			this.portBox.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
			this.portBox.Name = "portBox";
			this.portBox.Size = new System.Drawing.Size(200, 20);
			this.portBox.TabIndex = 9;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(3, 111);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(58, 13);
			this.label5.TabIndex = 11;
			this.label5.Text = "Username:";
			// 
			// usernameBox
			// 
			this.usernameBox.Location = new System.Drawing.Point(67, 108);
			this.usernameBox.Name = "usernameBox";
			this.usernameBox.Size = new System.Drawing.Size(200, 20);
			this.usernameBox.TabIndex = 10;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(3, 137);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(56, 13);
			this.label6.TabIndex = 13;
			this.label6.Text = "Password:";
			// 
			// passwordBox
			// 
			this.passwordBox.Location = new System.Drawing.Point(67, 134);
			this.passwordBox.Name = "passwordBox";
			this.passwordBox.Size = new System.Drawing.Size(200, 20);
			this.passwordBox.TabIndex = 12;
			this.passwordBox.UseSystemPasswordChar = true;
			// 
			// LoginInfo
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.label6);
			this.Controls.Add(this.passwordBox);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.usernameBox);
			this.Controls.Add(this.portBox);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.protocolBox);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.hostBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.nameBox);
			this.MaximumSize = new System.Drawing.Size(273, 158);
			this.MinimumSize = new System.Drawing.Size(273, 158);
			this.Name = "LoginInfo";
			this.Size = new System.Drawing.Size(273, 158);
			((System.ComponentModel.ISupportInitialize)(this.portBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox nameBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox hostBox;
		private System.Windows.Forms.ComboBox protocolBox;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.NumericUpDown portBox;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox usernameBox;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox passwordBox;
	}
}
