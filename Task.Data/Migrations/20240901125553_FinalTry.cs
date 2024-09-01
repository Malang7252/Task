using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Task.Data.Migrations
{
    /// <inheritdoc />
    public partial class FinalTry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("bd51f9cc-fc6f-4992-bc45-a50b1e5cf398"));

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("c1e2ab0c-806d-472c-88b6-b3dc8b37ee42"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("bb46273a-e362-45fb-8de8-64cab2651ab8"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("ec4e2867-b208-4906-a9fa-3e406d2339f4"));

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: new Guid("1889bb43-9ccb-4960-93f1-06b8c20fa93a"));

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: new Guid("8c1f0f20-fc33-4705-9d6e-07960d9298c2"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Clients",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Clients",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Clients",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Clients",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Addresses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Addresses",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Addresses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Addresses",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Accounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Accounts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Accounts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Accounts",
                type: "datetime2",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Accounts");

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "MobileNumber", "PersonalId", "ProfilePhoto", "Sex" },
                values: new object[,]
                {
                    { new Guid("1889bb43-9ccb-4960-93f1-06b8c20fa93a"), "john.doe@example.com", "John", "Doe", "+11234567890", "12345678901", "john_doe_profile.jpg", "Male" },
                    { new Guid("8c1f0f20-fc33-4705-9d6e-07960d9298c2"), "jane.smith@example.com", "Jane", "Smith", "+19876543210", "10987654321", "jane_smith_profile.jpg", "Female" }
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "AccountNumber", "Balance", "ClientId" },
                values: new object[,]
                {
                    { new Guid("bd51f9cc-fc6f-4992-bc45-a50b1e5cf398"), "0987654321", 500m, new Guid("8c1f0f20-fc33-4705-9d6e-07960d9298c2") },
                    { new Guid("c1e2ab0c-806d-472c-88b6-b3dc8b37ee42"), "1234567890", 1000m, new Guid("1889bb43-9ccb-4960-93f1-06b8c20fa93a") }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "ClientId", "Country", "Street", "ZipCode" },
                values: new object[,]
                {
                    { new Guid("bb46273a-e362-45fb-8de8-64cab2651ab8"), "Toronto", new Guid("8c1f0f20-fc33-4705-9d6e-07960d9298c2"), "Canada", "456 Maple Ave", "M5V 2T6" },
                    { new Guid("ec4e2867-b208-4906-a9fa-3e406d2339f4"), "New York", new Guid("1889bb43-9ccb-4960-93f1-06b8c20fa93a"), "USA", "123 Main St", "10001" }
                });
        }
    }
}
