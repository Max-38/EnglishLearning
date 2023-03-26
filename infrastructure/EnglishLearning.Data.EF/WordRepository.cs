using Microsoft.EntityFrameworkCore;

namespace EnglishLearning.Data.EF
{
    internal class WordRepository : IWordRepository
    {
        private readonly IDbContextFactory<EnglishLearningDbContext> dbContextFactory;
        public WordRepository (IDbContextFactory<EnglishLearningDbContext> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public List<Word> GetWordsForLearning()
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                List<Word> wordsForLearning = dbContext.Words.Where(item => item.Passed == false)
                                                             .AsEnumerable()
                                                             .Select(Word.Mapper.Map)
                                                             .ToList();
                return wordsForLearning;
            }
        }

        public List<Word> GetWordsForExerciseWordTranslation()
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                List<Word> wordsForExercise = dbContext.Words.Where(item => item.Passed == true && item.ExerciseWordTranslation == false)
                                                                         .AsEnumerable()
                                                                         .Select(Word.Mapper.Map)
                                                                         .ToList();
                return wordsForExercise;
            };
        }

        public List<Word> GetWordsForExerciseListening()
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                List<Word> wordsForExercise = dbContext.Words.Where(item => item.Passed == true && item.ExerciseListening == false)
                                                         .AsEnumerable()
                                                         .Select(Word.Mapper.Map)
                                                         .ToList();
                return wordsForExercise;
            }
        }

        public List<Word> GetLearnedWords()
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                List<Word> learnedWords = dbContext.Words.Where(item => item.ExerciseWordTranslation == true && item.ExerciseListening == true)
                                                     .AsEnumerable()
                                                     .Select(Word.Mapper.Map)
                                                     .ToList();
                return learnedWords;
            }
        }

        public List<Word> GetAllWords()
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                return dbContext.Words.AsEnumerable().Select(Word.Mapper.Map).ToList();
            }
        }

        public void UpdateWord(Word word)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                dbContext.Update<WordDto>(Word.Mapper.Map(word));
                dbContext.SaveChanges();
            }
        }
    }
}
