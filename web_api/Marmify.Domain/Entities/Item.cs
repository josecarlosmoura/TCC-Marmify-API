using Marmify.Domain.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Marmify.Domain.Entities
{
	public class Item : BaseEntity
	{
		public long EstablishmentId { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public decimal Value { get; set; }

		public bool Available { get; set; }

		public string ImagePath { get; set; }

		public int PreparationTime { get; set; }

		public virtual Establishment Establishment { get; set; }

		public virtual IEnumerable<ItemPurchase> ItemPurchases { get; set; }
	}
}
