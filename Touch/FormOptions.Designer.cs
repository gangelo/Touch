namespace Touch {
	partial class FormOptions {
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
			System.Windows.Forms.Label m_defaultTouchDirectoryLabel;
			System.Windows.Forms.Label m_lastouchDirectoryLabel;
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOptions));
			this.m_exit = new System.Windows.Forms.Button();
			this.m_ok = new System.Windows.Forms.Button();
			this.m_useRecursionByDefault = new System.Windows.Forms.CheckBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.m_touchDirectory = new System.Windows.Forms.LinkLabel();
			this.m_lastTouchDirectory = new System.Windows.Forms.Label();
			this.m_folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
			m_defaultTouchDirectoryLabel = new System.Windows.Forms.Label();
			m_lastouchDirectoryLabel = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_exit
			// 
			this.m_exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.m_exit.AutoSize = true;
			this.m_exit.Location = new System.Drawing.Point(505, 204);
			this.m_exit.Name = "m_exit";
			this.m_exit.Size = new System.Drawing.Size(75, 27);
			this.m_exit.TabIndex = 2;
			this.m_exit.Text = "Exit";
			this.m_exit.UseVisualStyleBackColor = true;
			// 
			// m_ok
			// 
			this.m_ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.m_ok.AutoSize = true;
			this.m_ok.Location = new System.Drawing.Point(424, 204);
			this.m_ok.Name = "m_ok";
			this.m_ok.Size = new System.Drawing.Size(75, 27);
			this.m_ok.TabIndex = 1;
			this.m_ok.Text = "OK";
			this.m_ok.UseVisualStyleBackColor = true;
			// 
			// m_useRecursionByDefault
			// 
			this.m_useRecursionByDefault.AutoSize = true;
			this.m_useRecursionByDefault.Location = new System.Drawing.Point(12, 12);
			this.m_useRecursionByDefault.Name = "m_useRecursionByDefault";
			this.m_useRecursionByDefault.Size = new System.Drawing.Size(191, 21);
			this.m_useRecursionByDefault.TabIndex = 3;
			this.m_useRecursionByDefault.Text = "Use Recursion by Default";
			this.m_useRecursionByDefault.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
							| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.m_lastTouchDirectory);
			this.groupBox1.Controls.Add(m_lastouchDirectoryLabel);
			this.groupBox1.Controls.Add(m_defaultTouchDirectoryLabel);
			this.groupBox1.Controls.Add(this.m_touchDirectory);
			this.groupBox1.Location = new System.Drawing.Point(12, 40);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(568, 152);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Direcories";
			// 
			// m_touchDirectory
			// 
			this.m_touchDirectory.AutoSize = true;
			this.m_touchDirectory.Location = new System.Drawing.Point(170, 31);
			this.m_touchDirectory.Name = "m_touchDirectory";
			this.m_touchDirectory.Size = new System.Drawing.Size(86, 17);
			this.m_touchDirectory.TabIndex = 6;
			this.m_touchDirectory.TabStop = true;
			this.m_touchDirectory.Text = "[Click to Set]";
			// 
			// m_defaultTouchDirectoryLabel
			// 
			m_defaultTouchDirectoryLabel.AutoSize = true;
			m_defaultTouchDirectoryLabel.Location = new System.Drawing.Point(6, 31);
			m_defaultTouchDirectoryLabel.Name = "m_defaultTouchDirectoryLabel";
			m_defaultTouchDirectoryLabel.Size = new System.Drawing.Size(162, 17);
			m_defaultTouchDirectoryLabel.TabIndex = 7;
			m_defaultTouchDirectoryLabel.Text = "Default Touch Directory:";
			// 
			// m_lastouchDirectoryLabel
			// 
			m_lastouchDirectoryLabel.AutoSize = true;
			m_lastouchDirectoryLabel.Location = new System.Drawing.Point(28, 58);
			m_lastouchDirectoryLabel.Name = "m_lastouchDirectoryLabel";
			m_lastouchDirectoryLabel.Size = new System.Drawing.Size(140, 17);
			m_lastouchDirectoryLabel.TabIndex = 7;
			m_lastouchDirectoryLabel.Text = "LastTouch Directory:";
			// 
			// m_lastTouchDirectory
			// 
			this.m_lastTouchDirectory.AutoSize = true;
			this.m_lastTouchDirectory.Location = new System.Drawing.Point(170, 58);
			this.m_lastTouchDirectory.Name = "m_lastTouchDirectory";
			this.m_lastTouchDirectory.Size = new System.Drawing.Size(148, 17);
			this.m_lastTouchDirectory.TabIndex = 8;
			this.m_lastTouchDirectory.Text = "[Last Touch Directory]";
			// 
			// FormOptions
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(592, 243);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.m_useRecursionByDefault);
			this.Controls.Add(this.m_exit);
			this.Controls.Add(this.m_ok);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "FormOptions";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "Options";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button m_exit;
		private System.Windows.Forms.Button m_ok;
		private System.Windows.Forms.CheckBox m_useRecursionByDefault;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.LinkLabel m_touchDirectory;
		private System.Windows.Forms.Label m_lastTouchDirectory;
		private System.Windows.Forms.FolderBrowserDialog m_folderBrowserDialog;
	}
}