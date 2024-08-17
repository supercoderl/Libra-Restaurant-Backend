using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraRestaurant.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class OrderUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderHeaders",
                keyColumn: "OrderId",
                keyValue: new Guid("f069e54c-b5f4-416b-8c7a-f4d22e566e60"));

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "StoreId",
                keyValue: new Guid("f069e54c-b5f4-416b-8c7a-f4d22e566e60"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f069e54c-b5f4-416b-8c7a-f4d22e566e60"));

            migrationBuilder.AlterColumn<Guid>(
                name: "ServantId",
                table: "OrderHeaders",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<int>(
                name: "PaymentTimeId",
                table: "OrderHeaders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PaymentMethodId",
                table: "OrderHeaders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LatestStatusUpdate",
                table: "OrderHeaders",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "LatestStatus",
                table: "OrderHeaders",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<Guid>(
                name: "CashierId",
                table: "OrderHeaders",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "ItemId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 8, 14, 21, 2, 26, 304, DateTimeKind.Local).AddTicks(3871));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 1,
                column: "StoreId",
                value: new Guid("52c5388c-3125-406a-8b36-756f7bf4a947"));

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "StoreId", "Address", "BankAccount", "BankBranch", "BankCode", "CityId", "Deleted", "DistrictId", "Email", "Fax", "GpsLocation", "Id", "IsActive", "Logo", "Name", "NumberId", "Phone", "PostalCode", "TaxCode", "WardId", "Website" },
                values: new object[] { new Guid("9e4af200-6f90-49e6-9b76-4ca049848214"), "", null, null, null, 1, false, 1, null, null, null, new Guid("9e4af200-6f90-49e6-9b76-4ca049848214"), true, null, "Nhà hàng Libra - Chi nhánh 1", 0, null, null, null, 1, null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Deleted", "Email", "FirstName", "LastLoggedinDate", "LastName", "Mobile", "NumberId", "Password", "RegisteredAt", "Status" },
                values: new object[] { new Guid("9e4af200-6f90-49e6-9b76-4ca049848214"), false, "admin@email.com", "Admin", null, "User", "09091234567", 0, "$2a$12$Blal/uiFIJdYsCLTMUik/egLbfg3XhbnxBC6Sb5IKz2ZYhiU/MzL2", new DateTime(2024, 8, 14, 21, 2, 26, 304, DateTimeKind.Local).AddTicks(2125), 0 });

            migrationBuilder.CreateIndex(
                name: "IX_OrderHeaders_ReservationId",
                table: "OrderHeaders",
                column: "ReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderHeader_Reservation_ReservationId",
                table: "OrderHeaders",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "ReservationId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderHeader_Reservation_ReservationId",
                table: "OrderHeaders");

            migrationBuilder.DropIndex(
                name: "IX_OrderHeaders_ReservationId",
                table: "OrderHeaders");

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "StoreId",
                keyValue: new Guid("9e4af200-6f90-49e6-9b76-4ca049848214"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9e4af200-6f90-49e6-9b76-4ca049848214"));

            migrationBuilder.AlterColumn<Guid>(
                name: "ServantId",
                table: "OrderHeaders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PaymentTimeId",
                table: "OrderHeaders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PaymentMethodId",
                table: "OrderHeaders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LatestStatusUpdate",
                table: "OrderHeaders",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<string>(
                name: "LatestStatus",
                table: "OrderHeaders",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<Guid>(
                name: "CashierId",
                table: "OrderHeaders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "ItemId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 8, 13, 10, 27, 3, 973, DateTimeKind.Local).AddTicks(1393));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 1,
                column: "StoreId",
                value: new Guid("694a1bdf-828c-401c-841d-f0caeba479e6"));

            migrationBuilder.InsertData(
                table: "OrderHeaders",
                columns: new[] { "OrderId", "CanceledReason", "CanceledTime", "CashierId", "CompletedTime", "CustomerNotes", "DelayedTime", "Deleted", "Id", "IsCanceled", "IsCompleted", "IsPaid", "IsPreparationDelayed", "IsReady", "LatestStatus", "LatestStatusUpdate", "NumberId", "OrderNo", "PaymentMethodId", "PaymentTimeId", "PriceAdjustment", "PriceAdjustmentReason", "PriceCalculated", "ReadyTime", "ReservationId", "ServantId", "StoreId", "Subtotal", "Tax", "Total" },
                values: new object[] { new Guid("f069e54c-b5f4-416b-8c7a-f4d22e566e60"), null, null, new Guid("e1b57137-bf14-4e95-8848-216b7bcb2bc7"), null, null, null, false, new Guid("f069e54c-b5f4-416b-8c7a-f4d22e566e60"), false, false, false, false, true, "", "", 0, "00000001", 1, 1, null, null, 1000000.0, new DateTime(2024, 8, 13, 10, 27, 3, 973, DateTimeKind.Local).AddTicks(7288), 1, new Guid("fd69a161-2308-4d96-a985-8288c1f9a58a"), new Guid("f6f9658f-3bb2-4c61-8ee8-5cd7b203e8c4"), 1000000.0, 10.0, 1100000.0 });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "StoreId", "Address", "BankAccount", "BankBranch", "BankCode", "CityId", "Deleted", "DistrictId", "Email", "Fax", "GpsLocation", "Id", "IsActive", "Logo", "Name", "NumberId", "Phone", "PostalCode", "TaxCode", "WardId", "Website" },
                values: new object[] { new Guid("f069e54c-b5f4-416b-8c7a-f4d22e566e60"), "", null, null, null, 1, false, 1, null, null, null, new Guid("f069e54c-b5f4-416b-8c7a-f4d22e566e60"), true, null, "Nhà hàng Libra - Chi nhánh 1", 0, null, null, null, 1, null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Deleted", "Email", "FirstName", "LastLoggedinDate", "LastName", "Mobile", "NumberId", "Password", "RegisteredAt", "Status" },
                values: new object[] { new Guid("f069e54c-b5f4-416b-8c7a-f4d22e566e60"), false, "admin@email.com", "Admin", null, "User", "09091234567", 0, "$2a$12$Blal/uiFIJdYsCLTMUik/egLbfg3XhbnxBC6Sb5IKz2ZYhiU/MzL2", new DateTime(2024, 8, 13, 10, 27, 3, 972, DateTimeKind.Local).AddTicks(9479), 0 });
        }
    }
}
