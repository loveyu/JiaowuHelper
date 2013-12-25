namespace JiaowuHelper
{
	partial class FormLogin
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
			this.components = new System.ComponentModel.Container();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.textBox_url = new System.Windows.Forms.TextBox();
			this.textBox_username = new System.Windows.Forms.TextBox();
			this.textBox_password = new System.Windows.Forms.TextBox();
			this.textBox_checkcode = new System.Windows.Forms.TextBox();
			this.pictureBox_checkCode = new System.Windows.Forms.PictureBox();
			this.button_login = new System.Windows.Forms.Button();
			this.button_cancal = new System.Windows.Forms.Button();
			this.button_set = new System.Windows.Forms.Button();
			this.button_confSave = new System.Windows.Forms.Button();
			this.checkBox_checkCode = new System.Windows.Forms.CheckBox();
			this.button_confDel = new System.Windows.Forms.Button();
			this.panel_checkCode = new System.Windows.Forms.Panel();
			this.button_help = new System.Windows.Forms.Button();
			this.checkBox_autoLogin = new System.Windows.Forms.CheckBox();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.button_about = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox_checkCode)).BeginInit();
			this.panel_checkCode.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(40, 21);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(35, 12);
			this.label1.TabIndex = 0;
			this.label1.Text = "地址:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(30, 61);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(47, 12);
			this.label2.TabIndex = 0;
			this.label2.Text = "用户名:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(40, 100);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(35, 12);
			this.label3.TabIndex = 0;
			this.label3.Text = "密码:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(5, 14);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(47, 12);
			this.label4.TabIndex = 0;
			this.label4.Text = "验证码:";
			// 
			// textBox_url
			// 
			this.textBox_url.Location = new System.Drawing.Point(81, 18);
			this.textBox_url.Name = "textBox_url";
			this.textBox_url.Size = new System.Drawing.Size(276, 21);
			this.textBox_url.TabIndex = 1;
			// 
			// textBox_username
			// 
			this.textBox_username.Location = new System.Drawing.Point(81, 58);
			this.textBox_username.Name = "textBox_username";
			this.textBox_username.Size = new System.Drawing.Size(183, 21);
			this.textBox_username.TabIndex = 3;
			// 
			// textBox_password
			// 
			this.textBox_password.Location = new System.Drawing.Point(81, 97);
			this.textBox_password.Name = "textBox_password";
			this.textBox_password.PasswordChar = '*';
			this.textBox_password.Size = new System.Drawing.Size(183, 21);
			this.textBox_password.TabIndex = 4;
			// 
			// textBox_checkcode
			// 
			this.textBox_checkcode.Location = new System.Drawing.Point(60, 11);
			this.textBox_checkcode.Name = "textBox_checkcode";
			this.textBox_checkcode.Size = new System.Drawing.Size(101, 21);
			this.textBox_checkcode.TabIndex = 6;
			// 
			// pictureBox_checkCode
			// 
			this.pictureBox_checkCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBox_checkCode.Location = new System.Drawing.Point(167, 7);
			this.pictureBox_checkCode.Name = "pictureBox_checkCode";
			this.pictureBox_checkCode.Size = new System.Drawing.Size(72, 27);
			this.pictureBox_checkCode.TabIndex = 4;
			this.pictureBox_checkCode.TabStop = false;
			this.pictureBox_checkCode.Tag = "";
			this.pictureBox_checkCode.Click += new System.EventHandler(this.pictureBox_checkCode_Click);
			// 
			// button_login
			// 
			this.button_login.Location = new System.Drawing.Point(42, 172);
			this.button_login.Name = "button_login";
			this.button_login.Size = new System.Drawing.Size(75, 23);
			this.button_login.TabIndex = 7;
			this.button_login.Text = "登录";
			this.button_login.UseVisualStyleBackColor = true;
			this.button_login.Click += new System.EventHandler(this.button_login_Click);
			// 
			// button_cancal
			// 
			this.button_cancal.Location = new System.Drawing.Point(138, 172);
			this.button_cancal.Name = "button_cancal";
			this.button_cancal.Size = new System.Drawing.Size(66, 23);
			this.button_cancal.TabIndex = 8;
			this.button_cancal.Text = "取消";
			this.button_cancal.UseVisualStyleBackColor = true;
			this.button_cancal.Click += new System.EventHandler(this.button_cancal_Click);
			// 
			// button_set
			// 
			this.button_set.Location = new System.Drawing.Point(369, 16);
			this.button_set.Name = "button_set";
			this.button_set.Size = new System.Drawing.Size(44, 23);
			this.button_set.TabIndex = 2;
			this.button_set.Text = "设置";
			this.button_set.UseVisualStyleBackColor = true;
			this.button_set.Click += new System.EventHandler(this.button_set_Click);
			// 
			// button_confSave
			// 
			this.button_confSave.Location = new System.Drawing.Point(341, 56);
			this.button_confSave.Name = "button_confSave";
			this.button_confSave.Size = new System.Drawing.Size(72, 23);
			this.button_confSave.TabIndex = 10;
			this.button_confSave.Text = "保存配置";
			this.button_confSave.UseVisualStyleBackColor = true;
			this.button_confSave.Click += new System.EventHandler(this.button_confSave_Click);
			// 
			// checkBox_checkCode
			// 
			this.checkBox_checkCode.AutoSize = true;
			this.checkBox_checkCode.Checked = true;
			this.checkBox_checkCode.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox_checkCode.Location = new System.Drawing.Point(329, 116);
			this.checkBox_checkCode.Name = "checkBox_checkCode";
			this.checkBox_checkCode.Size = new System.Drawing.Size(84, 16);
			this.checkBox_checkCode.TabIndex = 12;
			this.checkBox_checkCode.Text = "显示验证码";
			this.checkBox_checkCode.UseVisualStyleBackColor = true;
			this.checkBox_checkCode.CheckedChanged += new System.EventHandler(this.checkBox_checkCode_CheckedChanged);
			// 
			// button_confDel
			// 
			this.button_confDel.Location = new System.Drawing.Point(341, 86);
			this.button_confDel.Name = "button_confDel";
			this.button_confDel.Size = new System.Drawing.Size(72, 23);
			this.button_confDel.TabIndex = 11;
			this.button_confDel.Text = "删除配置";
			this.button_confDel.UseVisualStyleBackColor = true;
			this.button_confDel.Click += new System.EventHandler(this.button_confDel_Click);
			// 
			// panel_checkCode
			// 
			this.panel_checkCode.Controls.Add(this.label4);
			this.panel_checkCode.Controls.Add(this.textBox_checkcode);
			this.panel_checkCode.Controls.Add(this.pictureBox_checkCode);
			this.panel_checkCode.Location = new System.Drawing.Point(22, 124);
			this.panel_checkCode.Name = "panel_checkCode";
			this.panel_checkCode.Size = new System.Drawing.Size(242, 44);
			this.panel_checkCode.TabIndex = 5;
			// 
			// button_help
			// 
			this.button_help.Location = new System.Drawing.Point(341, 169);
			this.button_help.Name = "button_help";
			this.button_help.Size = new System.Drawing.Size(72, 23);
			this.button_help.TabIndex = 14;
			this.button_help.Text = "帮助";
			this.button_help.UseVisualStyleBackColor = true;
			this.button_help.Click += new System.EventHandler(this.button_help_Click);
			// 
			// checkBox_autoLogin
			// 
			this.checkBox_autoLogin.AutoSize = true;
			this.checkBox_autoLogin.Location = new System.Drawing.Point(211, 176);
			this.checkBox_autoLogin.Name = "checkBox_autoLogin";
			this.checkBox_autoLogin.Size = new System.Drawing.Size(120, 16);
			this.checkBox_autoLogin.TabIndex = 9;
			this.checkBox_autoLogin.Text = "无验证码自动登录";
			this.toolTip1.SetToolTip(this.checkBox_autoLogin, "记得保存配置后生效");
			this.checkBox_autoLogin.UseVisualStyleBackColor = true;
			// 
			// button_about
			// 
			this.button_about.Location = new System.Drawing.Point(341, 139);
			this.button_about.Name = "button_about";
			this.button_about.Size = new System.Drawing.Size(72, 23);
			this.button_about.TabIndex = 13;
			this.button_about.Text = "关于";
			this.button_about.UseVisualStyleBackColor = true;
			this.button_about.Click += new System.EventHandler(this.button_about_Click);
			// 
			// FormLogin
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(421, 207);
			this.Controls.Add(this.checkBox_autoLogin);
			this.Controls.Add(this.button_about);
			this.Controls.Add(this.button_help);
			this.Controls.Add(this.panel_checkCode);
			this.Controls.Add(this.checkBox_checkCode);
			this.Controls.Add(this.button_confDel);
			this.Controls.Add(this.button_confSave);
			this.Controls.Add(this.button_set);
			this.Controls.Add(this.button_cancal);
			this.Controls.Add(this.button_login);
			this.Controls.Add(this.textBox_password);
			this.Controls.Add(this.textBox_username);
			this.Controls.Add(this.textBox_url);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.KeyPreview = true;
			this.Name = "FormLogin";
			this.Text = "登录教务系统";
			this.Activated += new System.EventHandler(this.FormLogin_Activated);
			this.Load += new System.EventHandler(this.FormLogin_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormLogin_KeyDown);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox_checkCode)).EndInit();
			this.panel_checkCode.ResumeLayout(false);
			this.panel_checkCode.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBox_url;
		private System.Windows.Forms.TextBox textBox_username;
		private System.Windows.Forms.TextBox textBox_password;
		private System.Windows.Forms.TextBox textBox_checkcode;
		private System.Windows.Forms.PictureBox pictureBox_checkCode;
		private System.Windows.Forms.Button button_login;
		private System.Windows.Forms.Button button_cancal;
		private System.Windows.Forms.Button button_set;
		private System.Windows.Forms.Button button_confSave;
		private System.Windows.Forms.CheckBox checkBox_checkCode;
		private System.Windows.Forms.Button button_confDel;
		private System.Windows.Forms.Panel panel_checkCode;
		private System.Windows.Forms.Button button_help;
		private System.Windows.Forms.CheckBox checkBox_autoLogin;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Button button_about;
	}
}