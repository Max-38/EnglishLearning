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

        public int GetMaxId();

        public Uri GetPathToAudio(string path);
    }
}
