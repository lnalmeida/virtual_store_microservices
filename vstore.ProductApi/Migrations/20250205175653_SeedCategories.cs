using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vstore.ProductApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.InsertData(
                table: "Categories",
                columns: new[] {"Name"},
                values: new object[] {"Carros"});

            mb.InsertData(
                table: "Categories",
                columns: new[] {"Name"},
                values: new object[] {"Motos"});

            mb.InsertData(
                table: "Categories",
                columns: new[] {"Name"},
                values: new object[] {"Utilitários"});
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM Categories");
        }
    }
}
