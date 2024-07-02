using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECommerce.Ploto.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seedRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleUser_User_UsersId",
                table: "RoleUser");

            migrationBuilder.RenameColumn(
                name: "UsersId",
                table: "RoleUser",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_RoleUser_UsersId",
                table: "RoleUser",
                newName: "IX_RoleUser_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Role",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "CreateAt", "Createdby", "Name" },
                values: new object[,]
                {
                    { new Guid("7c75ea36-6235-441f-88f0-8c8ae56ef651"), null, null, "Admin" },
                    { new Guid("c82d28b9-7d98-4d43-9270-adedf4d2c945"), null, null, "user" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_RoleUser_User_UserId",
                table: "RoleUser",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleUser_User_UserId",
                table: "RoleUser");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("7c75ea36-6235-441f-88f0-8c8ae56ef651"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("c82d28b9-7d98-4d43-9270-adedf4d2c945"));

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "RoleUser",
                newName: "UsersId");

            migrationBuilder.RenameIndex(
                name: "IX_RoleUser_UserId",
                table: "RoleUser",
                newName: "IX_RoleUser_UsersId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Role",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleUser_User_UsersId",
                table: "RoleUser",
                column: "UsersId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
