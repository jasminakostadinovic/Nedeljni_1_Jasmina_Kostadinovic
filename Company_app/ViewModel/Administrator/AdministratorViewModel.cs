using Company_app.Command;
using Company_app.View.Administrator;
using CompanyData.Models;
using CompanyData.Repositories;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace Company_app.ViewModel.Administrator
{
    class AdministratorViewModel : ViewModelBase
    {
        #region Fields
        private readonly AdministratorView adminView;
        private string adminType;
        private tblSector sector;
        private tblSector selectedSector;
        private List<tblSector> sectors;
        private readonly CompanyDBRepository companyDB = new CompanyDBRepository();
        #endregion
        #region Constructors
        public AdministratorViewModel(AdministratorView adminView, string adminType)
        {
            this.adminView = adminView;
            this.adminType = adminType;
            Sectors = LoadSectors();
            selectedSector = new tblSector();
            sector = new tblSector();
        }
        #endregion
        #region Properties            
        public tblSector Sector
        {
            get
            {
                return sector;
            }
            set
            {
                sector = value;
                OnPropertyChanged(nameof(Sector));
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
                sectors = value;
                OnPropertyChanged(nameof(Sectors));
            }
        }

        #endregion
        #region Methods
        private List<tblSector> LoadSectors()
        {
            return companyDB.LoadSectors();
        }
        #endregion
        #region Commands

        //adding new sector

        private ICommand addNewSector;
        public ICommand AddNewSector
        {
            get
            {
                if (addNewSector == null)
                {
                    addNewSector = new RelayCommand(param => AddNewSectorExecute(), param => CanAddNewSector());
                }
                return addNewSector;
            }
        }

        private void AddNewSectorExecute()
        {
            try
            {
                AddNewSectorView addNewSectorViewView = new AddNewSectorView();
                addNewSectorViewView.ShowDialog();

                if ((addNewSectorViewView.DataContext as AddNewSectorViewModel).IsAddedNewSector == true)
                {
                    Sectors = LoadSectors();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanAddNewSector()
        {
            if (Sectors.Count < 17)
                return true;
            return false;
        }

        //Deleting sector

        private ICommand delete;
        public ICommand Delete
        {
            get
            {
                if (delete == null)
                {
                    delete = new RelayCommand(param => DeleteExecute(), param => CanDelete());
                }
                return delete;
            }
        }

        private void DeleteExecute()
        {
            try
            {
                if (Sector != null)
                {
                    DeleteSectorView deleteSector = new DeleteSectorView();
                    deleteSector.ShowDialog();
                    if ((deleteSector.DataContext as DeleteSectorViewModel).ShouldDelete == true)
                    {
                        bool isdeleted = companyDB.TryDeleteSector(Sector.SectorID);
                        if (isdeleted)
                        {
                            Sectors = LoadSectors();
                            MessageBox.Show("You have successfully deleted the sector.");
                        }
                        else
                        {
                            MessageBox.Show("Something went wrong. Sector is not deleted.");
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanDelete()
        {
            if (Sector == null || Sector.SectorName == "Default")
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
            loginWindow.Show();
            adminView.Close();
        }
        #endregion
    }
}
