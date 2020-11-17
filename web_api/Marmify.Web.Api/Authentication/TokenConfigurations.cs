using System.Collections.Generic;

namespace Marmify.Web.Api.Authentication
{
    public class TokenConfigurations
    {
        public IEnumerable<string> Audience { get; set; }
        public IEnumerable<string> Issuer { get; set; }
        public int Seconds { get; set; }
    }
}
