using System;
using SQLite;

namespace Pengeplan.Core
{
	[Table (TABLENAME)]
	public class Transaction : BaseEntity
	{
		public const string TABLENAME = "Transaction";
		public const string ID = "Id";
		public const string TRANSACTION_TYPE = "TransactionType";
		public const string DATE = "Date";
		public const string PAPER_NAME = "PaperName";
		public const string STOCK_EXCHANGE = "StockExchange";
		public const string CURRENCY = "Currency";
		public const string NUMBER_OF_ITEMS = "NumberOfItems";
		public const string VALUATION = "Valuation";
		public const string AMOUNT = "Amount";
		public const string LEGAL_ENTITY = "LegalEntity";
		public const string OWNED_ACCOUNT = "OwnedAccount";
		public const string LOCAL_AMOUNT = "LocalAmount";

		public Transaction ()
		{
		}

		[PrimaryKey]
		[Column (ID)] 
		public long id { get; set; }

		[Column (TRANSACTION_TYPE)] 
		public TransactionType transactionType { get; set; }

		[Column (DATE)] 
		public DateTime date { get; set; }

		[Column (PAPER_NAME)] 
		public String paperName { get; set; }

		[Column (STOCK_EXCHANGE)] 
		public String stockExchange { get; set; }

		[Column (CURRENCY)] 
		public String currency { get; set; }

		[Column (NUMBER_OF_ITEMS)] 
		public decimal numberOfItems { get; set; }

		[Column (VALUATION)] 
		public decimal valuation { get; set; }

		[Column (AMOUNT)] 
		public decimal amount { get; set; }

		[Column (LEGAL_ENTITY)] 
		public string legalEntity { get; set; }

		[Column (OWNED_ACCOUNT)] 
		public string ownedAccount { get; set; }

		[Column (LOCAL_AMOUNT)] 
		public decimal localAmount { get; set; }

		public string getTableName ()
		{
			return TABLENAME;
		}
	}
}

