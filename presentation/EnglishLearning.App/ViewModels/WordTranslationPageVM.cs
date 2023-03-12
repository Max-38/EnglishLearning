using DevExpress.DXBinding.Native;
using DevExpress.Mvvm;
using EnglishLearning.App.Models;
using EnglishLearning.App.Views;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

namespace EnglishLearning.App.ViewModels
{
    public class WordTranslationPageVM : ViewModelBase
    {
        private readonly IWordRepository wordRepository;

        private List<Word> PassedWords { get; set; }
        public string TrainedWordName { get; set; }
        public string TrainedWordTranslation { get; set; }
        public string[] ButtonContent { get; set; }
        public string DescriptionAnswer { get; set; }
        public SolidColorBrush Color { get; set; }

        private int idTrainedWord;
        private string? answer;
        private Random rnd = new Random();


        public WordTranslationPageVM (IWordRepository wordRepository)
        {
            this.wordRepository = wordRepository;

            PassedWords = wordRepository.GetPassedWords();
            AssingValues();
        }


        public ICommand AcceptAnswer => new RelayCommand(obj =>
        {
            answer = obj as string;

            if (answer == TrainedWordTranslation)
            {
                DescriptionAnswer = "Правильно";
                Color = new SolidColorBrush(Colors.Green);
                wordRepository.GetWord(idTrainedWord).Learned = true;
            }
            else
            {
                DescriptionAnswer = $"Неверно. Правильный ответ: {TrainedWordTranslation}";
                Color = new SolidColorBrush(Colors.Red);
                wordRepository.GetWord(idTrainedWord).Passed = false;
            }
        }, obj => answer == null && TrainedWordName != "Слов для тренировки не осталось");

        public ICommand NextWord => new RelayCommand(obj =>
        {
            Word word = PassedWords.Single(item => item.Id == idTrainedWord);
            PassedWords.Remove(word);
            answer = null;
            DescriptionAnswer = null;
            Color = null;
            AssingValues();
        }, obj => answer != null && TrainedWordName != "Слов для тренировки не осталось");


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
            Word word = GetTrainedWord();
            int index = rnd.Next(0, 4);

            if (word == null)
            {
                TrainedWordName = "Слов для тренировки не осталось";
                return;
            }

            if (!buttonContent.Any(item => item == word.Translation))
                buttonContent[index] = word.Translation;

            ButtonContent = buttonContent;
            TrainedWordName = word.Name;
            TrainedWordTranslation = word.Translation;
        }


            private Word GetTrainedWord()
        {
            if(PassedWords.Count > 0)
            {
                int index = rnd.Next(0, PassedWords.Count);
                idTrainedWord = PassedWords[index].Id;
                return PassedWords[index];
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
