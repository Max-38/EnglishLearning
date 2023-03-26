using DevExpress.Mvvm;
using EnglishLearning.App.Models;
using EnglishLearning.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using System.Windows.Media;

namespace EnglishLearning.App.ViewModels
{
    public class WordTranslationPageVM : ViewModelBase
    {
        private readonly WordService wordService;

        public string TrainedWordNameOrMessage { get; set; }
        public string[] ButtonContent { get; set; }
        public string DescriptionAnswer { get; set; }
        public SolidColorBrush Color { get; set; }

        private List<Word> words;
        private List<Word> allWords;
        private Word trainedWord;
        private string answer;
        Random rnd = new Random();


        public WordTranslationPageVM (WordService wordService)
        {
            this.wordService = wordService;

            words = wordService.GetListOfWordsForPage(nameof(WordTranslationPageVM));
            allWords = wordService.GetListOfWordsForPage();
            GetNextWord();
        }


        public ICommand AcceptAnswer => new RelayCommand(obj =>
        {
            answer = obj as string;

            if (answer == trainedWord.Translation)
            {
                DescriptionAnswer = "Правильно";
                Color = new SolidColorBrush(Colors.Green);
                trainedWord.ExerciseWordTranslation = true;
                wordService.UpdateWord(trainedWord);
            }
            else
            {
                DescriptionAnswer = $"Неверно. Правильный ответ: {trainedWord.Translation}";
                Color = new SolidColorBrush(Colors.Red);
                trainedWord.Passed = false;
                trainedWord.ExerciseListening = false;
                wordService.UpdateWord(trainedWord);
            }
        }, obj => answer == null && TrainedWordNameOrMessage != "Нет слов для тренировки");

        public ICommand NextWord => new RelayCommand(obj =>
        {
            words.Remove(trainedWord);
            answer = null;
            DescriptionAnswer = null;
            Color = null;
            GetNextWord();
        }, obj => answer != null && TrainedWordNameOrMessage != "Нет слов для тренировки");

        private void GetNextWord()
        {
            if (words.Count > 0 && words != null)
            {
                trainedWord = words[0];
                TrainedWordNameOrMessage = trainedWord.Name;
                GetContentForButton();
                return;
            }
            else
            {
                TrainedWordNameOrMessage = "Нет слов для тренировки";
                return;
            }
        }

        private void GetContentForButton()
        {
            if (trainedWord != null)
            {
                int index = trainedWord.Id - 1;
                string[] buttonContent = new string[4];
                for (int i = 0; i < buttonContent.Length; i++)
                {
                    buttonContent[i] = allWords[index].Translation;

                    if (index < allWords.Count - 1)
                        index++;
                    else
                        index = 0;
                }

                if (!buttonContent.Any(item => item == trainedWord.Translation))
                    buttonContent[rnd.Next(0,4)] = trainedWord.Translation;

                ButtonContent = buttonContent;
            }
        }
    }
}
