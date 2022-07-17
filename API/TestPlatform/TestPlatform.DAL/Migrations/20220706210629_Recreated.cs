using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestPlatform.DAL.Migrations
{
    public partial class Recreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "group",
                columns: table => new
                {
                    entity_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    naming = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    updated_datetype = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_group", x => x.entity_id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    entity_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    login = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    password = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    first_name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    last_name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    updated_datetype = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.entity_id);
                    table.UniqueConstraint("AK_user_login", x => x.login);
                });

            migrationBuilder.CreateTable(
                name: "student",
                columns: table => new
                {
                    entity_id = table.Column<int>(type: "int", nullable: false),
                    assgined_group_id = table.Column<int>(type: "int", nullable: false),
                    updated_datetype = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_student", x => x.entity_id);
                    table.ForeignKey(
                        name: "FK_student_group_assgined_group_id",
                        column: x => x.assgined_group_id,
                        principalTable: "group",
                        principalColumn: "entity_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_student_user_entity_id",
                        column: x => x.entity_id,
                        principalTable: "user",
                        principalColumn: "entity_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "teacher",
                columns: table => new
                {
                    entity_id = table.Column<int>(type: "int", nullable: false),
                    updated_datetype = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teacher", x => x.entity_id);
                    table.ForeignKey(
                        name: "FK_teacher_user_entity_id",
                        column: x => x.entity_id,
                        principalTable: "user",
                        principalColumn: "entity_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "test",
                columns: table => new
                {
                    entity_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    is_closed = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    updated_datetype = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_test", x => x.entity_id);
                    table.ForeignKey(
                        name: "FK_test_teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "teacher",
                        principalColumn: "entity_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupTest",
                columns: table => new
                {
                    AssignedGroupsId = table.Column<int>(type: "int", nullable: false),
                    AssignedTestsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupTest", x => new { x.AssignedGroupsId, x.AssignedTestsId });
                    table.ForeignKey(
                        name: "FK_GroupTest_group_AssignedGroupsId",
                        column: x => x.AssignedGroupsId,
                        principalTable: "group",
                        principalColumn: "entity_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupTest_test_AssignedTestsId",
                        column: x => x.AssignedTestsId,
                        principalTable: "test",
                        principalColumn: "entity_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "test_question",
                columns: table => new
                {
                    entity_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    is_multiselect = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    TestId = table.Column<int>(type: "int", nullable: false),
                    updated_datetype = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_test_question", x => x.entity_id);
                    table.ForeignKey(
                        name: "FK_test_question_test_TestId",
                        column: x => x.TestId,
                        principalTable: "test",
                        principalColumn: "entity_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "question_option",
                columns: table => new
                {
                    entity_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    content = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    points = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    test_question_id = table.Column<int>(type: "int", nullable: false),
                    updated_datetype = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_question_option", x => x.entity_id);
                    table.ForeignKey(
                        name: "FK_question_option_test_question_test_question_id",
                        column: x => x.test_question_id,
                        principalTable: "test_question",
                        principalColumn: "entity_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupTest_AssignedTestsId",
                table: "GroupTest",
                column: "AssignedTestsId");

            migrationBuilder.CreateIndex(
                name: "IX_question_option_test_question_id",
                table: "question_option",
                column: "test_question_id");

            migrationBuilder.CreateIndex(
                name: "IX_student_assgined_group_id",
                table: "student",
                column: "assgined_group_id");

            migrationBuilder.CreateIndex(
                name: "IX_test_TeacherId",
                table: "test",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_test_question_TestId",
                table: "test_question",
                column: "TestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupTest");

            migrationBuilder.DropTable(
                name: "question_option");

            migrationBuilder.DropTable(
                name: "student");

            migrationBuilder.DropTable(
                name: "test_question");

            migrationBuilder.DropTable(
                name: "group");

            migrationBuilder.DropTable(
                name: "test");

            migrationBuilder.DropTable(
                name: "teacher");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
