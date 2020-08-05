using Company_app.ViewModel.User;
using System.Windows;

namespace Company_app.View.User
{
    /// <summary>
    /// Interaction logic for RegistrateView.xaml
    /// </summary>
    public partial class RegistrateView : Window
    {
        public RegistrateView()
        {
            InitializeComponent();
            this.DataContext = new RegistrateViewModel(this);
        }
    }
}
