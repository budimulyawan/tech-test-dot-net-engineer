using Microsoft.EntityFrameworkCore.Migrations;

namespace Hipages.Infrastructure.Tradie.Migrations
{
    public partial class RenameJobStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_Category_ParentCategoryId",
                table: "Category");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Category_CategoryId",
                table: "Jobs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "LeadStatus",
                table: "Jobs");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "category");

            migrationBuilder.RenameIndex(
                name: "IX_Category_ParentCategoryId",
                table: "category",
                newName: "IX_category_ParentCategoryId");

            migrationBuilder.AddColumn<int>(
                name: "JobStatus",
                table: "Jobs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_category",
                table: "category",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_category_category_ParentCategoryId",
                table: "category",
                column: "ParentCategoryId",
                principalTable: "category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_category_CategoryId",
                table: "Jobs",
                column: "CategoryId",
                principalTable: "category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_category_category_ParentCategoryId",
                table: "category");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_category_CategoryId",
                table: "Jobs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_category",
                table: "category");

            migrationBuilder.DropColumn(
                name: "JobStatus",
                table: "Jobs");

            migrationBuilder.RenameTable(
                name: "category",
                newName: "Category");

            migrationBuilder.RenameIndex(
                name: "IX_category_ParentCategoryId",
                table: "Category",
                newName: "IX_Category_ParentCategoryId");

            migrationBuilder.AddColumn<int>(
                name: "LeadStatus",
                table: "Jobs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Category_ParentCategoryId",
                table: "Category",
                column: "ParentCategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Category_CategoryId",
                table: "Jobs",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
