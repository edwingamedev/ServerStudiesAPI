using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyFirstAPI.Migrations
{
    /// <inheritdoc />
    public partial class PopulateCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert into Categories (Name, ImgUrl) values ('Drink','drinks.jpg')");
            migrationBuilder.Sql("Insert into Categories (Name, ImgUrl) values ('Food','foods.jpg')");
            migrationBuilder.Sql("Insert into Categories (Name, ImgUrl) values ('Dessert','desserts.jpg')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from Categories");
        }
    }
}
