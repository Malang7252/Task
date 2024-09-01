using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Task.Data.Migrations
{
    /// <inheritdoc />
    public partial class Final : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("00b1b6be-1b8a-45e1-91d2-5cbb4762b422"));

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("95dcad01-4633-46f0-bc62-c1ad5074396a"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("1fbeac17-f493-499a-95ad-b3b5714cb476"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("7917158d-88f3-433f-ad5b-7b91377c95f3"));

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: new Guid("80a9e596-0f72-498a-9fbf-627df473def0"));

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: new Guid("a5f81e83-06ec-4f65-9872-7de8707ea955"));

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Email", "FirstName", "IsDeleted", "LastName", "MobileNumber", "PersonalId", "ProfilePhoto", "Sex", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("5f105c64-fb6d-4c9d-995b-54cb021351f0"), new DateTime(2024, 9, 1, 13, 13, 57, 400, DateTimeKind.Utc).AddTicks(7365), null, "jane.smith@example.com", "Jane", false, "Smith", "+19876543210", "10987654321", "jane_smith_profile.jpg", "Female", null },
                    { new Guid("d9d3868e-a002-48fd-8b83-7d4b740b950e"), new DateTime(2024, 9, 1, 13, 13, 57, 400, DateTimeKind.Utc).AddTicks(7359), null, "john.doe@example.com", "John", false, "Doe", "+11234567890", "12345678901", "john_doe_profile.jpg", "Male", null }
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "AccountNumber", "Balance", "ClientId", "CreatedDate", "DeletedDate", "IsDeleted", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("a8b382f6-af66-4908-813b-eeeaa28538ba"), "0987654321", 500m, new Guid("5f105c64-fb6d-4c9d-995b-54cb021351f0"), new DateTime(2024, 9, 1, 13, 13, 57, 400, DateTimeKind.Utc).AddTicks(7435), null, false, null },
                    { new Guid("d8185acd-32af-4592-9f1e-2d4efacb515a"), "1234567890", 1000m, new Guid("d9d3868e-a002-48fd-8b83-7d4b740b950e"), new DateTime(2024, 9, 1, 13, 13, 57, 400, DateTimeKind.Utc).AddTicks(7426), null, false, null }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "ClientId", "Country", "CreatedDate", "DeletedDate", "IsDeleted", "Street", "UpdatedDate", "ZipCode" },
                values: new object[,]
                {
                    { new Guid("139d7c3c-ab52-4ce0-8a9b-0697b313e8b8"), "Toronto", new Guid("5f105c64-fb6d-4c9d-995b-54cb021351f0"), "Canada", new DateTime(2024, 9, 1, 13, 13, 57, 400, DateTimeKind.Utc).AddTicks(7398), null, false, "456 Maple Ave", null, "M5V 2T6" },
                    { new Guid("2712b292-022a-42d8-89b4-43e2703afabe"), "New York", new Guid("d9d3868e-a002-48fd-8b83-7d4b740b950e"), "USA", new DateTime(2024, 9, 1, 13, 13, 57, 400, DateTimeKind.Utc).AddTicks(7393), null, false, "123 Main St", null, "10001" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("a8b382f6-af66-4908-813b-eeeaa28538ba"));

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("d8185acd-32af-4592-9f1e-2d4efacb515a"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("139d7c3c-ab52-4ce0-8a9b-0697b313e8b8"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("2712b292-022a-42d8-89b4-43e2703afabe"));

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: new Guid("5f105c64-fb6d-4c9d-995b-54cb021351f0"));

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: new Guid("d9d3868e-a002-48fd-8b83-7d4b740b950e"));

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Email", "FirstName", "IsDeleted", "LastName", "MobileNumber", "PersonalId", "ProfilePhoto", "Sex", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("80a9e596-0f72-498a-9fbf-627df473def0"), new DateTime(2024, 9, 1, 12, 55, 53, 106, DateTimeKind.Utc).AddTicks(1495), null, "jane.smith@example.com", "Jane", false, "Smith", "+19876543210", "10987654321", "jane_smith_profile.jpg", "Female", null },
                    { new Guid("a5f81e83-06ec-4f65-9872-7de8707ea955"), new DateTime(2024, 9, 1, 12, 55, 53, 106, DateTimeKind.Utc).AddTicks(1488), null, "john.doe@example.com", "John", false, "Doe", "+11234567890", "12345678901", "john_doe_profile.jpg", "Male", null }
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "AccountNumber", "Balance", "ClientId", "CreatedDate", "DeletedDate", "IsDeleted", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("00b1b6be-1b8a-45e1-91d2-5cbb4762b422"), "1234567890", 1000m, new Guid("a5f81e83-06ec-4f65-9872-7de8707ea955"), new DateTime(2024, 9, 1, 12, 55, 53, 106, DateTimeKind.Utc).AddTicks(1553), null, false, null },
                    { new Guid("95dcad01-4633-46f0-bc62-c1ad5074396a"), "0987654321", 500m, new Guid("80a9e596-0f72-498a-9fbf-627df473def0"), new DateTime(2024, 9, 1, 12, 55, 53, 106, DateTimeKind.Utc).AddTicks(1560), null, false, null }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "ClientId", "Country", "CreatedDate", "DeletedDate", "IsDeleted", "Street", "UpdatedDate", "ZipCode" },
                values: new object[,]
                {
                    { new Guid("1fbeac17-f493-499a-95ad-b3b5714cb476"), "Toronto", new Guid("80a9e596-0f72-498a-9fbf-627df473def0"), "Canada", new DateTime(2024, 9, 1, 12, 55, 53, 106, DateTimeKind.Utc).AddTicks(1527), null, false, "456 Maple Ave", null, "M5V 2T6" },
                    { new Guid("7917158d-88f3-433f-ad5b-7b91377c95f3"), "New York", new Guid("a5f81e83-06ec-4f65-9872-7de8707ea955"), "USA", new DateTime(2024, 9, 1, 12, 55, 53, 106, DateTimeKind.Utc).AddTicks(1523), null, false, "123 Main St", null, "10001" }
                });
        }
    }
}
