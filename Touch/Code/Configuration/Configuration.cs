using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Touch.Code.Configuration {

	public class Configuration {
		// Fields
		// --------------------------------------------------------------------------
		#region Fields
		static private readonly object m_syncRoot = new object();
		static private readonly Configuration m_instance;

		private GeneralConfiguration m_generalConfiguration;
		private DirectoriesConfiguration m_directoriesConfiguration;

		private string m_applicationFolderName;
		#endregion	// Fields

		// Constructors
		// --------------------------------------------------------------------------
		#region Constructors
		static Configuration() {
			m_instance = new Configuration();
		}

		protected Configuration() {
			this.ApplicationFolderName = "Touch";

			// Create the application data folder for the first time if it does not exist.
			if (!Directory.Exists(this.ApplicationFolder)) {
				Directory.CreateDirectory(this.ApplicationFolder);
			}

			// Create the user data folder for the first time if it does not exist.
			if (!Directory.Exists(this.UserDataFolder)) {
				Directory.CreateDirectory(this.UserDataFolder);
			}

			// Create the backup folder for the first time if it does not exist.
			if (!Directory.Exists(this.BackupFolder)) {
				Directory.CreateDirectory(this.BackupFolder);
			}

			this.GeneralConfiguration = new GeneralConfiguration();
			this.DirectoriesConfiguration = new DirectoriesConfiguration(BaseConfiguration.GetConfigurationRootFolder());
			
			
			if (!File.Exists(this.ConfigurationFile)) {
				CreateConfigurationFile();
			}

			LoadConfigurationFile();
		}
		#endregion	// Constructors

		static public Configuration Instance {
			get {
				lock (m_syncRoot) {
					if (m_instance == null) {
						throw new InvalidOperationException("Singleton instance object is null.");
					} else {
						return m_instance;
					}
				}
			}
		}		

		// Properties
		// --------------------------------------------------------------------------
		#region Properties
		/// <summary>
		/// Determines if the configuration has changeed. If the configuration has changed
		/// it should be either saved or the changes discarded.
		/// </summary>
		public virtual bool IsDirty {
			get {
				if (this.DirectoriesConfiguration == null ||
					this.GeneralConfiguration == null) {
					throw new InvalidOperationException("Property IsDirty was called while not properly instantiated.");
				} else {
					return this.GeneralConfiguration.IsDirty ||
						this.DirectoriesConfiguration.IsDirty;
				}
			}
		}

		public virtual GeneralConfiguration GeneralConfiguration {
			get { return m_generalConfiguration; }
			protected set { m_generalConfiguration = value; }
		}

		public virtual DirectoriesConfiguration DirectoriesConfiguration {
			get { return m_directoriesConfiguration; }
			protected set { m_directoriesConfiguration = value; }
		}
		
		protected virtual string ApplicationFolderName {
			get { return m_applicationFolderName; }
			set { m_applicationFolderName = value; }
		}

		public string ApplicationFolder {
			get { return BaseConfiguration.GetConfigurationRootFolder() + @"\" + this.ApplicationFolderName; }
		}

		public string UserDataFolder {
			get { return BaseConfiguration.GetConfigurationRootFolder() + @"\" + this.ApplicationFolderName + @"\UserData"; }
		}

		public string BackupFolder {
			get { return BaseConfiguration.GetConfigurationRootFolder() + @"\" + this.ApplicationFolderName + @"\Backup"; }
		}

		public string ConfigurationFile {
			get { return this.ApplicationFolder + @"\" + "Application.xml"; }
		}
		#endregion	// Properties

		// Methods
		// --------------------------------------------------------------------------
		#region Methods
		protected virtual void LoadConfigurationFile() {
			XElement root = XElement.Load(this.ConfigurationFile);

			this.GeneralConfiguration = GeneralConfiguration.FromXml(root);
			this.DirectoriesConfiguration = DirectoriesConfiguration.FromXml(root);
		}

		protected virtual void CreateConfigurationFile() {
			XElement root = new XElement("root");
			XElement configuration =
				new XElement("configuration",
					new XElement(this.GeneralConfiguration.ToXml()),
					new XElement(this.DirectoriesConfiguration.ToXml())
				);

			root.Add(configuration);

			root.Save(this.ConfigurationFile);
		}

		public void Save() {
			if (!this.IsDirty) {
				// Nothing to save, just get out.
				return;
			} else {
				this.GeneralConfiguration.ApplyChanges();
				this.DirectoriesConfiguration.ApplyChanges();
				CreateConfigurationFile();
			}
		}
		#endregion	// Methods
	};
};
