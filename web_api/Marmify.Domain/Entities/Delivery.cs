using System;

namespace Marmify.Domain.Entities
{
	public class Delivery : BaseEntity
	{
		public long EstablishmentId { get; set; }

		public DateTime DeliveryDate { get; set; }

		public string Status { get; set; }

		public int TotalDeliveryTime { get; set; }

		public virtual Establishment Establishment { get; set; }

		public virtual PurchaseOrder PurchaseOrder { get; set; }
	}
}
