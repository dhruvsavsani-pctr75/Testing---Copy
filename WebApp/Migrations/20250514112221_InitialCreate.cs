using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "role",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    role = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("role_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    username = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    role_id = table.Column<int>(type: "integer", nullable: false),
                    createdtime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    lastmodifiedtime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    createdby = table.Column<int>(type: "integer", nullable: false),
                    modifiedby = table.Column<int>(type: "integer", nullable: false),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("user_pkey", x => x.id);
                    table.ForeignKey(
                        name: "fk_createdby",
                        column: x => x.createdby,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_modifiedby",
                        column: x => x.modifiedby,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_role_id",
                        column: x => x.role_id,
                        principalTable: "role",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "id", "role" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "User" }
                });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "id", "createdby", "createdtime", "isdeleted", "lastmodifiedtime", "modifiedby", "password", "role_id", "username" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 5, 14, 16, 52, 21, 386, DateTimeKind.Local).AddTicks(4242), false, new DateTime(2025, 5, 14, 16, 52, 21, 386, DateTimeKind.Local).AddTicks(4252), 1, "GYTHWp4fhH6h5hv/WFDkR9zOqaNkQq4I2paR3u9yflY=", 1, "dhruvsavsani1" },
                    { 2, 1, new DateTime(2025, 5, 14, 16, 52, 21, 386, DateTimeKind.Local).AddTicks(4256), false, new DateTime(2025, 5, 14, 16, 52, 21, 386, DateTimeKind.Local).AddTicks(4256), 1, "GYTHWp4fhH6h5hv/WFDkR9zOqaNkQq4I2paR3u9yflY=", 2, "dhruvsavsani2" },
                    { 3, 1, new DateTime(2025, 5, 14, 16, 52, 21, 386, DateTimeKind.Local).AddTicks(4258), false, new DateTime(2025, 5, 14, 16, 52, 21, 386, DateTimeKind.Local).AddTicks(4258), 1, "GYTHWp4fhH6h5hv/WFDkR9zOqaNkQq4I2paR3u9yflY=", 2, "dhruvsavsani3" },
                    { 4, 1, new DateTime(2025, 5, 14, 16, 52, 21, 386, DateTimeKind.Local).AddTicks(4260), false, new DateTime(2025, 5, 14, 16, 52, 21, 386, DateTimeKind.Local).AddTicks(4260), 1, "GYTHWp4fhH6h5hv/WFDkR9zOqaNkQq4I2paR3u9yflY=", 2, "dhruvsavsani4" },
                    { 5, 1, new DateTime(2025, 5, 14, 16, 52, 21, 386, DateTimeKind.Local).AddTicks(4262), false, new DateTime(2025, 5, 14, 16, 52, 21, 386, DateTimeKind.Local).AddTicks(4262), 1, "GYTHWp4fhH6h5hv/WFDkR9zOqaNkQq4I2paR3u9yflY=", 2, "dhruvsavsani5" },
                    { 6, 1, new DateTime(2025, 5, 14, 16, 52, 21, 386, DateTimeKind.Local).AddTicks(4264), false, new DateTime(2025, 5, 14, 16, 52, 21, 386, DateTimeKind.Local).AddTicks(4264), 1, "GYTHWp4fhH6h5hv/WFDkR9zOqaNkQq4I2paR3u9yflY=", 2, "dhruvsavsani6" },
                    { 7, 1, new DateTime(2025, 5, 14, 16, 52, 21, 386, DateTimeKind.Local).AddTicks(4266), false, new DateTime(2025, 5, 14, 16, 52, 21, 386, DateTimeKind.Local).AddTicks(4266), 1, "GYTHWp4fhH6h5hv/WFDkR9zOqaNkQq4I2paR3u9yflY=", 2, "dhruvsavsani7" },
                    { 8, 1, new DateTime(2025, 5, 14, 16, 52, 21, 386, DateTimeKind.Local).AddTicks(4268), false, new DateTime(2025, 5, 14, 16, 52, 21, 386, DateTimeKind.Local).AddTicks(4268), 1, "GYTHWp4fhH6h5hv/WFDkR9zOqaNkQq4I2paR3u9yflY=", 2, "dhruvsavsani8" },
                    { 9, 1, new DateTime(2025, 5, 14, 16, 52, 21, 386, DateTimeKind.Local).AddTicks(4311), false, new DateTime(2025, 5, 14, 16, 52, 21, 386, DateTimeKind.Local).AddTicks(4311), 1, "GYTHWp4fhH6h5hv/WFDkR9zOqaNkQq4I2paR3u9yflY=", 2, "dhruvsavsani9" },
                    { 10, 1, new DateTime(2025, 5, 14, 16, 52, 21, 386, DateTimeKind.Local).AddTicks(4313), false, new DateTime(2025, 5, 14, 16, 52, 21, 386, DateTimeKind.Local).AddTicks(4313), 1, "GYTHWp4fhH6h5hv/WFDkR9zOqaNkQq4I2paR3u9yflY=", 2, "dhruvsavsani10" },
                    { 11, 1, new DateTime(2025, 5, 14, 16, 52, 21, 386, DateTimeKind.Local).AddTicks(4315), false, new DateTime(2025, 5, 14, 16, 52, 21, 386, DateTimeKind.Local).AddTicks(4315), 1, "GYTHWp4fhH6h5hv/WFDkR9zOqaNkQq4I2paR3u9yflY=", 2, "dhruvsavsani11" },
                    { 12, 1, new DateTime(2025, 5, 14, 16, 52, 21, 386, DateTimeKind.Local).AddTicks(4316), false, new DateTime(2025, 5, 14, 16, 52, 21, 386, DateTimeKind.Local).AddTicks(4317), 1, "GYTHWp4fhH6h5hv/WFDkR9zOqaNkQq4I2paR3u9yflY=", 2, "dhruvsavsani12" }
                });

            migrationBuilder.CreateIndex(
                name: "role_role_key",
                table: "role",
                column: "role",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_createdby",
                table: "user",
                column: "createdby");

            migrationBuilder.CreateIndex(
                name: "IX_user_modifiedby",
                table: "user",
                column: "modifiedby");

            migrationBuilder.CreateIndex(
                name: "IX_user_role_id",
                table: "user",
                column: "role_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "role");
        }
    }
}
