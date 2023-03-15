using DevExpress.Mvvm;
using EnglishLearning.App.Models;
using EnglishLearning.Services;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using System.Windows.Media;

namespace EnglishLearning.App.ViewModels
{
    public class ListeningPageVM : ViewModelBase
    {
        private readonly WordService wordService;

        public Word TrainedWord { get; set; }
        public string Answer { get; set; }
        public string DescriptionAnswer { get; set; }
        public string Message { get; set; }
        public SolidColorBrush Color { get; set; }


        private List<Word> words;


        public ListeningPageVM(WordService wordService)
        {
            this.wordService = wordService;

            words = wordService.GetListOfWordsForPage(nameof(ListeningPageVM));
            GetNextWord();
        }

        public ICommand CheckAnswer => new RelayCommand(obj =>
        {
            if (Answer.ToUpper() == TrainedWord.Name.ToUpper())
            {
                Color = new SolidColorBrush(Colors.Green);
                DescriptionAnswer = "Правильно";

                TrainedWord.ExerciseListening = true;
            }
            else
            {
                Color = new SolidColorBrush(Colors.Red);
                DescriptionAnswer = $"Неверно. Правильный ответ: {TrainedWord.Name}";

                TrainedWord.Passed = false;
                TrainedWord.ExerciseWordTranslation = false;
            }

            words.Remove(TrainedWord);

        }, obj => TrainedWord != null && DescriptionAnswer == null);

        public ICommand NextWord => new RelayCommand(obj =>
        {
            Answer = null;
            DescriptionAnswer = null;
            GetNextWord();

        }, obj => TrainedWord != null && DescriptionAnswer != null);

        public ICommand Play => new RelayCommand(obj =>
        {
            PlayAudio();
        }, obj => TrainedWord != null);

        private void GetNextWord()
        {
            if (words.Count > 0 && words != null)
            {
                TrainedWord = words[0];
                Message = "Напишите услышанное слово";
                PlayAudio();
                return;
            }
            else
            {
                TrainedWord = null;
                Message = "Нет слов для тренировки";
                return;
            }
        }

        private void PlayAudio()
        {
            var player = new MediaPlayer();
            player.Open(wordService.GetPathToAudio(TrainedWord.PathToAudio));
            player.Play();
        }
    }
}
