using EnglishLearning.Data;
using EnglishLearning.Services;
using Moq;

namespace EnglishLearning.Tests
{
    public class WordServiceTests
    {
        [Fact]
        public void GetListOfWordsForPage_WithLearningPageVM_CallsGetWordsForLearning()
        {
            var wordRepositoryStud = new Mock<IWordRepository>();
            wordRepositoryStud.Setup(x => x.GetWordsForLearning())
                              .Returns(new List<Word> { Word.Mapper.Map(new WordDto { Id = 1,
                                                                                      Name = "",
                                                                                      Translation = "",
                                                                                      Passed = false,
                                                                                      ExerciseWordTranslation = false,
                                                                                      ExerciseListening = false,
                                                                                      NameAudio = ""}) });
            wordRepositoryStud.Setup(x => x.GetWordsForExerciseWordTranslation())
                              .Returns(new List<Word> { Word.Mapper.Map(new WordDto { Id = 2,
                                                                                      Name = "",
                                                                                      Translation = "",
                                                                                      Passed = true,
                                                                                      ExerciseWordTranslation = false,
                                                                                      ExerciseListening = false,
                                                                                      NameAudio = ""}) });
            wordRepositoryStud.Setup(x => x.GetWordsForExerciseListening())
                              .Returns(new List<Word> { Word.Mapper.Map(new WordDto { Id = 3,
                                                                                      Name = "",
                                                                                      Translation = "",
                                                                                      Passed = true,
                                                                                      ExerciseWordTranslation = false,
                                                                                      ExerciseListening = false,
                                                                                      NameAudio = ""}) });
            wordRepositoryStud.Setup(x => x.GetLearnedWords())
                              .Returns(new List<Word> { Word.Mapper.Map(new WordDto { Id = 4,
                                                                                      Name = "",
                                                                                      Translation = "",
                                                                                      Passed = true,
                                                                                      ExerciseWordTranslation = true,
                                                                                      ExerciseListening = true,
                                                                                      NameAudio = ""}) });
            wordRepositoryStud.Setup(x => x.GetAllWords())
                              .Returns(new List<Word> { Word.Mapper.Map(new WordDto { Id = 5,
                                                                                      Name = "",
                                                                                      Translation = "",
                                                                                      Passed = false,
                                                                                      ExerciseWordTranslation = false,
                                                                                      ExerciseListening = false,
                                                                                      NameAudio = ""}) });

            var wordService = new WordService(wordRepositoryStud.Object);

            var actual = wordService.GetListOfWordsForPage("LearningPageVM");
            Assert.Collection(actual, word => Assert.Equal(1, word.Id));
        }

        [Fact]
        public void GetListOfWordsForPage_WithWordTranslationPageVM_CallsGetWordsForExerciseWordTranslation()
        {
            var wordRepositoryStud = new Mock<IWordRepository>();
            wordRepositoryStud.Setup(x => x.GetWordsForLearning())
                              .Returns(new List<Word> { Word.Mapper.Map(new WordDto { Id = 1,
                                                                                      Name = "",
                                                                                      Translation = "",
                                                                                      Passed = false,
                                                                                      ExerciseWordTranslation = false,
                                                                                      ExerciseListening = false,
                                                                                      NameAudio = ""}) });
            wordRepositoryStud.Setup(x => x.GetWordsForExerciseWordTranslation())
                              .Returns(new List<Word> { Word.Mapper.Map(new WordDto { Id = 2,
                                                                                      Name = "",
                                                                                      Translation = "",
                                                                                      Passed = true,
                                                                                      ExerciseWordTranslation = false,
                                                                                      ExerciseListening = false,
                                                                                      NameAudio = ""}) });
            wordRepositoryStud.Setup(x => x.GetWordsForExerciseListening())
                              .Returns(new List<Word> { Word.Mapper.Map(new WordDto { Id = 3,
                                                                                      Name = "",
                                                                                      Translation = "",
                                                                                      Passed = true,
                                                                                      ExerciseWordTranslation = false,
                                                                                      ExerciseListening = false,
                                                                                      NameAudio = ""}) });
            wordRepositoryStud.Setup(x => x.GetLearnedWords())
                              .Returns(new List<Word> { Word.Mapper.Map(new WordDto { Id = 4,
                                                                                      Name = "",
                                                                                      Translation = "",
                                                                                      Passed = true,
                                                                                      ExerciseWordTranslation = true,
                                                                                      ExerciseListening = true,
                                                                                      NameAudio = ""}) });
            wordRepositoryStud.Setup(x => x.GetAllWords())
                              .Returns(new List<Word> { Word.Mapper.Map(new WordDto { Id = 5,
                                                                                      Name = "",
                                                                                      Translation = "",
                                                                                      Passed = false,
                                                                                      ExerciseWordTranslation = false,
                                                                                      ExerciseListening = false,
                                                                                      NameAudio = ""}) });

            var wordService = new WordService(wordRepositoryStud.Object);

            var actual = wordService.GetListOfWordsForPage("WordTranslationPageVM");
            Assert.Collection(actual, word => Assert.Equal(2, word.Id));
        }

