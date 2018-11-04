using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1 {
	public class EmialInfo {
		public EmialInfo() {
			this.AsHtml = true;
		}

		public string From { get; set; }
		public string To { get; set; }
		public string Subject { get; set; }
		public string Body { get; set; }
		public bool AsHtml { get; set; }
	}

	public static class Utilities {
		public static bool SendEmail(EmialInfo info) {
			try {
				using (HttpClient client = new HttpClient()) {
					string json = JsonConvert.SerializeObject(info);
					StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
					Task<HttpResponseMessage> task = client.PostAsync(Settings.EmailApi, content);
					task.Wait();
					return task.Result.IsSuccessStatusCode;
				}
			} catch {
				//Ignore this error
			}
			return false;
		}
	}
}
