using Newtonsoft.Json;

namespace Marmify.Domain.DTO
{
	public class ItemDTO
	{
		[JsonProperty(PropertyName = "id", Required = Required.Default)]
		public long Id { get; set; }

		[JsonProperty(PropertyName = "name", Required = Required.Always)]
		public string Name { get; set; }

		[JsonProperty(PropertyName = "description", Required = Required.Always)]
		public string Description { get; set; }

		[JsonProperty(PropertyName = "value", Required = Required.Always)]
		public decimal Value { get; set; }

		[JsonProperty(PropertyName = "available", Required = Required.Always)]
		public bool Available { get; set; }

		[JsonProperty(PropertyName = "imagepath", Required = Required.Always)]
		public string ImagePath { get; set; }

		[JsonProperty(PropertyName = "establishmentid", Required = Required.Always)]
		public long EstablishmentId { get; set; }
	}
}
