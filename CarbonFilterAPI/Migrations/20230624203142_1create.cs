using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarbonFilter.Migrations
{
    /// <inheritdoc />
    public partial class _1create : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "DropDowns",
                columns: table => new
                {
                    DropDownId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DropDownName = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    DropDownUnit = table.Column<string>(type: "nvarchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DropDowns", x => x.DropDownId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    UserMobileNumber = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    UserFootPrint = table.Column<decimal>(type: "decimal(10,4)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "DropDownOptions",
                columns: table => new
                {
                    DropDownOptionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MinValue = table.Column<decimal>(type: "decimal(10,4)", nullable: false),
                    MaxValue = table.Column<decimal>(type: "decimal(10,4)", nullable: true),
                    DropDownId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DropDownOptions", x => x.DropDownOptionId);
                    table.ForeignKey(
                        name: "FK_DropDownOptions_DropDowns_DropDownId",
                        column: x => x.DropDownId,
                        principalTable: "DropDowns",
                        principalColumn: "DropDownId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionNum = table.Column<int>(type: "int", nullable: false),
                    QuestionName = table.Column<string>(type: "nvarchar(2000)", nullable: false),
                    InfoNotes = table.Column<string>(type: "nvarchar(2000)", nullable: true),
                    kgCo2eEmissions = table.Column<string>(type: "nvarchar(2000)", nullable: true),
                    DropDownId = table.Column<int>(type: "int", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ImageId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.QuestionId);
                    table.ForeignKey(
                        name: "FK_Questions_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Questions_DropDowns_DropDownId",
                        column: x => x.DropDownId,
                        principalTable: "DropDowns",
                        principalColumn: "DropDownId");
                });

            migrationBuilder.CreateTable(
                name: "PickLists",
                columns: table => new
                {
                    PickListItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PickListItemName = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    PickListItemDescription = table.Column<string>(type: "nvarchar(2000)", nullable: true),
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PickLists", x => x.PickListItemId);
                    table.ForeignKey(
                        name: "FK_PickLists_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Responses",
                columns: table => new
                {
                    ResponseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    InfoNotes = table.Column<string>(type: "nvarchar(2000)", nullable: true),
                    kgCo2eEmissions = table.Column<string>(type: "nvarchar(2000)", nullable: true),
                    PickListItemId = table.Column<int>(type: "int", nullable: true),
                    DropDownOptionId = table.Column<int>(type: "int", nullable: true),
                    ImageId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responses", x => x.ResponseId);
                    table.ForeignKey(
                        name: "FK_Responses_DropDownOptions_DropDownOptionId",
                        column: x => x.DropDownOptionId,
                        principalTable: "DropDownOptions",
                        principalColumn: "DropDownOptionId");
                    table.ForeignKey(
                        name: "FK_Responses_PickLists_PickListItemId",
                        column: x => x.PickListItemId,
                        principalTable: "PickLists",
                        principalColumn: "PickListItemId");
                    table.ForeignKey(
                        name: "FK_Responses_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserResponses",
                columns: table => new
                {
                    UserResponseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ResponseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserResponses", x => x.UserResponseId);
                    table.ForeignKey(
                        name: "FK_UserResponses_Responses_ResponseId",
                        column: x => x.ResponseId,
                        principalTable: "Responses",
                        principalColumn: "ResponseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserResponses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Energy/Electricty" },
                    { 2, "Transportation" },
                    { 3, "Food by Meal Type" },
                    { 4, "Food by Items" },
                    { 5, "Water" },
                    { 6, "Waste Management" }
                });

            migrationBuilder.InsertData(
                table: "DropDowns",
                columns: new[] { "DropDownId", "DropDownName", "DropDownUnit" },
                values: new object[,]
                {
                    { 1, "People", null },
                    { 2, "Electricity", "units" },
                    { 3, "Fuel", "liters" },
                    { 4, "Travel", "km" },
                    { 5, "Meals", "meals per week" },
                    { 6, "Water", "liters" },
                    { 7, "WasteWeight", "kg" },
                    { 8, "WastePercentage", "%" },
                    { 9, "Age", null }
                });

            migrationBuilder.InsertData(
                table: "DropDownOptions",
                columns: new[] { "DropDownOptionId", "DropDownId", "MaxValue", "MinValue" },
                values: new object[,]
                {
                    { 1, 1, null, 1m },
                    { 2, 1, null, 2m },
                    { 3, 1, null, 3m },
                    { 4, 1, null, 4m },
                    { 5, 1, null, 5m },
                    { 6, 1, null, 6m },
                    { 7, 1, null, 7m },
                    { 8, 1, null, 8m },
                    { 9, 1, null, 9m },
                    { 10, 1, null, 10m },
                    { 11, 2, 50m, 0m },
                    { 12, 2, 100m, 50m },
                    { 13, 2, 150m, 100m },
                    { 14, 2, 200m, 150m },
                    { 15, 2, 250m, 200m },
                    { 16, 2, 300m, 250m },
                    { 17, 2, 400m, 300m },
                    { 18, 2, 500m, 400m },
                    { 19, 2, 750m, 500m },
                    { 20, 2, 1000m, 750m },
                    { 21, 3, 20m, 0m },
                    { 22, 3, 40m, 20m },
                    { 23, 3, 60m, 40m },
                    { 24, 3, 80m, 60m },
                    { 25, 3, 100m, 80m },
                    { 26, 4, null, 0m },
                    { 27, 4, 50m, 1m },
                    { 28, 4, 100m, 51m },
                    { 29, 4, 200m, 101m },
                    { 30, 4, 300m, 201m },
                    { 31, 4, 400m, 301m },
                    { 32, 4, 500m, 401m },
                    { 33, 4, 600m, 501m },
                    { 34, 4, 700m, 601m },
                    { 35, 4, 800m, 701m },
                    { 36, 4, 900m, 801m },
                    { 37, 4, 1000m, 901m },
                    { 38, 5, 5m, 0m },
                    { 39, 5, 10m, 6m },
                    { 40, 5, 15m, 11m },
                    { 41, 5, 20m, 16m },
                    { 42, 6, 10m, 0m },
                    { 43, 6, 20m, 10m },
                    { 44, 6, 30m, 20m },
                    { 45, 6, 40m, 30m },
                    { 46, 6, 50m, 40m },
                    { 47, 6, 60m, 50m },
                    { 48, 6, 70m, 60m },
                    { 49, 6, 80m, 70m },
                    { 50, 6, 90m, 80m },
                    { 51, 6, 100m, 90m },
                    { 52, 7, 2m, 0m },
                    { 53, 7, 5m, 2m },
                    { 54, 7, 10m, 5m },
                    { 55, 7, 15m, 10m },
                    { 56, 7, 20m, 15m },
                    { 57, 7, 25m, 20m },
                    { 58, 7, 30m, 25m },
                    { 59, 8, null, 0m },
                    { 60, 8, null, 10m },
                    { 61, 8, null, 20m },
                    { 62, 8, null, 30m },
                    { 63, 8, null, 40m },
                    { 64, 8, null, 50m },
                    { 65, 8, null, 60m },
                    { 66, 8, null, 70m },
                    { 67, 8, null, 80m },
                    { 68, 8, null, 90m },
                    { 69, 8, null, 100m },
                    { 70, 9, 20m, 0m },
                    { 71, 9, 40m, 20m },
                    { 72, 9, 60m, 40m },
                    { 73, 9, 80m, 60m }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "QuestionId", "CategoryId", "DropDownId", "ImageId", "InfoNotes", "QuestionName", "QuestionNum", "kgCo2eEmissions" },
                values: new object[,]
                {
                    { 1, 1, 1, null, null, "How many people live in your household?", 1, null },
                    { 2, 1, 2, null, null, "How many electricity units does your household consume in a month?", 2, null },
                    { 3, 2, 3, null, null, "How many liters of fuel does your household consume in a month through personal vehicles? ", 3, null },
                    { 4, 2, 4, null, null, "How many kilometers does your household travel in public transportation per month?", 4, null },
                    { 5, 3, 5, null, null, "On average, how many meals are consumed per week by a person in your household?", 5, null },
                    { 6, 5, 6, null, null, "How many liters of water does your household consume in a week?", 6, null },
                    { 7, 6, 7, null, "According to Central Pollution Control Board in India, the average amount of waste generated per capita per day in urban areas is 0.62 kg. This translates to approximately 17.36 kg of waste generated by an average household of 4 in a week.", "How much waste is generated in a week by your household?", 7, null },
                    { 8, 6, 8, null, null, "->What Portion of it is recycled", 8, null },
                    { 9, 6, 8, null, null, "->What Portion of it is composted", 9, null },
                    { 10, 6, 9, null, null, "What is the average age of the people in your household?", 10, null }
                });

            migrationBuilder.InsertData(
                table: "PickLists",
                columns: new[] { "PickListItemId", "PickListItemDescription", "PickListItemName", "QuestionId" },
                values: new object[,]
                {
                    { 1, null, "Regular Utility", 2 },
                    { 2, null, "Diesel Generator", 2 },
                    { 3, "Solar energy produced can either be used for 'Self-use' and power household activities- Reducing the need to draw further electricity from the grid OR 'Net Metering' - Produced Solar energy can be used to offset electricity units in a given period. I think its worth capturing if the individual follows any of this practice", "Solar", 2 },
                    { 4, null, "Petrol", 3 },
                    { 5, null, "Diesel", 3 },
                    { 6, null, "Car Taxi", 4 },
                    { 7, null, "Bike Taxi", 4 },
                    { 8, null, "Auto Taxi", 4 },
                    { 9, null, "Bus", 4 },
                    { 10, null, "Rail", 4 },
                    { 11, null, "Air", 4 },
                    { 12, null, "Vegetarian", 5 },
                    { 13, null, "Non-Vegetarian", 5 },
                    { 14, null, "Bottled Drinking Water", 6 },
                    { 15, null, "Canned Drinking Water", 6 },
                    { 16, null, "Home Purified Water", 6 },
                    { 17, null, "General Household Water Consumption", 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DropDownOptions_DropDownId",
                table: "DropDownOptions",
                column: "DropDownId");

            migrationBuilder.CreateIndex(
                name: "IX_PickLists_QuestionId",
                table: "PickLists",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_CategoryId",
                table: "Questions",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_DropDownId",
                table: "Questions",
                column: "DropDownId");

            migrationBuilder.CreateIndex(
                name: "IX_Responses_DropDownOptionId",
                table: "Responses",
                column: "DropDownOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Responses_PickListItemId",
                table: "Responses",
                column: "PickListItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Responses_QuestionId",
                table: "Responses",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserResponses_ResponseId",
                table: "UserResponses",
                column: "ResponseId");

            migrationBuilder.CreateIndex(
                name: "IX_UserResponses_UserId",
                table: "UserResponses",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserResponses");

            migrationBuilder.DropTable(
                name: "Responses");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "DropDownOptions");

            migrationBuilder.DropTable(
                name: "PickLists");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "DropDowns");
        }
    }
}
