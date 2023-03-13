using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishLearning
{
    public interface IWordRepository
    {
        public Word GetWord(int id);
        public Word GetRandomWord(Random rnd);
        public List<Word> GetWordsForExerciseWordTranslation();
        public List<Word> GetWordsForExerciseListening();
        public bool CheckNonPassedWord();
        public List<Word> GetLearnedWords();
        public int GetMaxId();
        public Uri GetPathToAudio(string path);
    }
}
