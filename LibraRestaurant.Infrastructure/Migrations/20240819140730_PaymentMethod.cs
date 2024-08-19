using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraRestaurant.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PaymentMethod : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "StoreId",
                keyValue: new Guid("81791eab-6b44-4362-9176-4f64d35857cb"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("81791eab-6b44-4362-9176-4f64d35857cb"));

            migrationBuilder.CreateTable(
                name: "PaymentMethods",
                columns: table => new
                {
                    PaymentMethodId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumberId = table.Column<int>(type: "int", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethods", x => x.PaymentMethodId);
                });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "ItemId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 8, 19, 21, 7, 28, 481, DateTimeKind.Local).AddTicks(7916));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 1,
                column: "StoreId",
                value: new Guid("8e5c1803-231a-4932-9ed8-281daaebe334"));

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "StoreId", "Address", "BankAccount", "BankBranch", "BankCode", "CityId", "Deleted", "DistrictId", "Email", "Fax", "GpsLocation", "Id", "IsActive", "Logo", "Name", "NumberId", "Phone", "PostalCode", "TaxCode", "WardId", "Website" },
                values: new object[] { new Guid("faac6920-a5ba-431d-a52e-342e31b5a8de"), "", null, null, null, 1, false, 1, null, null, null, new Guid("faac6920-a5ba-431d-a52e-342e31b5a8de"), true, null, "Nhà hàng Libra - Chi nhánh 1", 0, null, null, null, 1, null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Deleted", "Email", "FirstName", "LastLoggedinDate", "LastName", "Mobile", "NumberId", "Password", "RegisteredAt", "Status" },
                values: new object[] { new Guid("faac6920-a5ba-431d-a52e-342e31b5a8de"), false, "admin@email.com", "Admin", null, "User", "09091234567", 0, "$2a$12$Blal/uiFIJdYsCLTMUik/egLbfg3XhbnxBC6Sb5IKz2ZYhiU/MzL2", new DateTime(2024, 8, 19, 21, 7, 28, 481, DateTimeKind.Local).AddTicks(4840), 0 });

            migrationBuilder.CreateIndex(
                name: "IX_OrderHeaders_PaymentMethodId",
                table: "OrderHeaders",
                column: "PaymentMethodId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderHeader_PaymentMethod_PaymentMethodId",
                table: "OrderHeaders",
                column: "PaymentMethodId",
                principalTable: "PaymentMethods",
                principalColumn: "PaymentMethodId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderHeader_PaymentMethod_PaymentMethodId",
                table: "OrderHeaders");

            migrationBuilder.DropTable(
                name: "PaymentMethods");

            migrationBuilder.DropIndex(
                name: "IX_OrderHeaders_PaymentMethodId",
                table: "OrderHeaders");

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "StoreId",
                keyValue: new Guid("faac6920-a5ba-431d-a52e-342e31b5a8de"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("faac6920-a5ba-431d-a52e-342e31b5a8de"));

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
        }
    }
}
