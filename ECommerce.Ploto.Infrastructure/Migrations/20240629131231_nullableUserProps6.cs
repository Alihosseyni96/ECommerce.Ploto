using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Ploto.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class nullableUserProps6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Image");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Image",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Image");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Image",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
