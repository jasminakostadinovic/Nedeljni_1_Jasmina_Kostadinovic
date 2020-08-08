using Company_app.Model;
using Company_app.ViewModel;
using System.Windows;

namespace Company_app
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel(this);
            Logger.Instance.GetType();
        }
    }
}
