using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace YPM.Veri.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_KategoriNitelikTbl",
                schema: "Mulk",
                table: "KategoriNitelikTbl");

            migrationBuilder.RenameTable(
                name: "KategoriNitelikTbl",
                schema: "Mulk",
                newName: "KategoriNitelik",
                newSchema: "MulkUrun");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KategoriNitelik",
                schema: "MulkUrun",
                table: "KategoriNitelik",
                column: "UrunKategoriNitelikGercekId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_KategoriNitelik",
                schema: "MulkUrun",
                table: "KategoriNitelik");

            migrationBuilder.EnsureSchema(
                name: "Mulk");

            migrationBuilder.RenameTable(
                name: "KategoriNitelik",
                schema: "MulkUrun",
                newName: "KategoriNitelikTbl",
                newSchema: "Mulk");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KategoriNitelikTbl",
                schema: "Mulk",
                table: "KategoriNitelikTbl",
                column: "UrunKategoriNitelikGercekId");
        }
    }
}
