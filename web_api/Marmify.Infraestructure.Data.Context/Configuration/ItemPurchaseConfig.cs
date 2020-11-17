using Marmify.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Marmify.Infraestructure.Data.Context.Configuration
{
    // Configure Table ItemPurchase
    public static class ItemPurchaseConfig
    {
        public static void ConfigurationItemPurchase(ModelBuilder builder)
        {
            builder.Entity<ItemPurchase>().HasKey(x => x.Id);

            builder.Entity<ItemPurchase>()
                .ToTable("item_purchase");

            builder.Entity<ItemPurchase>().Property(x => x.Id)
                   .HasColumnName("id");
            builder.Entity<ItemPurchase>().Property(x => x.ItemId)
                .HasColumnName("item_id");
            builder.Entity<ItemPurchase>().Property(x => x.PurchaseOrderId)
                .HasColumnName("purchase_order_id");
            builder.Entity<ItemPurchase>().Property(x => x.ItemName)
                .HasColumnName("item_name")
                .HasMaxLength(50);
            builder.Entity<ItemPurchase>().Property(x => x.ItemValue)
                .HasColumnName("item_value");
            builder.Entity<ItemPurchase>().Property(x=> x.ItemQuantity)
                .HasColumnName("item_quantity");
        }
    }
}
