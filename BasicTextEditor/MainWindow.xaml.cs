using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace BasicTextEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            myTextBox.Text= string.Empty;
        }

        private void fontSize_Select(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cBox = (ComboBox)sender;
            ComboBoxItem cbItem = cBox.SelectedItem as ComboBoxItem;
            string newFontSize = (string)cbItem.Content;

            int temp;
            if (Int32.TryParse(newFontSize, out temp))
            {
                if (myTextBox != null)
                {
                    myTextBox.FontSize = temp;
                }
            }
        }

        private void boldButton_Click(object sender, RoutedEventArgs e)
        {
            if (myTextBox.FontWeight == FontWeights.Bold)
            {
                myTextBox.FontWeight = FontWeights.Regular;
            }
            else
            {
                myTextBox.FontWeight = FontWeights.Bold;
            }
        }

        private void openButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                myTextBox.Text = File.ReadAllText(openFileDialog.FileName);
            }
            
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All files (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, myTextBox.Text);
            }
        }

        private void italicizeButton_Click(object sender, RoutedEventArgs e)
        {
            if (myTextBox.FontStyle == FontStyles.Italic)
            {
                myTextBox.FontStyle = FontStyles.Normal;
            }
            else
            {
                myTextBox.FontStyle = FontStyles.Italic;
            }
        }

        private void colorComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cBox = (ComboBox)sender;
            ComboBoxItem selectedItem = cBox.SelectedItem as ComboBoxItem;

            if (selectedItem != null && myTextBox != null)
            {
                string colorName = selectedItem.Tag.ToString();

                try
                {
                    Color color = (Color)ColorConverter.ConvertFromString(colorName);
                    myTextBox.Foreground = new SolidColorBrush(color);
                }
                catch (FormatException)
                {
                    myTextBox.Foreground = Brushes.Black;
                }

                
            }
        }
        }
    }

