using Company_app.ViewModel.Master;
using System.Windows;
using System.Windows.Controls;

namespace Company_app.View.Master
{
    /// <summary>
    /// Interaction logic for MasterView.xaml
    /// </summary>
    public partial class MasterView : Window
    {
        public MasterView()
        {
            InitializeComponent();
            this.DataContext = new MasterViewModel(this);
        }
        private void DataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            //hiding id columns
            if (e.Column.Header.ToString() == "EmployeeID")
            {
                e.Column.Visibility = Visibility.Collapsed;
            }
        }
    }
}
