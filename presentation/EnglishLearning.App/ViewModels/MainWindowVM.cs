using DevExpress.Mvvm;
using EnglishLearning.App.Models;
using EnglishLearning.App.Services;
using EnglishLearning.App.Views;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace EnglishLearning.App.ViewModels
{
    public class MainWindowVM : ViewModelBase
    {
        private readonly PageService pageService;

        public Page PageSource { get; set; }

        public MainWindowVM (PageService pageService)
        {
            this.pageService = pageService;

            this.pageService.OnPageChanged += (page) => PageSource = page;
        }

        public ICommand ChangePageToLearningPage => new RelayCommand(obj =>
        {
            this.pageService.ChangePage(new LearningPage());
        });

        public ICommand ChangePageToWordTranslationPage => new RelayCommand(obj =>
        {
            this.pageService.ChangePage(new WordTranslationPage());
        });

        public ICommand ChangePageToDictionaryPage => new RelayCommand(obj =>
        {
            this.pageService.ChangePage(new DictionaryPage());
        });

        public ICommand Quit => new RelayCommand(obj =>
        {
            Application.Current.Shutdown();
        });
    }
}
