using Company_app.Command;
using Company_app.View.Master;
using CompanyData.Models;
using CompanyData.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Company_app.ViewModel.Master
{
    class UpdateExpirationAccountDateViewModel : ViewModelBase, IDataErrorInfo
    {
        #region Fields
        private readonly UpdateExpirationAccountDateView updateExpirationAccountDateView;
        private string expirationAccountDate;
        private DateTime dateValue;
        private tblAdministrator administrator;
        private readonly CompanyDBRepository db = new CompanyDBRepository();

        #endregion
        #region Properties
        public bool CanSave { get; set; }
        public string ExpirationAccountDate
        {
            get
            {
                return expirationAccountDate;
            }
            set
            {
                if (expirationAccountDate == value) return;
                expirationAccountDate = value;
                OnPropertyChanged(nameof(ExpirationAccountDate));
            }
        }

        public bool IsDateUpdated { get; set; }
        #endregion

        #region Constructors
        public UpdateExpirationAccountDateViewModel(UpdateExpirationAccountDateView updateExpirationAccountDateView, tblAdministrator administrator)
        {
            this.updateExpirationAccountDateView = updateExpirationAccountDateView;
            this.administrator = administrator;
        }
        #endregion

        #region IDataErrorInfoImplementation
        //validations

        public string Error
        {
            get
            {
                return null;
            }
        }

        public string this[string name]
        {
            get
            {
                CanSave = true;

                string validationMessage = string.Empty;
                var culture = CultureInfo.InvariantCulture;
                var styles = DateTimeStyles.None;

                if (name == nameof(ExpirationAccountDate))
                {
                    if (!DateTime.TryParse(ExpirationAccountDate, culture, styles, out dateValue))
                    {
                        validationMessage = "Invalid date format! use: [4/10/2008]";
                        CanSave = false;
                    }
                    if(dateValue < DateTime.Now)
                    {
                        validationMessage = "Expiration Account Date can not be in the past.";
                        CanSave = false;
                    }
                }
                if (string.IsNullOrEmpty(validationMessage))
                    CanSave = true;

                return validationMessage;
            }
        }
        #endregion

        #region Commands
        private ICommand save;
        public ICommand Save
        {
            get
            {
                if (save == null)
                {
                    save = new RelayCommand(param => SaveExecute(), param => CanSaveExecute());
                }
                return save;
            }
        }

        private bool CanSaveExecute()
        {
            if (
                string.IsNullOrWhiteSpace(ExpirationAccountDate)
                || CanSave == false)
                return false;
            return true;
        }
        private void SaveExecute()
        {
            try
            {
                administrator.ExpirationAccountDate = dateValue;

                //adding new employee record to database 
                IsDateUpdated = db.TryUpdateAdministrator(administrator.AdministratorID, administrator);
                if (IsDateUpdated == false)
                    MessageBox.Show("Unable to update the Expiration Account Date");
                updateExpirationAccountDateView.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        //Escaping action
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
            updateExpirationAccountDateView.Close();
        }

        #endregion
    }
}
