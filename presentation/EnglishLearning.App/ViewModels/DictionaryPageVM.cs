using DevExpress.Mvvm;
using DevExpress.Mvvm.Native;
using EnglishLearning.App.Models;
using EnglishLearning.App.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EnglishLearning.App.ViewModels
{
    public class DictionaryPageVM : ViewModelBase
    {
        private readonly IWordRepository wordRepository;

        public ObservableCollection<Word> LearnedWords { get; set; }
        public string Message { get; set; }

        public DictionaryPageVM (IWordRepository wordRepository)
        {
            this.wordRepository = wordRepository;

            ShowListOrMessage();
        }

        private void ShowListOrMessage()
        {
            LearnedWords = wordRepository.GetLearnedWords().ToObservableCollection();

            if (LearnedWords.Count == 0)
                Message = "Словарь пуст";
        }

        public ICommand SubmitWordForLearning => new RelayCommand(obj =>
        {
            Word word = obj as Word;
            word.Learned = false;
            word.Passed = false;
            LearnedWords.Remove(word);
            if (LearnedWords.Count == 0)
                Message = "Словарь пуст";
        }, obj => obj != null);
    }
}
