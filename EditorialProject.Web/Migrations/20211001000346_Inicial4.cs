using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EditorialProject.Web.Migrations
{
    public partial class Inicial4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reader_AspNetUsers_UserId",
                table: "Reader");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reader",
                table: "Reader");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Writers");

            migrationBuilder.DropColumn(
                name: "NumberExt",
                table: "Moderators");

            migrationBuilder.DropColumn(
                name: "NumberInt",
                table: "Moderators");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "Moderators");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "Moderators");

            migrationBuilder.DropColumn(
                name: "Town",
                table: "Moderators");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Reader");

            migrationBuilder.RenameTable(
                name: "Reader",
                newName: "Readers");

            migrationBuilder.RenameIndex(
                name: "IX_Reader_UserId",
                table: "Readers",
                newName: "IX_Readers_UserId");

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDay",
                table: "Writers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Moderators",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "Readers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Readers",
                table: "Readers",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Editions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FileFormats",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileFormats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GenreTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Novels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Synopsis = table.Column<string>(nullable: true),
                    NumberPages = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: true),
                    EditionId = table.Column<int>(nullable: true),
                    FileFormatId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Novels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Novels_Editions_EditionId",
                        column: x => x.EditionId,
                        principalTable: "Editions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Novels_FileFormats_FileFormatId",
                        column: x => x.FileFormatId,
                        principalTable: "FileFormats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Novels_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenreTypeId = table.Column<int>(nullable: true),
                    NovelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Genres_GenreTypes_GenreTypeId",
                        column: x => x.GenreTypeId,
                        principalTable: "GenreTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Genres_Novels_NovelId",
                        column: x => x.NovelId,
                        principalTable: "Novels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RegisterNovels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublishDate = table.Column<DateTime>(nullable: false),
                    NovelId = table.Column<int>(nullable: true),
                    WriterId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisterNovels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegisterNovels_Novels_NovelId",
                        column: x => x.NovelId,
                        principalTable: "Novels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RegisterNovels_Writers_WriterId",
                        column: x => x.WriterId,
                        principalTable: "Writers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Suscriptions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SuscriptionDate = table.Column<DateTime>(nullable: false),
                    ReaderId = table.Column<int>(nullable: true),
                    NovelId = table.Column<int>(nullable: true),
                    StatusId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suscriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Suscriptions_Novels_NovelId",
                        column: x => x.NovelId,
                        principalTable: "Novels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Suscriptions_Readers_ReaderId",
                        column: x => x.ReaderId,
                        principalTable: "Readers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Suscriptions_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Validations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ValidationDate = table.Column<DateTime>(nullable: false),
                    Comments = table.Column<string>(nullable: true),
                    NovelId = table.Column<int>(nullable: true),
                    StatusId = table.Column<int>(nullable: true),
                    ModeratorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Validations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Validations_Moderators_ModeratorId",
                        column: x => x.ModeratorId,
                        principalTable: "Moderators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Validations_Novels_NovelId",
                        column: x => x.NovelId,
                        principalTable: "Novels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Validations_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Moderators_StatusId",
                table: "Moderators",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Genres_GenreTypeId",
                table: "Genres",
                column: "GenreTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Genres_NovelId",
                table: "Genres",
                column: "NovelId");

            migrationBuilder.CreateIndex(
                name: "IX_Novels_EditionId",
                table: "Novels",
                column: "EditionId");

            migrationBuilder.CreateIndex(
                name: "IX_Novels_FileFormatId",
                table: "Novels",
                column: "FileFormatId");

            migrationBuilder.CreateIndex(
                name: "IX_Novels_LanguageId",
                table: "Novels",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_RegisterNovels_NovelId",
                table: "RegisterNovels",
                column: "NovelId");

            migrationBuilder.CreateIndex(
                name: "IX_RegisterNovels_WriterId",
                table: "RegisterNovels",
                column: "WriterId");

            migrationBuilder.CreateIndex(
                name: "IX_Suscriptions_NovelId",
                table: "Suscriptions",
                column: "NovelId");

            migrationBuilder.CreateIndex(
                name: "IX_Suscriptions_ReaderId",
                table: "Suscriptions",
                column: "ReaderId");

            migrationBuilder.CreateIndex(
                name: "IX_Suscriptions_StatusId",
                table: "Suscriptions",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Validations_ModeratorId",
                table: "Validations",
                column: "ModeratorId");

            migrationBuilder.CreateIndex(
                name: "IX_Validations_NovelId",
                table: "Validations",
                column: "NovelId");

            migrationBuilder.CreateIndex(
                name: "IX_Validations_StatusId",
                table: "Validations",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Moderators_Statuses_StatusId",
                table: "Moderators",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Readers_AspNetUsers_UserId",
                table: "Readers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Moderators_Statuses_StatusId",
                table: "Moderators");

            migrationBuilder.DropForeignKey(
                name: "FK_Readers_AspNetUsers_UserId",
                table: "Readers");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "RegisterNovels");

            migrationBuilder.DropTable(
                name: "Suscriptions");

            migrationBuilder.DropTable(
                name: "Validations");

            migrationBuilder.DropTable(
                name: "GenreTypes");

            migrationBuilder.DropTable(
                name: "Novels");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "Editions");

            migrationBuilder.DropTable(
                name: "FileFormats");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropIndex(
                name: "IX_Moderators_StatusId",
                table: "Moderators");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Readers",
                table: "Readers");

            migrationBuilder.DropColumn(
                name: "BirthDay",
                table: "Writers");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Moderators");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Readers");

            migrationBuilder.RenameTable(
                name: "Readers",
                newName: "Reader");

            migrationBuilder.RenameIndex(
                name: "IX_Readers_UserId",
                table: "Reader",
                newName: "IX_Reader_UserId");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Writers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "NumberExt",
                table: "Moderators",
                type: "int",
                maxLength: 50,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberInt",
                table: "Moderators",
                type: "int",
                maxLength: 50,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PostalCode",
                table: "Moderators",
                type: "int",
                maxLength: 50,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "Moderators",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Town",
                table: "Moderators",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Reader",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reader",
                table: "Reader",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reader_AspNetUsers_UserId",
                table: "Reader",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
