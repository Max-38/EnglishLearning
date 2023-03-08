using EnglishLearning.Memory;

namespace EnglishLearning.Tests
{
    public class WordRepositoryTests
    {
        [Fact]
        public void GetWord_WithNegativeArgument_ReturnNull()
        {
            IWordRepository wordRepository = new WordRepository();
            Word actual = wordRepository.GetWord(-1);
            Assert.Null(actual);
        }

        [Fact]
        public void GetWord_WithZeroArgument_ReturnNull()
        {
            IWordRepository wordRepository = new WordRepository();
            Word actual = wordRepository.GetWord(0);
            Assert.Null(actual);
        }
    }
}