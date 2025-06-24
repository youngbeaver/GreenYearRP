using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServerSide.Migrations
{
    /// <inheritdoc />
    public partial class UpdateNamesAndAddNewTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Serial",
                table: "accounts",
                newName: "serial");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "accounts",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "Login",
                table: "accounts",
                newName: "login");

            migrationBuilder.RenameColumn(
                name: "IP",
                table: "accounts",
                newName: "ip");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "accounts",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "accounts",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "SocialID",
                table: "accounts",
                newName: "social_id");

            migrationBuilder.AddColumn<int>(
                name: "donate_count",
                table: "accounts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "donate_count",
                table: "accounts");

            migrationBuilder.RenameColumn(
                name: "serial",
                table: "accounts",
                newName: "Serial");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "accounts",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "login",
                table: "accounts",
                newName: "Login");

            migrationBuilder.RenameColumn(
                name: "ip",
                table: "accounts",
                newName: "IP");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "accounts",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "accounts",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "social_id",
                table: "accounts",
                newName: "SocialID");
        }
    }
}
