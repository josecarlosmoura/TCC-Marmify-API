using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Marmify.Application.Utils
{
    public class CurrentUser
    {
        ClaimsPrincipal User { get; set; }
        public long Id { get; set; }
        public long EstablishmentId { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }

        public CurrentUser(ClaimsPrincipal user)
        {
            this.User = user;
            this.Id = long.Parse(this.User.Claims.Where(x => x.Type.Equals("Id")).FirstOrDefault().Value.ToString());
            this.EstablishmentId = long.Parse(this.User.Claims.Where(x => x.Type.Equals("EstablishmentId")).FirstOrDefault().Value.ToString());
            this.UserName = this.User.Claims.Where(x => x.Type.Equals("UserName")).FirstOrDefault().Value.ToString();
            this.Role = user.Claims.Where(x => x.Type.Equals("http://schemas.microsoft.com/ws/2008/06/identity/claims/role")).FirstOrDefault().Value.ToString();
        }
    }
}
