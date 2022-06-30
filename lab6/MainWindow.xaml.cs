using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace lab6
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		FlowDocument flowDoc = new FlowDocument();
		TitleInfo _titleInfo = new TitleInfo();
		internal TitleInfo TitleInfo
		{
			get => _titleInfo;
		}
		internal bool IsMain { get; set; }
		public MainWindow()
		{
			InitializeComponent();
			Application.Current.MainWindow.Closing += new CancelEventHandler(MainWindow_Closing);
			_titleInfo.FilePath = "";
			TitleInfo.NumWindows = ++TitleInfo.NumWindows;
			if (TitleInfo.NumWindows == 1) IsMain = true;
			else IsMain = false;
			cmbFontFamily.ItemsSource = Fonts.SystemFontFamilies.OrderBy(f => f.Source);
			//cmbFontSize.ItemsSource = new List<double>() { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
			//colorFont.ItemsSource = new List<string> { "синий", "красный" };
			Uri iconUri = new Uri("pack://application:,,,/images/editor_icon.ico", UriKind.RelativeOrAbsolute);
			this.Icon = BitmapFrame.Create(iconUri);
			this.Title += ", №" + TitleInfo.NumWindows;
			this.DataContext = this;
			this.rtbEditor.AllowDrop = true;
			rtbEditor.AddHandler(RichTextBox.DragOverEvent, new DragEventHandler(rtbEditor_DragOver), true);
			rtbEditor.AddHandler(RichTextBox.DropEvent, new DragEventHandler(rtbEditor_Drop), true);
			DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(Queue<string>));
			using (FileStream fs = new FileStream("lastDocs.json", FileMode.OpenOrCreate))
			{
				if (fs.Length != 0)
				{
					object res = jsonFormatter.ReadObject(fs);
					TitleInfo._lastDocs = (Queue<string>)res;
					foreach (var doc in TitleInfo._lastDocs)
					{
						MenuItem menuItemDoc = new MenuItem()
						{
							Header = doc.Split('\\').Last(),
							Foreground = Brushes.Black,
						};
						menuItemDoc.Click += MenuItemDoc_Click;
						fileMenu.Items.Add(menuItemDoc);
					}
				}
			}
		}
		private void MainWindow_Closing(object sender, CancelEventArgs e)
		{
			DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(Queue<string>));
			using (FileStream fs = new FileStream("lastDocs.json", FileMode.OpenOrCreate))
			{
				jsonFormatter.WriteObject(fs, TitleInfo._lastDocs);
			}
		}

		private void MenuItemDoc_Click(object sender, RoutedEventArgs e)
		{
			MenuItem mu = (MenuItem)sender;
			string clicked_path = TitleInfo._lastDocs.Where(path => path.Contains((string)mu.Header)).First();
			TextRange tr = new TextRange(rtbEditor.Document.ContentStart, rtbEditor.Document.ContentEnd);
			using (FileStream fs = File.Open(clicked_path, FileMode.Open))
			{
				tr.Load(fs, DataFormats.Rtf);
				this.Title = "№" + TitleInfo.NumWindows;
			}
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
		private void MenuItem_Click1(object sender, RoutedEventArgs e)//new
        {
			new MainWindow().Show();
			/*flowDoc = new FlowDocument();
			rtbEditor.Document = flowDoc;
			this.TitleInfo.FilePath = "";
			this.Title = " Path: " + _titleInfo.FilePath;*/
		}
		private void MenuItem_Click2(object sender, RoutedEventArgs e)//close new
		{
			foreach (Window window in App.Current.Windows)
			{
				if (window is MainWindow)
				{
					MainWindow mw = (MainWindow)window;
					if (!mw.IsMain) mw.Close();
				}
			}
		}
		private void MenuItem_Click3(object sender, RoutedEventArgs e)//save
		{
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Filter = "Text Files (*.txt)|*.txt|RichText Files (*.rtf)|*.rtf|XAML Files (*.xaml)|*.xaml|All files (*.*)|*.*";
			if (sfd.ShowDialog() == true)
			{
				TextRange doc = new TextRange(rtbEditor.Document.ContentStart, rtbEditor.Document.ContentEnd);
				using (FileStream fs = File.Create(sfd.FileName))
				{
					if (System.IO.Path.GetExtension(sfd.FileName).ToLower() == ".rtf")
						doc.Save(fs, DataFormats.Rtf);
					else if (System.IO.Path.GetExtension(sfd.FileName).ToLower() == ".txt")
						doc.Save(fs, DataFormats.Text);
					else
						doc.Save(fs, DataFormats.Xaml);
					this.Title = "Path: " + sfd.FileName + ", № " + TitleInfo.NumWindows;
				}
				AddPathMenuItem(sfd.FileName);
			}
		}
		private void AddPathMenuItem(string path)
		{
			if (TitleInfo._lastDocs.Count < 5)
			{
				TitleInfo._lastDocs.Enqueue(path);
			}
			else
			{
				TitleInfo._lastDocs.Dequeue();
				TitleInfo._lastDocs.Enqueue(path);
			}
			MenuItem menuItemDoc = new MenuItem()
			{
				Header = path.Split('\\').Last(),
				Foreground = Brushes.Black,
			};
			menuItemDoc.Click += MenuItemDoc_Click;
			fileMenu.Items.Add(menuItemDoc);
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
		public void Undo(object sender, RoutedEventArgs e)
		{
			rtbEditor.Undo();
		}

		public void Redo(object sender, RoutedEventArgs e)
		{
			rtbEditor.Redo();
		}

		private void cmbFontFamily_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (cmbFontFamily.SelectedItem != null)
				rtbEditor.Selection.ApplyPropertyValue(Inline.FontFamilyProperty, cmbFontFamily.SelectedItem);
		}
		private void colorFont_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (rtbEditor == null) return;
			ComboBox comboBox = (ComboBox)sender;
			string color = colorFont.SelectedItem.ToString();
			this.ChangeSelectedTextProperty(TextElement.ForegroundProperty, Regex.Replace(color.Trim(), @".*\s+", ""));

		}
		private void ChangeSelectedTextProperty(DependencyProperty property, object value)
		{
			var selection = rtbEditor.Selection;
			if (!selection.IsEmpty)
				selection.ApplyPropertyValue(property, value);
		}
		//private void cmbFontSize_TextChanged(object sender, TextChangedEventArgs e)
		//{
		//    rtbEditor.Selection.ApplyPropertyValue(Inline.FontSizeProperty, cmbFontSize.Text);
		//}
		private void sldrFontSize_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			rtbEditor?.Selection.ApplyPropertyValue(Inline.FontSizeProperty, sldrFontSize.Value);//чтобы работала 47 строка с ApplyProperty
		}
		private void interfaceLanguage_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			switch ((string)interfaceLanguage.SelectedItem)
			{
				case "En":
					this.Resources.Source = new Uri("pack://application:,,,/language/en.xaml");
					break;
				case "Рус":
					this.Resources.Source = new Uri("pack://application:,,,/language/ru.xaml");
					//this.Resources.Source = new Uri("en.xaml");
					break;
			}
		}
		private void theme_Selected(object sender, RoutedEventArgs e)
		{
			ComboBoxItem thm = (ComboBoxItem)selectedTheme.SelectedItem;
			Application.Current.Resources.Clear();

			switch ((string)thm?.Content)
			{
				case "Розовая":
					var uri = new Uri("/themes/pink.xaml", UriKind.Relative);
					ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
					Application.Current.Resources.Clear();
					Application.Current.Resources.MergedDictionaries.Add(resourceDict);
					break;
				case "Желтая":
					var uri2 = new Uri("/themes/yellow.xaml", UriKind.Relative);
					ResourceDictionary resourceDict2 = Application.LoadComponent(uri2) as ResourceDictionary;
					Application.Current.Resources.Clear();
					Application.Current.Resources.MergedDictionaries.Add(resourceDict2);
					break;
				case "Зеленая":
					var uri3 = new Uri("/themes/green.xaml", UriKind.Relative);
					ResourceDictionary resourceDict3 = Application.LoadComponent(uri3) as ResourceDictionary;
					Application.Current.Resources.Clear();
					Application.Current.Resources.MergedDictionaries.Add(resourceDict3);
					break;
			}

		}

        private void fileMenu_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
