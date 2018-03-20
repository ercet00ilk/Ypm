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

            migrationBuilder.CreateTable(
                name: "KurulumTbl",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ad = table.Column<string>(nullable: true),
                    Sonuc = table.Column<bool>(nullable: false),
                    Tip = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KurulumTbl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kisi",
                schema: "MulkKisi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ad = table.Column<string>(maxLength: 400, nullable: true),
                    EPosta = table.Column<string>(maxLength: 150, nullable: true),
                    Sifre = table.Column<string>(maxLength: 400, nullable: true),
                    Soyad = table.Column<string>(maxLength: 400, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kisi", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KurulumTbl");

            migrationBuilder.DropTable(
                name: "Kisi",
                schema: "MulkKisi");
        }
    }
}
