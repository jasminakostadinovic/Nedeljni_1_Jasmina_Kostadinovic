using Company_app.ViewModel.Administrator;
using System.Windows;

namespace Company_app.View.Administrator
{
    /// <summary>
    /// Interaction logic for DeleteSectorView.xaml
    /// </summary>
    public partial class DeleteSectorView : Window
    {
        public DeleteSectorView()
        {
            InitializeComponent();
            this.DataContext = new DeleteSectorViewModel(this);
        }
    }
}
