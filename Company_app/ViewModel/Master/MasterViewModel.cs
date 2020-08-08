using Company_app.Command;
using Company_app.View.Master;
using CompanyData.Models;
using CompanyData.Repositories;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace Company_app.ViewModel.Master
{
    class MasterViewModel : ViewModelBase
    {
        #region Fields
        private readonly MasterView hotelOwnerView;
        private vwAdministrator administrator;
        private tblAdministrator selectedAdministrator;
        private List<vwAdministrator> administrators;
        private readonly CompanyDBRepository companyDB = new CompanyDBRepository();
        #endregion
        #region Constructors
        public MasterViewModel(MasterView hotelOwnerView)
        {
            this.hotelOwnerView = hotelOwnerView;
            Administrators = LoadAdministrators();
            selectedAdministrator = new tblAdministrator();
            administrator = new vwAdministrator();
        }
        #endregion
        #region Properties            

        public vwAdministrator Administrator
        {
            get
            {
                return administrator;
            }
            set
            {
                administrator = value;
                OnPropertyChanged(nameof(Administrator));
            }
        }
        public List<vwAdministrator> Administrators
        {
            get
            {
                return administrators;
            }
            set
            {
                administrators = value;
                OnPropertyChanged(nameof(Administrators));
            }
        }

        #endregion
        #region Methods
        private List<vwAdministrator> LoadAdministrators()
        {
            return companyDB.LoadAdministrators();   
        }
        #endregion
        #region Commands

        //adding new administrator

        private ICommand addNewAdministrator;
        public ICommand AddNewAdministrator
        {
            get
            {
                if (addNewAdministrator == null)
                {
                    addNewAdministrator = new RelayCommand(param => AddNewAdministratorExecute(), param => CanAddNewAdministrator());
                }
                return addNewAdministrator;
            }
        }

        private void AddNewAdministratorExecute()
        {
            try
            {
                AddNewAdministratorView addNewAdministratorView = new AddNewAdministratorView();
                addNewAdministratorView.ShowDialog();

                if ((addNewAdministratorView.DataContext as AddNewAdministratorViewModel).IsAddedNewAdministrator == true)
                {
                    Administrators = LoadAdministrators();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanAddNewAdministrator()
        {
            return true;
        }

        //Update administrator ExpirationAccountDate

        private ICommand updateExpirationAccountDate;
        public ICommand UpdateExpirationAccountDate
        {
            get
            {
                if (updateExpirationAccountDate == null)
                {
                    updateExpirationAccountDate = new RelayCommand(param => UpdateExpirationAccountDateExecute(), param => CanupdateExpirationAccountDate());
                }
                return updateExpirationAccountDate;
            }
        }

        private void UpdateExpirationAccountDateExecute()
        {
            try
            {
                if (Administrator != null)
                {
                    selectedAdministrator = companyDB.LoadAdministrator(administrator.AdministratorID);
                    UpdateExpirationAccountDateView updateExpirationAccountDateView = new UpdateExpirationAccountDateView(selectedAdministrator);
                    updateExpirationAccountDateView.ShowDialog();

                    if ((updateExpirationAccountDateView.DataContext as UpdateExpirationAccountDateViewModel).IsDateUpdated == true)
                    {
                        Administrators = LoadAdministrators();
                    }
                }
           
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanupdateExpirationAccountDate()
        {
            if (Administrator == null)
                return false;
            return true;
        }

        //logging out

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
            hotelOwnerView.Close();
            loginWindow.Show();
        }
        #endregion
    }
}
