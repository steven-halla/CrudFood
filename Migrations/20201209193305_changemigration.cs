using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CrudFood.Migrations
{
    public partial class changemigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DishRecipes",
                table: "DishRecipes");

            migrationBuilder.DropColumn(
                name: "DishesId",
                table: "DishRecipes");

            migrationBuilder.AddColumn<int>(
                name: "DishRecipeId",
                table: "DishRecipes",
                nullable: false,
                defaultValue: 0)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DishRecipes",
                table: "DishRecipes",
                column: "DishRecipeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DishRecipes",
                table: "DishRecipes");

            migrationBuilder.DropColumn(
                name: "DishRecipeId",
                table: "DishRecipes");

            migrationBuilder.AddColumn<int>(
                name: "DishesId",
                table: "DishRecipes",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DishRecipes",
                table: "DishRecipes",
                column: "DishesId");
        }
    }
}
