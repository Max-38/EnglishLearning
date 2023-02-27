using EnglishLearning.App.ViewModels;
using EnglishLearning.Memory;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

namespace EnglishLearning.App
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup (StartupEventArgs e)
        {
            ViewModelLocator.Init();

            base.OnStartup (e);
        }       
    }
}
