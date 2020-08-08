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
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Company_app.ViewModel.User
{
    class AddNewEmployeeViewModel : ViewModelBase, IDataErrorInfo
    {
        #region Fields
        private readonly AddNewEmployeeView addNewEmployeeView;
        private tblEmployee employee;
        private string surname;
        private string givenName;
        private string personalNo;
        private string username;
        private string password;
        private string sex;
        private string placeOfResidence;
        private string maritalStatus;
        private Random random = new Random();
        private string[] sexTypes = new string[] { "M", "F", "N", "X" };
        private string[] maritalStatusTypes = new string[] { "single", "married", "divorced" };
        private tblUserData userData;
        private readonly CompanyDBRepository db = new CompanyDBRepository();

        private string sectorName;
        private string position;
        private tblSector sector;
        private List<tblSector> sectors;
        private string professionalQualificationsLevel;
        private string yearsOfService;
        private string[] positions = new string[] {"cleaning",
"cooking", "monitoring", "reporting" };
        private string[] professionalQualificationsLevels = new string[] { "I", "II", "III", "IV", "V", "VI", "VII" };
        private int yearsOfServiceValue;
        #endregion
        #region Properties
        public string SectorName 
        {
            get
            {
                return sectorName;
            }
            set
            {
                if (sectorName == value) return;
                sectorName = value;
                OnPropertyChanged(nameof(SectorName));
            }
        }
        public bool IsAddedNewEmployee { get; internal set; }
        public bool CanSave { get; set; }

        public string[] ProfessionalQualificationsLevels
        {
            get
            {
                return professionalQualificationsLevels;
            }
            set
            {
                if (professionalQualificationsLevels == value) return;
                professionalQualificationsLevels = value;
                OnPropertyChanged(nameof(ProfessionalQualificationsLevels));
            }
        }
        public string[] Positions
        {
            get
            {
                return positions;
            }
            set
            {
                if (positions == value) return;
                positions = value;
                OnPropertyChanged(nameof(Positions));
            }
        }
        public string YearsOfService
        {
            get
            {
                return yearsOfService;
            }
            set
            {
                if (yearsOfService == value) return;
                yearsOfService = value;
                OnPropertyChanged(nameof(YearsOfService));
            }
        }
        public string ProfessionalQualificationsLevel
        {
            get
            {
                return professionalQualificationsLevel;
            }
            set
            {
                if (professionalQualificationsLevel == value) return;
                professionalQualificationsLevel = value;
                OnPropertyChanged(nameof(ProfessionalQualificationsLevel));
            }
        }
        public List<tblSector> Sectors
        {
            get
            {
                return sectors;
            }
            set
            {
                if (sectors == value) return;
                sectors = value;
                OnPropertyChanged(nameof(Sectors));
            }
        }
        public tblSector Sector
        {
            get
            {
                return sector;
            }
            set
            {
                if (sector == value) return;
                sector = value;
                OnPropertyChanged(nameof(Sector));
            }
        }
        public string Position
        {
            get
            {
                return position;
            }
            set
            {
                if (position == value) return;
                position = value;
                OnPropertyChanged(nameof(Position));
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

        public tblEmployee Employee
        {
            get
            {
                return employee;
            }
            set
            {
                employee = value;
                OnPropertyChanged(nameof(Employee));
            }
        }
        #endregion
        #region Constructors
        public AddNewEmployeeViewModel(AddNewEmployeeView addNewEmployeeView)
        {
            this.addNewEmployeeView = addNewEmployeeView;
            PersonalNo = string.Empty;
            Sex = string.Empty;
            PlaceOfResidence = string.Empty;
            MaritalStatus = string.Empty;
            Position = string.Empty;
            Username = string.Empty;
            Password = string.Empty;
            GivenName = string.Empty;
            Surname = string.Empty;
            CanSave = true;
            userData = new tblUserData();
            sectors = LoadSectors();

            Employee = new tblEmployee();
            position = string.Empty;
            sector = new tblSector();
            sectors = LoadSectors();
            professionalQualificationsLevel = string.Empty;
            yearsOfService = string.Empty;
            sectorName = Sector.SectorName;
        }

        private List<tblSector> LoadSectors()
        {
            return db.LoadSectors();
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
                else if (name == nameof(YearsOfService))
                {
                    if (!int.TryParse(YearsOfService, out yearsOfServiceValue))
                    {
                        validationMessage = "Invalid format!";
                        CanSave = false;
                    }
                    if (yearsOfServiceValue < 0)
                    {
                        validationMessage = "Invalid format!";
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
                || Sector == new tblSector()
                || string.IsNullOrWhiteSpace(ProfessionalQualificationsLevel)
                || string.IsNullOrWhiteSpace(YearsOfService)
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
                    employee.Position = Position;
                    employee.YearsOfService = yearsOfServiceValue;
                    employee.UserDataID = userId;
                    employee.SectorID = sector.SectorID;
                    employee.ProfessionalQualificationsLevel = ProfessionalQualificationsLevel;
                    var managers = db.LoadManagers();
                    if(managers == null)
                    {
                        MessageBox.Show("Something went wrong. New employee is not created.");
                    }
                    else
                    {
                        if (managers.Any())
                        {
                            int index = random.Next(0, managers.Count);
                            employee.ManagerID = managers[index].ManagerID;
                            IsAddedNewEmployee = db.TryAddNewEmployee(employee);
                            if (IsAddedNewEmployee == false)
                                MessageBox.Show("Something went wrong. New employee is not created.");
                            else
                            {
                                Logger.Instance.LogCRUD($"[{DateTime.Now.ToString("dd.MM.yyyy hh: mm")}] Created new employee with Personal Number : '{PersonalNo}'");
                                MessageBox.Show("You have successfully created new employee account.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("You can not create the new employee account at the moment.");
                        }
                    }

                
                    var login = new MainWindow();
                    login.Show();
                    addNewEmployeeView.Close();
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
            IsAddedNewEmployee = false;
            addNewEmployeeView.Close();
        }
        #endregion
    }
}
