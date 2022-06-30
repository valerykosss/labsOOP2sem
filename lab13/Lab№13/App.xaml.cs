using Lab_13.Repository;
using Lab_13.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Lab_13
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void OnStartup(object sender, StartupEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            Context.Context context = new Context.Context();
            ConsultationRepository repository = new ConsultationRepository(context);
            //repository.Insert(new Models.Consultation { Subject = "KGiG", Date = "3 May", Time = "16:30 - 17:50", Count = 20 });
            //context.SaveChanges();
            MainViewModel mainViewModel = new MainViewModel(repository.GetAll().ToList());
            mainWindow.DataContext = mainViewModel;
            mainWindow.Show();
        }
    }
}
