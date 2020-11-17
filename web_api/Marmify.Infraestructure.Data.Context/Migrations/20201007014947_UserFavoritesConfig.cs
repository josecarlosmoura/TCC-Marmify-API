using Microsoft.EntityFrameworkCore.Migrations;

namespace Marmify.Infraestructure.Data.Context.Migrations
{
    public partial class UserFavoritesConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFavorites_establishment_EstablishmentId",
                table: "UserFavorites");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFavorites_user_UserId",
                table: "UserFavorites");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserFavorites",
                table: "UserFavorites");

            migrationBuilder.RenameTable(
                name: "UserFavorites",
                newName: "user_favorites");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "user_favorites",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "user_favorites",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "EstablishmentId",
                table: "user_favorites",
                newName: "establishment_id");

            migrationBuilder.RenameIndex(
                name: "IX_UserFavorites_UserId",
                table: "user_favorites",
                newName: "IX_user_favorites_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_UserFavorites_EstablishmentId",
                table: "user_favorites",
                newName: "IX_user_favorites_establishment_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_user_favorites",
                table: "user_favorites",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_user_favorites_establishment_establishment_id",
                table: "user_favorites",
                column: "establishment_id",
                principalTable: "establishment",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_user_favorites_user_user_id",
                table: "user_favorites",
                column: "user_id",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_favorites_establishment_establishment_id",
                table: "user_favorites");

            migrationBuilder.DropForeignKey(
                name: "FK_user_favorites_user_user_id",
                table: "user_favorites");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user_favorites",
                table: "user_favorites");

            migrationBuilder.RenameTable(
                name: "user_favorites",
                newName: "UserFavorites");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "UserFavorites",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "UserFavorites",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "establishment_id",
                table: "UserFavorites",
                newName: "EstablishmentId");

            migrationBuilder.RenameIndex(
                name: "IX_user_favorites_user_id",
                table: "UserFavorites",
                newName: "IX_UserFavorites_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_user_favorites_establishment_id",
                table: "UserFavorites",
                newName: "IX_UserFavorites_EstablishmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserFavorites",
                table: "UserFavorites",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFavorites_establishment_EstablishmentId",
                table: "UserFavorites",
                column: "EstablishmentId",
                principalTable: "establishment",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFavorites_user_UserId",
                table: "UserFavorites",
                column: "UserId",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
