using Company_app.ViewModel.Administrator;
using System.Windows;
using System.Windows.Controls;

namespace Company_app.View.Administrator
{
    /// <summary>
    /// Interaction logic for AddNewSectorView.xaml
    /// </summary>
    public partial class AddNewSectorView : Window
    {
        public AddNewSectorView()
        {
            InitializeComponent();
            this.DataContext = new AddNewSectorViewModel(this);        
        }    
    }
}
