using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _31._01.Migrations
{
    public partial class many : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "ApplicationUserCategory",
                columns: table => new
                {
                    ApplicationUsersId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CategoriesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserCategory", x => new { x.ApplicationUsersId, x.CategoriesId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserCategory_AspNetUsers_ApplicationUsersId",
                        column: x => x.ApplicationUsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserCategory_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserCategory_CategoriesId",
                table: "ApplicationUserCategory",
                column: "CategoriesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUserCategory");

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
    }
}
