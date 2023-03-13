

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

        public Word GetWord(int id)
        {
            Word word = words.SingleOrDefault(item => item.Id == id);
            return word;
        }

        public Word GetRandomWord(Random rnd)
        {
            int index = rnd.Next(0, words.Count);
            Word randomWord = words[index];
            return randomWord;
        }

        public List<Word> GetWordsForExerciseWordTranslation()
        {
            List<Word> wordsForExercise = words.Where(item => item.Passed == true && item.ExerciseWordTranslation == false).ToList();
            return wordsForExercise;
        }

        public List<Word> GetWordsForExerciseListening()
        {
            List<Word> wordsForExercise = words.Where(item => item.Passed == true && item.ExerciseListening == false).ToList();
            return wordsForExercise;
        }

        public bool CheckNonPassedWord()
        {
            bool result = words.Any(item => item.Passed == false);
            return result;
        }

        public List<Word> GetLearnedWords()
        {
            List<Word> learnedWords = words.Where(item =>
                                                  item.ExerciseWordTranslation == true
                                                  && item.ExerciseListening == true)
                                                  .ToList();
            return learnedWords;
        }

        public int GetMaxId()
        {
            return words.Count;
        }

        public Uri GetPathToAudio(string path)
        {
            // получаем путь к корневой папке проекта
            string workingDirectory = Environment.CurrentDirectory;
            string root = Directory.GetParent(workingDirectory).Parent.Parent.Parent.Parent.FullName;

            Uri uri = new Uri(Path.Combine(root, path), UriKind.RelativeOrAbsolute);
            return uri;
        }
    }
}