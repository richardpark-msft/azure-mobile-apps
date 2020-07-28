using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogServer.Database.Migrations
{
    public partial class InitialModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(nullable: false),
                    Version = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    AvatarURL = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BlogPosts",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(nullable: false),
                    Version = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Data = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    CommentCount = table.Column<int>(nullable: false),
                    OwnerId = table.Column<string>(nullable: true),
                    PostedAt = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogPosts_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bookmark",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(nullable: false),
                    Version = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    PostId = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookmark", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookmark_BlogPosts_PostId",
                        column: x => x.PostId,
                        principalTable: "BlogPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bookmark_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PostComments",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(nullable: false),
                    Version = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    PostId = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true),
                    OwnerId = table.Column<string>(nullable: true),
                    PostedAt = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostComments_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostComments_BlogPosts_PostId",
                        column: x => x.PostId,
                        principalTable: "BlogPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogPosts_OwnerId",
                table: "BlogPosts",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookmark_PostId",
                table: "Bookmark",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookmark_UserId",
                table: "Bookmark",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PostComments_OwnerId",
                table: "PostComments",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_PostComments_PostId",
                table: "PostComments",
                column: "PostId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookmark");

            migrationBuilder.DropTable(
                name: "PostComments");

            migrationBuilder.DropTable(
                name: "BlogPosts");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
