using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chinook.Migrations
{
    /// <inheritdoc />
    public partial class UpdateIdentitycolumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FavouriteTracks" +
                "",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    PlaylistId = table.Column<long>(type: "INTEGER", nullable: false),
                     TrackId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavouriteTracks", x => new { x.UserId, x.PlaylistId,x.TrackId });
                    table.ForeignKey(
                        name: "FK_FavouriteTracks_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavouriteTracks_Playlist_PlaylistId",
                        column: x => x.PlaylistId,
                        principalTable: "Playlist",
                        principalColumn: "PlaylistId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                       name: "FK_FavouriteTracks_Track_TrackId",
                       column: x => x.TrackId,
                       principalTable: "Track",
                       principalColumn: "TrackId",
                       onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FavouriteTracks_PlaylistId",
                table: "FavouriteTracks",
                column: "PlaylistId");
            migrationBuilder.CreateIndex(
               name: "IX_FavouriteTracks_TrackId",
               table: "FavouriteTracks",
               column: "TrackId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavouriteTracks");

        }
    }
}
