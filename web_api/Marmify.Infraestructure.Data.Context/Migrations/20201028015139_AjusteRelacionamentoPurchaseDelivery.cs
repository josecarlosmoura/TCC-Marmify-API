using Microsoft.EntityFrameworkCore.Migrations;

namespace Marmify.Infraestructure.Data.Context.Migrations
{
    public partial class AjusteRelacionamentoPurchaseDelivery : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_purchase_order_delivery_id",
                table: "purchase_order");

            migrationBuilder.CreateIndex(
                name: "IX_purchase_order_delivery_id",
                table: "purchase_order",
                column: "delivery_id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_purchase_order_delivery_id",
                table: "purchase_order");

            migrationBuilder.CreateIndex(
                name: "IX_purchase_order_delivery_id",
                table: "purchase_order",
                column: "delivery_id");
        }
    }
}
