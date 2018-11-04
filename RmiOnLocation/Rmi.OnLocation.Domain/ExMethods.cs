using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rmi.OnLocation.Domain {
	public static class ExMethods {
		public static bool HasValue(this string value) {
			return !string.IsNullOrEmpty(value);
		}

		public static bool IsEmpty(this string value) {
			return string.IsNullOrEmpty(value);
		}
	}
}
