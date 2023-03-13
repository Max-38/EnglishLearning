using DevExpress.Mvvm;
using EnglishLearning.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using System.Windows.Media;

namespace EnglishLearning.App.ViewModels
{
    public class WordTranslationPageVM : ViewModelBase
    {
        private readonly IWordRepository wordRepository;

        private List<Word> WordsForExercise { get; set; }
        public Word TrainedWord { get; set; }
        public string TrainedWordName { get; set; }
        public string[] ButtonContent { get; set; }
        public string DescriptionAnswer { get; set; }
        public SolidColorBrush Color { get; set; }


        private string answer; 
        private Random rnd = new Random();


        public WordTranslationPageVM (IWordRepository wordRepository)
        {
            this.wordRepository = wordRepository;

            WordsForExercise = wordRepository.GetWordsForExerciseWordTranslation();
            TrainedWord = GetTrainedWord();
            AssingValues();
        }


        public ICommand AcceptAnswer => new RelayCommand(obj =>
        {
            answer = obj as string;

            if (answer == TrainedWord.Translation)
            {
                DescriptionAnswer = "Правильно";
                Color = new SolidColorBrush(Colors.Green);
                TrainedWord.ExerciseWordTranslation = true;
            }
            else
            {
                DescriptionAnswer = $"Неверно. Правильный ответ: {TrainedWord.Translation}";
                Color = new SolidColorBrush(Colors.Red);
                TrainedWord.Passed = false;
                TrainedWord.ExerciseListening = false;
            }
        }, obj => answer == null && TrainedWordName != "Нет слов для тренировки");

        public ICommand NextWord => new RelayCommand(obj =>
        {
            WordsForExercise.Remove(TrainedWord);
            answer = null;
            DescriptionAnswer = null;
            Color = null;
            TrainedWord = GetTrainedWord();
            AssingValues();
        }, obj => answer != null && TrainedWordName != "Нет слов для тренировки");


        private void AssingValues()
        {
            string[] buttonContent = new string[4];
            for (int i = 0; i < 4; i++)
            {
                // переменная count введена из-за малого количества слов. Потом надо будет убрать
                int count = 0;
                do
                {
                    buttonContent[i] = GetContentForButton();
                    count++;
                }
                while (buttonContent.Any(item => item == buttonContent[i]) && count < 4);
            }
            int index = rnd.Next(0, 4);

            if (TrainedWord == null)
            {
                TrainedWordName = "Нет слов для тренировки";
                return;
            }

            if (!buttonContent.Any(item => item == TrainedWord.Translation))
                buttonContent[index] = TrainedWord.Translation;

            ButtonContent = buttonContent;
            TrainedWordName = TrainedWord.Name;
        }


            private Word GetTrainedWord()
            {
                if(WordsForExercise.Count > 0)
                {
                    int index = rnd.Next(0, WordsForExercise.Count);
                    return WordsForExercise[index];
                }
                return null;
            }

        private string GetContentForButton()
        {
            string content = wordRepository.GetRandomWord(rnd).Translation;
            return content;
        }
    }
}
