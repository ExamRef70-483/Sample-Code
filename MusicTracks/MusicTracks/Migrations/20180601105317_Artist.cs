using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MusicTracks.Migrations
{
    public partial class Artist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Artist",
                table: "MusicTrack");

            migrationBuilder.AddColumn<int>(
                name: "ArtistID",
                table: "MusicTrack",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArtistID",
                table: "MusicTrack");

            migrationBuilder.AddColumn<string>(
                name: "Artist",
                table: "MusicTrack",
                nullable: true);
        }
    }
}
