using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Marmify.Domain.DTO
{
	public class EstablishmentDTO
	{
		[JsonProperty(PropertyName = "id", Required = Required.Default)]
		public long? Id { get; set; }

		[JsonProperty(PropertyName = "corporatename", Required = Required.Always)]
		public string CorporateName { get; set; }

		[JsonProperty(PropertyName = "cnpj", Required = Required.Always)]
		public string Cnpj { get; set; }

		[JsonProperty(PropertyName = "companyname", Required = Required.Always)]
		public string CompanyName { get; set; }

		[JsonProperty(PropertyName = "email", Required = Required.Always)]
		public string Email { get; set; }

		[JsonProperty(PropertyName = "phone", Required = Required.Always)]
		public string Phone { get; set; }

		[JsonProperty(PropertyName = "address", Required = Required.Always)]
		public string Address { get; set; }

		[JsonProperty(PropertyName = "number", Required = Required.Always)]
		public int Number { get; set; }

		[JsonProperty(PropertyName = "neighborhood", Required = Required.Always)]
		public string Neighborhood { get; set; }

		[JsonProperty(PropertyName = "ispartner", Required = Required.AllowNull)]
		public bool ispartner { get; set; }
	}
}
