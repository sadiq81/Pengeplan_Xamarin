using NUnit.Framework;
using System;

namespace Pengeplan.Core
{
	[TestFixture ()]
	public class TestJerseyApi
	{
		[Test ()]
		public async void  TestAuthenticate ()
		{
			String userName = "tommy1";
			String userPassword = "1q2w3e4R";
//			AuthResponse response = await PengeplanApi.authenticate (userName, userPassword);
//			Assert.AreEqual (true, response.authorized);

		}

		[Test ()]
		public void TestGetItems ()
		{
			String userName = "tommy1";
			String userPassword = "1q2w3e4R";

//			Assert.AreEqual (7, PengeplanApi.getItems (userName, userPassword).Count);

		}
	}
}

