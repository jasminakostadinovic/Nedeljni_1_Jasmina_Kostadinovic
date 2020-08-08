using Company_app.Command;
using Company_app.Model;
using Company_app.View.Administrator;
using CompanyData.Models;
using CompanyData.Repositories;
using CompanyData.Validations;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace Company_app.ViewModel.Administrator
{
    class AddNewSectorViewModel : ViewModelBase, IDataErrorInfo
    {
        #region Fields
        private readonly AddNewSectorView addNewSector;
        private string name;
        private string description;
        private tblSector sector;
        private readonly CompanyDBRepository db = new CompanyDBRepository();
        #endregion
        #region Properties
        public bool IsAddedNewSector { get; set; }
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                if (description == value) return;
                description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public bool CanSave { get; set; }
        #endregion

        #region Constructors
        public AddNewSectorViewModel(AddNewSectorView addNewSector)
        {
            this.addNewSector = addNewSector;
            Name = string.Empty;
            Description = string.Empty;
            sector = new tblSector();
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
                var companyValidation = new CompanyValidations();
                string validationMessage = string.Empty;
                if (name == nameof(Name))
                {
                    if (!companyValidation.IsUniqueSectorName(Name))
                    {
                        validationMessage = "Sector name must be unique!";
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
                string.IsNullOrWhiteSpace(Name)
                || CanSave == false)
                return false;
            return true;
        }
        private void SaveExecute()
        {
            try
            {
                sector.SectorName = Name;
                sector.Description = Description;
                //adding new sector to database 
                bool isAdded = db.TryAddNewSector(sector);
                if (isAdded)
                {
                    MessageBox.Show("You have successfully created the new sector.");
                    Logger.Instance.LogCRUD($"[{DateTime.Now.ToString("dd.MM.yyyy hh: mm")}] Created new secto with name: '{Name}'");
                    IsAddedNewSector = true;
                }
                else
                {
                    MessageBox.Show("Something went wrong. New sector is not created.");
                }
                addNewSector.Close();
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
            MainWindow loginWindow = new MainWindow();
            addNewSector.Close();
            loginWindow.Show();

        }

        #endregion
    }
}
