using Company_app.Command;
using Company_app.Model;
using Company_app.View.User;
using CompanyData.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Company_app.ViewModel.User
{
    class AddNewManagerEvaluationViewModel : ViewModelBase
    {
        #region Fields
        readonly AddNewManagerEvaluationView view;
        private List<string> managerCodes;
        private int count = 0;
        #endregion
        #region Constructor
        internal AddNewManagerEvaluationViewModel(AddNewManagerEvaluationView view)
        {
            this.view = view;
            managerCodes = Logger.Instance.GetManagerCodes();
        }
        #endregion

        #region Commands        

        //adding new manager

        private ICommand addNewManager;
        public ICommand AddNewManager
        {
            get
            {
                if (addNewManager == null)
                {
                    addNewManager = new RelayCommand(AddNewManagerExecute);
                }
                return addNewManager;
            }
        }

        private void AddNewManagerExecute(object obj)
        {
            try
            {
                string password = (obj as PasswordBox).Password;
                if (managerCodes.Contains(password) && count < 3)
                {
                    AddNewManagerView addNewManagerViewView = new AddNewManagerView();                
                    view.Close();
                    addNewManagerViewView.ShowDialog();
                    return;
                }
                else if(count < 2)
                {
                    count++;
                    int attempts = GetLeftAttempts();
                    MessageBox.Show($"Code is wrong. You have {attempts} more attempts.");
                    return;
                }
                else
                {
                    MessageBox.Show("You can not create mannager type of account, continue with creating the employee account.");
                    RegistrationView registrationWindow = new RegistrationView(false);                  
                    registrationWindow.Show();
                    view.Close();

                }           
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private int GetLeftAttempts()
        {
            return 3 - count;
        }

        private bool CanAddNewManager()
        {
            return true;
        }


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
