using DevExpress.Mvvm;
using EnglishLearning.App.Models;
using EnglishLearning.App.Services;
using System.Windows.Input;
using System.Windows.Media;

namespace EnglishLearning.App.ViewModels
{
    public class LearningPageVM : ViewModelBase
    {
        private readonly IWordRepository wordRepository;

        public Word TrainedWord { get; set; }
        public string Message { get; set; }

        private int readId = 1;

        public LearningPageVM(IWordRepository wordRepository, PageService pageService)
        {
            this.wordRepository = wordRepository;

            GetNextWord();
        }


        public ICommand NextWord => new RelayCommand(obj =>
        {
            TrainedWord.Passed = true;
            GetNextWord();
        }, obj => Message != "Нет слов для изучения");

        public ICommand PlayAudio => new RelayCommand(obj =>
        {
            var player = new MediaPlayer();
            player.Open(wordRepository.GetPathToAudio(TrainedWord.PathToAudio));
            player.Play();
        }, obj => Message != "Нет слов для изучения");


        private void GetNextWord()
        {
            if (!wordRepository.CheckNonPassedWord())
            {
                TrainedWord = null;
                Message = "Нет слов для изучения";
                return;
            }
            else
            {
                while (wordRepository.GetWord(readId).Passed)
                {
                    if (readId + 1 > wordRepository.GetMaxId())
                        readId = 1;
                    else
                        readId++;
                }
                TrainedWord = wordRepository.GetWord(readId);
            }
        }
    }
}