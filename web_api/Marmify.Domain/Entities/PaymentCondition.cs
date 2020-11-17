using Marmify.Domain.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Marmify.Domain.Entities
{
    public class PaymentCondition : BaseEntity
    {
        public long EstablishmentId { get; set; }

        public string Description { get; set; }

        public virtual Establishment Establishment { get; set; }

        public virtual IEnumerable<PurchaseOrder> PurchaseOrders { get; set; }
    }
}
