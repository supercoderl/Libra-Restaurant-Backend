using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraRestaurant.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Order : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e3be85b7-caef-4dbb-8733-58aaa992a6f0"));

            migrationBuilder.CreateTable(
                name: "OrderHeaders",
                columns: table => new
                {
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StoreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaymentMethodId = table.Column<int>(type: "int", nullable: false),
                    PaymentTimeId = table.Column<int>(type: "int", nullable: false),
                    ServantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CashierId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReservationId = table.Column<int>(type: "int", nullable: false),
                    PriceCalculated = table.Column<double>(type: "float", nullable: false),
                    PriceAdjustment = table.Column<double>(type: "float", nullable: true),
                    PriceAdjustmentReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Subtotal = table.Column<double>(type: "float", nullable: false),
                    Tax = table.Column<double>(type: "float", nullable: false),
                    Total = table.Column<double>(type: "float", nullable: false),
                    LatestStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LatestStatusUpdate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsPaid = table.Column<bool>(type: "bit", nullable: false),
                    IsPreparationDelayed = table.Column<bool>(type: "bit", nullable: false),
                    DelayedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsCanceled = table.Column<bool>(type: "bit", nullable: false),
                    CanceledTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CanceledReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsReady = table.Column<bool>(type: "bit", nullable: false),
                    ReadyTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    CompletedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumberId = table.Column<int>(type: "int", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderHeaders", x => x.OrderId);
                });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "ItemId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 8, 3, 16, 55, 12, 22, DateTimeKind.Local).AddTicks(7857));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 1,
                column: "StoreId",
                value: new Guid("f46f849d-c345-4c17-a821-3cb1cf910b57"));

            migrationBuilder.InsertData(
                table: "OrderHeaders",
                columns: new[] { "OrderId", "CanceledReason", "CanceledTime", "CashierId", "CompletedTime", "CustomerNotes", "DelayedTime", "Deleted", "Id", "IsCanceled", "IsCompleted", "IsPaid", "IsPreparationDelayed", "IsReady", "LatestStatus", "LatestStatusUpdate", "NumberId", "OrderNo", "PaymentMethodId", "PaymentTimeId", "PriceAdjustment", "PriceAdjustmentReason", "PriceCalculated", "ReadyTime", "ReservationId", "ServantId", "StoreId", "Subtotal", "Tax", "Total" },
                values: new object[] { new Guid("26361ab2-1410-480d-98e2-d7b23ce84ee6"), null, null, new Guid("3a0d12b1-4867-4d3d-996a-52cc38feb2a9"), null, null, null, false, new Guid("26361ab2-1410-480d-98e2-d7b23ce84ee6"), false, false, false, false, true, "", "", 0, "00000001", 1, 1, null, null, 1000000.0, new DateTime(2024, 8, 3, 16, 55, 12, 23, DateTimeKind.Local).AddTicks(1782), 1, new Guid("55be38ae-3f3f-401d-bafb-bbcfe0677ba0"), new Guid("75bd5777-1737-4efa-9bde-5eeba646dc4b"), 1000000.0, 10.0, 1100000.0 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Deleted", "Email", "FirstName", "LastLoggedinDate", "LastName", "Mobile", "NumberId", "Password", "RegisteredAt", "Status" },
                values: new object[] { new Guid("26361ab2-1410-480d-98e2-d7b23ce84ee6"), false, "admin@email.com", "Admin", null, "User", "09091234567", 0, "$2a$12$Blal/uiFIJdYsCLTMUik/egLbfg3XhbnxBC6Sb5IKz2ZYhiU/MzL2", new DateTime(2024, 8, 3, 16, 55, 12, 22, DateTimeKind.Local).AddTicks(6409), 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderHeaders");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("26361ab2-1410-480d-98e2-d7b23ce84ee6"));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "ItemId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 8, 3, 10, 21, 2, 470, DateTimeKind.Local).AddTicks(7717));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 1,
                column: "StoreId",
                value: new Guid("14754053-7ea0-4e81-a268-cb5eae6e6140"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Deleted", "Email", "FirstName", "LastLoggedinDate", "LastName", "Mobile", "NumberId", "Password", "RegisteredAt", "Status" },
                values: new object[] { new Guid("e3be85b7-caef-4dbb-8733-58aaa992a6f0"), false, "admin@email.com", "Admin", null, "User", "09091234567", 0, "$2a$12$Blal/uiFIJdYsCLTMUik/egLbfg3XhbnxBC6Sb5IKz2ZYhiU/MzL2", new DateTime(2024, 8, 3, 10, 21, 2, 470, DateTimeKind.Local).AddTicks(6393), 0 });
        }
    }
}
