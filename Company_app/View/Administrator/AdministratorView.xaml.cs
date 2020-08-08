using Company_app.ViewModel.Administrator;
using System.Windows;
using System.Windows.Controls;

namespace Company_app.View.Administrator
{
    /// <summary>
    /// Interaction logic for AdministratorView.xaml
    /// </summary>
    public partial class AdministratorView : Window
    {
        public AdministratorView(string adminType)
        {
            InitializeComponent();
            this.DataContext = new AdministratorViewModel(this, adminType);
        }
        private void DataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            //hiding id columns
            if (e.Column.Header.ToString() == "SectorID")
            {
                e.Column.Visibility = Visibility.Collapsed;
            }
        }
    }
}
