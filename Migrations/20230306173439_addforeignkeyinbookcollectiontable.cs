using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoLibWorld.Migrations
{
    /// <inheritdoc />
    public partial class addforeignkeyinbookcollectiontable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookCategoryId",
                table: "BookCollections",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BookCollections_BookCategoryId",
                table: "BookCollections",
                column: "BookCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookCollections_BookCategories_BookCategoryId",
                table: "BookCollections",
                column: "BookCategoryId",
                principalTable: "BookCategories",
                principalColumn: "BookCategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookCollections_BookCategories_BookCategoryId",
                table: "BookCollections");

            migrationBuilder.DropIndex(
                name: "IX_BookCollections_BookCategoryId",
                table: "BookCollections");

            migrationBuilder.DropColumn(
                name: "BookCategoryId",
                table: "BookCollections");
        }
    }
}
