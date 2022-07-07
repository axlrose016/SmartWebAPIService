using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartWebAPI.Migrations
{
    public partial class Added_Location_Libraries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lib_Barangays",
                columns: table => new
                {
                    barangayCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    barangayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    oldName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cityCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    provinceCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    regionCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    islandGroupCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lib_Barangays", x => x.barangayCode);
                });

            migrationBuilder.CreateTable(
                name: "Lib_Cities",
                columns: table => new
                {
                    cityCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    cityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    oldName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isCapital = table.Column<bool>(type: "bit", nullable: false),
                    regionCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    provinceCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    islandGroupCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lib_Cities", x => x.cityCode);
                });

            migrationBuilder.CreateTable(
                name: "Lib_Provinces",
                columns: table => new
                {
                    provinceCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    provinceName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    regionCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    islandGroupCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lib_Provinces", x => x.provinceCode);
                });

            migrationBuilder.CreateTable(
                name: "Lib_Regions",
                columns: table => new
                {
                    regionCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    regionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    islandGroupCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lib_Regions", x => x.regionCode);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lib_Barangays");

            migrationBuilder.DropTable(
                name: "Lib_Cities");

            migrationBuilder.DropTable(
                name: "Lib_Provinces");

            migrationBuilder.DropTable(
                name: "Lib_Regions");
        }
    }
}
