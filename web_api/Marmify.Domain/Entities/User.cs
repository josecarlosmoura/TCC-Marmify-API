using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Marmify.Domain.Entities
{
    public class User : IdentityUser<long>
    {
        public User()
        {
            this.Addresses = new List<Address>();
        }

        public string FullName { get; set; }

        public string Cpf { get; set; }

        public DateTime DateBirth { get; set; }

        public string CellPhone { get; set; }

        public long EstablishmentId { get; set; }

        public virtual Establishment Establishment { get; set; }

        public virtual IEnumerable<PurchaseOrder> PurchaseOrders { get; set; }
        public virtual IEnumerable<Address> Addresses { get; set; }
        public virtual IEnumerable<UserFavorites> UserFavorites { get; set; }
    }
}
