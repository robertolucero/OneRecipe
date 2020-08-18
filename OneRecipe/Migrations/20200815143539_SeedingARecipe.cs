using Microsoft.EntityFrameworkCore.Migrations;

namespace OneRecipe.Migrations
{
    public partial class SeedingARecipe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImagePath",
                table: "Recipe",
                type: "varchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Recipe",
                type: "varchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(1000)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Directions",
                table: "Recipe",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Ingredients",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Recipe",
                columns: new[] { "Id", "Description", "Directions", "ImagePath", "Name" },
                values: new object[] { 1, "It's already no-fuss, but throwing everything into a slow cooker makes it even better and easier!", "1. Make meatballs: In a large bowl, mix together ground beef, bread crumbs, Parmesan, parsley, egg, salt, and crushed red pepper flakes. Form into 16 meatballs and place in the bottom of a Crock Pot.2. In another large bowl, mix together crushed tomatoes, tomato paste, onion, oregano, and garlic. Season with salt, pepper and a pinch of red pepper flakes. Pour sauce over meatballs. Cover Crock Pot with lid and cook on high for 3 hours or on low for 5 hours.3. Add broth spaghetti to Crock Pot, breaking noodles in half to fit and stirring to coat noodles. Replace lid and continue cooking on low for 1 1/2 hour more hours, stirring about every 30 minutes and breaking up any clumps of noodles and adding more broth as needed.4. Garnish with Parmesan and parsley before serving.", "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/crock-pot-spaghetti-horizontal-jpg-1522721232.jpg?crop=1xw:1xh;center,top&resize=768:*", "Spaghetti and meatballs" });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Amount", "Name", "RecipeId" },
                values: new object[,]
                {
                    { 1, 1m, "ground beef", 1 },
                    { 2, 1.25m, "bread crumbs", 1 },
                    { 3, 1.25m, "freshly grated parmesan", 1 },
                    { 4, 1m, "large egg, beaten", 1 },
                    { 5, 2m, "cloves garlic, minced", 1 },
                    { 6, 1.25m, "freshly chopped parsley", 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Recipe",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Directions",
                table: "Recipe");

            migrationBuilder.AlterColumn<string>(
                name: "ImagePath",
                table: "Recipe",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Recipe",
                type: "varchar(1000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Amount",
                table: "Ingredients",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
