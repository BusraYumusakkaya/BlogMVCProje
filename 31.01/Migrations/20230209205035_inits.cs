using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _31._01.Migrations
{
    public partial class inits : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ae7feea5-a98c-44a4-a8c2-52717722f9c0", "27d23369-08f9-4ff3-8ab8-df25304c1873" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "90075520-4e17-4ef1-8fbc-ae2a4d573a92", "aa81f6db-3973-4824-856b-2cc286d33c8f" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "90075520-4e17-4ef1-8fbc-ae2a4d573a92");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ae7feea5-a98c-44a4-a8c2-52717722f9c0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "27d23369-08f9-4ff3-8ab8-df25304c1873");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "aa81f6db-3973-4824-856b-2cc286d33c8f");

            migrationBuilder.AddColumn<string>(
                name: "İnformation",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2cecbc59-6c94-42d2-acb7-c0f4b22f9795", "fc865479-eb87-4077-881c-5a742d1f65f4", "admin", "ADMIN" },
                    { "531dc7ef-2736-4338-93e7-6983ea1f555f", "cb6d10f0-8fd6-4666-ac61-e8be1af327a3", "standart", "STANDART" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Photo", "SecurityStamp", "TwoFactorEnabled", "UserName", "İnformation" },
                values: new object[,]
                {
                    { "7ee72727-4e8d-4b03-93c3-10cf251f9190", 0, "d9fc03d8-68c1-454e-ada3-5975d73dab8f", "standart@standart.com", true, "Standart", "Standart", false, null, "STANDART@STANDART.COM", "STANDART@STANDART.COM", "AQAAAAEAACcQAAAAEBdqHIT9fbiLWGzW6XDN9HVM4s2lZJZHuoXiBvFEtFaP7JgxMDCVD/ZKn5FTFlvsww==", null, false, null, "8289eeee-d67a-4bf2-a9d1-dc5ca01f3ab4", false, "standart@standart.com", null },
                    { "fda52fe8-aa18-4c6c-b201-8f8c18e9bdca", 0, "6b4aaeb9-fd9a-4394-b086-c6a0decf9fbd", "admin@admin.com", true, "Admin", "Admin", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEDk93sP7oy9bIYxco8Cf3PppzdI4HgWG2z8as9KuSR7MEKhrIWJ9kFGvDppwMEEiQw==", null, false, null, "4f41b448-d224-408d-8924-89c4fd0c3aea", false, "admin@admin.com", null }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: "fda52fe8-aa18-4c6c-b201-8f8c18e9bdca");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "531dc7ef-2736-4338-93e7-6983ea1f555f", "7ee72727-4e8d-4b03-93c3-10cf251f9190" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "2cecbc59-6c94-42d2-acb7-c0f4b22f9795", "fda52fe8-aa18-4c6c-b201-8f8c18e9bdca" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "531dc7ef-2736-4338-93e7-6983ea1f555f", "7ee72727-4e8d-4b03-93c3-10cf251f9190" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2cecbc59-6c94-42d2-acb7-c0f4b22f9795", "fda52fe8-aa18-4c6c-b201-8f8c18e9bdca" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2cecbc59-6c94-42d2-acb7-c0f4b22f9795");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "531dc7ef-2736-4338-93e7-6983ea1f555f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7ee72727-4e8d-4b03-93c3-10cf251f9190");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fda52fe8-aa18-4c6c-b201-8f8c18e9bdca");

            migrationBuilder.DropColumn(
                name: "İnformation",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "90075520-4e17-4ef1-8fbc-ae2a4d573a92", "4c6452dc-0070-42f7-acea-ee29f67ae4ca", "admin", "ADMIN" },
                    { "ae7feea5-a98c-44a4-a8c2-52717722f9c0", "5c945519-5ddc-4037-a9d8-fe9243b26717", "standart", "STANDART" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Photo", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "27d23369-08f9-4ff3-8ab8-df25304c1873", 0, "dfcbd50a-345b-4b4c-9c02-53434dd06ba7", "standart@standart.com", true, "Standart", "Standart", false, null, "STANDART@STANDART.COM", "STANDART@STANDART.COM", "AQAAAAEAACcQAAAAEF6T0DICUbhHUawohBp+vmmQSzB/H6alUUahWsMXMmAWhfFWm28OGDzgEtoTkyp7dg==", null, false, null, "ab44d16e-aebc-4537-946c-ff2a8bfef791", false, "standart@standart.com" },
                    { "aa81f6db-3973-4824-856b-2cc286d33c8f", 0, "96eb811f-aa1a-45b8-99b8-f4ac2c8568d8", "admin@admin.com", true, "Admin", "Admin", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEBxKuzSSAJw9WN17XX92CBqLcwxTbGToCbUOSzNYh84SRbp/Flx4jtxpzh+hTdC5AA==", null, false, null, "cf3d1388-71b2-4c5e-bcaa-513f8d6c2011", false, "admin@admin.com" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: "aa81f6db-3973-4824-856b-2cc286d33c8f");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ae7feea5-a98c-44a4-a8c2-52717722f9c0", "27d23369-08f9-4ff3-8ab8-df25304c1873" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "90075520-4e17-4ef1-8fbc-ae2a4d573a92", "aa81f6db-3973-4824-856b-2cc286d33c8f" });
        }
    }
}
