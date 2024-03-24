using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hafta10.Web.Migrations
{
    /// <inheritdoc />
    public partial class kayitmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "kullanicilar",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KullaniciSoyadi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KullaniciYas = table.Column<int>(type: "int", nullable: false),
                    KullaniciEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KullaniciSifre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kullanicilar", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "kullanicilar");
        }
    }
}
