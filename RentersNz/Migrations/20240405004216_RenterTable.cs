using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentersNz.Migrations
{
    /// <inheritdoc />
    public partial class RenterTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Renter",
                columns: table => new
                {
                    RenterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RenterName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RenterDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bedrooms = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bathrooms = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnimalSupport = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SquareFootprint = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitorStandAlone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Renter", x => x.RenterId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Renter");
        }
    }
}
