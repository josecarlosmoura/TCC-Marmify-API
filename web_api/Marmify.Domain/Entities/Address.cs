namespace Marmify.Domain.Entities
{
    public class Address : BaseEntity
    { 
        public string Street { get; set; }

        public int Number { get; set; }

        public string Neighborhood { get; set; }

        public string PostalCode { get; set; }

        public long UserId { get; set; }

        public virtual User User { get; set; }
    }
}
