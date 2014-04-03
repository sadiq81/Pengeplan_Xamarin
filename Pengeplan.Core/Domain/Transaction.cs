using System;
using SQLite;

namespace Pengeplan.Core
{
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

		public string legalEntity { get; set; }

		public string ownedAccount { get; set; }

		public decimal localAmount { get; set; }

		public override bool Equals (object obj)
		{
			if (!typeof(Transaction).Equals (obj.GetType ()))
				return false;

			return this.id == ((Transaction)obj).id;
		}
	}
}

