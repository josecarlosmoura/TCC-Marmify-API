using Marmify.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Marmify.Infraestructure.Data.Context.Configuration
{
	// Configure Table PaymentCondition
	public static class PaymentConditionConfig
	{
		public static void ConfigurationPaymentCondition(ModelBuilder builder)
		{
			builder.Entity<PaymentCondition>().HasKey(x => x.Id);

			builder.Entity<PaymentCondition>()
					.ToTable("payment_condition");

			builder.Entity<PaymentCondition>().Property(x => x.Id)
					.HasColumnName("id");
			builder.Entity<PaymentCondition>().Property(x => x.EstablishmentId)
								.HasColumnName("establishment_id");
			builder.Entity<PaymentCondition>().Property(x => x.Description)
					.HasColumnName("description")
					.HasMaxLength(100);
		}
	}
}
