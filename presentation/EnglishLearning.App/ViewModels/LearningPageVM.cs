using DevExpress.Mvvm;
using EnglishLearning.App.Models;
using EnglishLearning.Services;
using System.Collections.Generic;
using System.Windows.Input;
using System.Windows.Media;

namespace EnglishLearning.App.ViewModels
{
    public class LearningPageVM : ViewModelBase
    {
        private readonly WordService wordService;

        public Word TrainedWord { get; set; }
        public string Message { get; set; }

        private List<Word> words;



        public LearningPageVM(WordService wordService)
        {
            this.wordService = wordService;

            words = wordService.GetListOfWordsForPage(nameof(LearningPageVM));
            GetNextWord();
        }


        public ICommand NextWord => new RelayCommand(obj =>
        {
            TrainedWord.Passed = true;
            words.Remove(TrainedWord);
            GetNextWord();
        }, obj => Message != "Нет слов для изучения");

        public ICommand PlayAudio => new RelayCommand(obj =>
        {
            var player = new MediaPlayer();
            player.Open(wordService.GetPathToAudio(TrainedWord.PathToAudio));
            player.Play();
        }, obj => Message != "Нет слов для изучения");


        private void GetNextWord()
        {
            if (words.Count > 0 && words != null)
            {
                TrainedWord = words[0];
                return;
            }
            else
            {
                Message = "Нет слов для изучения";
                return;
            }
        }
    }
}