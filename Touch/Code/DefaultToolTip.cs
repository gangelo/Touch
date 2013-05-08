using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;

namespace Touch.Code {
	
	internal class DefaultToolTip : ToolTip {
		public DefaultToolTip() {
			Initialize();
		}

		public DefaultToolTip(IContainer container)
			: base(container) {
				Initialize();
		}

		protected virtual void Initialize() {
			this.AutoPopDelay = 3000;
			this.InitialDelay = 100;
			this.ReshowDelay = 500;
			this.ShowAlways = true;
		}
	};
};
