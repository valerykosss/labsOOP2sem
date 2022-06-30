using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace lab7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void ExitCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        private void ExitCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        // Start / Stop Timer
        DispatcherTimer _timer = new DispatcherTimer();
        int counter = 0;
        private void timer_Tick(object sender, EventArgs e)
        {
            counter++;
            TimerLabel.Text = counter.ToString();

            if (counter == 100)
            {
                _timer.Stop();
                TimerLabel.Text = "0".ToString();
            }
        }

        private void StartTimer()
        {
            cpb_uc.Visibility = Visibility.Visible;
            if (counter > 0)
            {
                _timer.Tick -= timer_Tick;
                counter = 0;
            }
            _timer.Interval = TimeSpan.FromMilliseconds(188);
            _timer.Tick += timer_Tick;
            _timer.Start();
        }

        private void StopTimer()
        {
            if (counter > 0)
            {
                _timer.Tick -= timer_Tick;
                counter = 0;
            }

            _timer.Stop();
            cpb_uc.Visibility = Visibility.Collapsed;
            TimerLabel.Text = "0".ToString();
        }

        private void StartAnimation()
        {
            ((Storyboard)cpb_uc.Resources["ProgressBarAnimation"]).Begin();
        }

        private void StopAnimation()
        {
            ((Storyboard)cpb_uc.Resources["ProgressBarAnimation"]).Stop();
        }

        private void Start_Btn_Checked(object sender, RoutedEventArgs e)
        {
            StartTimer();
            StartAnimation();
        }

        private void Start_Btn_Unchecked(object sender, RoutedEventArgs e)
        {
            StopTimer();
            StopAnimation();
        }

        private void Uncheck_Stop(object sender, RoutedEventArgs e)
        {
            Start_Btn.IsChecked = false;
        }

        /*private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }*/
        private void CloseBtn_MouseEnter(object sender, MouseEventArgs e)
        {
            popup_closeBtn.PlacementTarget = CloseBtn;
            popup_closeBtn.Placement = PlacementMode.Left;
            popup_closeBtn.IsOpen = true;

        }
        private void CloseBtn_MouseLeave(object sender, MouseEventArgs e)
        {
            popup_closeBtn.Visibility = Visibility.Collapsed;
            popup_closeBtn.IsOpen = false;

        }
        private void Button_MouseDown(object sender, RoutedEventArgs e)
        {
            TextBlock2.Text += "sender: " + sender.ToString() + "\n";
            TextBlock2.Text += "source: " + e.Source.ToString() + "\n\n";
        }
    }
    public static class CustomCommands
    {
        public static readonly RoutedUICommand Exit = new RoutedUICommand
            (
                "Exit",
                "Exit",
                typeof(CustomCommands),
                new InputGestureCollection()
                {
                    new KeyGesture(Key.F4, ModifierKeys.Alt)
                }
            );

        //Define more commands here, just like the one above
    }
}
