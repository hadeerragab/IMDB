using Microsoft.EntityFrameworkCore.Migrations;

namespace IMDB.Migrations
{
    public partial class fav : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fav_ActorID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Fav_DirectorID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Fav_MovieID",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "FavActorID",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FavDirectorID",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FavMovieID",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "actorID",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "directorID",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "movieID",
                table: "AspNetUsers",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "Fav_ActorID",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Fav_DirectorID",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Fav_MovieID",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
