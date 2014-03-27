using System;
using System.IO;
using System.Net;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Pengeplan.Core
{
	public class PengeplanApi
	{
		protected static PengeplanApi me = null;
		protected static String userPassword;

		static PengeplanApi ()
		{
			me = new PengeplanApi ();
		}

		public async static Task<AuthResponse> authenticate (String userName, String userPassword)
		{
			AuthResponse authresponse = new AuthResponse ();

			String path = string.Format (@"http://localhost:8080/api/user/authenticate/{0}", userName);
			var request = (HttpWebRequest)WebRequest.Create (path);
			request.ContentType = "application/json";
			request.Method = "GET";
			setBasicAuthHeader (request, userName, userPassword);

			using (HttpWebResponse response = request.GetResponse () as HttpWebResponse) {
				if (response.StatusCode == HttpStatusCode.OK) {
					using (StreamReader reader = new StreamReader (response.GetResponseStream ())) {
						var content = reader.ReadToEnd ();

						authresponse = JsonConvert.DeserializeObject<AuthResponse> (content);
					}
				} 
			}
			return authresponse;
		}

		public static List<Transaction> getItems (String userName, String userPassword)
		{
			List<Transaction> transactions = null;

			String path = string.Format (@"http://localhost:8080/api/user/transactions/{0}", userName);
			var request = (HttpWebRequest)WebRequest.Create (path);
			request.ContentType = "application/json";
			request.Method = "GET";
			setBasicAuthHeader (request, userName, userPassword);

			using (HttpWebResponse response = request.GetResponse () as HttpWebResponse) {
				if (response.StatusCode == HttpStatusCode.OK) {
					using (StreamReader reader = new StreamReader (response.GetResponseStream ())) {
						var content = reader.ReadToEnd ();
						transactions = JsonConvert.DeserializeObject<List<Transaction>> (content);
					}
				} 
			}
			return transactions != null ? transactions : new List<Transaction> ();
		}

		private static void setBasicAuthHeader (WebRequest req, String userName, String userPassword)
		{
			string authInfo = userName + ":" + userPassword;
			authInfo = Convert.ToBase64String (Encoding.Default.GetBytes (authInfo));
			req.Headers ["Authorization"] = "Basic " + authInfo;
		}
	}
}

