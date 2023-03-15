

namespace EnglishLearning.Memory
{
    public class WordRepository : IWordRepository
    {
        private readonly List<Word> words = new List<Word>
        {
            new Word (1, "Exist", "Существовать", false, false, false, @"infrastructure\EnglishLearning.Memory\Resources\Audio\Exist.mp3"),
            new Word (2, "Work", "Работа", true, false, false, @"infrastructure\EnglishLearning.Memory\Resources\Audio\Work.mp3"),
            new Word (3, "Sword", "Меч", false, false, false, @"infrastructure\EnglishLearning.Memory\Resources\Audio\Sword.mp3"),
            new Word (4, "Money", "Деньги", false, false, false, @"infrastructure\EnglishLearning.Memory\Resources\Audio\Work.mp3"),
            new Word (5, "Time", "Время", true, true, true, @"infrastructure\EnglishLearning.Memory\Resources\Audio\Work.mp3")
        };

        public List<Word> GetWordsForLearning()
        {
            List<Word> wordsForLearning = words.Where(item =>
                                                      item.Passed == false)
                                                      .ToList();
            return wordsForLearning;
        }

        public List<Word> GetWordsForExerciseWordTranslation()
        {
            List<Word> wordsForExercise = words.Where(item =>
                                                      item.Passed == true 
                                                      && item.ExerciseWordTranslation == false)
                                                      .ToList();
            return wordsForExercise;
        }

        public List<Word> GetWordsForExerciseListening()
        {
            List<Word> wordsForExercise = words.Where(item =>
                                                      item.Passed == true
                                                      && item.ExerciseListening == false)
                                                      .ToList();
            return wordsForExercise;
        }

        public List<Word> GetLearnedWords()
        {
            List<Word> learnedWords = words.Where(item =>
                                                  item.ExerciseWordTranslation == true
                                                  && item.ExerciseListening == true)
                                                  .ToList();
            return learnedWords;
        }

        public List<Word> GetAllWords()
        {
            return words;
        }
    }
}