using Marmify.Domain.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Text;

namespace Marmify.Domain.Entities
{
    public class PurchaseOrder : BaseEntity
    {
        public long UserId { get; set; }

        public long EstablishmentId { get; set; }

        public long PaymentConditionId { get; set; }

        public long DeliveryTypeId { get; set; }

        public long DeliveryId { get; set; }

        public DateTime DatePurchase { get; set; }

        public decimal Amount { get; set; }

        public string Status { get; set; }

        public virtual User User { get; set; }

        public virtual Establishment Establishment { get; set; }

        public virtual PaymentCondition PaymentCondition { get; set; }

        public virtual DeliveryType DeliveryType { get; set; }
        
        public virtual Delivery Delivery { get; set; }

        public virtual IEnumerable<ItemPurchase> ItemPurchases { get; set; }
    }
}
