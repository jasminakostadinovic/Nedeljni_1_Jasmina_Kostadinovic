using Company_app.ViewModel.Master;
using System.Windows;

namespace Company_app.View.Master
{
    /// <summary>
    /// Interaction logic for AddNewAdministratorView.xaml
    /// </summary>
    public partial class AddNewAdministratorView : Window
    {
        public AddNewAdministratorView()
        {
            InitializeComponent();
            this.DataContext = new AddNewAdministratorViewModel(this);
        }
    }
}
