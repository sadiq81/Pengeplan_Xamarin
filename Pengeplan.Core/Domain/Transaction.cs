using System;
using SQLite;

namespace Pengeplan.Core
{
	[Table ("Transaction")]
	public class Transaction : BaseEntity
	{
		public Transaction ()
		{
		}

		[PrimaryKey]
		public long id { get; set; }

		public TransactionType transactionType { get; set; }

		public DateTime date { get; set; }

		public String paperName { get; set; }

		public String stockExchange { get; set; }

		public String currency { get; set; }

		public decimal numberOfItems { get; set; }

		public decimal valuation { get; set; }

		public decimal amount { get; set; }
	}
}

