using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Touch.Code.Configuration {

	public class GeneralConfiguration : BaseConfiguration {
		static private object m_syncRoot = new object();
		
		private bool m_useRecursionByDefault;
		private bool m_queuedRecursionByDefault;
		
		public GeneralConfiguration(bool useRecursionByDefault = true) {
			m_queuedRecursionByDefault = m_useRecursionByDefault = useRecursionByDefault;
		}

		public bool UseRecursionByDefault {
			get { return m_useRecursionByDefault; }
			set {	m_queuedRecursionByDefault = value;	}
		}

		// Abstract Overrides
		// --------------------------------------------------------------------------
		#region Abstract Overrides
		public override bool IsDirty {
			get { return m_useRecursionByDefault != m_queuedRecursionByDefault; }
		}

		public override void ApplyChanges() {
			m_useRecursionByDefault = m_queuedRecursionByDefault;
		}

		public override XElement ToXml() {
			XElement configuration =
				new XElement("generalConfiguration",
					new XElement("useRecursionByDefault",
						new XAttribute("useRecursionByDefault", this.UseRecursionByDefault))
				);
			return configuration;
		}
		#endregion	// Abstract Overrides

		static public GeneralConfiguration FromXml(XElement root) {
			lock (m_syncRoot) {
				XElement xElement = root.XPathSelectElement("./configuration/generalConfiguration/useRecursionByDefault");
				bool useRecursionByDefault = Convert.ToBoolean(xElement.Attribute("useRecursionByDefault").Value);
				return new GeneralConfiguration(useRecursionByDefault);
			}
		}
	};
};

