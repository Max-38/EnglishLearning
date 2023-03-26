using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EnglishLearning.Data.EF.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Words",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Translation = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Passed = table.Column<bool>(type: "INTEGER", nullable: false),
                    ExerciseWordTranslation = table.Column<bool>(type: "INTEGER", nullable: false),
                    ExerciseListening = table.Column<bool>(type: "INTEGER", nullable: false),
                    NameAudio = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Words", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Words",
                columns: new[] { "Id", "ExerciseListening", "ExerciseWordTranslation", "Name", "NameAudio", "Passed", "Translation" },
                values: new object[,]
                {
                    { 1, false, false, "Exist", "Exist.mp3", false, "Существовать" },
                    { 2, false, false, "Work", "Work.mp3", false, "Работа" },
                    { 3, false, false, "Sword", "Sword.mp3", false, "Меч" },
                    { 4, false, false, "Money", "Money.mp3", false, "Деньги" },
                    { 5, false, false, "Time", "Time.mp3", false, "Время" },
                    { 6, false, false, "Door", "Door.mp3", false, "Дверь" },
                    { 7, false, false, "Table", "Table.mp3", false, "Стол" },
                    { 8, false, false, "Cook", "Cook.mp3", false, "Готовить" },
                    { 9, false, false, "Avenue", "Avenue.mp3", false, "Проспект" },
                    { 10, false, false, "Paint", "Paint.mp3", false, "Рисовать" },
                    { 11, false, false, "Color", "Color.mp3", false, "Цвет" },
                    { 12, false, false, "Beautiful", "Beautiful.mp3", false, "Красивый" },
                    { 13, false, false, "Flower", "Flower.mp3", false, "Цветок" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Words");
        }
    }
}
