using EnglishLearning.App.Models;
using EnglishLearning.App.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows.Media;

namespace EnglishLearning.App.ViewModels
{
    public class LearningPageVM : INotifyPropertyChanged
    {
        private readonly IWordRepository wordRepository;
        private readonly PageService pageService;


        private int readId = 1;
        private string wordName;
        public string WordName
        {
            get { return wordName; }
            set
            {
                wordName = value;
                OnPropertyChanged();
            }
        }

        private string wordTranslation;
        public string WordTranslation
        {
            get { return wordTranslation; }
            set
            {
                wordTranslation = value;
                OnPropertyChanged();
            }
        }

        public LearningPageVM(IWordRepository wordRepository, PageService pageService)
        {
            this.wordRepository = wordRepository;
            this.pageService = pageService;

            WordName = wordRepository.GetWord(readId).Name;
            WordTranslation = wordRepository.GetWord(readId).Translation;
        }

        public ICommand NextWord => new RelayCommand(obj =>
                {
                    if (readId >= wordRepository.GetMaxId())
                    {
                        readId = 0;
                    }
                    WordName = wordRepository.GetWord(++readId).Name;
                    WordTranslation = wordRepository.GetWord(readId).Translation;
                });

        public ICommand PlayAudio => new RelayCommand(obj =>
                {
                    var player = new MediaPlayer();
                    player.Open(wordRepository.GetPathToAudio(wordRepository.GetWord(readId).PathToAudio));
                    player.Play();
                });

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}