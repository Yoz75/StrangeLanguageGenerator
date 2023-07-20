using System;
using System.Windows;
using System.IO;
namespace StrangeLanguageGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private short iteration = 0;
        private IAlgorithmCalculator selectedAlgorithm;
        public MainWindow()
        {
            InitializeComponent();
        }


        private  void GenerateButton_Click(object sender, RoutedEventArgs e)
        {


            if (iteration % 2 == 0)
            {
                 ResultUserText.Text += selectedAlgorithm.Calculate(UserText.Text, isReversedIndex: false, wordlength: Convert.ToInt16(LengthText.Text));
            }
            else
            {
                ResultUserText.Text += selectedAlgorithm.Calculate(UserText.Text, isReversedIndex: true, wordlength: Convert.ToInt16(LengthText.Text));
            }
        
            iteration++;
        }

        private void OpenFileButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.FileName = "Text";
            dialog.DefaultExt = ".txt";
            dialog.Filter = "Text documents |*.txt";
            bool? result = dialog.ShowDialog();
            if (result.Value)
            {
                StreamReader reader = new StreamReader(dialog.FileName);

                UserText.Text = reader.ReadToEnd();
            }
        }

        private void SaveFileButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.SaveFileDialog();
            dialog.FileName = "Document"; // Default file name
            dialog.DefaultExt = ".txt"; // Default file extension
            dialog.Filter = "Text documents (.txt)|*.txt";

            // Show save file dialog box
            bool? result = dialog.ShowDialog();

            // Process save file dialog box results
            if (result == true)
            {
                // Save document
                string filename = dialog.FileName;
                bool isExist = File.Exists(filename);
                if (isExist)
                {
                    File.WriteAllText(filename, ResultUserText.Text);
                }
                else
                {
                    File.Create(filename);
                    File.WriteAllText(filename, ResultUserText.Text);
                }
            }
        }

        private void Scb_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            LengthText.Text = Scb.Value.ToString();
            Scb.Maximum = UserText.Text.Length - 1 ;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            VersionLabel.Content = "Version " + StrangeLanguageGenerator.Version.VERSION;
            selectedAlgorithm = new AlgorithmCalculator();
        }
    }
}
