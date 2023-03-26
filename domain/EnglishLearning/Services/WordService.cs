namespace EnglishLearning.Services
{
    public class WordService
    {
        private readonly IWordRepository wordRepository;

        public WordService (IWordRepository wordRepository)
        {
            this.wordRepository = wordRepository;
        }

        public List<Word> GetListOfWordsForPage(string callingClass = "All")
        {
            switch (callingClass)
            {
                case "LearningPageVM":
                    List<Word> words = wordRepository.GetWordsForLearning();
                    Shuffle(words);
                    return words;

                case "WordTranslationPageVM":
                    words = wordRepository.GetWordsForExerciseWordTranslation();
                    Shuffle(words);
                    return words;

                case "ListeningPageVM":
                    words = wordRepository.GetWordsForExerciseListening();
                    Shuffle(words);
                    return words;

                case "DictionaryPageVM":
                    return wordRepository.GetLearnedWords();

                default:
                    words = wordRepository.GetAllWords();
                    Shuffle(words);
                    return words;
            }
        }

        public void Shuffle (List<Word> words)
        {
            Random random = new Random();

            for (int i = words.Count -1; i >= 1; i--)
            {
                int j = random.Next(i + 1);

                Word temp = words[j];
                words[j] = words[i];
                words[i] = temp;
            }
        }

        public void UpdateWord(Word word)
        {
            wordRepository.UpdateWord(word);
        }
    }
}
