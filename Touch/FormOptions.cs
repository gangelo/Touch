using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using IOLib.Helpers;
using StringLib.Helpers;
using Touch.Code;
using Touch.Code.Configuration;

namespace Touch {
	
	public partial class FormOptions : Form {
		static private string ClickToSet { get { return "[Click to Set]"; } }

		private DefaultToolTip UpdateDefaultTouchDirectoryLinkLabelToolTip { get; set; }
		private DefaultToolTip UpdateLastTouchDirectoryLabelToolTip { get; set; }

		public FormOptions() {
			InitializeComponent();

			m_ok.Enabled = false;
			this.ShowInTaskbar = false;
			this.StartPosition = FormStartPosition.CenterParent;
			//m_touchDirectory.Text = FormOptions.ClickToSet;

			m_useRecursionByDefault.Checked = Configuration.Instance.GeneralConfiguration.UseRecursionByDefault;

			string defaultTouchDirectory = Configuration.Instance.DirectoriesConfiguration.DefaultTouchDirectory;
			DefaultTouchDirectoryChangedProcessing(defaultTouchDirectory);
			
			if (Configuration.Instance.DirectoriesConfiguration.HasLastTouchDirectory) {
				string lastTouchDirectory = Configuration.Instance.DirectoriesConfiguration.LastTouchDirectory;
				LastTouchDirectoryChangedProcessing(lastTouchDirectory);
			} else {
				LastTouchDirectoryChangedProcessing();
			}

			m_useRecursionByDefault.CheckedChanged += new EventHandler(this.OnUseRecursionByDefaultCheckedChanged);
			m_touchDirectory.LinkClicked += new LinkLabelLinkClickedEventHandler(this.OnTouchDirectoryLinkClicked);

			m_ok.Click += new EventHandler(this.OnOkClick);
			m_exit.Click += new EventHandler(this.OnExitClick);
		}

		private bool GetFolder(out string fileName) {
			fileName = string.Empty;

			if (m_folderBrowserDialog.ShowDialog() != DialogResult.OK) {
				return false;
			} else {
				fileName = m_folderBrowserDialog.SelectedPath;
				return true;
			}
		}				

		protected void DefaultTouchDirectoryChangedProcessing(string touchDirectory) {			
			if (this.UpdateDefaultTouchDirectoryLinkLabelToolTip == null) {
				this.UpdateDefaultTouchDirectoryLinkLabelToolTip = new DefaultToolTip();				
			}

			bool hasTouchDirectory = !string.IsNullOrEmpty(touchDirectory);

			m_touchDirectory.Text = hasTouchDirectory ? PathHelpers.MinifyPath(touchDirectory) : FormOptions.ClickToSet;
			m_touchDirectory.Tag = hasTouchDirectory ? touchDirectory : null;
			if (hasTouchDirectory) {
				this.UpdateDefaultTouchDirectoryLinkLabelToolTip.SetToolTip(m_touchDirectory, touchDirectory);
			} else {
				this.UpdateDefaultTouchDirectoryLinkLabelToolTip.RemoveAll();
			}

			m_folderBrowserDialog.SelectedPath = touchDirectory;
		}
		
		protected void LastTouchDirectoryChangedProcessing(string touchDirectory = null) {			
			if (this.UpdateLastTouchDirectoryLabelToolTip == null){
				this.UpdateLastTouchDirectoryLabelToolTip = new DefaultToolTip();
			}

			bool hasTouchDirectory = !string.IsNullOrEmpty(touchDirectory);

			m_lastTouchDirectory.Text = hasTouchDirectory ? PathHelpers.MinifyPath(touchDirectory) : "None";
			m_lastTouchDirectory.Tag = hasTouchDirectory ? touchDirectory : null;
			if (hasTouchDirectory) {
				this.UpdateLastTouchDirectoryLabelToolTip.SetToolTip(m_lastTouchDirectory, touchDirectory);
			} else {
				this.UpdateLastTouchDirectoryLabelToolTip.RemoveAll();
			}
		}

		protected void OnUseRecursionByDefaultCheckedChanged(object sender, EventArgs e) {
			bool useRecursionByDefault = m_useRecursionByDefault.Checked;
			if (Configuration.Instance.GeneralConfiguration.UseRecursionByDefault != useRecursionByDefault) {
				Configuration.Instance.GeneralConfiguration.UseRecursionByDefault = useRecursionByDefault;
				m_ok.Enabled = true;
			}
		}

		protected void OnTouchDirectoryLinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			string touchDirectory;
			if (this.GetFolder(out touchDirectory)) {				
				DefaultTouchDirectoryChangedProcessing(touchDirectory);

				string defaultTouchDirectory = Configuration.Instance.DirectoriesConfiguration.DefaultTouchDirectory;
				if (!defaultTouchDirectory.Equals(touchDirectory, StringComparison.InvariantCultureIgnoreCase)) {
					Configuration.Instance.DirectoriesConfiguration.DefaultTouchDirectory = touchDirectory;
					m_ok.Enabled = true;
				}
			}
		}

		protected void OnOkClick(object sender, EventArgs e) {
			Configuration.Instance.GeneralConfiguration.UseRecursionByDefault = m_useRecursionByDefault.Checked;
			Configuration.Instance.DirectoriesConfiguration.DefaultTouchDirectory = Convert.ToString(m_touchDirectory.Tag);

			if (Configuration.Instance.IsDirty) {
				Configuration.Instance.Save();
				MessageBox.Show(this, "Configuration saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
				this.Close();
			}
		}

		protected void OnExitClick(object sender, EventArgs e) {
			if (!Configuration.Instance.IsDirty) {
				this.Close();
			} else {
				if (MessageBox.Show(this, "You have made changes to the Application Configuration, if you exit without saving " +
						"your changes will be lost.  Are you sure you want to exit?", "Attention",
						MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2) == DialogResult.Yes) {
					this.Close();
				} else {
					MessageBox.Show(this, "Exit canceled.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
		}
	};
};
