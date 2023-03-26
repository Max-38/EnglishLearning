using DevExpress.Mvvm;
using EnglishLearning.App.Models;
using EnglishLearning.Services;
using System;
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
        private MediaPlayer player = new MediaPlayer();



        public LearningPageVM(WordService wordService)
        {
            this.wordService = wordService;

            words = wordService.GetListOfWordsForPage(nameof(LearningPageVM));
            GetNextWord();
        }


        public ICommand NextWord => new RelayCommand(obj =>
        {
            TrainedWord.Passed = true;
            wordService.UpdateWord(TrainedWord);
            words.Remove(TrainedWord);
            GetNextWord();
        }, obj => Message != "Нет слов для изучения");

        public ICommand PlayAudio => new RelayCommand(obj =>
        {
            player.Open(new Uri(@$"Resources\Audio\{TrainedWord.NameAudio}", UriKind.RelativeOrAbsolute));
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