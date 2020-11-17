using Microsoft.EntityFrameworkCore.Migrations;

namespace Marmify.Infraestructure.Data.Context.Migrations
{
    public partial class PaymentConditionConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrder_PaymentCondition_PaymentConditionId",
                table: "PurchaseOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPayment_PaymentCondition_PaymentConditionsId",
                table: "UserPayment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentCondition",
                table: "PaymentCondition");

            migrationBuilder.RenameTable(
                name: "PaymentCondition",
                newName: "payment_condition");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "payment_condition",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "payment_condition",
                newName: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_payment_condition",
                table: "payment_condition",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrder_payment_condition_PaymentConditionId",
                table: "PurchaseOrder",
                column: "PaymentConditionId",
                principalTable: "payment_condition",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPayment_payment_condition_PaymentConditionsId",
                table: "UserPayment",
                column: "PaymentConditionsId",
                principalTable: "payment_condition",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrder_payment_condition_PaymentConditionId",
                table: "PurchaseOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPayment_payment_condition_PaymentConditionsId",
                table: "UserPayment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_payment_condition",
                table: "payment_condition");

            migrationBuilder.RenameTable(
                name: "payment_condition",
                newName: "PaymentCondition");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "PaymentCondition",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "PaymentCondition",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentCondition",
                table: "PaymentCondition",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrder_PaymentCondition_PaymentConditionId",
                table: "PurchaseOrder",
                column: "PaymentConditionId",
                principalTable: "PaymentCondition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPayment_PaymentCondition_PaymentConditionsId",
                table: "UserPayment",
                column: "PaymentConditionsId",
                principalTable: "PaymentCondition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
