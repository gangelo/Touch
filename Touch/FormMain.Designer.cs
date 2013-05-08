namespace Touch {
	partial class FormMain {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			System.Windows.Forms.GroupBox m_filesGroupBox;
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
			this.m_listView = new System.Windows.Forms.ListView();
			this.m_ok = new System.Windows.Forms.Button();
			this.m_exit = new System.Windows.Forms.Button();
			this.m_folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.m_touchDirectory = new System.Windows.Forms.LinkLabel();
			this.label1 = new System.Windows.Forms.Label();
			this.m_recursive = new System.Windows.Forms.CheckBox();
			this.m_menuStrip = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.m_exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.m_optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.m_aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			m_filesGroupBox = new System.Windows.Forms.GroupBox();
			m_filesGroupBox.SuspendLayout();
			this.m_menuStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_filesGroupBox
			// 
			m_filesGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
							| System.Windows.Forms.AnchorStyles.Left)
							| System.Windows.Forms.AnchorStyles.Right)));
			m_filesGroupBox.Controls.Add(this.m_listView);
			m_filesGroupBox.Location = new System.Drawing.Point(12, 58);
			m_filesGroupBox.Name = "m_filesGroupBox";
			m_filesGroupBox.Size = new System.Drawing.Size(768, 465);
			m_filesGroupBox.TabIndex = 6;
			m_filesGroupBox.TabStop = false;
			m_filesGroupBox.Text = "Files";
			// 
			// m_listView
			// 
			this.m_listView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_listView.Location = new System.Drawing.Point(3, 18);
			this.m_listView.Name = "m_listView";
			this.m_listView.Size = new System.Drawing.Size(762, 444);
			this.m_listView.TabIndex = 0;
			this.m_listView.UseCompatibleStateImageBehavior = false;
			// 
			// m_ok
			// 
			this.m_ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.m_ok.AutoSize = true;
			this.m_ok.Location = new System.Drawing.Point(624, 529);
			this.m_ok.Name = "m_ok";
			this.m_ok.Size = new System.Drawing.Size(75, 27);
			this.m_ok.TabIndex = 0;
			this.m_ok.Text = "OK";
			this.m_ok.UseVisualStyleBackColor = true;
			// 
			// m_exit
			// 
			this.m_exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.m_exit.AutoSize = true;
			this.m_exit.Location = new System.Drawing.Point(705, 529);
			this.m_exit.Name = "m_exit";
			this.m_exit.Size = new System.Drawing.Size(75, 27);
			this.m_exit.TabIndex = 0;
			this.m_exit.Text = "Exit";
			this.m_exit.UseVisualStyleBackColor = true;
			// 
			// m_touchDirectory
			// 
			this.m_touchDirectory.AutoSize = true;
			this.m_touchDirectory.Location = new System.Drawing.Point(78, 38);
			this.m_touchDirectory.Name = "m_touchDirectory";
			this.m_touchDirectory.Size = new System.Drawing.Size(86, 17);
			this.m_touchDirectory.TabIndex = 2;
			this.m_touchDirectory.TabStop = true;
			this.m_touchDirectory.Text = "[Click to Set]";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 38);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(69, 17);
			this.label1.TabIndex = 3;
			this.label1.Text = "Directory:";
			// 
			// m_recursive
			// 
			this.m_recursive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.m_recursive.AutoSize = true;
			this.m_recursive.Location = new System.Drawing.Point(15, 529);
			this.m_recursive.Name = "m_recursive";
			this.m_recursive.Size = new System.Drawing.Size(93, 21);
			this.m_recursive.TabIndex = 4;
			this.m_recursive.Text = "Recursive";
			this.m_recursive.UseVisualStyleBackColor = true;
			// 
			// m_menuStrip
			// 
			this.m_menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
			this.m_menuStrip.Location = new System.Drawing.Point(0, 0);
			this.m_menuStrip.Name = "m_menuStrip";
			this.m_menuStrip.Size = new System.Drawing.Size(792, 26);
			this.m_menuStrip.TabIndex = 5;
			this.m_menuStrip.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(40, 22);
			this.fileToolStripMenuItem.Text = "&File";
			// 
			// m_exitToolStripMenuItem
			// 
			this.m_exitToolStripMenuItem.Name = "m_exitToolStripMenuItem";
			this.m_exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.m_exitToolStripMenuItem.Text = "&Exit";
			// 
			// toolsToolStripMenuItem
			// 
			this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_optionsToolStripMenuItem});
			this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
			this.toolsToolStripMenuItem.Size = new System.Drawing.Size(55, 22);
			this.toolsToolStripMenuItem.Text = "&Tools";
			// 
			// m_optionsToolStripMenuItem
			// 
			this.m_optionsToolStripMenuItem.Name = "m_optionsToolStripMenuItem";
			this.m_optionsToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
			this.m_optionsToolStripMenuItem.Text = "&Options";
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_aboutToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(48, 22);
			this.helpToolStripMenuItem.Text = "&Help";
			// 
			// m_aboutToolStripMenuItem
			// 
			this.m_aboutToolStripMenuItem.Name = "m_aboutToolStripMenuItem";
			this.m_aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.m_aboutToolStripMenuItem.Text = "&About";
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(792, 568);
			this.Controls.Add(m_filesGroupBox);
			this.Controls.Add(this.m_touchDirectory);
			this.Controls.Add(this.m_recursive);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.m_exit);
			this.Controls.Add(this.m_ok);
			this.Controls.Add(this.m_menuStrip);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.m_menuStrip;
			this.Name = "FormMain";
			this.Text = "Touch";
			m_filesGroupBox.ResumeLayout(false);
			this.m_menuStrip.ResumeLayout(false);
			this.m_menuStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button m_ok;
		private System.Windows.Forms.Button m_exit;
		private System.Windows.Forms.FolderBrowserDialog m_folderBrowserDialog;
		private System.Windows.Forms.LinkLabel m_touchDirectory;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox m_recursive;
		private System.Windows.Forms.MenuStrip m_menuStrip;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem m_exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem m_optionsToolStripMenuItem;
		private System.Windows.Forms.ListView m_listView;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem m_aboutToolStripMenuItem;
	}
}

