using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Marmify.Infraestructure.Data.Context.Migrations
{
    public partial class DeleteTabelaDeliveryTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_delivery_delivery_time_delivery_time_id",
                table: "delivery");

            migrationBuilder.DropTable(
                name: "delivery_time");

            migrationBuilder.DropIndex(
                name: "IX_delivery_delivery_time_id",
                table: "delivery");

            migrationBuilder.DropColumn(
                name: "delivery_amount",
                table: "delivery");

            migrationBuilder.DropColumn(
                name: "delivery_time_id",
                table: "delivery");

            migrationBuilder.AddColumn<int>(
                name: "preparation_time",
                table: "item",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "DeliveryValue",
                table: "delivery_type",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "total_delivery_time",
                table: "delivery",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "preparation_time",
                table: "item");

            migrationBuilder.DropColumn(
                name: "DeliveryValue",
                table: "delivery_type");

            migrationBuilder.DropColumn(
                name: "total_delivery_time",
                table: "delivery");

            migrationBuilder.AddColumn<decimal>(
                name: "delivery_amount",
                table: "delivery",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<long>(
                name: "delivery_time_id",
                table: "delivery",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "delivery_time",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    description = table.Column<string>(maxLength: 50, nullable: true),
                    establishment_id = table.Column<long>(nullable: false),
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

            migrationBuilder.CreateIndex(
                name: "IX_delivery_delivery_time_id",
                table: "delivery",
                column: "delivery_time_id");

            migrationBuilder.CreateIndex(
                name: "IX_delivery_time_establishment_id",
                table: "delivery_time",
                column: "establishment_id");

            migrationBuilder.AddForeignKey(
                name: "FK_delivery_delivery_time_delivery_time_id",
                table: "delivery",
                column: "delivery_time_id",
                principalTable: "delivery_time",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
