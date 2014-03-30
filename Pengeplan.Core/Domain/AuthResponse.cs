using System;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Pengeplan.Core
{
	public class AuthResponse
	{
		public AuthResponse ()
		{
			authorized = false;
			username = "";
			password = "";
			pin = "";
		}

		public bool authorized { get; set; }

		public string username { get; set; }

		public string password { get; set; }

		public string pin { get; set; }

		public Exception ex { get; set; }
	}
}

