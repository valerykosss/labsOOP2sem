using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;

namespace lab7
{
    /// <summary>
    /// Interaction logic for radial_progress.xaml
    /// </summary>
    public partial class radial_progress : UserControl
    {
        public radial_progress()
        {
            InitializeComponent();
        }
        public static readonly RoutedEvent ToggleButtonEvent;
        static radial_progress()
        {
            radial_progress.ToggleButtonEvent = EventManager.RegisterRoutedEvent("Click",
            RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Button));

        }
        public event RoutedEventHandler Click
        {
            add
            {
                // добавление обработчика
                base.AddHandler(Button.ClickEvent, value);
            }
            remove
            {
                // удаление обработчика
                base.RemoveHandler(Button.ClickEvent, value);
            }
        }
        private void Storyboard_Completed(object sender, EventArgs e)
        {
            if (Application.Current.MainWindow is MainWindow mainWindow)
            {
                mainWindow.Start_Btn.IsChecked = false;
            }
        }
    }
}
