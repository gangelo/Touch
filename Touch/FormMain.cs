using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

using Touch.Code;
using Touch.Code.Configuration;

using IOLib.Helpers;
using StringLib.Helpers;
using ControlsLib.CommonControls.ListViewControl;

namespace Touch {
	public partial class FormMain : Form {
		static private string ClickToSet { get { return "[Click to Set]"; } }
		static private FileNameKey FileNameKey { get; set; }
		static private ModifiedDateOriginalKey ModifiedDateOriginalKey { get; set; }
		static private ModifiedDateNewKey ModifiedDateNewKey { get; set; }		
		static private DirectoryKey DirectoryKey { get; set; }

		private DefaultToolTip TouchDirectoryLinkLabelToolTip { get; set; }
		private DateTime TouchDate { get; set; }

		static FormMain() {			
			FormMain.FileNameKey = new FileNameKey();
			FormMain.ModifiedDateOriginalKey = new ModifiedDateOriginalKey();
			FormMain.ModifiedDateNewKey = new ModifiedDateNewKey();			
			FormMain.DirectoryKey = new DirectoryKey();
		}

		public FormMain() {
			InitializeComponent();
			//
			this.TouchDate = DateTime.Now;

			//
			this.MinimumSize = this.Size = new System.Drawing.Size(800, 600);

			//
			m_ok.Enabled = false;
			m_touchDirectory.Text = FormMain.ClickToSet;
			m_recursive.Checked = Configuration.Instance.GeneralConfiguration.UseRecursionByDefault;

			//
			m_folderBrowserDialog.SelectedPath = Configuration.Instance.DirectoriesConfiguration.DefaultTouchDirectory;
			m_folderBrowserDialog.ShowNewFolderButton = false;

			//
			m_ok.Click += new EventHandler(this.OnOkClick);
			m_exit.Click += new EventHandler(this.OnExitClick);
			m_recursive.CheckedChanged += new EventHandler(this.OnRecursiveCheckedChanged);
			m_touchDirectory.Click += new EventHandler(this.OnTouchDirectoryClick);

			m_optionsToolStripMenuItem.Click += new EventHandler(this.OnOptionsToolStripMenuItemClick);
			m_exitToolStripMenuItem.Click += new EventHandler(this.OnExitClick);
			m_aboutToolStripMenuItem.Click += new EventHandler(this.OnAboutToolStripMenuItemClick);

			// CommonControls.ListViewControl...
			InitializeListView();
		}				

