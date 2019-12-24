using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace NfcAdapters.Database.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdapterTypes",
                columns: table => new
                {
                    AdapterTypeId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdapterTypes", x => x.AdapterTypeId);
                });

            migrationBuilder.CreateTable(
                name: "DbUsers",
                columns: table => new
                {
                    DbUserId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AuthKey = table.Column<string>(nullable: false),
                    Username = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Authorized = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbUsers", x => x.DbUserId);
                });

            migrationBuilder.CreateTable(
                name: "Adapters",
                columns: table => new
                {
                    AdapterId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AdapterTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adapters", x => x.AdapterId);
                    table.ForeignKey(
                        name: "FK_Adapters_AdapterTypes_AdapterTypeId",
                        column: x => x.AdapterTypeId,
                        principalTable: "AdapterTypes",
                        principalColumn: "AdapterTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lendings",
                columns: table => new
                {
                    LendingId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AdapterId = table.Column<int>(nullable: false),
                    Username = table.Column<string>(nullable: false),
                    LendingStart = table.Column<DateTime>(nullable: false),
                    Returned = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lendings", x => x.LendingId);
                    table.ForeignKey(
                        name: "FK_Lendings_Adapters_AdapterId",
                        column: x => x.AdapterId,
                        principalTable: "Adapters",
                        principalColumn: "AdapterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adapters_AdapterTypeId",
                table: "Adapters",
                column: "AdapterTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Lendings_AdapterId",
                table: "Lendings",
                column: "AdapterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DbUsers");

            migrationBuilder.DropTable(
                name: "Lendings");

            migrationBuilder.DropTable(
                name: "Adapters");

            migrationBuilder.DropTable(
                name: "AdapterTypes");
        }
    }
}
