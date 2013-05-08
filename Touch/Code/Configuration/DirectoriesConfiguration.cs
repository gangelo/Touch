using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Touch.Code.Configuration {

	public class DirectoriesConfiguration : BaseConfiguration {
		static private object m_syncRoot = new object();
				
		private string m_defaultTouchDirectory;
		private string m_lastTouchDirectory;

		private string m_queuedDefaultTouchDirectory;
		private string m_queuedLastTouchDirectory;		

		public DirectoriesConfiguration(string defaultTouchDirectory, string lastTouchDirectory = null) {
			m_queuedDefaultTouchDirectory = m_defaultTouchDirectory = BaseConfiguration.GetValueOrEmpty(defaultTouchDirectory);
			m_queuedLastTouchDirectory = m_lastTouchDirectory = BaseConfiguration.GetValueOrEmpty(lastTouchDirectory);
		}		
		
		public string DefaultTouchDirectory {
			get { return m_defaultTouchDirectory; }
			set { m_queuedDefaultTouchDirectory = BaseConfiguration.GetValueOrEmpty(value); }
		}

		public string LastTouchDirectory {
			get { return m_lastTouchDirectory; }
			set { m_queuedLastTouchDirectory = BaseConfiguration.GetValueOrEmpty(value); }
		}

		public bool HasLastTouchDirectory {
			get {	return !string.IsNullOrEmpty(this.LastTouchDirectory); }
		}

		// Abstract Overrides
		// --------------------------------------------------------------------------
		#region Abstract Overrides
		public override bool IsDirty {
			get {
				bool defaultTouchDirectoryIsDirty = !m_defaultTouchDirectory.Equals(m_queuedDefaultTouchDirectory, StringComparison.InvariantCultureIgnoreCase);
				bool lastTouchDirectoryIsDirty = !m_lastTouchDirectory.Equals(m_queuedLastTouchDirectory, StringComparison.InvariantCultureIgnoreCase);
				return (defaultTouchDirectoryIsDirty || lastTouchDirectoryIsDirty);
			}
		}

		public override void ApplyChanges() {
			m_defaultTouchDirectory = m_queuedDefaultTouchDirectory;
			m_lastTouchDirectory = m_queuedLastTouchDirectory;
		}

		public override XElement ToXml() {
			XElement configuration =
				new XElement("directoriesConfiguration",
					new XElement("defaultTouchDirectory", this.DefaultTouchDirectory),
					new XElement("lastTouchDirectory", this.LastTouchDirectory)

				);
			return configuration;
		} 
		#endregion	// Abstract Overrides

		static public DirectoriesConfiguration FromXml(XElement root) {
			lock (m_syncRoot) {
				XElement xElement = null;
					
				xElement = root.XPathSelectElement("./configuration/directoriesConfiguration/defaultTouchDirectory");
				string defaultTouchDirectory = xElement.Value;

				xElement = root.XPathSelectElement("./configuration/directoriesConfiguration/lastTouchDirectory");
				string lastTouchDirectory = xElement.Value;

				return new DirectoriesConfiguration(defaultTouchDirectory, lastTouchDirectory);
			}
		}
	};
};
