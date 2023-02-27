

namespace EnglishLearning.Memory
{
    public class WordRepository : IWordRepository
    {
        private readonly List<Word> words = new List<Word>
        {
            new Word (1, "Exist", "Существовать", false, false, @"infrastructure\EnglishLearning.Memory\Resources\Audio\Exist.mp3"),
            new Word (2, "Work", "Работа", false, false, @"infrastructure\EnglishLearning.Memory\Resources\Audio\Work.mp3"),
            new Word (3, "Sword", "Меч", false, false, @"infrastructure\EnglishLearning.Memory\Resources\Audio\Sword.mp3")
        };

        public Word GetWord(int id)
        {
            Word word = words.SingleOrDefault(item => item.Id == id);
            return word;
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