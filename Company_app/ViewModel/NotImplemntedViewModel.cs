using Company_app.Command;
using Company_app.View;
using System.Windows.Input;

namespace Company_app.ViewModel
{
    class NotImplemntedViewModel : ViewModelBase
    {
        #region Fields
        readonly NotImplemntedView view;
        #endregion

        #region Constructor
        internal NotImplemntedViewModel(NotImplemntedView view)
        {
            this.view = view;
        }
        #endregion

        #region Commands

        //closing the view

        private ICommand logout;
        public ICommand Logout
        {
            get
            {
                if (logout == null)
                {
                    logout = new RelayCommand(param => ExitExecute(), param => CanExitExecute());
                }
                return logout;
            }
        }

        private bool CanExitExecute()
        {
            return true;
        }
        private void ExitExecute()
        {
            MainWindow loginWindow = new MainWindow();
            view.Close();
            loginWindow.Show();
        }
        #endregion
    }
}