		protected override void OnLoad(EventArgs e) {
			if (Configuration.Instance.DirectoriesConfiguration.HasLastTouchDirectory) {
				this.Show();

				string lastTouchDirectrory = Configuration.Instance.DirectoriesConfiguration.LastTouchDirectory;
				string message = string.Format("The last directory you touched was: {0}{1}Do you want to reload this directory?", 
					lastTouchDirectrory, StringHelpers.CRLF + StringHelpers.CRLF);
				if (MessageBox.Show(this, message, "Attention", MessageBoxButtons.YesNo, 
					MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes) {
					m_folderBrowserDialog.SelectedPath = lastTouchDirectrory;
					TouchDirectoryChangedProcessing(lastTouchDirectrory);					
					this.LoadFiles();
				}
			}
		}

		protected void InitializeListView() {
			// Set up our view type...
			m_listView.View = View.Details;
			m_listView.CheckBoxes = true;
			m_listView.GridLines = true;

			// Image list...						
			//m_listView.SmallImageList = m_imageList;

			// Columns...
			m_listView.Columns.Add(FormMain.FileNameKey.ToString(), "File Name", 100);
			m_listView.Columns.Add(FormMain.ModifiedDateOriginalKey.ToString(), "Modified Date", 100);
			m_listView.Columns.Add(FormMain.ModifiedDateNewKey.ToString(), "New Modified Date", 100);
			m_listView.Columns.Add(FormMain.DirectoryKey.ToString(), "Directory", 100);
			
			// Events...
			m_listView.ColumnClick += new ColumnClickEventHandler(this.OnListViewColumnClick);

			// Sorter...
			m_listView.ListViewItemSorter = new ListViewColumnSorter();
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

		protected void LoadFiles() {
			if (this.DoLoadFiles()) {
				m_ok.Enabled = true;
				ListViewSort.SortListView(m_listView);
				ListViewColumns.ResizeColumns(m_listView,
					new string[] { 
						FormMain.FileNameKey.ToString(), 
						FormMain.ModifiedDateOriginalKey.ToString(), 
						FormMain.ModifiedDateNewKey.ToString(), 
						FormMain.DirectoryKey.ToString() 
					}
				);
			} else {
				m_ok.Enabled = false;
			}
		}

		protected bool DoLoadFiles() {
			bool recursive = m_recursive.Checked;
			string touchDirectory = Convert.ToString(m_touchDirectory.Tag);

			m_listView.Items.Clear();
						
			string[] files = Directory.GetFiles(touchDirectory, "*.*", recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
			foreach (string file in files) {				
				ListViewItem listViewItem = new ListViewItem(Path.GetFileName(file));
				listViewItem.SubItems[0].Name = FormMain.FileNameKey.ToString();

				listViewItem.Tag = file;
				listViewItem.Checked = true;

				listViewItem.SubItems.Add(File.GetLastWriteTime(file).ToString());
				listViewItem.SubItems[1].Name = FormMain.ModifiedDateOriginalKey.ToString();

				listViewItem.SubItems.Add("");
				listViewItem.SubItems[2].Name = FormMain.ModifiedDateNewKey.ToString();

				listViewItem.SubItems.Add(Path.GetDirectoryName(file));
				listViewItem.SubItems[3].Name = FormMain.DirectoryKey.ToString();

				m_listView.Items.Add(listViewItem);
			}

			return m_listView.Items.Count > 0;
		}

		protected void TouchDirectoryChangedProcessing(string touchDirectory) {
			if (this.TouchDirectoryLinkLabelToolTip == null) {
				this.TouchDirectoryLinkLabelToolTip = new DefaultToolTip();				
			}

			bool hasTouchDirectory = !string.IsNullOrEmpty(touchDirectory);

			m_touchDirectory.Text = hasTouchDirectory ? PathHelpers.MinifyPath(touchDirectory) : FormMain.ClickToSet;
			m_touchDirectory.Tag = hasTouchDirectory ? touchDirectory : null;
			if (hasTouchDirectory) {
				this.TouchDirectoryLinkLabelToolTip.SetToolTip(m_touchDirectory, touchDirectory);
			} else {
				this.TouchDirectoryLinkLabelToolTip.RemoveAll();
			}

			m_folderBrowserDialog.SelectedPath = touchDirectory;		
		}

		protected void OnOptionsToolStripMenuItemClick(object sender, EventArgs e) {
			FormOptions form = new FormOptions();
			form.ShowDialog(this);
		}

		protected void OnExitToolStripMenuItemClick(object sender, EventArgs e) {
			this.OnExitClick(this, EventArgs.Empty);
		}
		

		private void OnListViewColumnClick(object sender, ColumnClickEventArgs e) {
			ListViewSort.SortListView(m_listView, e.Column);
		}

		protected void OnTouchDirectoryClick(object sender, EventArgs e) {
			string touchDirectory;
			if (this.GetFolder(out touchDirectory)) {
				TouchDirectoryChangedProcessing(touchDirectory);
				this.LoadFiles();
			}
		}

		protected void OnRecursiveCheckedChanged(object sender, EventArgs e) {
			if (m_listView.Items.Count > 0) {
				this.LoadFiles();
			}
		}

		protected void OnAboutToolStripMenuItemClick(object sender, EventArgs e) {
			AboutBox form = new AboutBox();
			form.ShowDialog(this);
		}

		protected void OnOkClick(object sender, EventArgs e) {
			// Perform our Touch processing...
			foreach (ListViewItem listViewItem in m_listView.Items) {
				if (listViewItem.Checked) {
					string file = Convert.ToString(listViewItem.Tag);
					DateTime touchDate = this.TouchDate;
					File.SetLastWriteTime(file, touchDate);
					listViewItem.SubItems[FormMain.ModifiedDateNewKey.ToString()].Text = touchDate.ToString();
				} else {
					listViewItem.SubItems[FormMain.ModifiedDateNewKey.ToString()].Text = "Unchanged";
				}
			}

			// Resize the CommonControls.ListViewControl column that displays the new Modified Date because we just populated it
			// with new data...
			ListViewColumns.ResizeColumns(m_listView, new string[] { FormMain.ModifiedDateNewKey.ToString() });

			// Update the LastTouchDirectory in the config...
			Configuration.Instance.DirectoriesConfiguration.LastTouchDirectory = Convert.ToString(m_touchDirectory.Tag);
			if (Configuration.Instance.IsDirty) {
				Configuration.Instance.Save();
			}

			MessageBox.Show(this, "Touch complete", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		protected void OnExitClick(object sender, EventArgs e) {
			Application.Exit();				
		}		
	};
};
