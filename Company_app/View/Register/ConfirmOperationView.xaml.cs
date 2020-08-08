using Company_app.ViewModel.User;
using System.Windows;

namespace Company_app.View.User
{
    /// <summary>
    /// Interaction logic for ConfirmOperationView.xaml
    /// </summary>
    public partial class ConfirmOperationView : Window
    {
        public ConfirmOperationView()
        {
            InitializeComponent();
            this.DataContext = new ConfirmOperationViewModel(this);
        }
        public void Show(string message)
        {
            lblText.Content = message;
            this.Show();
        }
    }
}
