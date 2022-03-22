using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Rentacar.DataAccess.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationId);
                });

            migrationBuilder.CreateTable(
                name: "Make",
                columns: table => new
                {
                    MakeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MakeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MakeDescription = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Make", x => x.MakeId);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "VehicleType",
                columns: table => new
                {
                    VehicleTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleTypeName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleType", x => x.VehicleTypeId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_User_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Model",
                columns: table => new
                {
                    ModelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModelName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModelDescription = table.Column<string>(type: "text", nullable: false),
                    Year = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    NoOfSeats = table.Column<short>(type: "smallint", nullable: false),
                    MakeId = table.Column<int>(type: "int", nullable: false),
                    VehicleTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Model", x => x.ModelId);
                    table.ForeignKey(
                        name: "Fk_Make_Model_MakeId",
                        column: x => x.MakeId,
                        principalTable: "Make",
                        principalColumn: "MakeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Model_VehicleType_VehicleTypeId",
                        column: x => x.VehicleTypeId,
                        principalTable: "VehicleType",
                        principalColumn: "VehicleTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    ReviewId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Score = table.Column<short>(type: "smallint", nullable: false),
                    ModelId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.ReviewId);
                    table.ForeignKey(
                        name: "FK_Review_Model_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Model",
                        principalColumn: "ModelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Review_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    VehicleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RatePerDay = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    TransmissionType = table.Column<short>(type: "smallint", nullable: false),
                    ModelId = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.VehicleId);
                    table.ForeignKey(
                        name: "Fk_Model_Vehicle_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Model",
                        principalColumn: "ModelId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vehicle_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.BookingId);
                    table.ForeignKey(
                        name: "Fk_User_Booking_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Fk_Vehicle_Booking_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicle",
                        principalColumn: "VehicleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Booking_UserId",
                table: "Booking",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_VehicleId",
                table: "Booking",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Model_MakeId",
                table: "Model",
                column: "MakeId");

            migrationBuilder.CreateIndex(
                name: "IX_Model_VehicleTypeId",
                table: "Model",
                column: "VehicleTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_ModelId",
                table: "Review",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_UserId",
                table: "Review",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleId",
                table: "User",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_LocationId",
                table: "Vehicle",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_ModelId",
                table: "Vehicle",
                column: "ModelId");

            migrationBuilder.InsertData(
               table: "Locations",
               columns: new[] { "LocationId", "LocationName", "LocationDescription", "Address" },
               values: new object[,]
               {
                   { 1, "Sarajevo Airport", "Sarajevo Airport", "Kurta Schorka 36 71210" },
                   { 2, "Sarajevo Railway Station", "Sarajevo Railway Station", "Put zivota 2 71000" },
                   { 3, "Sarajevo City Center", "Sarajevo City Center", "Vrbanja 1 71000" },
                   { 4, "Sarajevo National Theatre", "Sarajevo National Theatre", "Obala Kulina Bana 9 71000" }
               });

            migrationBuilder.InsertData(
                table: "Make",
                columns: new[] { "MakeId", "MakeName", "MakeDescription" },
                values: new object[,]
                {
                    { 1, "Alfa Romeo", "Stellantis" },
                    { 2, "Audi", "Volkswagen Group" },
                    { 3, "BMW", "BMW Group" },
                    { 4, "Fiat", "Stellantis" },
                    { 5, "Ford", "Ford Motor Co." },
                    { 6, "Honda", "Honda Motor Co." },
                    { 7, "Hyundai", "Hyundai Motor Group" },
                    { 8, "Jeep", "Stellantis" },
                    { 9, "Kia", "Hyundai Motor Group" },
                    { 10, "Mercedes-Benz", "Daimler AG" },
                    { 11, "Mini", "BMW Group" },
                    { 12, "Nissan", "Renault-Nissan-Mitsubishi Alliance" },
                    { 13, "Porsche", "Volkswagen Group" },
                    { 14, "Toyota", "Toyota Motor Corp." },
                    { 15, "Volkswagen", "Volkswagen AG." },
                    { 16, "Volvo", "Zhejiang Geely Holding Group" }
                });

            migrationBuilder.InsertData(
               table: "Role",
               columns: new[] { "RoleId", "RoleName"},
               values: new object[,]
               {
                   {1, "Customer" },
                   {2, "Administrator" }
               });

            migrationBuilder.InsertData(
               table: "VehicleType",
               columns: new[] { "VehicleTypeId", "VehicleTypeName" },
               values: new object[,]
               {
                   {1, "Small car" },
                   {2, "Sedan" },
                   {3, "SUV" },
                   {4, "Sports car" }
               });

            migrationBuilder.InsertData(
               table: "User",
               columns: new[] { "UserId", "Email", "FirstName", "LastName", "Password", "DateCreated", "DateUpdated", "RoleId"},
               values: new object[,]
               {
                   {1, "sara", "Sara", "Dzemidzic", "password", new DateTime(2022, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                   {2, "user", "Sara", "Dzemidzic", "user", new DateTime(2022, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
               });

           migrationBuilder.InsertData(
                table: "Model",
                columns: new[] { "ModelId", "ModelName", "ModelDescription", "Year", "NoOfSeats", "MakeId", "VehicleTypeId" },
                values: new object[,]
                {
                    {1, "Stelvio", "4-wheel drive", "2018", 5, 1, 3 },
                    {2, "4C Spider", "Italian sports car", "2019", 4, 1, 4 },
                    {3, "Giulietta", "City car", "2019", 4, 1, 1 },
                    {4, "Q7", "4-wheel drive", "2021", 5, 2, 3 },
                    {5, "A8", "Estate car", "2021", 5, 2, 2 },
                    {6, "A3", "City car", "2018", 4, 2, 1 },
                    {7, "RS5", "Fast sports car", "2021", 4, 2, 4 },
                    {8, "X5", "4-wheel drive", "2021", 5, 3, 3 },
                    {9, "118d", "City car", "2020", 4, 3, 1 },
                    {10, "M4", "Fast sports car", "2021", 4, 3, 4 },
                    {11, "730d", "Estate car", "2021", 5, 3, 2 },
                    {12, "Punto", "City car", "2017", 4, 4, 1 },
                    {13, "Stilo", "City car", "2017", 4, 4, 1 },
                    {14, "Kuga", "4-wheel drive", "2019", 5, 5, 3 },
                    {15, "Fiesta", "City car", "2017", 4, 5, 1 },
                    {16, "Mondeo", "Estate car", "2017", 5, 5, 2 },
                    {17, "Focus RS", "Fast sports car", "2021", 4, 5, 4 },
                    {18, "Civic", "City car", "2018", 4, 6, 1 },
                    {19, "Tucson", "4-wheel drive", "2018", 5, 7, 3 },
                    {20, "i30", "City car", "2020", 4, 7, 1 },
                    {21, "Elantra", "Estate car", "2018", 5, 7, 2 },
                    {22, "Wrangler", "4-wheel drive", "2021", 5, 8, 3 },
                    {23, "Compass", "4-wheel drive", "2018", 5, 8, 3 },
                    {24, "Sorento", "4-wheel drive", "2018", 5, 9, 3 },
                    {25, "Ceed", "City car", "2018", 4, 9, 1 },
                    {26, "GLA", "4-wheel drive", "2020", 5, 10, 3 },
                    {27, "S-Class", "Estate car", "2021", 5, 10, 2 },
                    {28, "AMG GT", "Fast sports car", "2022", 4, 10, 4 },
                    {29, "G-Class", "4-wheel drive", "2020", 5, 10, 3 },
                    {30, "CLS", "Fast sports car", "2020", 4, 10, 4 },
                    {31, "Cooper", "City car", "2020", 4, 11, 1 },
                    {32, "Moris", "City car", "2018", 4, 11, 1 },
                    {33, "Patrol", "4-wheel drive", "2017", 5, 12, 3 },
                    {34, "Juke", "4-wheel drive", "2020", 5, 12, 3 },
                    {35, "Micra", "City car", "2019", 4, 12, 1 },
                    {36, "Cayenne", "4-wheel drive", "2020", 5, 13, 3 },
                    {37, "Panamera", "Fast sports car", "2021", 4, 13, 4 },
                    {38, "Corolla", "City car", "2020", 4, 14, 1 },
                    {39, "Yaris", "City car", "2020", 4, 14, 1 },
                    {40, "Land Cruiser", "4-wheel drive", "2016", 5, 14, 3 },
                    {41, "Passat", "Estate car", "2017", 5, 15, 2 },
                    {42, "Polo", "City car", "2021", 4, 15, 1 },
                    {43, "Golf VII", "City car", "2021", 4, 15, 1 },
                    {44, "T Roc", "4-wheel drive", "2020", 5, 15, 3 },
                    {45, "V40", "City car", "2029", 4, 16, 1 },
                    {46, "XC90", "4-wheel drive", "2021", 5, 16, 3 }
                });

            migrationBuilder.InsertData(
               table: "Review",
               columns: new[] { "ReviewId", "Content", "Score", "ModelId", "UserId" },
               values: new object[,]
               {
                   {1, "Great car", 5, 45, 2 },
                   {2, "Nice car.", 4, 30, 2 },
                   {3, "I did not like the car", 1, 11, 2 },
                   {4, "Great car", 5, 10, 1 },
                   {5, "Very comfortable and clean", 5, 5, 1 },
                   {6, "I did not like the color", 3, 26, 1 },
                   {7, "Nice car.", 4, 41, 1 }
               });

            migrationBuilder.InsertData(
               table: "Vehicle",
               columns: new[] { "VehicleId", "RatePerDay", "IsActive", "TransmissionType", "ModelId", "LocationId", "ImageUrl" },
               values: new object[,]
               {
                   {1, decimal.Parse("70"), true, 1, 45, 1, "https://i.imgur.com/Et4zWdn.jpg" },
                   {2, decimal.Parse("50"), true, 1, 20, 2, "https://www.automobili.ba/wp-content/uploads/2020/09/novi-hyundai-i30.jpg" },
                   {3, decimal.Parse("60"), true, 1, 31, 3, "https://i.imgur.com/KgXMySH.jpg" },
                   {4, decimal.Parse("100"), true, 1, 10, 4, "https://www.tportal.hr/media/thumbnail/w1000/525457.jpeg" },
                   {5, decimal.Parse("120"), true, 1, 5, 1, "https://audimediacenter-a.akamaihd.net/system/production/media/66243/images/479a24d3a67427d9e7d3d7c8c8b086057ac49d94/A189655_x500.jpg?1582445375" },
                   {6, decimal.Parse("120"), true, 1, 26, 2, "https://www.mercedes-benz.hr/osobna-vozila/mercedes-benz-vozila/modeli/gla/gla-h247/dizajn/lines/_jcr_content/swipeableteaserbox/par/swipeableteaser/asset.MQ6.12.20200917083806.jpeg" },
                   {7, decimal.Parse("70"), true, 1, 41, 3, "https://autostart.24sata.hr/media/img/ca/cc/83569c17a8434548a0b3.jpeg" },
                   {8, decimal.Parse("60"), true, 1, 25, 4, "https://ip.index.hr/remote/indexnew.s3.index.hr/1386cb6c-dabc-43ba-bc3e-c743ddf403d4.jpg" },
                   {9, decimal.Parse("70"), true, 1, 6, 1, "https://static.jutarnji.hr/images/live-multimedia/binary/2018/7/11/15/IMG_4076.jpg" },
                   {10, decimal.Parse("60"), true, 1, 18, 2, "https://assets-eu-01.kc-usercontent.com/bb5aba31-d98c-0160-8548-418b3723c58e/a9e89138-d4e9-4b81-8e3c-c4d8d0b8350e/Honda%20Civic%20(10).jpg?width=800&fm=jpg&auto=format" },
                   {11, decimal.Parse("125"), true, 1, 36, 3, "https://i.imgur.com/xrAWayQ.jpg" },
                   {12, decimal.Parse("65"), true, 1, 38, 4, "https://autoportal.hr/wp-content/uploads/2020/07/Toyota-Corolla-GR-1.jpg" }
               });

            migrationBuilder.InsertData(
               table: "Booking",
               columns: new[] { "BookingId", "StartDate", "EndDate", "CreatedDate", "UpdatedDate", "UserId", "VehicleId", "TotalPrice" },
               values: new object[,]
               {
                   {1, new DateTime(2021, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 17, 1, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, decimal.Parse("70") },
                   {2, new DateTime(2022, 4, 17, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 4, 17, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 4, 16, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 4, 16, 12, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, decimal.Parse("50") },
                   {3, new DateTime(2022, 5, 17, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 5, 18, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 3, decimal.Parse("720") },
                   {4, new DateTime(2022, 3, 21, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 5, 21, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 4, decimal.Parse("6100") },
                   {5, new DateTime(2022, 3, 15, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 4, 15, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 5, decimal.Parse("3720") },
                   {6, new DateTime(2022, 3, 17, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 4, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 6, decimal.Parse("1800") },
                   {7, new DateTime(2022, 3, 20, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 27, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 7, decimal.Parse("490") }
               });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Vehicle");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Model");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Make");

            migrationBuilder.DropTable(
                name: "VehicleType");
        }
    }
}
