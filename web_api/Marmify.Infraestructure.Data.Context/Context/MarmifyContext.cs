using Marmify.Domain.Entities;
using Marmify.Infraestructure.Data.Context.Configuration;
using Marmify.Infraestructure.Data.Context.Configuration.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using System;

namespace Marmify.Infraestructure.Data.Context.Context
{
	public class MarmifyContext : IdentityDbContext<User, ApplicationRole, long, IdentityUserClaim<long>
			, IdentityUserRole<long>, IdentityUserLogin<long>, IdentityRoleClaim<long>, IdentityUserToken<long>>
	{
		private string StrConnection { get; }

		public MarmifyContext(DbContextOptions<MarmifyContext> options)
				: base(options)
		{
			this.StrConnection = GetConnectionString();
		}

		private string GetConnectionString()
		{
			var builder = new ConfigurationBuilder()
					.SetBasePath(AppContext.BaseDirectory)
					.AddJsonFile("appsettings.json")
					.AddEnvironmentVariables();

			var config = builder.Build();

			string ret = config.GetConnectionString("BaseIdentity");

			if (string.IsNullOrEmpty(ret))
			{
				return null;
			}

			return ret;
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseLazyLoadingProxies();
				optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(CoreEventId.LazyLoadOnDisposedContextWarning));
				optionsBuilder.UseSqlServer(StrConnection);
			}
		}

		public DbSet<Address> Addresses { get; set; }
		public DbSet<Establishment> Establishments { get; set; }
		public DbSet<PaymentCondition> PaymentConditions { get; set; }
		public DbSet<Item> Items { get; set; }
		public DbSet<ItemPurchase> ItemPurchases { get; set; }
		public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
		public DbSet<User> User { get; set; }
		public DbSet<UserFavorites> UserFavorites { get; set; }
		public DbSet<Delivery> Deliveries { get; set; }
		public DbSet<DeliveryType> DeliveryTypes { get; set; }


		public DbSet<UserRole> UserRole { get; set; }
		public DbSet<ApplicationRole> ApplicationRoles { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			// Configuration of the Identity Class
			IdentityUserRoleConfig.ConfigurationIdentityUserRole(builder);
			IdentityUserClaimConfig.ConfigurationIdentityUserClaim(builder);
			IdentityRoleClaimConfig.ConfigurationIdentityRoleClaim(builder);
			IdentityUserTokenConfig.ConfigurationIdentityUserToken(builder);
			IdentityUserLoginConfig.ConfigurationIdentityUserLogin(builder);

			// Configuration of the Marmify Class
			UserConfig.ConfigurationUser(builder);
			ItemConfig.ConfigurationItem(builder);
			PaymentConditionConfig.ConfigurationPaymentCondition(builder);
			PurchaseOrderConfig.ConfigurationPurchaseOrder(builder);
			EstablishmentConfig.ConfigurationEstablishment(builder);
			ItemPurchaseConfig.ConfigurationItemPurchase(builder);
			UserFavoritesConfig.ConfigurationUserFavorites(builder);
			AddressConfig.ConfigurationAddress(builder);
			DeliveryConfig.ConfigurationDelivery(builder);
			DeliveryTypeConfig.ConfigurationDeliveryType(builder);

			ApplicationRoleConfig.ConfigurationApplicationRole(builder);
			//UserRoleConfig.ConfigurationUserRole(builder);

			// Do not change
			builder.Entity<Establishment>()
					.HasData(
							new Establishment
							{
								Id = 1,
								CorporateName = "Administration",
								Cnpj = "N/A",
								CompanyName = "Administration",
								Email = "N/A",
								Phone = "N/A",
								Address = "N/A",
								Number = 0,
								Neighborhood = "N/A",
								IsPartner = false
							},
							new Establishment
							{
								Id = 2,
								CorporateName = "User",
								Cnpj = "N/A",
								CompanyName = "User",
								Email = "N/A",
								Phone = "N/A",
								Address = "N/A",
								Number = 0,
								Neighborhood = "N/A",
								IsPartner = false
							});
		}
	}
}
