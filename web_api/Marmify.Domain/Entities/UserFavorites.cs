using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Marmify.Domain.Entities
{
	public class UserFavorites : BaseEntity
	{
		public long UserId { get; set; }

		public virtual User User { get; set; }

		public long EstablishmentId { get; set; }

		public virtual Establishment Establishment { get; set; }
	}
}
