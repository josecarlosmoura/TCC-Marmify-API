using Marmify.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;

namespace Marmify.Infraestructure.Data.Context.Configuration
{
    // Configure Table User
    public static class UserConfig
    {
        public static void ConfigurationUser(ModelBuilder builder)
        {
            builder.Entity<User>().HasKey(x => x.Id);

            builder.Entity<User>()
                .HasOne(x => x.Establishment)
                .WithMany(x => x.Users)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
            builder.Entity<User>()
                .HasMany(x => x.PurchaseOrders)
                .WithOne(x => x.User)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<User>()
                .HasMany(x => x.Addresses)
                .WithOne(x => x.User)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.Entity<User>()
                .ToTable("user");

            builder.Entity<User>().Property(x => x.Id)
                .HasColumnName("id");
            builder.Entity<User>().Property(x => x.UserName)
                .HasColumnName("user_name")
                .HasMaxLength(100);
            builder.Entity<User>().Property(x => x.FullName)
                .HasColumnName("full_name")
                .HasMaxLength(100);
            builder.Entity<User>().Property(x => x.Cpf)
                .HasColumnName("cpf")
                .HasMaxLength(14);
            builder.Entity<User>().Property(x => x.DateBirth)
                .HasColumnName("date_birth");
            builder.Entity<User>().Property(x => x.Email)
                .HasColumnName("email")
                .HasMaxLength(100);
            builder.Entity<User>().Property(x => x.PhoneNumber)
                .HasColumnName("phone_number")
                .HasMaxLength(20);
            builder.Entity<User>().Property(x => x.CellPhone)
                .HasColumnName("cell_phone")
                .HasMaxLength(20);
            builder.Entity<User>().Property(x => x.EstablishmentId)
                .HasColumnName("establishment_id");
            builder.Entity<User>().Property(x => x.AccessFailedCount)
                .HasColumnName("access_failed_count");
            builder.Entity<User>().Property(x => x.ConcurrencyStamp).
                HasColumnName("concurrency_stamp");
            builder.Entity<User>().Property(x => x.EmailConfirmed)
                .HasColumnName("email_confirmed")
                .HasConversion(new BoolToZeroOneConverter<Int16>());
            builder.Entity<User>().Property(x => x.LockoutEnabled)
                .HasColumnName("lockout_enabled")
                .HasConversion(new BoolToZeroOneConverter<Int16>());
            builder.Entity<User>().Property(x => x.LockoutEnd)
                .HasColumnName("lockout_end");
            builder.Entity<User>().Property(x => x.NormalizedEmail)
                .HasColumnName("normalized_email");
            builder.Entity<User>().Property(x => x.NormalizedUserName)
                .HasColumnName("normalized_user_name");
            builder.Entity<User>().Property(x => x.PasswordHash)
                .HasColumnName("password_hash");
            builder.Entity<User>().Property(x => x.PhoneNumberConfirmed)
                .HasColumnName("phone_number_confirmed")
                .HasConversion(new BoolToZeroOneConverter<Int16>());
            builder.Entity<User>().Property(x => x.SecurityStamp)
                .HasColumnName("security_stamp");
            builder.Entity<User>().Property(x => x.TwoFactorEnabled)
                .HasColumnName("two_factor_enabled")
                .HasConversion(new BoolToZeroOneConverter<Int16>());
        }
    }
}
