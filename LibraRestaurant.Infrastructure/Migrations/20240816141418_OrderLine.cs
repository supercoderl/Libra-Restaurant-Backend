using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraRestaurant.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class OrderLine : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "StoreId",
                keyValue: new Guid("9e4af200-6f90-49e6-9b76-4ca049848214"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9e4af200-6f90-49e6-9b76-4ca049848214"));

            migrationBuilder.CreateTable(
                name: "OrderLines",
                columns: table => new
                {
                    OrderLineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    IsCanceled = table.Column<bool>(type: "bit", nullable: false),
                    CanceledTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    CanceledReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerReview = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerLike = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumberId = table.Column<int>(type: "int", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderLines", x => x.OrderLineId);
                    table.ForeignKey(
                        name: "FK_OrderLine_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "MenuItems",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderLine_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "OrderHeaders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "ItemId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 8, 16, 21, 14, 17, 113, DateTimeKind.Local).AddTicks(3541));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 1,
                column: "StoreId",
                value: new Guid("547524b4-9098-4df3-b804-fdf32d5cedf1"));

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "StoreId", "Address", "BankAccount", "BankBranch", "BankCode", "CityId", "Deleted", "DistrictId", "Email", "Fax", "GpsLocation", "Id", "IsActive", "Logo", "Name", "NumberId", "Phone", "PostalCode", "TaxCode", "WardId", "Website" },
                values: new object[] { new Guid("81791eab-6b44-4362-9176-4f64d35857cb"), "", null, null, null, 1, false, 1, null, null, null, new Guid("81791eab-6b44-4362-9176-4f64d35857cb"), true, null, "Nhà hàng Libra - Chi nhánh 1", 0, null, null, null, 1, null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Deleted", "Email", "FirstName", "LastLoggedinDate", "LastName", "Mobile", "NumberId", "Password", "RegisteredAt", "Status" },
                values: new object[] { new Guid("81791eab-6b44-4362-9176-4f64d35857cb"), false, "admin@email.com", "Admin", null, "User", "09091234567", 0, "$2a$12$Blal/uiFIJdYsCLTMUik/egLbfg3XhbnxBC6Sb5IKz2ZYhiU/MzL2", new DateTime(2024, 8, 16, 21, 14, 17, 110, DateTimeKind.Local).AddTicks(5751), 0 });

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_ItemId",
                table: "OrderLines",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_OrderId",
                table: "OrderLines",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderLines");

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "StoreId",
                keyValue: new Guid("81791eab-6b44-4362-9176-4f64d35857cb"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("81791eab-6b44-4362-9176-4f64d35857cb"));

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
        }
    }
}
