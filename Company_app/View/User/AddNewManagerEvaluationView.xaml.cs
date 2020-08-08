using Company_app.ViewModel.User;
using System.Windows;

namespace Company_app.View.User
{
    /// <summary>
    /// Interaction logic for AddNewManagerEvaluationView.xaml
    /// </summary>
    public partial class AddNewManagerEvaluationView : Window
    {
        public AddNewManagerEvaluationView()
        {
            InitializeComponent();
            this.DataContext = new AddNewManagerEvaluationViewModel(this);
        }
    }
}
