using Company_app.ViewModel.Master;
using CompanyData.Models;
using System.Windows;

namespace Company_app.View.Master
{
    /// <summary>
    /// Interaction logic for UpdateExpirationAccountDateView.xaml
    /// </summary>
    public partial class UpdateExpirationAccountDateView : Window
    {
        public UpdateExpirationAccountDateView(tblAdministrator administrator)
        {
            InitializeComponent();
            this.DataContext = new UpdateExpirationAccountDateViewModel(this, administrator);
        }
    }
}
