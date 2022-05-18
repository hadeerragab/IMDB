using Microsoft.EntityFrameworkCore.Migrations;

namespace IMDB.Migrations
{
    public partial class mm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Actors_actorID",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Directors_directorID",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Movies_movieID",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_actorID",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_directorID",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_movieID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FavActorID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FavDirectorID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FavMovieID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "actorID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "directorID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "movieID",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "fav",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(nullable: false),
                    userId = table.Column<string>(nullable: true),
                    FavActorID = table.Column<int>(nullable: false),
                    actorID = table.Column<int>(nullable: true),
                    FavDirectorID = table.Column<int>(nullable: false),
                    directorID = table.Column<int>(nullable: true),
                    FavMovieID = table.Column<int>(nullable: false),
                    movieID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fav", x => x.ID);
                    table.ForeignKey(
                        name: "FK_fav_Actors_actorID",
                        column: x => x.actorID,
                        principalTable: "Actors",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_fav_Directors_directorID",
                        column: x => x.directorID,
                        principalTable: "Directors",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_fav_Movies_movieID",
                        column: x => x.movieID,
                        principalTable: "Movies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_fav_AspNetUsers_userId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_fav_actorID",
                table: "fav",
                column: "actorID");

            migrationBuilder.CreateIndex(
                name: "IX_fav_directorID",
                table: "fav",
                column: "directorID");

            migrationBuilder.CreateIndex(
                name: "IX_fav_movieID",
                table: "fav",
                column: "movieID");

            migrationBuilder.CreateIndex(
                name: "IX_fav_userId",
                table: "fav",
                column: "userId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "fav");

            migrationBuilder.AddColumn<int>(
                name: "FavActorID",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FavDirectorID",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FavMovieID",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "actorID",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "directorID",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "movieID",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_actorID",
                table: "AspNetUsers",
                column: "actorID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_directorID",
                table: "AspNetUsers",
                column: "directorID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_movieID",
                table: "AspNetUsers",
                column: "movieID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Actors_actorID",
                table: "AspNetUsers",
                column: "actorID",
                principalTable: "Actors",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Directors_directorID",
                table: "AspNetUsers",
                column: "directorID",
                principalTable: "Directors",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Movies_movieID",
                table: "AspNetUsers",
                column: "movieID",
                principalTable: "Movies",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
