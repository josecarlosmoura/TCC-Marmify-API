using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Marmify.Infraestructure.Data.Context.Migrations
{
    public partial class CreateDataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "establishment",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    corporate_name = table.Column<string>(nullable: true),
                    cnpj = table.Column<string>(nullable: true),
                    company_name = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    phone = table.Column<string>(nullable: true),
                    address = table.Column<string>(nullable: true),
                    number = table.Column<int>(nullable: false),
                    neighborhood = table.Column<string>(nullable: true),
                    is_partner = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_establishment", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentCondition",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentCondition", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "role",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(maxLength: 256, nullable: true),
                    normalized_mail = table.Column<string>(maxLength: 256, nullable: true),
                    concurrency_stamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Value = table.Column<decimal>(nullable: false),
                    Available = table.Column<bool>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    EstablishmentId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Item_establishment_EstablishmentId",
                        column: x => x.EstablishmentId,
                        principalTable: "establishment",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    user_name = table.Column<string>(maxLength: 256, nullable: true),
                    normalized_user_name = table.Column<string>(maxLength: 256, nullable: true),
                    email = table.Column<string>(maxLength: 256, nullable: true),
                    normalized_email = table.Column<string>(maxLength: 256, nullable: true),
                    email_confirmed = table.Column<short>(nullable: false),
                    password_hash = table.Column<string>(nullable: true),
                    security_stamp = table.Column<string>(nullable: true),
                    concurrency_stamp = table.Column<string>(nullable: true),
                    phone_number = table.Column<string>(nullable: true),
                    phone_number_confirmed = table.Column<short>(nullable: false),
                    two_factor_enabled = table.Column<short>(nullable: false),
                    lockout_end = table.Column<DateTimeOffset>(nullable: true),
                    lockout_enabled = table.Column<short>(nullable: false),
                    access_failed_count = table.Column<int>(nullable: false),
                    full_name = table.Column<string>(nullable: true),
                    cpf = table.Column<string>(nullable: true),
                    date_birth = table.Column<DateTime>(nullable: false),
                    cell_phone = table.Column<string>(nullable: true),
                    establishment_id = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                    table.ForeignKey(
                        name: "FK_user_establishment_establishment_id",
                        column: x => x.establishment_id,
                        principalTable: "establishment",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "role_claim",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    role_id = table.Column<long>(nullable: false),
                    claim_type = table.Column<string>(nullable: true),
                    claim_value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role_claim", x => x.id);
                    table.ForeignKey(
                        name: "FK_role_claim_role_role_id",
                        column: x => x.role_id,
                        principalTable: "role",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "address",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    street = table.Column<string>(nullable: true),
                    number = table.Column<int>(nullable: false),
                    neighborhood = table.Column<string>(nullable: true),
                    postal_code = table.Column<string>(nullable: true),
                    user_id = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_address", x => x.id);
                    table.ForeignKey(
                        name: "FK_address_user_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrder",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DatePurchase = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    DeliveryAmount = table.Column<decimal>(nullable: false),
                    DeliveryStatus = table.Column<int>(nullable: false),
                    DeliveryType = table.Column<int>(nullable: false),
                    UserId = table.Column<long>(nullable: false),
                    EstablishmentId = table.Column<long>(nullable: false),
                    PaymentConditionId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseOrder_establishment_EstablishmentId",
                        column: x => x.EstablishmentId,
                        principalTable: "establishment",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseOrder_PaymentCondition_PaymentConditionId",
                        column: x => x.PaymentConditionId,
                        principalTable: "PaymentCondition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseOrder_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "user_claim",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    user_id = table.Column<long>(nullable: false),
                    claim_type = table.Column<string>(nullable: true),
                    claim_value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_claim", x => x.id);
                    table.ForeignKey(
                        name: "FK_user_claim_user_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_login",
                columns: table => new
                {
                    login_provider = table.Column<string>(maxLength: 128, nullable: false),
                    provider_key = table.Column<string>(maxLength: 128, nullable: false),
                    provider_display_name = table.Column<string>(nullable: true),
                    user_id = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_login", x => new { x.login_provider, x.provider_key });
                    table.ForeignKey(
                        name: "FK_user_login_user_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_role",
                columns: table => new
                {
                    user_id = table.Column<long>(nullable: false),
                    role_id = table.Column<long>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_role", x => new { x.user_id, x.role_id });
                    table.ForeignKey(
                        name: "FK_user_role_role_role_id",
                        column: x => x.role_id,
                        principalTable: "role",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_role_user_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_token",
                columns: table => new
                {
                    user_id = table.Column<long>(nullable: false),
                    login_provider = table.Column<string>(maxLength: 128, nullable: false),
                    name = table.Column<string>(maxLength: 128, nullable: false),
                    value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_token", x => new { x.user_id, x.login_provider, x.name });
                    table.ForeignKey(
                        name: "FK_user_token_user_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserFavorites",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<long>(nullable: false),
                    EstablishmentId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFavorites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserFavorites_establishment_EstablishmentId",
                        column: x => x.EstablishmentId,
                        principalTable: "establishment",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserFavorites_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserPayment",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<long>(nullable: false),
                    PaymentConditionsId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPayment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPayment_PaymentCondition_PaymentConditionsId",
                        column: x => x.PaymentConditionsId,
                        principalTable: "PaymentCondition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPayment_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemPurchase",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ItemId = table.Column<long>(nullable: false),
                    PurchaseOrderId = table.Column<long>(nullable: false),
                    ItemName = table.Column<string>(nullable: true),
                    ItemValue = table.Column<decimal>(nullable: false),
                    ItemQuantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemPurchase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemPurchase_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemPurchase_PurchaseOrder_PurchaseOrderId",
                        column: x => x.PurchaseOrderId,
                        principalTable: "PurchaseOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "establishment",
                columns: new[] { "id", "address", "cnpj", "company_name", "corporate_name", "email", "is_partner", "neighborhood", "number", "phone" },
                values: new object[] { 1L, "N/A", "N/A", "Administration", "Administration", "N/A", false, "N/A", 0, "N/A" });

            migrationBuilder.InsertData(
                table: "establishment",
                columns: new[] { "id", "address", "cnpj", "company_name", "corporate_name", "email", "is_partner", "neighborhood", "number", "phone" },
                values: new object[] { 2L, "N/A", "N/A", "User", "User", "N/A", false, "N/A", 0, "N/A" });

            migrationBuilder.CreateIndex(
                name: "IX_address_user_id",
                table: "address",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Item_EstablishmentId",
                table: "Item",
                column: "EstablishmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemPurchase_ItemId",
                table: "ItemPurchase",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemPurchase_PurchaseOrderId",
                table: "ItemPurchase",
                column: "PurchaseOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrder_EstablishmentId",
                table: "PurchaseOrder",
                column: "EstablishmentId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrder_PaymentConditionId",
                table: "PurchaseOrder",
                column: "PaymentConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrder_UserId",
                table: "PurchaseOrder",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "role",
                column: "normalized_mail",
                unique: true,
                filter: "[normalized_mail] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_role_claim_role_id",
                table: "role_claim",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_establishment_id",
                table: "user",
                column: "establishment_id");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "user",
                column: "normalized_email");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "user",
                column: "normalized_user_name",
                unique: true,
                filter: "[normalized_user_name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_user_claim_user_id",
                table: "user_claim",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_login_user_id",
                table: "user_login",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_role_role_id",
                table: "user_role",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_UserFavorites_EstablishmentId",
                table: "UserFavorites",
                column: "EstablishmentId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFavorites_UserId",
                table: "UserFavorites",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPayment_PaymentConditionsId",
                table: "UserPayment",
                column: "PaymentConditionsId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPayment_UserId",
                table: "UserPayment",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "address");

            migrationBuilder.DropTable(
                name: "ItemPurchase");

            migrationBuilder.DropTable(
                name: "role_claim");

            migrationBuilder.DropTable(
                name: "user_claim");

            migrationBuilder.DropTable(
                name: "user_login");

            migrationBuilder.DropTable(
                name: "user_role");

            migrationBuilder.DropTable(
                name: "user_token");

            migrationBuilder.DropTable(
                name: "UserFavorites");

            migrationBuilder.DropTable(
                name: "UserPayment");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "PurchaseOrder");

            migrationBuilder.DropTable(
                name: "role");

            migrationBuilder.DropTable(
                name: "PaymentCondition");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "establishment");
        }
    }
}
