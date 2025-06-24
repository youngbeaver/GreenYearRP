using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServerSide.Migrations
{
    /// <inheritdoc />
    public partial class UpdateNamesAndAddNewTables2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Reason",
                table: "ban_lists",
                newName: "reason");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ban_lists",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "StartDateTime",
                table: "ban_lists",
                newName: "start_date_time");

            migrationBuilder.RenameColumn(
                name: "PlayerId",
                table: "ban_lists",
                newName: "player_id");

            migrationBuilder.RenameColumn(
                name: "EndDateTime",
                table: "ban_lists",
                newName: "end_date_time");

            migrationBuilder.RenameColumn(
                name: "AdminId",
                table: "ban_lists",
                newName: "admin_id");

            migrationBuilder.RenameColumn(
                name: "BanType",
                table: "ban_lists",
                newName: "type_blocking");

            migrationBuilder.CreateTable(
                name: "characters",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    account_id = table.Column<int>(type: "int", nullable: false),
                    nickname = table.Column<int>(type: "int", nullable: false),
                    exp = table.Column<int>(type: "int", nullable: false),
                    money = table.Column<int>(type: "int", nullable: false),
                    bank_money = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_characters", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "characters");

            migrationBuilder.RenameColumn(
                name: "reason",
                table: "ban_lists",
                newName: "Reason");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "ban_lists",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "start_date_time",
                table: "ban_lists",
                newName: "StartDateTime");

            migrationBuilder.RenameColumn(
                name: "player_id",
                table: "ban_lists",
                newName: "PlayerId");

            migrationBuilder.RenameColumn(
                name: "end_date_time",
                table: "ban_lists",
                newName: "EndDateTime");

            migrationBuilder.RenameColumn(
                name: "admin_id",
                table: "ban_lists",
                newName: "AdminId");

            migrationBuilder.RenameColumn(
                name: "type_blocking",
                table: "ban_lists",
                newName: "BanType");
        }
    }
}
