using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using WpfCodeGenerator.Core.ViewModels;

namespace wpf_code_generator_Xavier7071.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var languages = new List<string>
            {
                "CSharp",
                "Swift",
            };

            LanguagesList.ItemsSource = languages;
            LanguagesList.SelectedIndex = 0;
        }

        private void Convert(object sender, RoutedEventArgs e)
        {
            var json = JsonInput.Text;
            var className = ClassNameInput.Text;
            var language = LanguagesList.Text;
            var generatorViewModel = new GeneratorViewModel(json, className, language);

            DisplayErrors(generatorViewModel.ErrorMessages);
        }

        private void DisplayErrors(IReadOnlyList<string> errorMessages)
        {
            if (errorMessages[0].Length != 0)
            {
                ClassNameLabel.Text = errorMessages[0];
                ClassNameLabel.Foreground = Brushes.Red;
            }
            else
            {
                ClassNameLabel.Text = "Nom de la classe";
                ClassNameLabel.Foreground = Brushes.Black;
            }

            if (errorMessages[1].Length != 0)
            {
                JsonLabel.Text = errorMessages[1];
                JsonLabel.Foreground = Brushes.Red;
            }
            else
            {
                JsonLabel.Text = "JSON";
                JsonLabel.Foreground = Brushes.Black;
            }
        }
    }
}
