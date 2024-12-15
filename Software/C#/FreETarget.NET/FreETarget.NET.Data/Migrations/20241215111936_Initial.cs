using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FreETarget.NET.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Range",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Range", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Target",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    IpAddress = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Target", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Track",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    No = table.Column<int>(type: "INTEGER", nullable: false),
                    RangeId = table.Column<Guid>(type: "TEXT", nullable: false),
                    TargetId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Track", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Track_Range_RangeId",
                        column: x => x.RangeId,
                        principalTable: "Range",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Track_Target_TargetId",
                        column: x => x.TargetId,
                        principalTable: "Target",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Session",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Active = table.Column<bool>(type: "INTEGER", nullable: false),
                    TargetType = table.Column<int>(type: "INTEGER", nullable: false),
                    SessionType = table.Column<int>(type: "INTEGER", nullable: false),
                    ResultType = table.Column<int>(type: "INTEGER", nullable: false),
                    TrackId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Session", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Session_Track_TrackId",
                        column: x => x.TrackId,
                        principalTable: "Track",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shot",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    No = table.Column<int>(type: "INTEGER", nullable: false),
                    X = table.Column<decimal>(type: "TEXT", nullable: false),
                    Y = table.Column<decimal>(type: "TEXT", nullable: false),
                    R = table.Column<decimal>(type: "TEXT", nullable: false),
                    A = table.Column<decimal>(type: "TEXT", nullable: false),
                    ResultInteger = table.Column<int>(type: "INTEGER", nullable: true),
                    ResultIntegerX10 = table.Column<bool>(type: "INTEGER", nullable: true),
                    ResultDecimal = table.Column<decimal>(type: "TEXT", nullable: true),
                    SessionId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shot", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shot_Session_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Session",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Session_TrackId",
                table: "Session",
                column: "TrackId");

            migrationBuilder.CreateIndex(
                name: "IX_Shot_SessionId",
                table: "Shot",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Track_RangeId",
                table: "Track",
                column: "RangeId");

            migrationBuilder.CreateIndex(
                name: "IX_Track_TargetId",
                table: "Track",
                column: "TargetId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shot");

            migrationBuilder.DropTable(
                name: "Session");

            migrationBuilder.DropTable(
                name: "Track");

            migrationBuilder.DropTable(
                name: "Range");

            migrationBuilder.DropTable(
                name: "Target");
        }
    }
}
