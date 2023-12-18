using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Webbanhang_22011267.Migrations
{
    public partial class db2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CartId",
                table: "CartDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BillId",
                table: "BillDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Bill",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NgayMua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DiaChiGH = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    DienThoaiGH = table.Column<string>(type: "nchar(200)", nullable: true),
                    NguoiDungID = table.Column<int>(type: "int", nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: true),
                    NgayNhan = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bill", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NguoiDungId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DanhMucID = table.Column<int>(type: "int", nullable: true),
                    Ten = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Gia = table.Column<int>(type: "int", nullable: true),
                    SoLuong = table.Column<int>(type: "int", nullable: true),
                    NgayNhap = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ThuongHieu = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    Hinh = table.Column<string>(type: "nvarchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartDetails_CartId",
                table: "CartDetails",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_BillDetails_BillId",
                table: "BillDetails",
                column: "BillId");

            migrationBuilder.AddForeignKey(
                name: "FK_BillDetails_Bill_BillId",
                table: "BillDetails",
                column: "BillId",
                principalTable: "Bill",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CartDetails_Cart_CartId",
                table: "CartDetails",
                column: "CartId",
                principalTable: "Cart",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillDetails_Bill_BillId",
                table: "BillDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_CartDetails_Cart_CartId",
                table: "CartDetails");

            migrationBuilder.DropTable(
                name: "Bill");

            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropIndex(
                name: "IX_CartDetails_CartId",
                table: "CartDetails");

            migrationBuilder.DropIndex(
                name: "IX_BillDetails_BillId",
                table: "BillDetails");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "CartDetails");

            migrationBuilder.DropColumn(
                name: "BillId",
                table: "BillDetails");
        }
    }
}
