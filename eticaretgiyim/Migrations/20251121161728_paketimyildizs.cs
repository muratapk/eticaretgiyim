using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eticaretgiyim.Migrations
{
    /// <inheritdoc />
    public partial class paketimyildizs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "urunYildizs",
                columns: table => new
                {
                    YildizId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrunId = table.Column<int>(type: "int", nullable: true),
                    YildizSayisi = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_urunYildizs", x => x.YildizId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "urunYildizs");
        }
    }
}
