using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishLearning
{
    public interface IWordRepository
    {
        public List<Word> GetWordsForLearning();
        public List<Word> GetWordsForExerciseWordTranslation();
        public List<Word> GetWordsForExerciseListening();
        public List<Word> GetLearnedWords();
        public List<Word> GetAllWords();
    }
}
