using Company_app.Command;
using Company_app.View.User;
using System.Windows.Input;

namespace Company_app.ViewModel.User
{
    class ConfirmOperationViewModel
    {
        #region Fields
        private ConfirmOperationView confirmOperation;
        #endregion      
        #region Constructors
        public ConfirmOperationViewModel(ConfirmOperationView confirmOperation)
        {
            this.confirmOperation = confirmOperation;
            CanAdd = true;

        }
        #endregion
        public bool CanAdd { get; set; }
        #region Commands
        private ICommand addNewManager;
        public ICommand AddNewManager
        {
            get
            {
                if (addNewManager == null)
                {
                    addNewManager = new RelayCommand(param => SaveExecute(), param => CanSaveExecute());
                }
                return addNewManager;
            }
        }

        private bool CanSaveExecute()
        {
            return true;
        }

        private void SaveExecute()
        {
            AddNewManagerEvaluationView evaluationView = new AddNewManagerEvaluationView();
            evaluationView.Show();
            confirmOperation.Close();
        }

        private ICommand exit;
        public ICommand Exit
        {
            get
            {
                if (exit == null)
                {
                    exit = new RelayCommand(param => ExitExecute(), param => CanExitExecute());
                }
                return exit;
            }
        }

        private bool CanExitExecute()
        {
            return true;
        }

        private void ExitExecute()
        {
            RegistrationView registrationWindow = new RegistrationView(true);       
            confirmOperation.Close();
            registrationWindow.Show();
        }
        #endregion
    }
}
