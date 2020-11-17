using Marmify.Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Marmify.Domain.DTO
{
	public class PurchaseOrderDTO
	{
		[JsonProperty(PropertyName = "id", Required = Required.Default)]
		public long Id { get; set; }

		[JsonProperty(PropertyName = "userid", Required = Required.Always)]
		public long UserId { get; set; }

		[JsonProperty(PropertyName = "establishmentid", Required = Required.Always)]
		public long EstablishmentId { get; set; }

		[JsonProperty(PropertyName = "paymentconditionid", Required = Required.Always)]
		public long PaymentConditionId { get; set; }

		[JsonProperty(PropertyName = "deliverytypeid", Required = Required.Always)]
		public long DeliveryTypeId { get; set; }

		[JsonProperty(PropertyName = "deliveryid", Required = Required.Default)]
		public long DeliveryId { get; set; }

		[JsonProperty(PropertyName = "datepurchase", Required = Required.Default)]
		public DateTime DatePurchase { get; set; }

		[JsonProperty(PropertyName = "amount", Required = Required.Default)]
		public decimal Amount { get; set; }

		[JsonProperty(PropertyName = "status", Required = Required.Default)]
		public string Status { get; set; }

		[JsonProperty(PropertyName = "itenspurchase", Required = Required.Always)]
		public virtual IEnumerable<ItemPurchaseDTO> ItemPurchases { get; set; }
	}
}
