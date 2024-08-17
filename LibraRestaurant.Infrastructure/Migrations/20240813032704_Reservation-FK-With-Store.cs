using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraRestaurant.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ReservationFKWithStore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderHeaders",
                keyColumn: "OrderId",
                keyValue: new Guid("fb304497-a26b-4d15-8c90-fc8de10ed457"));

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "StoreId",
                keyValue: new Guid("fb304497-a26b-4d15-8c90-fc8de10ed457"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("fb304497-a26b-4d15-8c90-fc8de10ed457"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "ItemId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 8, 13, 10, 18, 21, 722, DateTimeKind.Local).AddTicks(5841));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 1,
                column: "StoreId",
                value: new Guid("bd748d2b-e2bc-400a-9ff8-5c2d5f09c0d4"));

            migrationBuilder.InsertData(
                table: "OrderHeaders",
                columns: new[] { "OrderId", "CanceledReason", "CanceledTime", "CashierId", "CompletedTime", "CustomerNotes", "DelayedTime", "Deleted", "Id", "IsCanceled", "IsCompleted", "IsPaid", "IsPreparationDelayed", "IsReady", "LatestStatus", "LatestStatusUpdate", "NumberId", "OrderNo", "PaymentMethodId", "PaymentTimeId", "PriceAdjustment", "PriceAdjustmentReason", "PriceCalculated", "ReadyTime", "ReservationId", "ServantId", "StoreId", "Subtotal", "Tax", "Total" },
                values: new object[] { new Guid("fb304497-a26b-4d15-8c90-fc8de10ed457"), null, null, new Guid("884ce607-61bf-4af8-9d49-79d1b337622c"), null, null, null, false, new Guid("fb304497-a26b-4d15-8c90-fc8de10ed457"), false, false, false, false, true, "", "", 0, "00000001", 1, 1, null, null, 1000000.0, new DateTime(2024, 8, 13, 10, 18, 21, 723, DateTimeKind.Local).AddTicks(188), 1, new Guid("df408027-f90f-41f5-80c3-bca57a950234"), new Guid("f4e80da6-4453-43c8-be02-8b54a38d93a7"), 1000000.0, 10.0, 1100000.0 });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "StoreId", "Address", "BankAccount", "BankBranch", "BankCode", "CityId", "Deleted", "DistrictId", "Email", "Fax", "GpsLocation", "Id", "IsActive", "Logo", "Name", "NumberId", "Phone", "PostalCode", "TaxCode", "WardId", "Website" },
                values: new object[] { new Guid("fb304497-a26b-4d15-8c90-fc8de10ed457"), "", null, null, null, 1, false, 1, null, null, null, new Guid("fb304497-a26b-4d15-8c90-fc8de10ed457"), true, null, "Nhà hàng Libra - Chi nhánh 1", 0, null, null, null, 1, null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Deleted", "Email", "FirstName", "LastLoggedinDate", "LastName", "Mobile", "NumberId", "Password", "RegisteredAt", "Status" },
                values: new object[] { new Guid("fb304497-a26b-4d15-8c90-fc8de10ed457"), false, "admin@email.com", "Admin", null, "User", "09091234567", 0, "$2a$12$Blal/uiFIJdYsCLTMUik/egLbfg3XhbnxBC6Sb5IKz2ZYhiU/MzL2", new DateTime(2024, 8, 13, 10, 18, 21, 722, DateTimeKind.Local).AddTicks(4425), 0 });
        }
    }
}
