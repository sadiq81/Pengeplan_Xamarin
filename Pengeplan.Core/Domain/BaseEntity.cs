using System;

namespace Pengeplan.Core
{
	public interface BaseEntity
	{
		long id { get; set; }

		bool Equals (object obj);
	}
}

