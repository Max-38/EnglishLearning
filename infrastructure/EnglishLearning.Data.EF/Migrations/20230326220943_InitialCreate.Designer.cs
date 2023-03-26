﻿// <auto-generated />
using EnglishLearning.Data.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EnglishLearning.Data.EF.Migrations
{
    [DbContext(typeof(EnglishLearningDbContext))]
    [Migration("20230326220943_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.4");

            modelBuilder.Entity("EnglishLearning.Data.WordDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("ExerciseListening")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("ExerciseWordTranslation")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<string>("NameAudio")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Passed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Translation")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Words");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ExerciseListening = false,
                            ExerciseWordTranslation = false,
                            Name = "Exist",
                            NameAudio = "Exist.mp3",
                            Passed = false,
                            Translation = "Существовать"
                        },
                        new
                        {
                            Id = 2,
                            ExerciseListening = false,
                            ExerciseWordTranslation = false,
                            Name = "Work",
                            NameAudio = "Work.mp3",
                            Passed = false,
                            Translation = "Работа"
                        },
                        new
                        {
                            Id = 3,
                            ExerciseListening = false,
                            ExerciseWordTranslation = false,
                            Name = "Sword",
                            NameAudio = "Sword.mp3",
                            Passed = false,
                            Translation = "Меч"
                        },
                        new
                        {
                            Id = 4,
                            ExerciseListening = false,
                            ExerciseWordTranslation = false,
                            Name = "Money",
                            NameAudio = "Money.mp3",
                            Passed = false,
                            Translation = "Деньги"
                        },
                        new
                        {
                            Id = 5,
                            ExerciseListening = false,
                            ExerciseWordTranslation = false,
                            Name = "Time",
                            NameAudio = "Time.mp3",
                            Passed = false,
                            Translation = "Время"
                        },
                        new
                        {
                            Id = 6,
                            ExerciseListening = false,
                            ExerciseWordTranslation = false,
                            Name = "Door",
                            NameAudio = "Door.mp3",
                            Passed = false,
                            Translation = "Дверь"
                        },
                        new
                        {
                            Id = 7,
                            ExerciseListening = false,
                            ExerciseWordTranslation = false,
                            Name = "Table",
                            NameAudio = "Table.mp3",
                            Passed = false,
                            Translation = "Стол"
                        },
                        new
                        {
                            Id = 8,
                            ExerciseListening = false,
                            ExerciseWordTranslation = false,
                            Name = "Cook",
                            NameAudio = "Cook.mp3",
                            Passed = false,
                            Translation = "Готовить"
                        },
                        new
                        {
                            Id = 9,
                            ExerciseListening = false,
                            ExerciseWordTranslation = false,
                            Name = "Avenue",
                            NameAudio = "Avenue.mp3",
                            Passed = false,
                            Translation = "Проспект"
                        },
                        new
                        {
                            Id = 10,
                            ExerciseListening = false,
                            ExerciseWordTranslation = false,
                            Name = "Paint",
                            NameAudio = "Paint.mp3",
                            Passed = false,
                            Translation = "Рисовать"
                        },
                        new
                        {
                            Id = 11,
                            ExerciseListening = false,
                            ExerciseWordTranslation = false,
                            Name = "Color",
                            NameAudio = "Color.mp3",
                            Passed = false,
                            Translation = "Цвет"
                        },
                        new
                        {
                            Id = 12,
                            ExerciseListening = false,
                            ExerciseWordTranslation = false,
                            Name = "Beautiful",
                            NameAudio = "Beautiful.mp3",
                            Passed = false,
                            Translation = "Красивый"
                        },
                        new
                        {
                            Id = 13,
                            ExerciseListening = false,
                            ExerciseWordTranslation = false,
                            Name = "Flower",
                            NameAudio = "Flower.mp3",
                            Passed = false,
                            Translation = "Цветок"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}