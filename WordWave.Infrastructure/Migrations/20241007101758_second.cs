using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WordWave.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogPostTag_BlogPosts_BlogPostsId",
                table: "BlogPostTag");

            migrationBuilder.DropForeignKey(
                name: "FK_BlogPostTag_Tags_TagsId",
                table: "BlogPostTag");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_BlogPosts_BlogPostId",
                table: "Comments");

            migrationBuilder.DropTable(
                name: "BlogPostTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BlogPostTag",
                table: "BlogPostTag");

            migrationBuilder.RenameColumn(
                name: "TagsId",
                table: "BlogPostTag",
                newName: "TagId");

            migrationBuilder.RenameColumn(
                name: "BlogPostsId",
                table: "BlogPostTag",
                newName: "BlogPostId");

            migrationBuilder.RenameIndex(
                name: "IX_BlogPostTag_TagsId",
                table: "BlogPostTag",
                newName: "IX_BlogPostTag_TagId");

            migrationBuilder.AlterColumn<int>(
                name: "BlogPostId",
                table: "Comments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "BlogPostTag",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "TagId",
                table: "BlogPosts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TagId1",
                table: "BlogPosts",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BlogPostTag",
                table: "BlogPostTag",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "BlogPostComments",
                columns: table => new
                {
                    BlogPostId = table.Column<int>(type: "int", nullable: false),
                    CommentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPostComments", x => new { x.BlogPostId, x.CommentId });
                    table.ForeignKey(
                        name: "FK_BlogPostComments_BlogPosts_BlogPostId",
                        column: x => x.BlogPostId,
                        principalTable: "BlogPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlogPostComments_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogPostTag_BlogPostId",
                table: "BlogPostTag",
                column: "BlogPostId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPosts_TagId",
                table: "BlogPosts",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPosts_TagId1",
                table: "BlogPosts",
                column: "TagId1");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPostComments_CommentId",
                table: "BlogPostComments",
                column: "CommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPosts_Tags_TagId",
                table: "BlogPosts",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPosts_Tags_TagId1",
                table: "BlogPosts",
                column: "TagId1",
                principalTable: "Tags",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPostTag_BlogPosts_BlogPostId",
                table: "BlogPostTag",
                column: "BlogPostId",
                principalTable: "BlogPosts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPostTag_Tags_TagId",
                table: "BlogPostTag",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_BlogPosts_BlogPostId",
                table: "Comments",
                column: "BlogPostId",
                principalTable: "BlogPosts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogPosts_Tags_TagId",
                table: "BlogPosts");

            migrationBuilder.DropForeignKey(
                name: "FK_BlogPosts_Tags_TagId1",
                table: "BlogPosts");

            migrationBuilder.DropForeignKey(
                name: "FK_BlogPostTag_BlogPosts_BlogPostId",
                table: "BlogPostTag");

            migrationBuilder.DropForeignKey(
                name: "FK_BlogPostTag_Tags_TagId",
                table: "BlogPostTag");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_BlogPosts_BlogPostId",
                table: "Comments");

            migrationBuilder.DropTable(
                name: "BlogPostComments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BlogPostTag",
                table: "BlogPostTag");

            migrationBuilder.DropIndex(
                name: "IX_BlogPostTag_BlogPostId",
                table: "BlogPostTag");

            migrationBuilder.DropIndex(
                name: "IX_BlogPosts_TagId",
                table: "BlogPosts");

            migrationBuilder.DropIndex(
                name: "IX_BlogPosts_TagId1",
                table: "BlogPosts");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "BlogPostTag");

            migrationBuilder.DropColumn(
                name: "TagId",
                table: "BlogPosts");

            migrationBuilder.DropColumn(
                name: "TagId1",
                table: "BlogPosts");

            migrationBuilder.RenameColumn(
                name: "TagId",
                table: "BlogPostTag",
                newName: "TagsId");

            migrationBuilder.RenameColumn(
                name: "BlogPostId",
                table: "BlogPostTag",
                newName: "BlogPostsId");

            migrationBuilder.RenameIndex(
                name: "IX_BlogPostTag_TagId",
                table: "BlogPostTag",
                newName: "IX_BlogPostTag_TagsId");

            migrationBuilder.AlterColumn<int>(
                name: "BlogPostId",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BlogPostTag",
                table: "BlogPostTag",
                columns: new[] { "BlogPostsId", "TagsId" });

            migrationBuilder.CreateTable(
                name: "BlogPostTags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPostTags", x => new { x.Id, x.TagId });
                    table.ForeignKey(
                        name: "FK_BlogPostTags_BlogPosts_Id",
                        column: x => x.Id,
                        principalTable: "BlogPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlogPostTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogPostTags_TagId",
                table: "BlogPostTags",
                column: "TagId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPostTag_BlogPosts_BlogPostsId",
                table: "BlogPostTag",
                column: "BlogPostsId",
                principalTable: "BlogPosts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPostTag_Tags_TagsId",
                table: "BlogPostTag",
                column: "TagsId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_BlogPosts_BlogPostId",
                table: "Comments",
                column: "BlogPostId",
                principalTable: "BlogPosts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
