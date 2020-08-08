using Company_app.Command;
using Company_app.Model;
using Company_app.View.Master;
using CompanyData.Models;
using CompanyData.Repositories;
using CompanyData.Validations;
using DataValidations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Company_app.ViewModel.Master
{
    class AddNewAdministratorViewModel : ViewModelBase, IDataErrorInfo
    {
        #region Fields
        private readonly AddNewAdministratorView addNewAdministratorView;
        private tblAdministrator administrator;
        private string surname;
        private string givenName;
        private string personalNo;
        private string sex;
        private string placeOfResidence;
        private string maritalStatus;
        private string administratorTeam;
        private string username;
        private string password;
        private tblUserData userData;
        private readonly CompanyDBRepository db = new CompanyDBRepository();
        private string[] sexTypes = new string[] { "M", "F", "N", "X" };
        private string[] maritalStatusTypes = new string[] { "single", "married", "divorced"};
        private string[] administratorTeams = new string[] { "Team", "System", "Local" };
        #endregion
        #region Properties
        public bool IsAddedNewAdministrator { get; internal set; }
        public bool CanSave { get; set; }
        public string[] AdministratorTeams
        {
            get
            {
                return administratorTeams;
            }
            set
            {
                if (administratorTeams == value) return;
                administratorTeams = value;
                OnPropertyChanged(nameof(AdministratorTeams));
            }
        }
        public string[] MaritalStatusTypes
        {
            get
            {
                return maritalStatusTypes;
            }
            set
            {
                if (maritalStatusTypes == value) return;
                maritalStatusTypes = value;
                OnPropertyChanged(nameof(MaritalStatusTypes));
            }
        }
        public string[] SexTypes
        {
            get
            {
                return sexTypes;
            }
            set
            {
                if (sexTypes == value) return;
                sexTypes = value;
                OnPropertyChanged(nameof(SexTypes));
            }
        }
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                if (password == value) return;
                password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                if (username == value) return;
                username = value;
                OnPropertyChanged(nameof(Username));
            }
        }
        public string AdministratorTeam
        {
            get
            {
                return administratorTeam;
            }
            set
            {
                if (administratorTeam == value) return;
                administratorTeam = value;
                OnPropertyChanged(nameof(AdministratorTeam));
            }
        }
        public string MaritalStatus
        {
            get
            {
                return maritalStatus;
            }
            set
            {
                if (maritalStatus == value) return;
                maritalStatus = value;
                OnPropertyChanged(nameof(MaritalStatus));
            }
        }
        public string PlaceOfResidence
        {
            get
            {
                return placeOfResidence;
            }
            set
            {
                if (placeOfResidence == value) return;
                placeOfResidence = value;
                OnPropertyChanged(nameof(PlaceOfResidence));
            }
        }
        public string Sex
        {
            get
            {
                return sex;
            }
            set
            {
                if (sex == value) return;
                sex = value;
                OnPropertyChanged(nameof(Sex));
            }
        }
        public string PersonalNo
        {
            get
            {
                return personalNo;
            }
            set
            {
                if (personalNo == value) return;
                personalNo = value;
                OnPropertyChanged(nameof(PersonalNo));
            }
        }
        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                if (surname == value) return;
                surname = value;
                OnPropertyChanged(nameof(Surname));
            }
        }

        public string GivenName
        {
            get
            {
                return givenName;
            }
            set
            {
                if (givenName == value) return;
                givenName = value;
                OnPropertyChanged(nameof(GivenName));
            }
        }

        public tblAdministrator Administrator
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
        #endregion
        #region Constructors
        public AddNewAdministratorViewModel(AddNewAdministratorView addNewAdministratorView)
        {
            this.addNewAdministratorView = addNewAdministratorView;
            PersonalNo = string.Empty;
            Sex = string.Empty;
            PlaceOfResidence = string.Empty;
            MaritalStatus = string.Empty;
            AdministratorTeam = string.Empty;
            Username = string.Empty;
            Password = string.Empty;
            GivenName = string.Empty;
            Surname = string.Empty;
            Administrator = new tblAdministrator();
            CanSave = true;
            userData = new tblUserData();
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
                var validate = new DataValidation();
                var companyValidation = new CompanyValidations();    
                string validationMessage = string.Empty;

                if (name == nameof(PersonalNo))
                {
                    if (!validate.IsValidPersonalNoFormat(PersonalNo))
                    {
                        validationMessage = "Invalid personal number format!";
                        CanSave = false;
                    }
                    if (!companyValidation.IsUniquePersonalNo(PersonalNo))
                    {
                        validationMessage = "Personal number must be unique!";
                        CanSave = false;
                    }
                }
                else if (name == nameof(Username))
                {
                    if (!companyValidation.IsUniqueUsername(Username))
                    {
                        validationMessage = "Username number must be unique!";
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
                string.IsNullOrWhiteSpace(GivenName)
                || string.IsNullOrWhiteSpace(Surname)
                || string.IsNullOrWhiteSpace(Sex)
                || string.IsNullOrWhiteSpace(PlaceOfResidence)
                || string.IsNullOrWhiteSpace(MaritalStatus)
                || string.IsNullOrWhiteSpace(PersonalNo)
                || string.IsNullOrWhiteSpace(AdministratorTeam)
                || string.IsNullOrWhiteSpace(Username)
                || string.IsNullOrWhiteSpace(Password)
                || CanSave == false)
                return false;
            return true;
        }
        private void SaveExecute()
        {
            try
            {
                userData.GivenName = GivenName;
                userData.Surname = Surname;
                userData.PersonalNo = PersonalNo;
                userData.Sex = Sex;
                userData.PlaceOfResidence = PlaceOfResidence;
                userData.MaritalStatus = MaritalStatus;
                userData.Username = Username;
                userData.Password = SecurePasswordHasher.Hash(Password);

                //adding new administrator to database 
                db.TryAddNewUserData(userData);
                var userId = db.GetUserDataId(Username);
                if (userId != 0)
                {
                    administrator.AdministratorTeam = AdministratorTeam;
                    administrator.ExpirationAccountDate = GenerateExpirationAccountDate();
                    administrator.UserDataID = userId;

                    IsAddedNewAdministrator = db.TryAddNewAdministrator(administrator);
                    if (IsAddedNewAdministrator == false)
                        MessageBox.Show("Something went wrong. New administrator is not created.");
                    else
                    {
                        Logger.Instance.LogCRUD($"[{DateTime.Now.ToString("dd.MM.yyyy hh: mm")}] Created new administrator with Personal Number : '{PersonalNo}'");
                    }
                    addNewAdministratorView.Close();
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private DateTime GenerateExpirationAccountDate()
        {
            return DateTime.Now.AddDays(7);
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
            IsAddedNewAdministrator = false;
            addNewAdministratorView.Close();
        }
        #endregion
    }
}
