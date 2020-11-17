using Newtonsoft.Json;

namespace Marmify.Domain.DTO
{
	public class PaymentConditionDTO
	{
		[JsonProperty(PropertyName = "id", Required = Required.Default)]
		public long? Id { get; set; }

		[JsonProperty(PropertyName = "description", Required = Required.Always)]
		public string Description { get; set; }

		[JsonProperty(PropertyName = "establishmentid", Required = Required.Always)]
		public long EstablishmentId { get; set; }
	}
}
