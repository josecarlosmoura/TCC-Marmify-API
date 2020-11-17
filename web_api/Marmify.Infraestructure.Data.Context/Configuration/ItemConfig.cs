using Marmify.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Marmify.Infraestructure.Data.Context.Configuration
{
	// Configuration Table Item
	public static class ItemConfig
	{
		public static void ConfigurationItem(ModelBuilder builder)
		{
			builder.Entity<Item>().HasKey(x => x.Id);

			builder.Entity<Item>()
					.HasOne(x => x.Establishment)
					.WithMany(x => x.Itens)
					.IsRequired()
					.OnDelete(DeleteBehavior.Restrict);

			builder.Entity<Item>()
					.ToTable("item");

			builder.Entity<Item>().Property(x => x.Id)
					.HasColumnName("id");
			builder.Entity<Item>().Property(x => x.EstablishmentId)
					.HasColumnName("establishment_id");
			builder.Entity<Item>().Property(x => x.Name)
					.HasColumnName("name")
					.HasMaxLength(50);
			builder.Entity<Item>().Property(x => x.Description)
					.HasColumnName("description");
			builder.Entity<Item>().Property(x => x.Value)
					.HasColumnName("value");
			builder.Entity<Item>().Property(x => x.Available)
					.HasColumnName("available");
			builder.Entity<Item>().Property(x => x.ImagePath)
					.HasColumnName("image_path");
			builder.Entity<Item>().Property(x => x.PreparationTime)
				.HasColumnName("preparation_time");
		}
	}
}
