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
                    status = table.Column<bool>(type: "boolean", nullable: false, defaultValueSql: "true"),
                    createdtime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    lastmodifiedtime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    createdby = table.Column<int>(type: "integer", nullable: true, defaultValueSql: "1"),
                    modifiedby = table.Column<int>(type: "integer", nullable: true, defaultValueSql: "1"),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false),
                    isfirsttime = table.Column<bool>(type: "boolean", nullable: false, defaultValueSql: "true")
                },
                constraints: table =>
                {
                    table.PrimaryKey("user_pkey", x => x.id);
                    table.ForeignKey(
                        name: "fk_createdby",
                        column: x => x.createdby,
                        principalTable: "user",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_modifiedby",
                        column: x => x.modifiedby,
                        principalTable: "user",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_role_id",
                        column: x => x.role_id,
                        principalTable: "role",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "job",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    company_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    location = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    description = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    no_of_applicant = table.Column<int>(type: "integer", nullable: false),
                    createdtime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    lastmodifiedtime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    createdby = table.Column<int>(type: "integer", nullable: true, defaultValueSql: "1"),
                    modifiedby = table.Column<int>(type: "integer", nullable: true, defaultValueSql: "1"),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("job_pkey", x => x.id);
                    table.ForeignKey(
                        name: "fk_createdby",
                        column: x => x.createdby,
                        principalTable: "user",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_modifiedby",
                        column: x => x.modifiedby,
                        principalTable: "user",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "jobapplication",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    job_id = table.Column<int>(type: "integer", nullable: false),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    status = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    resume = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    createdtime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    lastmodifiedtime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    createdby = table.Column<int>(type: "integer", nullable: true, defaultValueSql: "1"),
                    modifiedby = table.Column<int>(type: "integer", nullable: true, defaultValueSql: "1"),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("jobapplication_pkey", x => x.id);
                    table.ForeignKey(
                        name: "fk_createdby",
                        column: x => x.createdby,
                        principalTable: "user",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_job_id",
                        column: x => x.job_id,
                        principalTable: "job",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_modifiedby",
                        column: x => x.modifiedby,
                        principalTable: "user",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
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
                columns: new[] { "id", "createdby", "isdeleted", "modifiedby", "password", "role_id", "username" },
                values: new object[,]
                {
                    { 1, 1, false, 1, "GYTHWp4fhH6h5hv/WFDkR9zOqaNkQq4I2paR3u9yflY=", 1, "dhruvsavsani1" },
                    { 2, 1, false, 1, "GYTHWp4fhH6h5hv/WFDkR9zOqaNkQq4I2paR3u9yflY=", 2, "dhruvsavsani2" },
                    { 3, 1, false, 1, "GYTHWp4fhH6h5hv/WFDkR9zOqaNkQq4I2paR3u9yflY=", 2, "dhruvsavsani3" },
                    { 4, 1, false, 1, "GYTHWp4fhH6h5hv/WFDkR9zOqaNkQq4I2paR3u9yflY=", 2, "dhruvsavsani4" },
                    { 5, 1, false, 1, "GYTHWp4fhH6h5hv/WFDkR9zOqaNkQq4I2paR3u9yflY=", 2, "dhruvsavsani5" },
                    { 6, 1, false, 1, "GYTHWp4fhH6h5hv/WFDkR9zOqaNkQq4I2paR3u9yflY=", 2, "dhruvsavsani6" },
                    { 7, 1, false, 1, "GYTHWp4fhH6h5hv/WFDkR9zOqaNkQq4I2paR3u9yflY=", 2, "dhruvsavsani7" },
                    { 8, 1, false, 1, "GYTHWp4fhH6h5hv/WFDkR9zOqaNkQq4I2paR3u9yflY=", 2, "dhruvsavsani8" },
                    { 9, 1, false, 1, "GYTHWp4fhH6h5hv/WFDkR9zOqaNkQq4I2paR3u9yflY=", 2, "dhruvsavsani9" },
                    { 10, 1, false, 1, "GYTHWp4fhH6h5hv/WFDkR9zOqaNkQq4I2paR3u9yflY=", 2, "dhruvsavsani10" },
                    { 11, 1, false, 1, "GYTHWp4fhH6h5hv/WFDkR9zOqaNkQq4I2paR3u9yflY=", 2, "dhruvsavsani11" },
                    { 12, 1, false, 1, "GYTHWp4fhH6h5hv/WFDkR9zOqaNkQq4I2paR3u9yflY=", 2, "dhruvsavsani12" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_job_createdby",
                table: "job",
                column: "createdby");

            migrationBuilder.CreateIndex(
                name: "IX_job_modifiedby",
                table: "job",
                column: "modifiedby");

            migrationBuilder.CreateIndex(
                name: "IX_jobapplication_createdby",
                table: "jobapplication",
                column: "createdby");

            migrationBuilder.CreateIndex(
                name: "IX_jobapplication_job_id",
                table: "jobapplication",
                column: "job_id");

            migrationBuilder.CreateIndex(
                name: "IX_jobapplication_modifiedby",
                table: "jobapplication",
                column: "modifiedby");

            migrationBuilder.CreateIndex(
                name: "IX_jobapplication_user_id",
                table: "jobapplication",
                column: "user_id");

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
                name: "jobapplication");

            migrationBuilder.DropTable(
                name: "job");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "role");
        }
    }
}
