using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyFirstAPI.Migrations
{
    /// <inheritdoc />
    public partial class PopulateProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "Insert into Products(Name, Description, Price, ImgUrl, Stock, CreatedAt, CategoryId) Values ('Soda Diet', 'Pop soda 350ml', 5.45, 'soda.jpg', 50, now(), 1)");
            migrationBuilder.Sql(
                "Insert into Products(Name, Description, Price, ImgUrl, Stock, CreatedAt, CategoryId) Values ('Tuna Sandwich', 'Tuna Sandwich with Mayo', 8.50, 'tunaSandwich.jpg', 10, now(), 2)");
            migrationBuilder.Sql(
                "Insert into Products(Name, Description, Price, ImgUrl, Stock, CreatedAt, CategoryId) Values ('Pudding 100 g', 'Milk Pudding 100g', 6.75, 'pudding.jpg', 20, now(), 3)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from Products");
        }
    }
}
