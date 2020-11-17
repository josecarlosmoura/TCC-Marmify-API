using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Marmify.Domain.Entities
{
    public class ItemPurchase : BaseEntity
    {
        public long ItemId { get; set; }

        public long PurchaseOrderId { get; set; }
        
        public string ItemName { get; set; }

        public decimal ItemValue { get; set; }

        public int ItemQuantity { get; set; }

        public virtual Item Item { get; set; }

        public virtual PurchaseOrder PurchaseOrder { get; set; }
    }
}
