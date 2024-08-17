using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraRestaurant.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Reservation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderHeaders",
                keyColumn: "OrderId",
                keyValue: new Guid("a23aa816-d99a-4f80-bc99-3855450fdfe0"));

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "StoreId",
                keyValue: new Guid("a23aa816-d99a-4f80-bc99-3855450fdfe0"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a23aa816-d99a-4f80-bc99-3855450fdfe0"));

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    ReservationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TableNumber = table.Column<int>(type: "int", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    StoreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReservationTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumberId = table.Column<int>(type: "int", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.ReservationId);
                });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "ItemId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 8, 13, 8, 26, 6, 94, DateTimeKind.Local).AddTicks(4201));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 1,
                column: "StoreId",
                value: new Guid("1160416b-48e4-496a-98dc-23646d5e7487"));

            migrationBuilder.InsertData(
                table: "OrderHeaders",
                columns: new[] { "OrderId", "CanceledReason", "CanceledTime", "CashierId", "CompletedTime", "CustomerNotes", "DelayedTime", "Deleted", "Id", "IsCanceled", "IsCompleted", "IsPaid", "IsPreparationDelayed", "IsReady", "LatestStatus", "LatestStatusUpdate", "NumberId", "OrderNo", "PaymentMethodId", "PaymentTimeId", "PriceAdjustment", "PriceAdjustmentReason", "PriceCalculated", "ReadyTime", "ReservationId", "ServantId", "StoreId", "Subtotal", "Tax", "Total" },
                values: new object[] { new Guid("0d9d0716-9db9-4770-9a11-c926f60eaa34"), null, null, new Guid("1c5561fb-7227-47df-9598-54a989ccd32c"), null, null, null, false, new Guid("0d9d0716-9db9-4770-9a11-c926f60eaa34"), false, false, false, false, true, "", "", 0, "00000001", 1, 1, null, null, 1000000.0, new DateTime(2024, 8, 13, 8, 26, 6, 95, DateTimeKind.Local).AddTicks(36), 1, new Guid("2ba1215c-ff61-4c27-b5f8-74a9715f33b0"), new Guid("c96c1fd7-978d-4233-ab01-8719d4aa1ca8"), 1000000.0, 10.0, 1100000.0 });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "StoreId", "Address", "BankAccount", "BankBranch", "BankCode", "CityId", "Deleted", "DistrictId", "Email", "Fax", "GpsLocation", "Id", "IsActive", "Logo", "Name", "NumberId", "Phone", "PostalCode", "TaxCode", "WardId", "Website" },
                values: new object[] { new Guid("0d9d0716-9db9-4770-9a11-c926f60eaa34"), "", null, null, null, 1, false, 1, null, null, null, new Guid("0d9d0716-9db9-4770-9a11-c926f60eaa34"), true, null, "Nhà hàng Libra - Chi nhánh 1", 0, null, null, null, 1, null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Deleted", "Email", "FirstName", "LastLoggedinDate", "LastName", "Mobile", "NumberId", "Password", "RegisteredAt", "Status" },
                values: new object[] { new Guid("0d9d0716-9db9-4770-9a11-c926f60eaa34"), false, "admin@email.com", "Admin", null, "User", "09091234567", 0, "$2a$12$Blal/uiFIJdYsCLTMUik/egLbfg3XhbnxBC6Sb5IKz2ZYhiU/MzL2", new DateTime(2024, 8, 13, 8, 26, 6, 94, DateTimeKind.Local).AddTicks(1790), 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DeleteData(
                table: "OrderHeaders",
                keyColumn: "OrderId",
                keyValue: new Guid("0d9d0716-9db9-4770-9a11-c926f60eaa34"));

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "StoreId",
                keyValue: new Guid("0d9d0716-9db9-4770-9a11-c926f60eaa34"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0d9d0716-9db9-4770-9a11-c926f60eaa34"));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "ItemId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 8, 11, 20, 28, 11, 89, DateTimeKind.Local).AddTicks(9698));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 1,
                column: "StoreId",
                value: new Guid("33285ff4-f459-4fff-851a-b21d61e5f3ad"));

            migrationBuilder.InsertData(
                table: "OrderHeaders",
                columns: new[] { "OrderId", "CanceledReason", "CanceledTime", "CashierId", "CompletedTime", "CustomerNotes", "DelayedTime", "Deleted", "Id", "IsCanceled", "IsCompleted", "IsPaid", "IsPreparationDelayed", "IsReady", "LatestStatus", "LatestStatusUpdate", "NumberId", "OrderNo", "PaymentMethodId", "PaymentTimeId", "PriceAdjustment", "PriceAdjustmentReason", "PriceCalculated", "ReadyTime", "ReservationId", "ServantId", "StoreId", "Subtotal", "Tax", "Total" },
                values: new object[] { new Guid("a23aa816-d99a-4f80-bc99-3855450fdfe0"), null, null, new Guid("2da0f2ad-20a6-4c88-a8ec-b223e731af52"), null, null, null, false, new Guid("a23aa816-d99a-4f80-bc99-3855450fdfe0"), false, false, false, false, true, "", "", 0, "00000001", 1, 1, null, null, 1000000.0, new DateTime(2024, 8, 11, 20, 28, 11, 90, DateTimeKind.Local).AddTicks(4696), 1, new Guid("983c799b-df0b-42b8-9ed9-9b483d3be7a7"), new Guid("8a0af2be-f3b9-439b-bbfa-71579a3a185b"), 1000000.0, 10.0, 1100000.0 });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "StoreId", "Address", "BankAccount", "BankBranch", "BankCode", "CityId", "Deleted", "DistrictId", "Email", "Fax", "GpsLocation", "Id", "IsActive", "Logo", "Name", "NumberId", "Phone", "PostalCode", "TaxCode", "WardId", "Website" },
                values: new object[] { new Guid("a23aa816-d99a-4f80-bc99-3855450fdfe0"), "", null, null, null, 1, false, 1, null, null, null, new Guid("a23aa816-d99a-4f80-bc99-3855450fdfe0"), true, null, "Nhà hàng Libra - Chi nhánh 1", 0, null, null, null, 1, null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Deleted", "Email", "FirstName", "LastLoggedinDate", "LastName", "Mobile", "NumberId", "Password", "RegisteredAt", "Status" },
                values: new object[] { new Guid("a23aa816-d99a-4f80-bc99-3855450fdfe0"), false, "admin@email.com", "Admin", null, "User", "09091234567", 0, "$2a$12$Blal/uiFIJdYsCLTMUik/egLbfg3XhbnxBC6Sb5IKz2ZYhiU/MzL2", new DateTime(2024, 8, 11, 20, 28, 11, 89, DateTimeKind.Local).AddTicks(7764), 0 });
        }
    }
}
