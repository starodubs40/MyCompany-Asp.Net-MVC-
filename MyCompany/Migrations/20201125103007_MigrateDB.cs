using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyCompany.Migrations
{
    public partial class MigrateDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          
            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "ServiceItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("4aa76a4c-c59d-409a-84c1-06e6487a137a"),
                columns: new[] { "DateAdded", "Text" },
                values: new object[] { new DateTime(2020, 11, 25, 10, 30, 5, 955, DateTimeKind.Utc).AddTicks(6452), "Зміст заповнюється адміністратором" });

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("63dc8fa6-07ae-4391-8916-e057f71239ce"),
                columns: new[] { "DateAdded", "Text" },
                values: new object[] { new DateTime(2020, 11, 25, 10, 30, 5, 955, DateTimeKind.Utc).AddTicks(2660), "Зміст заповнюється адміністратором" });

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("70bf165a-700a-4156-91c0-e83fce0a277f"),
                columns: new[] { "DateAdded", "Text" },
                values: new object[] { new DateTime(2020, 11, 25, 10, 30, 5, 955, DateTimeKind.Utc).AddTicks(6326), "Зміст заповнюється адміністратором" });

           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "2b62472e-4f66-49fa-a20f-e7685b9565d7", "43546e06-8719-4ad8-b88a-f271ae9d6eba" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "43546e06-8719-4ad8-b88a-f271ae9d6eba");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2b62472e-4f66-49fa-a20f-e7685b9565d7");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "ServiceItems");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "44546e06-8719-4ad8-b88a-f271ae9d6eab", "dcd960b1-b36e-490d-b354-1ff8acbaed2c", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3b62472e-4f66-49fa-a20f-e7685b9565d8", 0, "ff39aae9-0c2a-4fe8-80a8-687dc1f6cbbd", "my@email.com", true, false, null, "MY@EMAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAEFf+TpSCJCw9Rav8YgDI3jICmA8uqGiNRiY2PcTxuEu3FY0zRDJITGYJNX33fDdNuw==", null, false, "", false, "admin" });

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("4aa76a4c-c59d-409a-84c1-06e6487a137a"),
                columns: new[] { "DateAdded", "Text" },
                values: new object[] { new DateTime(2020, 9, 18, 11, 0, 32, 315, DateTimeKind.Utc).AddTicks(6090), "Содержание заполняется администратором" });

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("63dc8fa6-07ae-4391-8916-e057f71239ce"),
                columns: new[] { "DateAdded", "Text" },
                values: new object[] { new DateTime(2020, 9, 18, 11, 0, 32, 315, DateTimeKind.Utc).AddTicks(3306), "Содержание заполняется администратором" });

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("70bf165a-700a-4156-91c0-e83fce0a277f"),
                columns: new[] { "DateAdded", "Text" },
                values: new object[] { new DateTime(2020, 9, 18, 11, 0, 32, 315, DateTimeKind.Utc).AddTicks(6017), "Содержание заполняется администратором" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "3b62472e-4f66-49fa-a20f-e7685b9565d8", "44546e06-8719-4ad8-b88a-f271ae9d6eab" });
        }
    }
}
