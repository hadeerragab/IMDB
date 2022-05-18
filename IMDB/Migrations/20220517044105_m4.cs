using Microsoft.EntityFrameworkCore.Migrations;

namespace IMDB.Migrations
{
    public partial class m4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Movies_MovieID",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "Commentss");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_MovieID",
                table: "Commentss",
                newName: "IX_Commentss_MovieID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Commentss",
                table: "Commentss",
                columns: new[] { "Id", "MovieID" });

            migrationBuilder.AddForeignKey(
                name: "FK_Commentss_Movies_MovieID",
                table: "Commentss",
                column: "MovieID",
                principalTable: "Movies",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commentss_Movies_MovieID",
                table: "Commentss");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Commentss",
                table: "Commentss");

            migrationBuilder.RenameTable(
                name: "Commentss",
                newName: "Comments");

            migrationBuilder.RenameIndex(
                name: "IX_Commentss_MovieID",
                table: "Comments",
                newName: "IX_Comments_MovieID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                columns: new[] { "Id", "MovieID" });

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Movies_MovieID",
                table: "Comments",
                column: "MovieID",
                principalTable: "Movies",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
