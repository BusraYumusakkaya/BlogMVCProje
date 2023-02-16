using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _31._01.Migrations
{
    public partial class about : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c767cb64-23fa-40db-860e-2ff1ef15cb44", "543ec2c1-6d89-46b8-ad02-5480ed0f8841" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e1324a08-af1c-4928-b7ca-c6ff6e30d5ec", "5d696afe-55ef-4607-b990-ec3e5bb6715f" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c767cb64-23fa-40db-860e-2ff1ef15cb44");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e1324a08-af1c-4928-b7ca-c6ff6e30d5ec");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "543ec2c1-6d89-46b8-ad02-5480ed0f8841");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5d696afe-55ef-4607-b990-ec3e5bb6715f");

            migrationBuilder.AddColumn<string>(
                name: "About",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5daeb6a2-fdf3-492a-8b54-7a3ea765e753", "c711ce7b-cd5e-49f3-9442-4943b5d95c60", "standart", "STANDART" },
                    { "6c14c20f-af7d-4364-8638-583e16b5c2ed", "b6445774-156c-44e4-941f-cc40e87aa902", "admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Photo", "SecurityStamp", "TwoFactorEnabled", "UserName", "İnformation" },
                values: new object[,]
                {
                    { "62e5c4fa-bb4e-49b4-ab2c-6c6bd3b0fa35", 0, "fa29adf1-bad1-47be-aa54-55dda1a92af4", "admin@admin.com", true, "Admin", "Admin", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAECJzrdViB7nh92NyRylAlSeHrjGVPdn/nOC5xvrsQgMwhgpcOekgGosLArEXrbQgqA==", null, false, null, "e7578003-1e46-4a26-ae06-eae8a138b4a6", false, "admin@admin.com", null },
                    { "bb1f20f3-8f8e-4487-a965-1d5f575cdfd8", 0, "d4cbdba5-ff69-44e0-86bc-01815ec621c2", "standart@standart.com", true, "Standart", "Standart", false, null, "STANDART@STANDART.COM", "STANDART@STANDART.COM", "AQAAAAEAACcQAAAAEE6W0MqDaCzh9fIZgGkMPTv3QcgucTYFqr1D9nWSQtR6pPrTk7AbCns8TkY4mQc99Q==", null, false, null, "a798cc58-a422-4a29-97cf-c592d20c96c3", false, "standart@standart.com", null }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "About",
                value: "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Nisl tincidunt eget nullam non. Quis hendrerit dolor magna eget est lorem ipsum dolor sit.");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "About",
                value: "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Nisl tincidunt eget nullam non. Quis hendrerit dolor magna eget est lorem ipsum dolor sit.");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "About",
                value: "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Nisl tincidunt eget nullam non. Quis hendrerit dolor magna eget est lorem ipsum dolor sit.");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "About",
                value: "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Nisl tincidunt eget nullam non. Quis hendrerit dolor magna eget est lorem ipsum dolor sit.");

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: "62e5c4fa-bb4e-49b4-ab2c-6c6bd3b0fa35");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "6c14c20f-af7d-4364-8638-583e16b5c2ed", "62e5c4fa-bb4e-49b4-ab2c-6c6bd3b0fa35" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "5daeb6a2-fdf3-492a-8b54-7a3ea765e753", "bb1f20f3-8f8e-4487-a965-1d5f575cdfd8" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6c14c20f-af7d-4364-8638-583e16b5c2ed", "62e5c4fa-bb4e-49b4-ab2c-6c6bd3b0fa35" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5daeb6a2-fdf3-492a-8b54-7a3ea765e753", "bb1f20f3-8f8e-4487-a965-1d5f575cdfd8" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5daeb6a2-fdf3-492a-8b54-7a3ea765e753");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6c14c20f-af7d-4364-8638-583e16b5c2ed");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "62e5c4fa-bb4e-49b4-ab2c-6c6bd3b0fa35");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bb1f20f3-8f8e-4487-a965-1d5f575cdfd8");

            migrationBuilder.DropColumn(
                name: "About",
                table: "Categories");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c767cb64-23fa-40db-860e-2ff1ef15cb44", "11cede8e-96a7-4d11-b4a0-4c14bb991d75", "standart", "STANDART" },
                    { "e1324a08-af1c-4928-b7ca-c6ff6e30d5ec", "92b676c4-f064-484c-8811-c83bb2e2ba57", "admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Photo", "SecurityStamp", "TwoFactorEnabled", "UserName", "İnformation" },
                values: new object[,]
                {
                    { "543ec2c1-6d89-46b8-ad02-5480ed0f8841", 0, "51800af3-3240-4b59-87b0-c0df5d430c4d", "standart@standart.com", true, "Standart", "Standart", false, null, "STANDART@STANDART.COM", "STANDART@STANDART.COM", "AQAAAAEAACcQAAAAEI8OH6pVIKwZIeDM/OGkBqkdB8PKAfINkgBM5KNcRMgti1hK1hOG0WozWQahRhQ+Ew==", null, false, null, "857d39a0-3ecf-460d-9149-6b2c4b52ffee", false, "standart@standart.com", null },
                    { "5d696afe-55ef-4607-b990-ec3e5bb6715f", 0, "eba25190-3e4c-4176-944a-61cc16862e9f", "admin@admin.com", true, "Admin", "Admin", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEBN/gDhrEUW7aVK3jUXk/wKzPcYoJfnraXJIWSXPceJ7j3aILUm0QOAfL2R/kk079A==", null, false, null, "8b018c58-71b0-41aa-a340-060f19301611", false, "admin@admin.com", null }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: "5d696afe-55ef-4607-b990-ec3e5bb6715f");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c767cb64-23fa-40db-860e-2ff1ef15cb44", "543ec2c1-6d89-46b8-ad02-5480ed0f8841" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "e1324a08-af1c-4928-b7ca-c6ff6e30d5ec", "5d696afe-55ef-4607-b990-ec3e5bb6715f" });
        }
    }
}
