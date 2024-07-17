using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECommerce.Ploto.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class innit2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "Id", "CreateAt", "Createdby", "PermissionType" },
                values: new object[,]
                {
                    { new Guid("45b9ea53-ee2a-440b-9d31-5f8383f8c015"), null, null, 0 },
                    { new Guid("b727642d-bbe8-4e5a-ae8a-7aa4560ae9a0"), null, null, 1 }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "CreateAt", "Createdby", "Name" },
                values: new object[,]
                {
                    { new Guid("0d4d6157-abba-4857-9f86-c220e72e9b68"), null, null, "User" },
                    { new Guid("f4754847-03b2-4795-9e4b-96a4165f4d8b"), null, null, "Admin" }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "Id", "CreateAt", "Createdby", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("26957c4c-5266-48ca-bcdf-96b9d6e5f6b0"), null, null, new Guid("b727642d-bbe8-4e5a-ae8a-7aa4560ae9a0"), new Guid("0d4d6157-abba-4857-9f86-c220e72e9b68") },
                    { new Guid("28ce2cf4-3994-4f2a-a03f-0f51ab944787"), null, null, new Guid("45b9ea53-ee2a-440b-9d31-5f8383f8c015"), new Guid("f4754847-03b2-4795-9e4b-96a4165f4d8b") },
                    { new Guid("fec9fdda-77f1-4607-a2fd-5d5760c160c4"), null, null, new Guid("b727642d-bbe8-4e5a-ae8a-7aa4560ae9a0"), new Guid("f4754847-03b2-4795-9e4b-96a4165f4d8b") }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Address_Avenue", "Address_City", "Address_HouseNO", "HomeNumber_CityCode", "HomeNumber_Number", "Name_FirtsName", "Name_LastName", "AvatarId", "CartId", "CreateAt", "Createdby", "Password", "PhoneNumber", "RoleId", "RoleId1" },
                values: new object[] { new Guid("4a749d90-6b05-4222-8364-e9d9edc5e92a"), "resalat", "tehran", 54, "021", "123456799", "pourya", "hosseyni", null, null, null, null, "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "09386562888", new Guid("f4754847-03b2-4795-9e4b-96a4165f4d8b"), null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: new Guid("26957c4c-5266-48ca-bcdf-96b9d6e5f6b0"));

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: new Guid("28ce2cf4-3994-4f2a-a03f-0f51ab944787"));

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: new Guid("fec9fdda-77f1-4607-a2fd-5d5760c160c4"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("4a749d90-6b05-4222-8364-e9d9edc5e92a"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("45b9ea53-ee2a-440b-9d31-5f8383f8c015"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("b727642d-bbe8-4e5a-ae8a-7aa4560ae9a0"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("0d4d6157-abba-4857-9f86-c220e72e9b68"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("f4754847-03b2-4795-9e4b-96a4165f4d8b"));
        }
    }
}
