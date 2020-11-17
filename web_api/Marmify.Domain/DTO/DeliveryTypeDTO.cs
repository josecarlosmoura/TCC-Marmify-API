using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Marmify.Domain.DTO
{
	public class DeliveryTypeDTO
	{
		[JsonProperty(PropertyName = "id", Required = Required.Default)]
		public long Id { get; set; }

		[JsonProperty(PropertyName = "establishmentid", Required = Required.Always)]
		public long EstablishmentId { get; set; }

		[JsonProperty(PropertyName = "description", Required = Required.Always)]
		public string Description { get; set; }

		[JsonProperty(PropertyName = "deliveryvalue", Required = Required.Always)]
		public double DeliveryValue { get; set; }
	}
}
