using Newtonsoft.Json;

namespace Marmify.Domain.DTO
{
	public class AddressDTO
	{
		[JsonProperty(PropertyName = "id", Required = Required.Default)]
		public long Id { get; set; }

		[JsonProperty(PropertyName = "street", Required = Required.Always)]
		public string Street { get; set; }

		[JsonProperty(PropertyName = "number", Required = Required.Always)]
		public int Number { get; set; }

		[JsonProperty(PropertyName = "neighborhood", Required = Required.Always)]
		public string Neighborhood { get; set; }

		[JsonProperty(PropertyName = "postalcode", Required = Required.Always)]
		public string PostalCode { get; set; }
	}
}
