using DevExpress.Mvvm;
using EnglishLearning.App.Models;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using System.Windows.Media;

namespace EnglishLearning.App.ViewModels
{
    public class ListeningPageVM : ViewModelBase
    {
        private readonly IWordRepository wordRepository;

        public Word TrainedWord { get; set; }
        public string Answer { get; set; }
        public string DescriptionAnswer { get; set; }
        public string Message { get; set; }
        public SolidColorBrush Color { get; set; }
        private List<Word> WordsForExercise { get; set; }


        private Random rnd = new Random();


        public ListeningPageVM(IWordRepository wordRepository)
        {
            this.wordRepository = wordRepository;

            WordsForExercise = wordRepository.GetWordsForExerciseListening();
            TrainedWord = GetTrainedWord();
            PlayAudio();
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

            WordsForExercise.Remove(TrainedWord);

        }, obj => TrainedWord != null && DescriptionAnswer == null);

        public ICommand NextWord => new RelayCommand(obj =>
        {
            TrainedWord = GetTrainedWord();

            Answer = null;
            DescriptionAnswer = null;

            PlayAudio();

        }, obj => TrainedWord != null && DescriptionAnswer != null);

        public ICommand Play => new RelayCommand(obj =>
        {
            PlayAudio();
        }, obj => TrainedWord != null);

        private Word GetTrainedWord()
        {
            if (WordsForExercise.Count > 0)
            {
                int index = rnd.Next(0, WordsForExercise.Count);
                Message = "Напишите услышанное слово";
                return WordsForExercise[index];
            }
            Message = "Нет слов для тренировки";
            return null;
        }

        private void PlayAudio()
        {
            if (TrainedWord != null)
            {
                var player = new MediaPlayer();
                player.Open(wordRepository.GetPathToAudio(TrainedWord.PathToAudio));
                player.Play();
            }
        }
    }
}
