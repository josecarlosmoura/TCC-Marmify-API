using Newtonsoft.Json;

namespace Marmify.Domain.DTO
{
	public class UserFavoritesDTO
	{
		[JsonProperty(PropertyName = "userid", Required = Required.Always)]
		public long UserId { get; set; }

		[JsonProperty(PropertyName = "establishmentid", Required = Required.Always)]
		public long Establishmentid { get; set; }

		[JsonProperty(PropertyName = "establishment", Required = Required.Always)]
		public EstablishmentDTO Establishment { get; set; }
	}
}
