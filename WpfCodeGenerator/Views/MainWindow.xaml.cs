using System.Collections.Generic;
using System.Windows;
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
        }
    }
}
