using Microsoft.EntityFrameworkCore.Migrations;

namespace AirAstana.Auth.Data.SqlServer.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "fa6aae40-9d76-4aa7-8bfe-09b599364222", "741697aa-e0f2-4e61-aa67-22bc2354e79f", "Administrator", "Administrator" },
                    { "b779a33a-301e-4961-8318-ada57a89172e", "208c49d1-a70b-4f7a-90cd-d6b1d011eea0", "Moderator", "Moderator" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "03920975-e91c-46e1-a380-e34dfed48dd4", 0, "02e66f18-521c-4b06-a136-a28ede4c29fa", "kalkenov.zh@gmail.com", true, "", "", false, null, null, "admin", "AQAAAAEAACcQAAAAEB6v385OsOqYICT6UUSmVLmN/MtCMw88VvHVjxj2no6+BPkBNI7yVrXPE2n5wy3xeA==", null, false, "", false, "admin" },
                    { "4c3584f3-2b7a-4cf8-b9e6-e102de72f0c5", 0, "0ecdf593-5570-490d-b05c-5237dd774896", "kalkenov.zh@gmail.com", true, "", "", false, null, null, "moderator", "AQAAAAEAACcQAAAAEJOh5FvtAb92eQn6Ru0GYtpX+FE8iSFMBlxh9h77WCGj+iQjk+HwjU66xCg71f+Www==", null, false, "", false, "moderator" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "03920975-e91c-46e1-a380-e34dfed48dd4", "fa6aae40-9d76-4aa7-8bfe-09b599364222" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "4c3584f3-2b7a-4cf8-b9e6-e102de72f0c5", "b779a33a-301e-4961-8318-ada57a89172e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "03920975-e91c-46e1-a380-e34dfed48dd4", "fa6aae40-9d76-4aa7-8bfe-09b599364222" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "4c3584f3-2b7a-4cf8-b9e6-e102de72f0c5", "b779a33a-301e-4961-8318-ada57a89172e" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b779a33a-301e-4961-8318-ada57a89172e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fa6aae40-9d76-4aa7-8bfe-09b599364222");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "03920975-e91c-46e1-a380-e34dfed48dd4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4c3584f3-2b7a-4cf8-b9e6-e102de72f0c5");
        }
    }
}
