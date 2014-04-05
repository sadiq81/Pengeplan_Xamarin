using System;
using SQLite;

namespace Pengeplan.Core
{
	public class Transaction : BaseEntity
	{
		public Transaction ()
		{
	
		}

		public Transaction (long id, TransactionType transactionType, DateTime date, string paperName, string stockExchange, string currency, decimal numberOfItems, decimal valuation, decimal amount, string legalEntity, string ownedAccount, decimal localAmount)
		{
			this.id = id;
			this.transactionType = transactionType;
			this.date = date;
			this.paperName = paperName;
			this.stockExchange = stockExchange;
			this.currency = currency;
			this.numberOfItems = numberOfItems;
			this.valuation = valuation;
			this.amount = amount;
			this.legalEntity = legalEntity;
			this.ownedAccount = ownedAccount;
			this.localAmount = localAmount;
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

