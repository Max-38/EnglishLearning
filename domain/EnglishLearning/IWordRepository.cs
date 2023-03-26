namespace EnglishLearning
{
    public interface IWordRepository
    {
        public List<Word> GetWordsForLearning();
        public List<Word> GetWordsForExerciseWordTranslation();
        public List<Word> GetWordsForExerciseListening();
        public List<Word> GetLearnedWords();
        public List<Word> GetAllWords();
        public void UpdateWord(Word word);
    }
}
