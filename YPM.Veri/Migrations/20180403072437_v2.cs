using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace YPM.Veri.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MetaAnahtarKelime",
                schema: "MulkUrun",
                table: "UrunKategori",
                newName: "AnahtarKelime");

            migrationBuilder.RenameColumn(
                name: "MetaAciklama",
                schema: "MulkUrun",
                table: "UrunKategori",
                newName: "Aciklama");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AnahtarKelime",
                schema: "MulkUrun",
                table: "UrunKategori",
                newName: "MetaAnahtarKelime");

            migrationBuilder.RenameColumn(
                name: "Aciklama",
                schema: "MulkUrun",
                table: "UrunKategori",
                newName: "MetaAciklama");
        }
    }
}
