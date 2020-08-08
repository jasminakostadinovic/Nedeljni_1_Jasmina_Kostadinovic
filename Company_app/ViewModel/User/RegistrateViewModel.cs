using Company_app.Command;
using Company_app.View.User;
using CompanyData.Repositories;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Company_app.ViewModel.User
{
	class RegistrationViewModel : ViewModelBase
    {
		#region Fields
		readonly RegistrationView view;
        private readonly CompanyDBRepository db = new CompanyDBRepository();
        #endregion

        #region Constructor
        internal RegistrationViewModel(RegistrationView view)
		{
			this.view = view;
		}
        #endregion

        #region Commands

        //adding new patient

        private ICommand addNewEmployee;
        public ICommand AddNewEmployee
        {
            get
            {
                if (addNewEmployee == null)
                {
                    addNewEmployee = new RelayCommand(param => AddNewEmployeeExecute(), param => CanAddNewEmployee());
                }
                return addNewEmployee;
            }
        }

        private void AddNewEmployeeExecute()
        {
            try
            {
                AddNewEmployeeView addNewEmployeeView = new AddNewEmployeeView();
                addNewEmployeeView.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanAddNewEmployee()
        {
            var sectors = db.LoadSectors();
            if (sectors == null)
                return false;
            else
            {
                if (sectors.Any())
                    return true;
                return false;
            }
        }


        //adding new patient

        private ICommand addNewManager;
        public ICommand AddNewManager
        {
            get
            {
                if (addNewManager == null)
                {
                    addNewManager = new RelayCommand(param => AddNewManagerExecute(), param => CanAddNewManager());
                }
                return addNewManager;
            }
        }

        private void AddNewManagerExecute()
        {
            try
            {
                AddNewManagerView addNewManagerViewView = new AddNewManagerView();
                addNewManagerViewView.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
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
