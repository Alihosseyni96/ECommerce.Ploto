using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECommerce.Ploto.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "Id", "CreateAt", "Createdby", "PermissionType" },
                values: new object[,]
                {
                    { new Guid("ee4827e8-e0ee-4a54-8c71-8d764658b1a8"), null, null, 1 },
                    { new Guid("ee4add70-068f-439b-8c70-f90a71306b63"), null, null, 0 }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "CreateAt", "Createdby", "Name" },
                values: new object[,]
                {
                    { new Guid("32a2a4bd-f1f9-4cd0-bf9e-0dcaa8d0d272"), null, null, "Admin" },
                    { new Guid("55eaf03e-dbf1-467f-9b19-df246254c150"), null, null, "User" }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "Id", "CreateAt", "Createdby", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("86da29cb-ae2f-4ab7-adfa-022756af48ba"), null, null, new Guid("ee4add70-068f-439b-8c70-f90a71306b63"), new Guid("32a2a4bd-f1f9-4cd0-bf9e-0dcaa8d0d272") },
                    { new Guid("90042e06-88a1-4e59-85b3-d65cc6fa848b"), null, null, new Guid("ee4827e8-e0ee-4a54-8c71-8d764658b1a8"), new Guid("55eaf03e-dbf1-467f-9b19-df246254c150") },
                    { new Guid("c23f9b14-2346-413e-b37f-26c44901eafa"), null, null, new Guid("ee4827e8-e0ee-4a54-8c71-8d764658b1a8"), new Guid("32a2a4bd-f1f9-4cd0-bf9e-0dcaa8d0d272") }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Address_Avenue", "Address_City", "Address_HouseNO", "HomeNumber_CityCode", "HomeNumber_Number", "Name_FirtsName", "Name_LastName", "AvatarId", "CartId", "CreateAt", "Createdby", "Password", "PhoneNumber", "RoleId", "RoleId1" },
                values: new object[] { new Guid("de87f8a6-c887-4cb7-84b0-c10a5309df4f"), "resalat", "tehran", 54, "021", "123456799", "pourya", "hosseyni", null, null, null, null, "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "09386562888", new Guid("32a2a4bd-f1f9-4cd0-bf9e-0dcaa8d0d272"), null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: new Guid("86da29cb-ae2f-4ab7-adfa-022756af48ba"));

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: new Guid("90042e06-88a1-4e59-85b3-d65cc6fa848b"));

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: new Guid("c23f9b14-2346-413e-b37f-26c44901eafa"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("de87f8a6-c887-4cb7-84b0-c10a5309df4f"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("ee4827e8-e0ee-4a54-8c71-8d764658b1a8"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("ee4add70-068f-439b-8c70-f90a71306b63"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("32a2a4bd-f1f9-4cd0-bf9e-0dcaa8d0d272"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("55eaf03e-dbf1-467f-9b19-df246254c150"));
        }
    }
}
