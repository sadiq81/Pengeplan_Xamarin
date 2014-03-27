using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Pengeplan.Core
{
	[TestFixture ()]
	public class NUnitTestClass
	{
		[SetUp ()]
		public void setUp ()
		{
			Transaction ta = new Transaction ();
			ta.id = 0;
			ta.transactionType = TransactionType.BUY;
			ta.date = new DateTime ();
			ta.paperName = "AMAZON";
			ta.stockExchange = "OMX_COPENHAGEN";
			ta.currency = "DKK";
			ta.numberOfItems = 1;
			ta.valuation = 1000;
			ta.amount = 1000;

			Assert.AreEqual (1, DataManager.SaveTransaction (ta));			
		}

		[TearDown ()]
		public void tearDown ()
		{
			DataManager.DeleteTransactions ();
		}

		[Test ()]
		public void TestCase ()
		{
			IEnumerable<Transaction> list = DataManager.GetTransactions ();
			List<Transaction> list2 = new List<Transaction> (list);
			Assert.AreEqual (1, list2.Count);
		}
	}
}

