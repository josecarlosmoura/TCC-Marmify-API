using Marmify.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Marmify.Infraestructure.Data.Context.Configuration
{
	public static class DeliveryTypeConfig
	{
		public static void ConfigurationDeliveryType(ModelBuilder builder)
		{
			builder.Entity<DeliveryType>().HasKey(x => x.Id);

			builder.Entity<DeliveryType>()
				.HasOne(x => x.Establishment)
				.WithMany(x => x.DeliveryTypes)
				.IsRequired()
				.OnDelete(DeleteBehavior.Restrict);

			//builder.Entity<PurchaseOrder>()
			//	.HasOne(x => x.DeliveryType)
			//	.WithMany(x => x.PurchaseOrder)
			//	.IsRequired()
			//	.OnDelete(DeleteBehavior.Restrict);

			builder.Entity<DeliveryType>().ToTable("delivery_type");

			builder.Entity<DeliveryType>().Property(x => x.Id)
				.HasColumnName("id");
			builder.Entity<DeliveryType>().Property(x => x.EstablishmentId)
				.HasColumnName("establishment_id");
			builder.Entity<DeliveryType>().Property(x => x.Description)
				.HasColumnName("description")
				.HasMaxLength(50);
		}
	}
}
