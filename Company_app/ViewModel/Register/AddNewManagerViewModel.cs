using Company_app.Command;
using Company_app.Model;
using Company_app.View.User;
using CompanyData.Models;
using CompanyData.Repositories;
using CompanyData.Validations;
using DataValidations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace Company_app.ViewModel.User
{
    class AddNewManagerViewModel : ViewModelBase, IDataErrorInfo
    {

        #region Fields
        private readonly AddNewManagerView addNewManagerView;
        private tblManager manager;
        private string surname;
        private string givenName;
        private string personalNo;
        private string username;
        private string password;
        private string sex;
        private string placeOfResidence;
        private string maritalStatus;
        private string[] sexTypes = new string[] { "M", "F", "N", "X" };
        private string[] maritalStatusTypes = new string[] { "single", "married", "divorced" };
        private tblUserData userData;
        private readonly CompanyDBRepository db = new CompanyDBRepository();

        private string passwordHint;
        private string email;
        private string officeNumber;
        private string projectsCount;
        
        private int projectsCountValue;
        #endregion
        #region Properties
        public bool IsAddedNewManager { get; internal set; }
        public bool CanSave { get; set; }
        public string ProjectsCount
        {
            get
            {
                return projectsCount;
            }
            set
            {
                if (projectsCount == value) return;
                projectsCount = value;
                OnPropertyChanged(nameof(ProjectsCount));
            }
        }
        public string OfficeNumber
        {
            get
            {
                return officeNumber;
            }
            set
            {
                if (officeNumber == value) return;
                officeNumber = value;
                OnPropertyChanged(nameof(OfficeNumber));
            }
        }
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                if (email == value) return;
                email = value;
                OnPropertyChanged(nameof(Email));
            }
        }
        public string PasswordHint
        {
            get
            {
                return passwordHint;
            }
            set
            {
                if (passwordHint == value) return;
                passwordHint = value;
                OnPropertyChanged(nameof(PasswordHint));
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

        public tblManager Manager
        {
            get
            {
                return manager;
            }
            set
            {
                manager = value;
                OnPropertyChanged(nameof(Manager));
            }
        }
        #endregion
        #region Constructors
        public AddNewManagerViewModel(AddNewManagerView addNewManagerView)
        {
            this.addNewManagerView = addNewManagerView;
            PersonalNo = string.Empty;
            Sex = string.Empty;
            PlaceOfResidence = string.Empty;
            MaritalStatus = string.Empty;
            Username = string.Empty;
            Password = string.Empty;
            GivenName = string.Empty;
            Surname = string.Empty;
            CanSave = true;
            userData = new tblUserData();

            Manager = new tblManager();
            passwordHint = string.Empty;
            email = string.Empty;
            officeNumber = string.Empty;
            projectsCount = string.Empty;
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
                else if (name == nameof(ProjectsCount))
                {
                    if (!int.TryParse(ProjectsCount, out projectsCountValue))
                    {
                        validationMessage = "Invalid format!";
                        CanSave = false;
                    }
                    if (projectsCountValue < 0)
                    {
                        validationMessage = "Invalid format!";
                        CanSave = false;
                    }

                }
                else if (name == nameof(Email))
                {
                    if (!validate.IsValidEmail(Email))
                    {
                        validationMessage = "Invalid email format!";
                        CanSave = false;
                    }
                }
                else if (name == nameof(PasswordHint))
                {
                    if (PasswordHint.Length < 5)
                    {
                        validationMessage = "Password hint must be at least 5 characters long!";
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
                || string.IsNullOrWhiteSpace(Username)
                || string.IsNullOrWhiteSpace(Password)
                || string.IsNullOrWhiteSpace(ProjectsCount)
                || string.IsNullOrWhiteSpace(OfficeNumber)
                || string.IsNullOrWhiteSpace(PasswordHint)
                || string.IsNullOrWhiteSpace(Email)
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

                //adding new employee to database 
                db.TryAddNewUserData(userData);
                var userId = db.GetUserDataId(Username);
                if (userId != 0)
                {
                    manager.PasswordHint = PasswordHint + "WPF";
                    manager.OfficeNumber = OfficeNumber;
                    manager.UserDataID = userId;
                    manager.ProjectsCount = ProjectsCount;
                    manager.Email = Email;

                    IsAddedNewManager = db.TryAddNewManager(manager);
                    if (IsAddedNewManager == false)
                        MessageBox.Show("Something went wrong. New manager is not created.");
                    else
                    {
                        Logger.Instance.LogCRUD($"[{DateTime.Now.ToString("dd.MM.yyyy hh: mm")}] Created new manager with Personal Number : '{PersonalNo}'");
                        MessageBox.Show("You have successfully created new manager account.");
                    }
                    var login = new MainWindow();
                    login.Show();
                    addNewManagerView.Close();
                    return;
                }
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
            var login = new MainWindow();
            login.Show();
            IsAddedNewManager = false;
            addNewManagerView.Close();
        }
        #endregion
    }
}
