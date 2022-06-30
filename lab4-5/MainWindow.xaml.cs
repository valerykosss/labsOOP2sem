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
using System.IO;
using Microsoft.Win32;

namespace lab4_5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            cmbFontFamily.ItemsSource = Fonts.SystemFontFamilies.OrderBy(f => f.Source);
			//cmbFontSize.ItemsSource = new List<double>() { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
			colorFont.ItemsSource = new List<string> { "синий", "красный" };
			Uri iconUri = new Uri("pack://application:,,,/images/editor_icon.ico", UriKind.RelativeOrAbsolute);
            this.Icon = BitmapFrame.Create(iconUri);
			rtbEditor.AddHandler(RichTextBox.DragOverEvent, new DragEventHandler(rtbEditor_DragOver), true);
			rtbEditor.AddHandler(RichTextBox.DropEvent, new DragEventHandler(rtbEditor_Drop), true);
		}
		private void rtbEditor_DragOver(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				e.Effects = DragDropEffects.All;
			}
			else
			{
				e.Effects = DragDropEffects.None;
			}
			e.Handled = false;
		}

		private void rtbEditor_Drop(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				string[] docPath = (string[])e.Data.GetData(DataFormats.FileDrop);

				// By default, open as Rich Text (RTF).
				var dataFormat = DataFormats.Rtf;

				// If the Shift key is pressed, open as plain text.
				if (e.KeyStates == DragDropKeyStates.ShiftKey)
				{
					dataFormat = DataFormats.Text;
				}

				System.Windows.Documents.TextRange range;
				System.IO.FileStream fStream;
				if (System.IO.File.Exists(docPath[0]))
				{
					try
					{
						// Open the document in the RichTextBox.
						range = new System.Windows.Documents.TextRange(rtbEditor.Document.ContentStart, rtbEditor.Document.ContentEnd);
						fStream = new System.IO.FileStream(docPath[0], System.IO.FileMode.OpenOrCreate);
						range.Load(fStream, dataFormat);
						fStream.Close();
					}
					catch (System.Exception)
					{
						MessageBox.Show("Файл не может быть открыт. Убедитесь, что это текстовый файл");
					}
				}
			}
		}
		private void rtbEditor_SelectionChanged(object sender, RoutedEventArgs e)
		{
			object temp = rtbEditor.Selection.GetPropertyValue(Inline.FontWeightProperty);
			btnBold.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(FontWeights.Bold));
			temp = rtbEditor.Selection.GetPropertyValue(Inline.FontStyleProperty);
			btnItalic.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(FontStyles.Italic));
			temp = rtbEditor.Selection.GetPropertyValue(Inline.TextDecorationsProperty);
			btnUnderline.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(TextDecorations.Underline));

			temp = rtbEditor.Selection.GetPropertyValue(Inline.FontFamilyProperty);
			cmbFontFamily.SelectedItem = temp;
			temp = rtbEditor.Selection.GetPropertyValue(Inline.FontSizeProperty);
			//cmbFontSize.Text = temp.ToString();
			rtbEditor.Selection.ApplyPropertyValue(Inline.FontSizeProperty, sldrFontSize.Value);
			lblCursorPosition.Text = (new TextRange(rtbEditor.Document.ContentStart, rtbEditor.Document.ContentEnd).Text.Split(' ').Length).ToString();
		}

		private void Open_Executed(object sender, ExecutedRoutedEventArgs e)
		{
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.Filter = "Rich Text Format (*.rtf)|*.rtf|All files (*.*)|*.*";
			if (dlg.ShowDialog() == true)
			{
				FileStream fileStream = new FileStream(dlg.FileName, FileMode.Open);
				TextRange range = new TextRange(rtbEditor.Document.ContentStart, rtbEditor.Document.ContentEnd);
				range.Load(fileStream, DataFormats.Rtf);
			}
		}
		private void Save_Executed(object sender, ExecutedRoutedEventArgs e)
		{
			SaveFileDialog dlg = new SaveFileDialog();
			dlg.Filter = "Rich Text Format (*.rtf)|*.rtf|All files (*.*)|*.*";
			if (dlg.ShowDialog() == true)
			{
				FileStream fileStream = new FileStream(dlg.FileName, FileMode.Create);
				TextRange range = new TextRange(rtbEditor.Document.ContentStart, rtbEditor.Document.ContentEnd);
				range.Save(fileStream, DataFormats.Rtf);
			}
		}
		private void New_Executed(object sender, ExecutedRoutedEventArgs e)
		{
			new MainWindow().Show();
		}
		private void Copy_Executed(object sender, ExecutedRoutedEventArgs e)
		{
		}
		private void Paste_Executed(object sender, ExecutedRoutedEventArgs e)
		{
		}

		private void cmbFontFamily_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (cmbFontFamily.SelectedItem != null)
				rtbEditor.Selection.ApplyPropertyValue(Inline.FontFamilyProperty, cmbFontFamily.SelectedItem);
		}
		private void colorFont_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (colorFont.SelectedItem.Equals("красный"))
			{
				rtbEditor.Foreground = Brushes.Red;
			}
			if (colorFont.SelectedItem.Equals("синий"))
			{
				rtbEditor.Foreground = Brushes.Blue;
			}

		}
		//private void cmbFontSize_TextChanged(object sender, TextChangedEventArgs e)
		//{
		//    rtbEditor.Selection.ApplyPropertyValue(Inline.FontSizeProperty, cmbFontSize.Text);
		//}
		private void sldrFontSize_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            rtbEditor?.Selection.ApplyPropertyValue(Inline.FontSizeProperty, sldrFontSize.Value);//чтобы работала 47 строка с ApplyProperty
        }
	}
}
