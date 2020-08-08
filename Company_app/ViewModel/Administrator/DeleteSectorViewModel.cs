using Company_app.Command;
using Company_app.View.Administrator;
using System.Windows.Input;

namespace Company_app.ViewModel.Administrator
{
    class DeleteSectorViewModel : ViewModelBase
    {
        #region Fields
        private DeleteSectorView deleteSector;
        #endregion

        #region Properties
        public bool ShouldDelete { get; set; }
        #endregion

        #region Constructors
        public DeleteSectorViewModel(DeleteSectorView deleteSector)
        {
            this.deleteSector = deleteSector;

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
            return true;
        }

        private void SaveExecute()
        {
            ShouldDelete = true;
            deleteSector.Close();
        }

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
            ShouldDelete = false;
            deleteSector.Close();
        }
        #endregion
    }
}
