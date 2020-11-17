using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Marmify.Domain.DTO
{
    public class ItemPurchaseDTO
    {
        [JsonProperty(PropertyName = "itemId", Required = Required.Always)]
        public long ItemId { get; set; }

        [JsonProperty(PropertyName = "purchaseorderid", Required = Required.Default)]
        public long PurchaseOrderId { get; set; }

        [JsonProperty(PropertyName = "itemname", Required = Required.Always)]
        public string ItemName { get; set; }

        [JsonProperty(PropertyName = "itemvalue", Required = Required.Always)]
        public decimal ItemValue { get; set; }

        [JsonProperty(PropertyName = "itemquantity", Required = Required.Always)]
        public int ItemQuantity { get; set; }
    }
}
