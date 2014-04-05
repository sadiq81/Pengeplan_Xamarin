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
		public PengeplanApi ()
		{
		}

		public async Task<AuthResponse> authenticate (string userName, string userPassword, string pin)
		{
			AuthResponse authresponse = new AuthResponse ();
			authresponse.authorized = true;
			authresponse.username = userName;
			authresponse.password = userPassword;
			authresponse.pin = pin;
			return authresponse;

//			String path = string.Format (@"https://www.pengeplan.dk/api/user/authenticate/{0}", userName);
//			var request = (HttpWebRequest)WebRequest.Create (path);
//			request.ContentType = "application/json";
//			request.Method = "GET";
//			setBasicAuthHeader (request, userName, userPassword);
//
//			try {
//				using (HttpWebResponse response = request.GetResponse () as HttpWebResponse) {
//					if (response.StatusCode == HttpStatusCode.OK) {
//						using (StreamReader reader = new StreamReader (response.GetResponseStream ())) {
//							var content = reader.ReadToEnd ();
//
//							authresponse = JsonConvert.DeserializeObject<AuthResponse> (content);
//							authresponse.username = userName;
//							authresponse.password = userPassword;
//							authresponse.pin = pin;
//						}
//					} 
//				}
//			} catch (WebException ex) {
//				authresponse.ex = ex;
//			}
//			return authresponse;
		}

		public async Task<List<Transaction>> getItems (String userName, String userPassword)
		{
			List<Transaction> transactions = new List<Transaction> ();
			transactions.Add (new Transaction (1, TransactionType.BUY, new DateTime (2014, 1, 1), "Paper1", "NYSE", "USD", 1, 1, 100, "Legal1-4321", "Account1-1234", 550));
			transactions.Add (new Transaction (2, TransactionType.BUY, new DateTime (2014, 1, 2), "Paper2", "CPH", "DKK", 1, 1, 100, "Legal1-4321", "Account1-1234", 100));
			transactions.Add (new Transaction (3, TransactionType.BUY, new DateTime (2014, 1, 3), "Paper1", "NYSE", "USD", 1, 1, 100, "Legal1-4321", "Account1-1234", 550));


//			String path = string.Format (@"https://www.pengeplan.dk/api/user/transactions/{0}", userName);
//			var request = (HttpWebRequest)WebRequest.Create (path);
//			request.ContentType = "application/json";
//			request.Method = "GET";
//			setBasicAuthHeader (request, userName, userPassword);
//
//			using (HttpWebResponse response = request.GetResponse () as HttpWebResponse) {
//				if (response.StatusCode == HttpStatusCode.OK) {
//					using (StreamReader reader = new StreamReader (response.GetResponseStream ())) {
//						var content = reader.ReadToEnd ();
//						transactions = JsonConvert.DeserializeObject<List<Transaction>> (content);
//					}
//				} 
//			}
			return transactions ?? new List<Transaction> ();
		}

		private static void setBasicAuthHeader (WebRequest req, String userName, String userPassword)
		{
			string authInfo = userName + ":" + userPassword;
			authInfo = Convert.ToBase64String (Encoding.Default.GetBytes (authInfo));
			req.Headers ["Authorization"] = "Basic " + authInfo;
		}
	}
}