        [Fact]
        public void GetListOfWordsForPage_WithListeningPageVM_CallsGetWordsForExerciseListening()
        {
            var wordRepositoryStud = new Mock<IWordRepository>();
            wordRepositoryStud.Setup(x => x.GetWordsForLearning())
                              .Returns(new List<Word> { Word.Mapper.Map(new WordDto { Id = 1,
                                                                                      Name = "",
                                                                                      Translation = "",
                                                                                      Passed = false,
                                                                                      ExerciseWordTranslation = false,
                                                                                      ExerciseListening = false,
                                                                                      NameAudio = ""}) });
            wordRepositoryStud.Setup(x => x.GetWordsForExerciseWordTranslation())
                              .Returns(new List<Word> { Word.Mapper.Map(new WordDto { Id = 2,
                                                                                      Name = "",
                                                                                      Translation = "",
                                                                                      Passed = true,
                                                                                      ExerciseWordTranslation = false,
                                                                                      ExerciseListening = false,
                                                                                      NameAudio = ""}) });
            wordRepositoryStud.Setup(x => x.GetWordsForExerciseListening())
                              .Returns(new List<Word> { Word.Mapper.Map(new WordDto { Id = 3,
                                                                                      Name = "",
                                                                                      Translation = "",
                                                                                      Passed = true,
                                                                                      ExerciseWordTranslation = false,
                                                                                      ExerciseListening = false,
                                                                                      NameAudio = ""}) });
            wordRepositoryStud.Setup(x => x.GetLearnedWords())
                              .Returns(new List<Word> { Word.Mapper.Map(new WordDto { Id = 4,
                                                                                      Name = "",
                                                                                      Translation = "",
                                                                                      Passed = true,
                                                                                      ExerciseWordTranslation = true,
                                                                                      ExerciseListening = true,
                                                                                      NameAudio = ""}) });
            wordRepositoryStud.Setup(x => x.GetAllWords())
                              .Returns(new List<Word> { Word.Mapper.Map(new WordDto { Id = 5,
                                                                                      Name = "",
                                                                                      Translation = "",
                                                                                      Passed = false,
                                                                                      ExerciseWordTranslation = false,
                                                                                      ExerciseListening = false,
                                                                                      NameAudio = ""}) });

            var wordService = new WordService(wordRepositoryStud.Object);

            var actual = wordService.GetListOfWordsForPage("ListeningPageVM");
            Assert.Collection(actual, word => Assert.Equal(3, word.Id));
        }

