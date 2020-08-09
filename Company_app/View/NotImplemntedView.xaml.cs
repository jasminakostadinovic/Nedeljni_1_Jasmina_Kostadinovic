using Company_app.ViewModel;
using System.Windows;

namespace Company_app.View
{
    /// <summary>
    /// Interaction logic for NotImplemntedView.xaml
    /// </summary>
    public partial class NotImplemntedView : Window
    {
        public NotImplemntedView()
        {
            InitializeComponent();
            this.DataContext = new NotImplemntedViewModel(this);
        }
    }
}
