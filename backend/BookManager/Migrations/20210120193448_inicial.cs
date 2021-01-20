using Microsoft.EntityFrameworkCore.Migrations;

namespace BookManager.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "tbl");

            migrationBuilder.CreateTable(
                name: "Author",
                schema: "tbl",
                columns: table => new
                {
                    AuthorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("AuthorId", x => x.AuthorId);
                });

            migrationBuilder.CreateTable(
                name: "Editor",
                schema: "tbl",
                columns: table => new
                {
                    EditorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("EditorId", x => x.EditorId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "tbl",
                columns: table => new
                {
                    AuthorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("UserId", x => x.AuthorId);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                schema: "tbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ISBN = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    numberPages = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    EditorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Book_Author_AuthorId",
                        column: x => x.AuthorId,
                        principalSchema: "tbl",
                        principalTable: "Author",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Book_Editor_EditorId",
                        column: x => x.EditorId,
                        principalSchema: "tbl",
                        principalTable: "Editor",
                        principalColumn: "EditorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookUsers",
                schema: "tbl",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    BookRead = table.Column<bool>(type: "bit", nullable: false),
                    BorrowedBook = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookUsers", x => new { x.BookId, x.UserId });
                    table.ForeignKey(
                        name: "FK_BookUsers_Book_BookId",
                        column: x => x.BookId,
                        principalSchema: "tbl",
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookUsers_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "tbl",
                        principalTable: "User",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_AuthorId",
                schema: "tbl",
                table: "Book",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Book_EditorId",
                schema: "tbl",
                table: "Book",
                column: "EditorId");

            migrationBuilder.CreateIndex(
                name: "IX_BookUsers_UserId",
                schema: "tbl",
                table: "BookUsers",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookUsers",
                schema: "tbl");

            migrationBuilder.DropTable(
                name: "Book",
                schema: "tbl");

            migrationBuilder.DropTable(
                name: "User",
                schema: "tbl");

            migrationBuilder.DropTable(
                name: "Author",
                schema: "tbl");

            migrationBuilder.DropTable(
                name: "Editor",
                schema: "tbl");
        }
    }
}
