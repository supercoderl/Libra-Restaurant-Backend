using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraRestaurant.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Itempicture : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderHeaders",
                keyColumn: "OrderId",
                keyValue: new Guid("26361ab2-1410-480d-98e2-d7b23ce84ee6"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("26361ab2-1410-480d-98e2-d7b23ce84ee6"));

            migrationBuilder.AddColumn<string>(
                name: "Picture",
                table: "MenuItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "ItemId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Picture" },
                values: new object[] { new DateTime(2024, 8, 10, 9, 24, 47, 63, DateTimeKind.Local).AddTicks(9753), null });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 1,
                column: "StoreId",
                value: new Guid("4155a157-f2d4-4ec6-a7e1-7c1960275754"));

            migrationBuilder.InsertData(
                table: "OrderHeaders",
                columns: new[] { "OrderId", "CanceledReason", "CanceledTime", "CashierId", "CompletedTime", "CustomerNotes", "DelayedTime", "Deleted", "Id", "IsCanceled", "IsCompleted", "IsPaid", "IsPreparationDelayed", "IsReady", "LatestStatus", "LatestStatusUpdate", "NumberId", "OrderNo", "PaymentMethodId", "PaymentTimeId", "PriceAdjustment", "PriceAdjustmentReason", "PriceCalculated", "ReadyTime", "ReservationId", "ServantId", "StoreId", "Subtotal", "Tax", "Total" },
                values: new object[] { new Guid("cb532bc6-7022-4a7b-94a2-49a3f4dc4a03"), null, null, new Guid("48b49549-4eff-444e-a62d-21bfff2102c5"), null, null, null, false, new Guid("cb532bc6-7022-4a7b-94a2-49a3f4dc4a03"), false, false, false, false, true, "", "", 0, "00000001", 1, 1, null, null, 1000000.0, new DateTime(2024, 8, 10, 9, 24, 47, 64, DateTimeKind.Local).AddTicks(4526), 1, new Guid("317872ab-59ee-470e-a39a-8bf57231cd03"), new Guid("09c7a902-40c1-444a-8134-f777b5d34f9d"), 1000000.0, 10.0, 1100000.0 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Deleted", "Email", "FirstName", "LastLoggedinDate", "LastName", "Mobile", "NumberId", "Password", "RegisteredAt", "Status" },
                values: new object[] { new Guid("cb532bc6-7022-4a7b-94a2-49a3f4dc4a03"), false, "admin@email.com", "Admin", null, "User", "09091234567", 0, "$2a$12$Blal/uiFIJdYsCLTMUik/egLbfg3XhbnxBC6Sb5IKz2ZYhiU/MzL2", new DateTime(2024, 8, 10, 9, 24, 47, 63, DateTimeKind.Local).AddTicks(8062), 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderHeaders",
                keyColumn: "OrderId",
                keyValue: new Guid("cb532bc6-7022-4a7b-94a2-49a3f4dc4a03"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("cb532bc6-7022-4a7b-94a2-49a3f4dc4a03"));

            migrationBuilder.DropColumn(
                name: "Picture",
                table: "MenuItems");

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
    }
}
