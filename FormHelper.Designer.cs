namespace JiaowuHelper
{
	partial class FormHelper
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHelper));
			this.richTextBox_help = new System.Windows.Forms.RichTextBox();
			this.SuspendLayout();
			// 
			// richTextBox_help
			// 
			this.richTextBox_help.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.richTextBox_help.Dock = System.Windows.Forms.DockStyle.Fill;
			this.richTextBox_help.Location = new System.Drawing.Point(0, 0);
			this.richTextBox_help.Name = "richTextBox_help";
			this.richTextBox_help.ReadOnly = true;
			this.richTextBox_help.Size = new System.Drawing.Size(543, 313);
			this.richTextBox_help.TabIndex = 0;
			this.richTextBox_help.Text = resources.GetString("richTextBox_help.Text");
			// 
			// FormHelper
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(543, 313);
			this.Controls.Add(this.richTextBox_help);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "FormHelper";
			this.Text = "用户帮助";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.RichTextBox richTextBox_help;
	}
}