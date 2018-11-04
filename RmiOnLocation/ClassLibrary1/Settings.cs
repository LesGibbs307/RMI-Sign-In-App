using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1 {
	public static class Settings {
		public static string EmailApi {
			get { return ConfigurationManager.AppSettings["EmailApi"]; }
		}

		public static string VisitorFromEmail {
			get { return ConfigurationManager.AppSettings["VisitorFromEmail"]; }
		}
			
	}
}
