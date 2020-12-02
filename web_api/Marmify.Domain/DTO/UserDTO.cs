using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Marmify.Domain.DTO
{
    public class UserResponseDTO
    {
        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        public long Id { get; set; }

        [JsonProperty(PropertyName = "username", Required = Required.Always)]
        public string UserName { get; set; }

        [JsonProperty(PropertyName = "email", Required = Required.Always)]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "phonenumber", Required = Required.AllowNull)]
        public string PhoneNumber { get; set; }

        [JsonProperty(PropertyName = "cellphone", Required = Required.AllowNull)]
        public string CellPhone { get; set; }

        [JsonProperty(PropertyName = "fullname", Required = Required.Always)]
        public string FullName { get; set; }

        [JsonProperty(PropertyName = "cpf", Required = Required.AllowNull)]
        public string Cpf { get; set; }

        [JsonProperty(PropertyName = "datebirth", Required = Required.Always)]
        public DateTime DateBirth { get; set; }

        [JsonProperty(PropertyName = "password", Required = Required.AllowNull)]
        public string Password { get; set; }

        [JsonProperty(PropertyName = "establishmentid", Required = Required.Always)]
        public long EstablishmentId { get; set; }

        [JsonProperty(PropertyName = "addresses", Required = Required.AllowNull)]
        public IEnumerable<AddressDTO> Addresses { get; set; }
    }

    public class UserResquestDTO
    {
        [JsonProperty(PropertyName = "id", Required = Required.Default)]
        public long Id { get; set; }

        [JsonProperty(PropertyName = "username", Required = Required.Always)]
        public string UserName { get; set; }

        [JsonProperty(PropertyName = "email", Required = Required.Always)]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "phonenumber", Required = Required.AllowNull)]
        public string PhoneNumber { get; set; }

        [JsonProperty(PropertyName = "cellphone", Required = Required.Always)]
        public string CellPhone { get; set; }

        [JsonProperty(PropertyName = "fullname", Required = Required.Always)]
        public string FullName { get; set; }

        [JsonProperty(PropertyName = "cpf", Required = Required.Always)]
        public string Cpf { get; set; }

        [JsonProperty(PropertyName = "datebirth", Required = Required.Always)]
        public DateTime DateBirth { get; set; }

        [JsonProperty(PropertyName = "password", Required = Required.Always)]
        public string Password { get; set; }

        [JsonProperty(PropertyName = "establishmentid", Required = Required.Always)]
        public long EstablishmentId { get; set; }

        [JsonProperty(PropertyName = "role", Required = Required.Always)]
        public long Role { get; set; }

        [JsonProperty(PropertyName = "addresses", Required = Required.Default)]
        public IEnumerable<AddressDTO> Addresses { get; set; }
    }

    public class UserUpdateDTO
    {
        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        public long Id { get; set; }

        [JsonProperty(PropertyName = "email", Required = Required.Default)]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "phonenumber", Required = Required.Default)]
        public string PhoneNumber { get; set; }

        [JsonProperty(PropertyName = "cellphone", Required = Required.Default)]
        public string CellPhone { get; set; }

        [JsonProperty(PropertyName = "fullname", Required = Required.Default)]
        public string FullName { get; set; }

        [JsonProperty(PropertyName = "establishmentid", Required = Required.Default)]
        public long EstablishmentId { get; set; }

        [JsonProperty(PropertyName = "role", Required = Required.Always)]
        public long Role { get; set; }
    }
}
