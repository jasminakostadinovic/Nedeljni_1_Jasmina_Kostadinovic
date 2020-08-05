using Company_app.ViewModel.Master;
using System.Windows;

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
    }
}
