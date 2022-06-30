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

namespace lab7
{
    /// <summary>
    /// Interaction logic for popup.xaml
    /// </summary>
    public partial class popup : UserControl
    {
        public popup()
        {
            InitializeComponent();
        }
        public static readonly DependencyProperty TextDependencyProperty;
        static popup()
        {
            TextDependencyProperty = DependencyProperty.Register("TextProperty", typeof(string), typeof(popup));

        }
        public string TextProperty
        {
            get { return (string)GetValue(TextDependencyProperty); }
            set { SetValue(TextDependencyProperty, value); }
        } 
    }
}
