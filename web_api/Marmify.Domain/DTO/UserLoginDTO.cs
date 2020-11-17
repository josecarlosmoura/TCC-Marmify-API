using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Marmify.Domain.DTO
{
    public class UserLoginRequestDTO
    {
        [JsonProperty(PropertyName = "email", Required = Required.Always)]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "password", Required = Required.Always)]
        public string Password { get; set; }

        [JsonProperty(PropertyName = "role", Required = Required.Always)]
        public string Role { get; set; }
    }

    public class UserLoginResponseDTO
    {
        [JsonProperty(PropertyName = "user")]
        public UserResponseDTO User { get; set; }

        [JsonProperty(PropertyName = "creationdate")]
        public DateTime CreationDate { get; set; }

        [JsonProperty(PropertyName = "expirationdate")]
        public DateTime ExpirationDate { get; set; }

        [JsonProperty(PropertyName = "token")]
        public string Token { get; set; }

    }
}
