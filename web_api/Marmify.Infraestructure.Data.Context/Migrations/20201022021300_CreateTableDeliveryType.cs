using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Marmify.Infraestructure.Data.Context.Migrations
{
    public partial class CreateTableDeliveryType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_establishment_EstablishmentId",
                table: "Item");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemPurchase_Item_ItemId",
                table: "ItemPurchase");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemPurchase_PurchaseOrder_PurchaseOrderId",
                table: "ItemPurchase");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrder_establishment_EstablishmentId",
                table: "PurchaseOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrder_payment_condition_PaymentConditionId",
                table: "PurchaseOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrder_user_UserId",
                table: "PurchaseOrder");

            migrationBuilder.DropTable(
                name: "UserPayment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Item",
                table: "Item");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PurchaseOrder",
                table: "PurchaseOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemPurchase",
                table: "ItemPurchase");

            migrationBuilder.DropColumn(
                name: "DeliveryAmount",
                table: "PurchaseOrder");

            migrationBuilder.DropColumn(
                name: "DeliveryStatus",
                table: "PurchaseOrder");

            migrationBuilder.DropColumn(
                name: "DeliveryType",
                table: "PurchaseOrder");

            migrationBuilder.RenameTable(
                name: "Item",
                newName: "item");

            migrationBuilder.RenameTable(
                name: "PurchaseOrder",
                newName: "purchase_order");

            migrationBuilder.RenameTable(
                name: "ItemPurchase",
                newName: "item_purchase");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "item",
                newName: "value");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "item",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "item",
                newName: "image");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "item",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Available",
                table: "item",
                newName: "available");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "item",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "EstablishmentId",
                table: "item",
                newName: "establishment_id");

            migrationBuilder.RenameIndex(
                name: "IX_Item_EstablishmentId",
                table: "item",
                newName: "IX_item_establishment_id");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "purchase_order",
                newName: "amount");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "purchase_order",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "purchase_order",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "PaymentConditionId",
                table: "purchase_order",
                newName: "payment_condition_id");

            migrationBuilder.RenameColumn(
                name: "EstablishmentId",
                table: "purchase_order",
                newName: "establishment_id");

            migrationBuilder.RenameColumn(
                name: "DatePurchase",
                table: "purchase_order",
                newName: "date_purchase");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseOrder_UserId",
                table: "purchase_order",
                newName: "IX_purchase_order_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseOrder_PaymentConditionId",
                table: "purchase_order",
                newName: "IX_purchase_order_payment_condition_id");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseOrder_EstablishmentId",
                table: "purchase_order",
                newName: "IX_purchase_order_establishment_id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "item_purchase",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "PurchaseOrderId",
                table: "item_purchase",
                newName: "purchase_order_id");

            migrationBuilder.RenameColumn(
                name: "ItemValue",
                table: "item_purchase",
                newName: "item_value");

            migrationBuilder.RenameColumn(
                name: "ItemQuantity",
                table: "item_purchase",
                newName: "item_quantity");

            migrationBuilder.RenameColumn(
                name: "ItemName",
                table: "item_purchase",
                newName: "item_name");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "item_purchase",
                newName: "item_id");

            migrationBuilder.RenameIndex(
                name: "IX_ItemPurchase_PurchaseOrderId",
                table: "item_purchase",
                newName: "IX_item_purchase_purchase_order_id");

            migrationBuilder.RenameIndex(
                name: "IX_ItemPurchase_ItemId",
                table: "item_purchase",
                newName: "IX_item_purchase_item_id");

            migrationBuilder.AddColumn<long>(
                name: "EstablishmentId",
                table: "payment_condition",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "delivery_id",
                table: "purchase_order",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "delivery_type_id",
                table: "purchase_order",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "purchase_order",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_item",
                table: "item",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_purchase_order",
                table: "purchase_order",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_item_purchase",
                table: "item_purchase",
                column: "id");

            migrationBuilder.CreateTable(
                name: "delivery_time",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    establishment_id = table.Column<long>(nullable: false),
                    description = table.Column<string>(maxLength: 50, nullable: true),
                    time = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_delivery_time", x => x.id);
                    table.ForeignKey(
                        name: "FK_delivery_time_establishment_establishment_id",
                        column: x => x.establishment_id,
                        principalTable: "establishment",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "delivery_type",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    establishment_id = table.Column<long>(nullable: false),
                    description = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_delivery_type", x => x.id);
                    table.ForeignKey(
                        name: "FK_delivery_type_establishment_establishment_id",
                        column: x => x.establishment_id,
                        principalTable: "establishment",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "delivery",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    establishment_id = table.Column<long>(nullable: false),
                    delivery_time_id = table.Column<long>(nullable: false),
                    delivery_date = table.Column<DateTime>(nullable: false),
                    status = table.Column<string>(maxLength: 50, nullable: true),
                    delivery_amount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_delivery", x => x.id);
                    table.ForeignKey(
                        name: "FK_delivery_delivery_time_delivery_time_id",
                        column: x => x.delivery_time_id,
                        principalTable: "delivery_time",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_delivery_establishment_establishment_id",
                        column: x => x.establishment_id,
                        principalTable: "establishment",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_payment_condition_EstablishmentId",
                table: "payment_condition",
                column: "EstablishmentId");

            migrationBuilder.CreateIndex(
                name: "IX_purchase_order_delivery_id",
                table: "purchase_order",
                column: "delivery_id");

            migrationBuilder.CreateIndex(
                name: "IX_purchase_order_delivery_type_id",
                table: "purchase_order",
                column: "delivery_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_delivery_delivery_time_id",
                table: "delivery",
                column: "delivery_time_id");

            migrationBuilder.CreateIndex(
                name: "IX_delivery_establishment_id",
                table: "delivery",
                column: "establishment_id");

            migrationBuilder.CreateIndex(
                name: "IX_delivery_time_establishment_id",
                table: "delivery_time",
                column: "establishment_id");

            migrationBuilder.CreateIndex(
                name: "IX_delivery_type_establishment_id",
                table: "delivery_type",
                column: "establishment_id");

            migrationBuilder.AddForeignKey(
                name: "FK_item_establishment_establishment_id",
                table: "item",
                column: "establishment_id",
                principalTable: "establishment",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_item_purchase_item_item_id",
                table: "item_purchase",
                column: "item_id",
                principalTable: "item",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_item_purchase_purchase_order_purchase_order_id",
                table: "item_purchase",
                column: "purchase_order_id",
                principalTable: "purchase_order",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_payment_condition_establishment_EstablishmentId",
                table: "payment_condition",
                column: "EstablishmentId",
                principalTable: "establishment",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_purchase_order_delivery_delivery_id",
                table: "purchase_order",
                column: "delivery_id",
                principalTable: "delivery",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_purchase_order_delivery_type_delivery_type_id",
                table: "purchase_order",
                column: "delivery_type_id",
                principalTable: "delivery_type",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_purchase_order_establishment_establishment_id",
                table: "purchase_order",
                column: "establishment_id",
                principalTable: "establishment",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_purchase_order_payment_condition_payment_condition_id",
                table: "purchase_order",
                column: "payment_condition_id",
                principalTable: "payment_condition",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_purchase_order_user_user_id",
                table: "purchase_order",
                column: "user_id",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_item_establishment_establishment_id",
                table: "item");

            migrationBuilder.DropForeignKey(
                name: "FK_item_purchase_item_item_id",
                table: "item_purchase");

            migrationBuilder.DropForeignKey(
                name: "FK_item_purchase_purchase_order_purchase_order_id",
                table: "item_purchase");

            migrationBuilder.DropForeignKey(
                name: "FK_payment_condition_establishment_EstablishmentId",
                table: "payment_condition");

            migrationBuilder.DropForeignKey(
                name: "FK_purchase_order_delivery_delivery_id",
                table: "purchase_order");

            migrationBuilder.DropForeignKey(
                name: "FK_purchase_order_delivery_type_delivery_type_id",
                table: "purchase_order");

            migrationBuilder.DropForeignKey(
                name: "FK_purchase_order_establishment_establishment_id",
                table: "purchase_order");

            migrationBuilder.DropForeignKey(
                name: "FK_purchase_order_payment_condition_payment_condition_id",
                table: "purchase_order");

            migrationBuilder.DropForeignKey(
                name: "FK_purchase_order_user_user_id",
                table: "purchase_order");

            migrationBuilder.DropTable(
                name: "delivery");

            migrationBuilder.DropTable(
                name: "delivery_type");

            migrationBuilder.DropTable(
                name: "delivery_time");

            migrationBuilder.DropIndex(
                name: "IX_payment_condition_EstablishmentId",
                table: "payment_condition");

            migrationBuilder.DropPrimaryKey(
                name: "PK_item",
                table: "item");

            migrationBuilder.DropPrimaryKey(
                name: "PK_purchase_order",
                table: "purchase_order");

            migrationBuilder.DropIndex(
                name: "IX_purchase_order_delivery_id",
                table: "purchase_order");

            migrationBuilder.DropIndex(
                name: "IX_purchase_order_delivery_type_id",
                table: "purchase_order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_item_purchase",
                table: "item_purchase");

            migrationBuilder.DropColumn(
                name: "EstablishmentId",
                table: "payment_condition");

            migrationBuilder.DropColumn(
                name: "delivery_id",
                table: "purchase_order");

            migrationBuilder.DropColumn(
                name: "delivery_type_id",
                table: "purchase_order");

            migrationBuilder.DropColumn(
                name: "status",
                table: "purchase_order");

            migrationBuilder.RenameTable(
                name: "item",
                newName: "Item");

            migrationBuilder.RenameTable(
                name: "purchase_order",
                newName: "PurchaseOrder");

            migrationBuilder.RenameTable(
                name: "item_purchase",
                newName: "ItemPurchase");

            migrationBuilder.RenameColumn(
                name: "value",
                table: "Item",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Item",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "image",
                table: "Item",
                newName: "Image");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Item",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "available",
                table: "Item",
                newName: "Available");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Item",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "establishment_id",
                table: "Item",
                newName: "EstablishmentId");

            migrationBuilder.RenameIndex(
                name: "IX_item_establishment_id",
                table: "Item",
                newName: "IX_Item_EstablishmentId");

            migrationBuilder.RenameColumn(
                name: "amount",
                table: "PurchaseOrder",
                newName: "Amount");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "PurchaseOrder",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "PurchaseOrder",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "payment_condition_id",
                table: "PurchaseOrder",
                newName: "PaymentConditionId");

            migrationBuilder.RenameColumn(
                name: "establishment_id",
                table: "PurchaseOrder",
                newName: "EstablishmentId");

            migrationBuilder.RenameColumn(
                name: "date_purchase",
                table: "PurchaseOrder",
                newName: "DatePurchase");

            migrationBuilder.RenameIndex(
                name: "IX_purchase_order_user_id",
                table: "PurchaseOrder",
                newName: "IX_PurchaseOrder_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_purchase_order_payment_condition_id",
                table: "PurchaseOrder",
                newName: "IX_PurchaseOrder_PaymentConditionId");

            migrationBuilder.RenameIndex(
                name: "IX_purchase_order_establishment_id",
                table: "PurchaseOrder",
                newName: "IX_PurchaseOrder_EstablishmentId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "ItemPurchase",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "purchase_order_id",
                table: "ItemPurchase",
                newName: "PurchaseOrderId");

            migrationBuilder.RenameColumn(
                name: "item_value",
                table: "ItemPurchase",
                newName: "ItemValue");

            migrationBuilder.RenameColumn(
                name: "item_quantity",
                table: "ItemPurchase",
                newName: "ItemQuantity");

            migrationBuilder.RenameColumn(
                name: "item_name",
                table: "ItemPurchase",
                newName: "ItemName");

            migrationBuilder.RenameColumn(
                name: "item_id",
                table: "ItemPurchase",
                newName: "ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_item_purchase_purchase_order_id",
                table: "ItemPurchase",
                newName: "IX_ItemPurchase_PurchaseOrderId");

            migrationBuilder.RenameIndex(
                name: "IX_item_purchase_item_id",
                table: "ItemPurchase",
                newName: "IX_ItemPurchase_ItemId");

            migrationBuilder.AddColumn<decimal>(
                name: "DeliveryAmount",
                table: "PurchaseOrder",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "DeliveryStatus",
                table: "PurchaseOrder",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DeliveryType",
                table: "PurchaseOrder",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Item",
                table: "Item",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PurchaseOrder",
                table: "PurchaseOrder",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemPurchase",
                table: "ItemPurchase",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "UserPayment",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PaymentConditionsId = table.Column<long>(nullable: false),
                    UserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPayment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPayment_payment_condition_PaymentConditionsId",
                        column: x => x.PaymentConditionsId,
                        principalTable: "payment_condition",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPayment_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserPayment_PaymentConditionsId",
                table: "UserPayment",
                column: "PaymentConditionsId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPayment_UserId",
                table: "UserPayment",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_establishment_EstablishmentId",
                table: "Item",
                column: "EstablishmentId",
                principalTable: "establishment",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemPurchase_Item_ItemId",
                table: "ItemPurchase",
                column: "ItemId",
                principalTable: "Item",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemPurchase_PurchaseOrder_PurchaseOrderId",
                table: "ItemPurchase",
                column: "PurchaseOrderId",
                principalTable: "PurchaseOrder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrder_establishment_EstablishmentId",
                table: "PurchaseOrder",
                column: "EstablishmentId",
                principalTable: "establishment",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrder_payment_condition_PaymentConditionId",
                table: "PurchaseOrder",
                column: "PaymentConditionId",
                principalTable: "payment_condition",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrder_user_UserId",
                table: "PurchaseOrder",
                column: "UserId",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
