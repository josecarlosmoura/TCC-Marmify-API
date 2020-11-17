using Newtonsoft.Json;
using System;

namespace Marmify.Domain.DTO
{
	public class DeliveryDTO
	{
		[JsonProperty(PropertyName = "id", Required = Required.Default)]
		public long Id { get; set; }

		[JsonProperty(PropertyName = "establishmentid", Required = Required.Default)]
		public long EstablishmentId { get; set; }

		[JsonProperty(PropertyName = "deliverydate", Required = Required.Default)]
		public DateTime DeliveryDate { get; set; }

		[JsonProperty(PropertyName = "status", Required = Required.Always)]
		public string Status { get; set; }

		[JsonProperty(PropertyName = "totaldeliverytime", Required = Required.Default)]
		public decimal TotalDeliveryTime { get; set; }
	}
}