        [Fact]
        public void GetListOfWordsForPage_WithDictionaryPageVM_CallsGetLearnedWords()
        {
            var wordRepositoryStud = new Mock<IWordRepository>();
            wordRepositoryStud.Setup(x => x.GetWordsForLearning())
                              .Returns(new List<Word> { Word.Mapper.Map(new WordDto { Id = 1,
                                                                                      Name = "",
                                                                                      Translation = "",
                                                                                      Passed = false,
                                                                                      ExerciseWordTranslation = false,
                                                                                      ExerciseListening = false,
                                                                                      NameAudio = ""}) });
            wordRepositoryStud.Setup(x => x.GetWordsForExerciseWordTranslation())
                              .Returns(new List<Word> { Word.Mapper.Map(new WordDto { Id = 2,
                                                                                      Name = "",
                                                                                      Translation = "",
                                                                                      Passed = true,
                                                                                      ExerciseWordTranslation = false,
                                                                                      ExerciseListening = false,
                                                                                      NameAudio = ""}) });
            wordRepositoryStud.Setup(x => x.GetWordsForExerciseListening())
                              .Returns(new List<Word> { Word.Mapper.Map(new WordDto { Id = 3,
                                                                                      Name = "",
                                                                                      Translation = "",
                                                                                      Passed = true,
                                                                                      ExerciseWordTranslation = false,
                                                                                      ExerciseListening = false,
                                                                                      NameAudio = ""}) });
            wordRepositoryStud.Setup(x => x.GetLearnedWords())
                              .Returns(new List<Word> { Word.Mapper.Map(new WordDto { Id = 4,
                                                                                      Name = "",
                                                                                      Translation = "",
                                                                                      Passed = true,
                                                                                      ExerciseWordTranslation = true,
                                                                                      ExerciseListening = true,
                                                                                      NameAudio = ""}) });
            wordRepositoryStud.Setup(x => x.GetAllWords())
                              .Returns(new List<Word> { Word.Mapper.Map(new WordDto { Id = 5,
                                                                                      Name = "",
                                                                                      Translation = "",
                                                                                      Passed = false,
                                                                                      ExerciseWordTranslation = false,
                                                                                      ExerciseListening = false,
                                                                                      NameAudio = ""}) });

            var wordService = new WordService(wordRepositoryStud.Object);

            var actual = wordService.GetListOfWordsForPage("DictionaryPageVM");
            Assert.Collection(actual, word => Assert.Equal(4, word.Id));
        }

        [Fact]
        public void GetListOfWordsForPage_WithNonParameter_CallsGetAllWords()
        {
            var wordRepositoryStud = new Mock<IWordRepository>();
            wordRepositoryStud.Setup(x => x.GetWordsForLearning())
                              .Returns(new List<Word> { Word.Mapper.Map(new WordDto { Id = 1,
                                                                                      Name = "",
                                                                                      Translation = "",
                                                                                      Passed = false,
                                                                                      ExerciseWordTranslation = false,
                                                                                      ExerciseListening = false,
                                                                                      NameAudio = ""}) });
            wordRepositoryStud.Setup(x => x.GetWordsForExerciseWordTranslation())
                              .Returns(new List<Word> { Word.Mapper.Map(new WordDto { Id = 2,
                                                                                      Name = "",
                                                                                      Translation = "",
                                                                                      Passed = true,
                                                                                      ExerciseWordTranslation = false,
                                                                                      ExerciseListening = false,
                                                                                      NameAudio = ""}) });
            wordRepositoryStud.Setup(x => x.GetWordsForExerciseListening())
                              .Returns(new List<Word> { Word.Mapper.Map(new WordDto { Id = 3,
                                                                                      Name = "",
                                                                                      Translation = "",
                                                                                      Passed = true,
                                                                                      ExerciseWordTranslation = false,
                                                                                      ExerciseListening = false,
                                                                                      NameAudio = ""}) });
            wordRepositoryStud.Setup(x => x.GetLearnedWords())
                              .Returns(new List<Word> { Word.Mapper.Map(new WordDto { Id = 4,
                                                                                      Name = "",
                                                                                      Translation = "",
                                                                                      Passed = true,
                                                                                      ExerciseWordTranslation = true,
                                                                                      ExerciseListening = true,
                                                                                      NameAudio = ""}) });
            wordRepositoryStud.Setup(x => x.GetAllWords())
                              .Returns(new List<Word> { Word.Mapper.Map(new WordDto { Id = 5,
                                                                                      Name = "",
                                                                                      Translation = "",
                                                                                      Passed = false,
                                                                                      ExerciseWordTranslation = false,
                                                                                      ExerciseListening = false,
                                                                                      NameAudio = ""}) });

            var wordService = new WordService(wordRepositoryStud.Object);

            var actual = wordService.GetListOfWordsForPage();
            Assert.Collection(actual, word => Assert.Equal(5, word.Id));
        }
    }
}
