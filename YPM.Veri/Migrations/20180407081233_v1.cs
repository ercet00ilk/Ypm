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
                name: "UrunKategori",
                schema: "MulkUrun",
                columns: table => new
                {
                    UrunKategoriId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Aciklama = table.Column<string>(maxLength: 400, nullable: true),
                    Ad = table.Column<string>(maxLength: 250, nullable: true),
                    AktifMi = table.Column<bool>(nullable: false),
                    AnahtarKelime = table.Column<string>(maxLength: 400, nullable: true),
                    BabaId = table.Column<int>(nullable: false),
                    SayfaBaslik = table.Column<string>(maxLength: 250, nullable: true),
                    Tanim = table.Column<string>(maxLength: 400, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UrunKategori", x => x.UrunKategoriId);
                });

            migrationBuilder.CreateTable(
                name: "UrunNitelik",
                schema: "MulkUrun",
                columns: table => new
                {
                    UrunOzellikId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ad = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UrunNitelik", x => x.UrunOzellikId);
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

            migrationBuilder.CreateTable(
                name: "UrunKategoriNitelik",
                schema: "MulkUrun",
                columns: table => new
                {
                    UrunKategoriOzellikId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UrunKategoriId = table.Column<int>(nullable: false),
                    UrunOzellikId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UrunKategoriNitelik", x => new { x.UrunKategoriOzellikId, x.UrunKategoriId, x.UrunOzellikId });
                    table.ForeignKey(
                        name: "FK_UrunKategoriNitelik_UrunKategori_UrunKategoriId",
                        column: x => x.UrunKategoriId,
                        principalSchema: "MulkUrun",
                        principalTable: "UrunKategori",
                        principalColumn: "UrunKategoriId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UrunKategoriNitelik_UrunNitelik_UrunOzellikId",
                        column: x => x.UrunOzellikId,
                        principalSchema: "MulkUrun",
                        principalTable: "UrunNitelik",
                        principalColumn: "UrunOzellikId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lokasyon_KisiId",
                schema: "MulkKisi",
                table: "Lokasyon",
                column: "KisiId");

            migrationBuilder.CreateIndex(
                name: "IX_UrunKategoriNitelik_UrunKategoriId",
                schema: "MulkUrun",
                table: "UrunKategoriNitelik",
                column: "UrunKategoriId");

            migrationBuilder.CreateIndex(
                name: "IX_UrunKategoriNitelik_UrunOzellikId",
                schema: "MulkUrun",
                table: "UrunKategoriNitelik",
                column: "UrunOzellikId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lokasyon",
                schema: "MulkKisi");

            migrationBuilder.DropTable(
                name: "Kurulum",
                schema: "MulkKurulum");

            migrationBuilder.DropTable(
                name: "UrunKategoriNitelik",
                schema: "MulkUrun");

            migrationBuilder.DropTable(
                name: "Kisi",
                schema: "MulkKisi");

            migrationBuilder.DropTable(
                name: "UrunKategori",
                schema: "MulkUrun");

            migrationBuilder.DropTable(
                name: "UrunNitelik",
                schema: "MulkUrun");
        }
    }
}
