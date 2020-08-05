using Company_app.Command;
using Company_app.View.Master;
using System;
using System.Windows.Input;

namespace Company_app.ViewModel.Master
{
    class MasterViewModel : ViewModelBase
    {
        #region Fields
        private readonly MasterView hotelOwnerView;
        #endregion
        #region Constructors
        public MasterViewModel(MasterView hotelOwnerView)
        {
            this.hotelOwnerView = hotelOwnerView;
        }
        #endregion

        //#region Commands

        ////adding new emloyee

        //private ICommand addNewEmployee;
        //public ICommand AddNewEmployee
        //{
        //    get
        //    {
        //        if (addNewEmployee == null)
        //        {
        //            addNewEmployee = new RelayCommand(param => AddNewEmployeeExecute(), param => CanAddNewEmployee());
        //        }
        //        return addNewEmployee;
        //    }
        //}

        //private void AddNewEmployeeExecute()
        //{
        //    try
        //    {
        //        AddNewEmployeeView addNewEmployeeView = new AddNewEmployeeView();
        //        addNewEmployeeView.ShowDialog();

        //        if ((addNewEmployeeView.DataContext as AddNewEmployeeViewModel).IsAddedNewEmployee == true)
        //        {
        //            MessageBox.Show("New employee has been successfully created.");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //}

        //private bool CanAddNewEmployee()
        //{
        //    return true;
        //}

        ////adding new manager

        //private ICommand addNewManager;
        //public ICommand AddNewManager
        //{
        //    get
        //    {
        //        if (addNewManager == null)
        //        {
        //            addNewManager = new RelayCommand(param => AddNewManagerExecute(), param => CanAddNewManager());
        //        }
        //        return addNewManager;
        //    }
        //}

        //private void AddNewManagerExecute()
        //{
        //    try
        //    {
        //        AddNewManagerView addNewManagerView = new AddNewManagerView();
        //        addNewManagerView.ShowDialog();

        //        if ((addNewManagerView.DataContext as AddNewManagerViewModel).IsAddedNewManager == true)
        //        {
        //            MessageBox.Show("New manager has been successfully created.");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //}

        //private bool CanAddNewManager()
        //{
        //    return true;
        //}

        ////logging out

        //private ICommand logout;
        //public ICommand Logout
        //{
        //    get
        //    {
        //        if (logout == null)
        //        {
        //            logout = new RelayCommand(param => ExitExecute(), param => CanExitExecute());
        //        }
        //        return logout;
        //    }
        //}

        //private bool CanExitExecute()
        //{
        //    return true;
        //}

        //private void ExitExecute()
        //{
        //    MainWindow loginWindow = new MainWindow();
        //    hotelOwnerView.Close();
        //    loginWindow.Show();
        //}
        //#endregion
    }
}
