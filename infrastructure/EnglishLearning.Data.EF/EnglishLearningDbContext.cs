using Microsoft.EntityFrameworkCore;

namespace EnglishLearning.Data.EF
{
    public class EnglishLearningDbContext : DbContext
    {
        public DbSet<WordDto> Words { get; set; }

        public EnglishLearningDbContext(DbContextOptions<EnglishLearningDbContext> options)
               : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            BuildWords(modelBuilder);
        }

        private static void BuildWords(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WordDto>(action =>
            {
                action.Property(dto => dto.Name)
                      .HasMaxLength(20)
                      .IsRequired();

                action.Property(dto => dto.Translation)
                      .HasMaxLength(20)
                      .IsRequired();

                action.HasData(
                    new WordDto
                    {
                        Id = 1,
                        Name = "Exist",
                        Translation = "Существовать",
                        Passed = false,
                        ExerciseWordTranslation = false,
                        ExerciseListening = false,
                        NameAudio = "Exist.mp3"
                    },
                    new WordDto
                    {
                        Id = 2,
                        Name = "Work",
                        Translation = "Работа",
                        Passed = false,
                        ExerciseWordTranslation = false,
                        ExerciseListening = false,
                        NameAudio = "Work.mp3"
                    },
                    new WordDto
                    {
                        Id = 3,
                        Name = "Sword",
                        Translation = "Меч",
                        Passed = false,
                        ExerciseWordTranslation = false,
                        ExerciseListening = false,
                        NameAudio = "Sword.mp3"
                    },
                    new WordDto
                    {
                        Id = 4,
                        Name = "Money",
                        Translation = "Деньги",
                        Passed = false,
                        ExerciseWordTranslation = false,
                        ExerciseListening = false,
                        NameAudio = "Money.mp3"
                    },
                    new WordDto
                    {
                        Id = 5,
                        Name = "Time",
                        Translation = "Время",
                        Passed = false,
                        ExerciseWordTranslation = false,
                        ExerciseListening = false,
                        NameAudio = "Time.mp3"
                    },
                    new WordDto
                    {
                        Id = 6,
                        Name = "Door",
                        Translation = "Дверь",
                        Passed = false,
                        ExerciseWordTranslation = false,
                        ExerciseListening = false,
                        NameAudio = "Door.mp3"
                    },
                    new WordDto
                    {
                        Id = 7,
                        Name = "Table",
                        Translation = "Стол",
                        Passed = false,
                        ExerciseWordTranslation = false,
                        ExerciseListening = false,
                        NameAudio = "Table.mp3"
                    },
                    new WordDto
                    {
                        Id = 8,
                        Name = "Cook",
                        Translation = "Готовить",
                        Passed = false,
                        ExerciseWordTranslation = false,
                        ExerciseListening = false,
                        NameAudio = "Cook.mp3"
                    },
                    new WordDto
                    {
                        Id = 9,
                        Name = "Avenue",
                        Translation = "Проспект",
                        Passed = false,
                        ExerciseWordTranslation = false,
                        ExerciseListening = false,
                        NameAudio = "Avenue.mp3"
                    },
                    new WordDto
                    {
                        Id = 10,
                        Name = "Paint",
                        Translation = "Рисовать",
                        Passed = false,
                        ExerciseWordTranslation = false,
                        ExerciseListening = false,
                        NameAudio = "Paint.mp3"
                    },
                    new WordDto
                    {
                        Id = 11,
                        Name = "Color",
                        Translation = "Цвет",
                        Passed = false,
                        ExerciseWordTranslation = false,
                        ExerciseListening = false,
                        NameAudio = "Color.mp3"
                    },
                    new WordDto
                    {
                        Id = 12,
                        Name = "Beautiful",
                        Translation = "Красивый",
                        Passed = false,
                        ExerciseWordTranslation = false,
                        ExerciseListening = false,
                        NameAudio = "Beautiful.mp3"
                    },
                    new WordDto
                    {
                        Id = 13,
                        Name = "Flower",
                        Translation = "Цветок",
                        Passed = false,
                        ExerciseWordTranslation = false,
                        ExerciseListening = false,
                        NameAudio = "Flower.mp3"
                    }
                    );
            });
        }
    }
}
