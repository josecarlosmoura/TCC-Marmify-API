using System.Collections.Generic;

namespace Marmify.Domain.Entities
{
	public class DeliveryType : BaseEntity
	{
		public long EstablishmentId { get; set; }

		public string Description { get; set; }

		public double DeliveryValue { get; set; }

		public virtual Establishment Establishment { get; set; }

		public virtual IEnumerable<PurchaseOrder> PurchaseOrder { get; set; }
	}
}