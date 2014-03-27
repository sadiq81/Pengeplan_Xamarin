using NUnit.Framework;
using System;

namespace Pengeplan.Core
{
	[TestFixture ()]
	public class TestJerseyApi
	{
		[Test ()]
		public void TestAuthenticate ()
		{
			String userName = "tommy1";
			String userPassword = "1q2w3e4R";

			Assert.AreEqual (true, PengeplanApi.authenticate (userName, userPassword).authorized);

		}

		[Test ()]
		public void TestGetItems ()
		{
			String userName = "tommy1";
			String userPassword = "1q2w3e4R";

			Assert.AreEqual (7, PengeplanApi.getItems (userName, userPassword).Count);

		}
	}
}

