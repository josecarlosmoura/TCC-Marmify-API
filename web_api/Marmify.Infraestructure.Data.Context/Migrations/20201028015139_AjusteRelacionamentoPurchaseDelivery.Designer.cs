﻿// <auto-generated />
using System;
using Marmify.Infraestructure.Data.Context.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Marmify.Infraestructure.Data.Context.Migrations
{
    [DbContext(typeof(MarmifyContext))]
    [Migration("20201028015139_AjusteRelacionamentoPurchaseDelivery")]
    partial class AjusteRelacionamentoPurchaseDelivery
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Marmify.Domain.Entities.Address", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Neighborhood")
                        .HasColumnName("neighborhood")
                        .HasMaxLength(50);

                    b.Property<int>("Number")
                        .HasColumnName("number");

                    b.Property<string>("PostalCode")
                        .HasColumnName("postal_code")
                        .HasMaxLength(20);

                    b.Property<string>("Street")
                        .HasColumnName("street")
                        .HasMaxLength(100);

                    b.Property<long>("UserId")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("address");
                });

            modelBuilder.Entity("Marmify.Domain.Entities.ApplicationRole", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnName("concurrency_stamp");

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnName("normalized_mail")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[normalized_mail] IS NOT NULL");

                    b.ToTable("role");
                });

            modelBuilder.Entity("Marmify.Domain.Entities.Delivery", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DeliveryDate")
                        .HasColumnName("delivery_date");

                    b.Property<long>("EstablishmentId")
                        .HasColumnName("establishment_id");

                    b.Property<string>("Status")
                        .HasColumnName("status")
                        .HasMaxLength(50);

                    b.Property<int>("TotalDeliveryTime")
                        .HasColumnName("total_delivery_time");

                    b.HasKey("Id");

                    b.HasIndex("EstablishmentId");

                    b.ToTable("delivery");
                });

            modelBuilder.Entity("Marmify.Domain.Entities.DeliveryType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("DeliveryValue");

                    b.Property<string>("Description")
                        .HasColumnName("description")
                        .HasMaxLength(50);

                    b.Property<long>("EstablishmentId")
                        .HasColumnName("establishment_id");

                    b.HasKey("Id");

                    b.HasIndex("EstablishmentId");

                    b.ToTable("delivery_type");
                });

            modelBuilder.Entity("Marmify.Domain.Entities.Establishment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnName("address")
                        .HasMaxLength(100);

                    b.Property<string>("Cnpj")
                        .HasColumnName("cnpj")
                        .HasMaxLength(14);

                    b.Property<string>("CompanyName")
                        .HasColumnName("company_name")
                        .HasMaxLength(100);

                    b.Property<string>("CorporateName")
                        .HasColumnName("corporate_name")
                        .HasMaxLength(100);

                    b.Property<string>("Email")
                        .HasColumnName("email")
                        .HasMaxLength(100);

                    b.Property<bool>("IsPartner")
                        .HasColumnName("is_partner");

                    b.Property<string>("Neighborhood")
                        .HasColumnName("neighborhood")
                        .HasMaxLength(100);

                    b.Property<int>("Number")
                        .HasColumnName("number");

                    b.Property<string>("Phone")
                        .HasColumnName("phone")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("establishment");

                    b.HasData(
                        new { Id = 1L, Address = "N/A", Cnpj = "N/A", CompanyName = "Administration", CorporateName = "Administration", Email = "N/A", IsPartner = false, Neighborhood = "N/A", Number = 0, Phone = "N/A" },
                        new { Id = 2L, Address = "N/A", Cnpj = "N/A", CompanyName = "User", CorporateName = "User", Email = "N/A", IsPartner = false, Neighborhood = "N/A", Number = 0, Phone = "N/A" }
                    );
                });

            modelBuilder.Entity("Marmify.Domain.Entities.Item", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Available")
                        .HasColumnName("available");

                    b.Property<string>("Description")
                        .HasColumnName("description");

                    b.Property<long>("EstablishmentId")
                        .HasColumnName("establishment_id");

                    b.Property<string>("Image")
                        .HasColumnName("image");

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasMaxLength(50);

                    b.Property<int>("PreparationTime")
                        .HasColumnName("preparation_time");

                    b.Property<decimal>("Value")
                        .HasColumnName("value");

                    b.HasKey("Id");

                    b.HasIndex("EstablishmentId");

                    b.ToTable("item");
                });

            modelBuilder.Entity("Marmify.Domain.Entities.ItemPurchase", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("ItemId")
                        .HasColumnName("item_id");

                    b.Property<string>("ItemName")
                        .HasColumnName("item_name")
                        .HasMaxLength(50);

                    b.Property<int>("ItemQuantity")
                        .HasColumnName("item_quantity");

                    b.Property<decimal>("ItemValue")
                        .HasColumnName("item_value");

                    b.Property<long>("PurchaseOrderId")
                        .HasColumnName("purchase_order_id");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("PurchaseOrderId");

                    b.ToTable("item_purchase");
                });

            modelBuilder.Entity("Marmify.Domain.Entities.PaymentCondition", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnName("description")
                        .HasMaxLength(100);

                    b.Property<long>("EstablishmentId")
                        .HasColumnName("establishment_id");

                    b.HasKey("Id");

                    b.HasIndex("EstablishmentId");

                    b.ToTable("payment_condition");
                });

            modelBuilder.Entity("Marmify.Domain.Entities.PurchaseOrder", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnName("amount");

                    b.Property<DateTime>("DatePurchase")
                        .HasColumnName("date_purchase");

                    b.Property<long>("DeliveryId")
                        .HasColumnName("delivery_id");

                    b.Property<long>("DeliveryTypeId")
                        .HasColumnName("delivery_type_id");

                    b.Property<long>("EstablishmentId")
                        .HasColumnName("establishment_id");

                    b.Property<long>("PaymentConditionId")
                        .HasColumnName("payment_condition_id");

                    b.Property<string>("Status")
                        .HasColumnName("status")
                        .HasMaxLength(50);

                    b.Property<long>("UserId")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("DeliveryId")
                        .IsUnique();

                    b.HasIndex("DeliveryTypeId");

                    b.HasIndex("EstablishmentId");

                    b.HasIndex("PaymentConditionId");

                    b.HasIndex("UserId");

                    b.ToTable("purchase_order");
                });

            modelBuilder.Entity("Marmify.Domain.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnName("access_failed_count");

                    b.Property<string>("CellPhone")
                        .HasColumnName("cell_phone")
                        .HasMaxLength(20);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnName("concurrency_stamp");

                    b.Property<string>("Cpf")
                        .HasColumnName("cpf")
                        .HasMaxLength(14);

                    b.Property<DateTime>("DateBirth")
                        .HasColumnName("date_birth");

                    b.Property<string>("Email")
                        .HasColumnName("email")
                        .HasMaxLength(100);

                    b.Property<short>("EmailConfirmed")
                        .HasColumnName("email_confirmed");

                    b.Property<long>("EstablishmentId")
                        .HasColumnName("establishment_id");

                    b.Property<string>("FullName")
                        .HasColumnName("full_name")
                        .HasMaxLength(100);

                    b.Property<short>("LockoutEnabled")
                        .HasColumnName("lockout_enabled");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnName("lockout_end");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnName("normalized_email")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnName("normalized_user_name")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnName("password_hash");

                    b.Property<string>("PhoneNumber")
                        .HasColumnName("phone_number")
                        .HasMaxLength(20);

                    b.Property<short>("PhoneNumberConfirmed")
                        .HasColumnName("phone_number_confirmed");

                    b.Property<string>("SecurityStamp")
                        .HasColumnName("security_stamp");

                    b.Property<short>("TwoFactorEnabled")
                        .HasColumnName("two_factor_enabled");

                    b.Property<string>("UserName")
                        .HasColumnName("user_name")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("EstablishmentId");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[normalized_user_name] IS NOT NULL");

                    b.ToTable("user");
                });

            modelBuilder.Entity("Marmify.Domain.Entities.UserFavorites", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("EstablishmentId")
                        .HasColumnName("establishment_id");

                    b.Property<long>("UserId")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("EstablishmentId");

                    b.HasIndex("UserId");

                    b.ToTable("user_favorites");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<long>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnName("claim_type");

                    b.Property<string>("ClaimValue")
                        .HasColumnName("claim_value");

                    b.Property<long>("RoleId")
                        .HasColumnName("role_id");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("role_claim");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<long>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnName("claim_type");

                    b.Property<string>("ClaimValue")
                        .HasColumnName("claim_value");

                    b.Property<long>("UserId")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("user_claim");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<long>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnName("login_provider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasColumnName("provider_key")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnName("provider_display_name");

                    b.Property<long>("UserId")
                        .HasColumnName("user_id");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("user_login");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<long>", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnName("user_id");

                    b.Property<long>("RoleId")
                        .HasColumnName("role_id");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("user_role");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUserRole<long>");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<long>", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnName("user_id");

                    b.Property<string>("LoginProvider")
                        .HasColumnName("login_provider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasMaxLength(128);

                    b.Property<string>("Value")
                        .HasColumnName("value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("user_token");
                });

            modelBuilder.Entity("Marmify.Domain.Entities.UserRole", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUserRole<long>");


                    b.ToTable("UserRole");

                    b.HasDiscriminator().HasValue("UserRole");
                });

            modelBuilder.Entity("Marmify.Domain.Entities.Address", b =>
                {
                    b.HasOne("Marmify.Domain.Entities.User", "User")
                        .WithMany("Addresses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Marmify.Domain.Entities.Delivery", b =>
                {
                    b.HasOne("Marmify.Domain.Entities.Establishment", "Establishment")
                        .WithMany("Deliveries")
                        .HasForeignKey("EstablishmentId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Marmify.Domain.Entities.DeliveryType", b =>
                {
                    b.HasOne("Marmify.Domain.Entities.Establishment", "Establishment")
                        .WithMany("DeliveryTypes")
                        .HasForeignKey("EstablishmentId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Marmify.Domain.Entities.Item", b =>
                {
                    b.HasOne("Marmify.Domain.Entities.Establishment", "Establishment")
                        .WithMany("Itens")
                        .HasForeignKey("EstablishmentId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Marmify.Domain.Entities.ItemPurchase", b =>
                {
                    b.HasOne("Marmify.Domain.Entities.Item", "Item")
                        .WithMany("ItemPurchases")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Marmify.Domain.Entities.PurchaseOrder", "PurchaseOrder")
                        .WithMany("ItemPurchases")
                        .HasForeignKey("PurchaseOrderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Marmify.Domain.Entities.PaymentCondition", b =>
                {
                    b.HasOne("Marmify.Domain.Entities.Establishment", "Establishment")
                        .WithMany()
                        .HasForeignKey("EstablishmentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Marmify.Domain.Entities.PurchaseOrder", b =>
                {
                    b.HasOne("Marmify.Domain.Entities.Delivery", "Delivery")
                        .WithOne("PurchaseOrder")
                        .HasForeignKey("Marmify.Domain.Entities.PurchaseOrder", "DeliveryId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Marmify.Domain.Entities.DeliveryType", "DeliveryType")
                        .WithMany("PurchaseOrder")
                        .HasForeignKey("DeliveryTypeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Marmify.Domain.Entities.Establishment", "Establishment")
                        .WithMany("PurchaseOrders")
                        .HasForeignKey("EstablishmentId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Marmify.Domain.Entities.PaymentCondition", "PaymentCondition")
                        .WithMany("PurchaseOrders")
                        .HasForeignKey("PaymentConditionId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Marmify.Domain.Entities.User", "User")
                        .WithMany("PurchaseOrders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Marmify.Domain.Entities.User", b =>
                {
                    b.HasOne("Marmify.Domain.Entities.Establishment", "Establishment")
                        .WithMany("Users")
                        .HasForeignKey("EstablishmentId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Marmify.Domain.Entities.UserFavorites", b =>
                {
                    b.HasOne("Marmify.Domain.Entities.Establishment", "Establishment")
                        .WithMany("UserFavorites")
                        .HasForeignKey("EstablishmentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Marmify.Domain.Entities.User", "User")
                        .WithMany("UserFavorites")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<long>", b =>
                {
                    b.HasOne("Marmify.Domain.Entities.ApplicationRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<long>", b =>
                {
                    b.HasOne("Marmify.Domain.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<long>", b =>
                {
                    b.HasOne("Marmify.Domain.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<long>", b =>
                {
                    b.HasOne("Marmify.Domain.Entities.ApplicationRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Marmify.Domain.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<long>", b =>
                {
                    b.HasOne("Marmify.Domain.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
