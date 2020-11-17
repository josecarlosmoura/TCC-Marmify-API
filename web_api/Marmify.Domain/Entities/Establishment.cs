using Marmify.Domain.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marmify.Domain.Entities
{
	public class Establishment : BaseEntity
	{
		public string CorporateName { get; set; }

		public string Cnpj { get; set; }

		public string CompanyName { get; set; }

		public string Email { get; set; }

		public string Phone { get; set; }

		public string Address { get; set; }

		public int Number { get; set; }

		public string Neighborhood { get; set; }

		public bool IsPartner { get; set; }

		public virtual IEnumerable<User> Users { get; set; }

		public virtual IEnumerable<Item> Itens { get; set; }

		public virtual IEnumerable<PurchaseOrder> PurchaseOrders { get; set; }

		public virtual IEnumerable<UserFavorites> UserFavorites { get; set; }

		public virtual IEnumerable<Delivery> Deliveries { get; set; }

		public virtual IEnumerable<DeliveryType> DeliveryTypes { get; set; }
	}
}
