using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bai4.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Khoas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenKhoa = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Khoas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SinhViens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaSV = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GioiTinh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SoDienThoai = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    KhoaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SinhViens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SinhViens_Khoas_KhoaId",
                        column: x => x.KhoaId,
                        principalTable: "Khoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Khoas",
                columns: new[] { "Id", "TenKhoa" },
                values: new object[,]
                {
                    { 1, "Công nghệ thông tin" },
                    { 2, "Kinh tế" },
                    { 3, "Ngoại ngữ" },
                    { 4, "Điện - Điện tử" }
                });

            migrationBuilder.InsertData(
                table: "SinhViens",
                columns: new[] { "Id", "DiaChi", "Email", "GioiTinh", "HoTen", "KhoaId", "MaSV", "NgaySinh", "SoDienThoai" },
                values: new object[,]
                {
                    { 1, "Hà Nội", "trung.nv@example.com", "Nam", "Nguyễn Văn Trung", 1, "SV001", new DateTime(2004, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "0901234567" },
                    { 2, "Yên Bái", "huong.tt@example.com", "Nữ", "Trần Thị Hường", 2, "SV002", new DateTime(2004, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "0912345678" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SinhViens_KhoaId",
                table: "SinhViens",
                column: "KhoaId");

            migrationBuilder.CreateIndex(
                name: "IX_SinhViens_MaSV",
                table: "SinhViens",
                column: "MaSV",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SinhViens");

            migrationBuilder.DropTable(
                name: "Khoas");
        }
    }
}
