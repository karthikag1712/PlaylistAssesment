using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chinook.Migrations
{
    /// <inheritdoc />
    public partial class updteuserplaylist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserPlaylists",
                table: "UserPlaylists");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserPlaylists",
                table: "UserPlaylists",
                columns: new[] { "UserId", "PlaylistId", "TrackId" });

            migrationBuilder.CreateIndex(
                name: "IX_UserPlaylists_TrackId",
                table: "UserPlaylists",
                column: "TrackId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPlaylists_Track_TrackId",
                table: "UserPlaylists",
                column: "TrackId",
                principalTable: "Track",
                principalColumn: "TrackId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPlaylists_Track_TrackId",
                table: "UserPlaylists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserPlaylists",
                table: "UserPlaylists");

            migrationBuilder.DropIndex(
                name: "IX_UserPlaylists_TrackId",
                table: "UserPlaylists");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserPlaylists",
                table: "UserPlaylists",
                columns: new[] { "UserId", "PlaylistId" });
        }
    }
}
