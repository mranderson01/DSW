using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ejercicio2.Migrations.seguridad
{
    public partial class seederUser_Rol_userRol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "12cdb07e-07f6-4441-92bf-106b30efd604", "b0e618c5-4ba0-4e07-b92a-bb15f74fd96b", "Basic", "BASIC" },
                    { "ac547774-f3fa-4431-b0ab-618f407e7466", "a93db842-06dc-4e05-9b36-150fff1059e2", "Premium", "PREMIUM" },
                    { "b9a95d80-9349-4432-841f-a8fc99155973", "bf81a7c0-c013-4ec5-90a7-d74df875bc2d", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "59304ff3-c28e-4e76-802f-71635ad4be18", 0, "07e78549-849d-4352-bc7e-d7dba18e2dd4", "admin@api.com", false, false, null, null, "ADMIN@API.COM", "AQAAAAEAACcQAAAAEBI/2OumnVCx31cNjIEaI+RTI02FcOApPCqpwQj4LTXeGLbMxuIWWyMAhMFiAthslw==", null, false, "d7d3651d-d483-4bc3-bdd9-7418ee225fbf", false, "admin@api.com" },
                    { "9e097118-e9dd-4db7-afec-110f355fbed0", 0, "f1d19760-f443-4870-8f6f-53cafdcf5613", "basic@api.com", false, false, null, null, "BASIC@API.COM", "AQAAAAEAACcQAAAAEBwd7MHHRSwLRqB+MY8DseLdcxetsRZJoIyaMiMy84d4HNKwOsgKdyDmuHEaFlUoqw==", null, false, "d4c07c93-b7bf-40b8-9c50-88d00cd212db", false, "basic@api.com" },
                    { "e75b3edc-e049-4e72-a072-6dc7648826c1", 0, "46cd37d5-93e4-4ac8-ae45-5ebd23ca0a21", "premium@api.com", false, false, null, null, "PREMIUM@API.COM", "AQAAAAEAACcQAAAAEDS84kiEF09OzRFNEjUyEFecp49GKldU/4cCL8oMafYSStk5d87sprKoV5rnaiUxEg==", null, false, "3791f7e6-9254-425d-afe6-2884e5ed727e", false, "premium@api.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "b9a95d80-9349-4432-841f-a8fc99155973", "59304ff3-c28e-4e76-802f-71635ad4be18" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "12cdb07e-07f6-4441-92bf-106b30efd604", "9e097118-e9dd-4db7-afec-110f355fbed0" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ac547774-f3fa-4431-b0ab-618f407e7466", "e75b3edc-e049-4e72-a072-6dc7648826c1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b9a95d80-9349-4432-841f-a8fc99155973", "59304ff3-c28e-4e76-802f-71635ad4be18" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "12cdb07e-07f6-4441-92bf-106b30efd604", "9e097118-e9dd-4db7-afec-110f355fbed0" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ac547774-f3fa-4431-b0ab-618f407e7466", "e75b3edc-e049-4e72-a072-6dc7648826c1" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "12cdb07e-07f6-4441-92bf-106b30efd604");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ac547774-f3fa-4431-b0ab-618f407e7466");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b9a95d80-9349-4432-841f-a8fc99155973");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "59304ff3-c28e-4e76-802f-71635ad4be18");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e097118-e9dd-4db7-afec-110f355fbed0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e75b3edc-e049-4e72-a072-6dc7648826c1");
        }
    }
}
