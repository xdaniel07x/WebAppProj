using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAppProj.Data.Migrations
{
    public partial class AnnouncementsController : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AnnouncementDesc",
                table: "Announcement",
                newName: "Announcements");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Announcements",
                table: "Announcement",
                newName: "AnnouncementDesc");
        }
    }
}
