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
    public class MainWindowVM : INotifyPropertyChanged
    {
        private readonly PageService pageService;

        private Page pageSource;
        public Page PageSource
        {
            get { return pageSource; }
            set
            {
                pageSource = value;
                OnPropertyChanged();
            }
        }

        public MainWindowVM (PageService pageService)
        {
            this.pageService = pageService;

            this.pageService.OnPageChanged += (page) => PageSource = page;
            this.pageService.ChangePage(new LearningPage());
        }

        public ICommand ChangePage => new RelayCommand(obj =>
        {
            this.pageService.ChangePage(new TestPage());
        });

        public ICommand Quit => new RelayCommand(obj =>
        {
            Application.Current.Shutdown();
        });


        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
