using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerAPI_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Update_Customer_Entity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Customers",
                type: "varchar(15)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(15)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Customers",
                type: "varchar(60)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(60)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Customers",
                type: "varchar(15)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(15)");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Customers",
                type: "varchar(60)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(60)");
        }
    }
}
