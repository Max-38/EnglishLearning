using DevExpress.Mvvm;
using DevExpress.Mvvm.Native;
using EnglishLearning.App.Models;
using EnglishLearning.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace EnglishLearning.App.ViewModels
{
    public class DictionaryPageVM : ViewModelBase
    {
        private readonly WordService wordService;

        public ObservableCollection<Word> LearnedWords { get; set; }
        public string Message { get; set; }

        public DictionaryPageVM (WordService wordService)
        {
            this.wordService = wordService;

            ShowListOrMessage();
        }

        private void ShowListOrMessage()
        {
            LearnedWords = wordService.GetListOfWordsForPage(nameof(DictionaryPageVM)).ToObservableCollection();

            if (LearnedWords.Count == 0)
                Message = "Словарь пуст";
        }

        public ICommand TransferWordToRelearn => new RelayCommand(obj =>
        {
            Word word = obj as Word;
            word.ExerciseWordTranslation = false;
            word.ExerciseListening = false;
            word.Passed = false;
            LearnedWords.Remove(word);
            if (LearnedWords.Count == 0)
                Message = "Словарь пуст";
        }, obj => obj != null);
    }
}
