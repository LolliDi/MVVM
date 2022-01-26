using System.Windows;

namespace MVVM
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ViewModel VM = new ViewModel();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = VM;
            CommandBindings.Add(VM.CBinding1);
        }
    }
}
