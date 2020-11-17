using Marmify.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Marmify.Infraestructure.Data.Context.Configuration
{
	public static class DeliveryConfig
	{
		public static void ConfigurationDelivery(ModelBuilder builder)
		{
			builder.Entity<Delivery>().HasKey(x => x.Id);

			builder.Entity<Delivery>()
				.HasOne(x => x.Establishment)
				.WithMany(x => x.Deliveries)
				.IsRequired()
				.OnDelete(DeleteBehavior.Restrict);

			builder.Entity<Delivery>().ToTable("delivery");

			builder.Entity<Delivery>().Property(x => x.Id)
				.HasColumnName("id");
			builder.Entity<Delivery>().Property(x => x.EstablishmentId)
				.HasColumnName("establishment_id");
			builder.Entity<Delivery>().Property(x => x.DeliveryDate)
				.HasColumnName("delivery_date");
			builder.Entity<Delivery>().Property(x => x.Status)
				.HasColumnName("status")
				.HasMaxLength(50);
			builder.Entity<Delivery>().Property(x => x.TotalDeliveryTime)
				.HasColumnName("total_delivery_time");
		}
	}
}
