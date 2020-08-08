using Company_app.ViewModel.User;
using System.Windows;

namespace Company_app.View.User
{
    /// <summary>
    /// Interaction logic for AddNewEmployeeView.xaml
    /// </summary>
    public partial class AddNewEmployeeView : Window
    {
        public AddNewEmployeeView()
        {
            InitializeComponent();
            this.DataContext = new AddNewEmployeeViewModel(this);
        }
    }
}
