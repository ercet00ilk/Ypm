using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace YPM.Veri.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "MulkKisi");

            migrationBuilder.EnsureSchema(
                name: "MulkKurulum");

            migrationBuilder.EnsureSchema(
                name: "MulkUrun");

            migrationBuilder.EnsureSchema(
                name: "Mulk");

            migrationBuilder.CreateTable(
                name: "KategoriNitelikTbl",
                schema: "Mulk",
                columns: table => new
                {
                    UrunKategoriNitelikGercekId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ad = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KategoriNitelikTbl", x => x.UrunKategoriNitelikGercekId);
                });

            migrationBuilder.CreateTable(
                name: "Kisi",
                schema: "MulkKisi",
                columns: table => new
                {
                    KisiId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ad = table.Column<string>(maxLength: 400, nullable: true),
                    EPosta = table.Column<string>(maxLength: 150, nullable: true),
                    EpostaKontrol = table.Column<string>(maxLength: 20, nullable: true),
                    EpostaOnayliMi = table.Column<bool>(nullable: false),
                    KayitTarihi = table.Column<DateTime>(nullable: false),
                    Sifre = table.Column<string>(maxLength: 400, nullable: true),
                    Soyad = table.Column<string>(maxLength: 400, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kisi", x => x.KisiId);
                });

            migrationBuilder.CreateTable(
                name: "Kurulum",
                schema: "MulkKurulum",
                columns: table => new
                {
                    KurulumId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ad = table.Column<string>(maxLength: 200, nullable: true),
                    Sonuc = table.Column<bool>(nullable: false),
                    Tip = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kurulum", x => x.KurulumId);
                });

            migrationBuilder.CreateTable(
                name: "Kategori",
                schema: "MulkUrun",
                columns: table => new
                {
                    UrunKategoriId = table.Column<int>(nullable: false),
                    UrunUstKategoriId = table.Column<int>(nullable: false),
                    Ad = table.Column<string>(maxLength: 250, nullable: true),
                    LinkYol = table.Column<string>(maxLength: 250, nullable: true),
                    ResimYol = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategori", x => new { x.UrunKategoriId, x.UrunUstKategoriId });
                });

            migrationBuilder.CreateTable(
                name: "Lokasyon",
                schema: "MulkKisi",
                columns: table => new
                {
                    LokasyonId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IpAdr = table.Column<string>(maxLength: 200, nullable: true),
                    KayitTarihi = table.Column<DateTime>(nullable: false),
                    KisiId = table.Column<int>(nullable: false),
                    MacAdr = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lokasyon", x => x.LokasyonId);
                    table.ForeignKey(
                        name: "FK_Lokasyon_Kisi_KisiId",
                        column: x => x.KisiId,
                        principalSchema: "MulkKisi",
                        principalTable: "Kisi",
                        principalColumn: "KisiId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lokasyon_KisiId",
                schema: "MulkKisi",
                table: "Lokasyon",
                column: "KisiId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KategoriNitelikTbl",
                schema: "Mulk");

            migrationBuilder.DropTable(
                name: "Lokasyon",
                schema: "MulkKisi");

            migrationBuilder.DropTable(
                name: "Kurulum",
                schema: "MulkKurulum");

            migrationBuilder.DropTable(
                name: "Kategori",
                schema: "MulkUrun");

            migrationBuilder.DropTable(
                name: "Kisi",
                schema: "MulkKisi");
        }
    }
}
