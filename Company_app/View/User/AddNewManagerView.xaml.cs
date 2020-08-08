using Company_app.ViewModel.User;
using System.Windows;

namespace Company_app.View.User
{
    /// <summary>
    /// Interaction logic for AddNewManagerView.xaml
    /// </summary>
    public partial class AddNewManagerView : Window
    {
        public AddNewManagerView()
        {
            InitializeComponent();
            this.DataContext = new AddNewManagerViewModel(this);
        }
    }
}
