using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Touch.Code.Configuration {
	
	public abstract class BaseConfiguration {

		public abstract bool IsDirty { get; }
		public abstract void ApplyChanges();
		public abstract XElement ToXml();

		static public string GetConfigurationRootFolder() {
			return Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);			
		}

		static public string GetValueOrEmpty(string value) {
			return (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value)) ? string.Empty : value;
		}
	};
};
