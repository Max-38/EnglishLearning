using DevExpress.Mvvm;
using EnglishLearning.App.Models;
using EnglishLearning.Memory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace EnglishLearning.App.ViewModels
{ 
    public class StudyWindowVM : INotifyPropertyChanged
    {
        private readonly IWordRepository wordRepository;

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

        public StudyWindowVM(IWordRepository wordRepository)
        {
            this.wordRepository = wordRepository;

            GetNextWord();
        }

        void GetNextWord()
        {
            if (readId >= wordRepository.GetMaxId())
            {
                readId = 0;
            }
            WordName = wordRepository.GetWord(++readId).Name;
            WordTranslation = wordRepository.GetWord(readId).Translation;
        }

        public ICommand NextWord
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    GetNextWord();
                });
            }
        }

        public ICommand PlayAudio
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    var player = new MediaPlayer();
                    player.Open(wordRepository.GetPathToAudio(wordRepository.GetWord(readId).PathToAudio));
                    player.Play();
                });
            }
        }

        //private int click;
        //public int Click
        //{
        //    get { return click; }
        //    set
        //    {
        //        click = value;
        //        OnPropertyChanged();
        //    }
        //}

        //public ICommand ClickAdd
        //{
        //    get
        //    {
        //        return new RelayCommand((obj) =>
        //        {
        //            Click++;
        //        });
        //    }
        //}

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}