using Marmify.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Marmify.Infraestructure.Data.Context.Configuration
{
	// Configure Table PurchaseOrder
	public static class PurchaseOrderConfig
	{
		public static void ConfigurationPurchaseOrder(ModelBuilder builder)
		{
			builder.Entity<PurchaseOrder>().HasKey(x => x.Id);

			builder.Entity<PurchaseOrder>()
					.HasOne(x => x.PaymentCondition)
					.WithMany(x => x.PurchaseOrders)
					.IsRequired()
					.OnDelete(DeleteBehavior.Restrict);

			builder.Entity<PurchaseOrder>()
					.HasOne(x => x.Establishment)
					.WithMany(x => x.PurchaseOrders)
					.IsRequired()
					.OnDelete(DeleteBehavior.Restrict);
			builder.Entity<PurchaseOrder>()
					.HasOne(x => x.User)
					.WithMany(x => x.PurchaseOrders)
					.IsRequired()
					.OnDelete(DeleteBehavior.Restrict);

			builder.Entity<PurchaseOrder>()
					.HasOne(x => x.Delivery)
					.WithOne(x => x.PurchaseOrder)
					.IsRequired()
					.OnDelete(DeleteBehavior.Restrict);

			builder.Entity<PurchaseOrder>()
					.HasOne(x => x.DeliveryType)
					.WithMany(x => x.PurchaseOrder)
					.IsRequired()
					.OnDelete(DeleteBehavior.Restrict);

			builder.Entity<PurchaseOrder>()
					.ToTable("purchase_order");

			builder.Entity<PurchaseOrder>().Property(x => x.Id)
				 .HasColumnName("id");
			builder.Entity<PurchaseOrder>().Property(x => x.UserId)
					.HasColumnName("user_id");
			builder.Entity<PurchaseOrder>().Property(x => x.PaymentConditionId)
					.HasColumnName("payment_condition_id");
			builder.Entity<PurchaseOrder>().Property(x => x.EstablishmentId)
					.HasColumnName("establishment_id");
			builder.Entity<PurchaseOrder>().Property(x => x.DeliveryId)
				.HasColumnName("delivery_id");
			builder.Entity<PurchaseOrder>().Property(x => x.DeliveryTypeId)
				.HasColumnName("delivery_type_id");

			builder.Entity<PurchaseOrder>().Property(x => x.DatePurchase)
					.HasColumnName("date_purchase");
			builder.Entity<PurchaseOrder>().Property(x => x.Amount)
					.HasColumnName("amount");
			builder.Entity<PurchaseOrder>().Property(x => x.Status)
					.HasColumnName("status")
					.HasMaxLength(50);
		}
	}
}
