using Company_app.ViewModel.User;
using System.Windows;

namespace Company_app.View.User
{
    /// <summary>
    /// Interaction logic for RegistrateView.xaml
    /// </summary>
    public partial class RegistrationView : Window
    {
        public RegistrationView()
        {
            InitializeComponent();
            this.DataContext = new RegistrationViewModel(this);
        }
    }
}
