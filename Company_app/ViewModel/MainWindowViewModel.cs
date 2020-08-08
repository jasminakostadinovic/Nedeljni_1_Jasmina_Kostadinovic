using Company_app.Command;
using Company_app.Model;
using Company_app.View;
using Company_app.View.Master;
using Company_app.View.User;
using CompanyData.Models;
using CompanyData.Repositories;
using CompanyData.Validations;
using System.Windows.Controls;
using System.Windows.Input;
using DataValidations;

namespace Company_app.ViewModel
{
	class MainWindowViewModel : ViewModelBase
	{
		#region Fields
		private string userName;
		readonly MainWindow loginView;
		#endregion

		#region Constructor
		internal MainWindowViewModel(MainWindow view)
		{
			this.loginView = view;
		}
		#endregion

		#region Properties
		public string UserName
		{
			get
			{
				return userName;
			}
			set
			{
				userName = value;
				OnPropertyChanged(nameof(UserName));
			}
		}
		#endregion
		//login
		private ICommand submitCommand;
		public ICommand SubmitCommand
		{
			get
			{
				if (submitCommand == null)
				{
					submitCommand = new RelayCommand(Submit);
					return submitCommand;
				}
				return submitCommand;
			}
		}

		void Submit(object obj)
		{
			string password = (obj as PasswordBox).Password;
			var validate = new DataValidations.DataValidation();
			var constants = new Constants();
			var validateCompanyData = new CompanyValidations();
			if (UserName == Constants.usernamedMaster && SecurePasswordHasher.Verify(password, constants.passwordEmployeeHashed))
			{
				MasterView masterView = new MasterView();
				loginView.Close();
				masterView.Show();
				return;
			}

			else if (validateCompanyData.IsCorrectUser(userName, password))
			{
				var db = new CompanyDBRepository();
				int userDataId = db.GetUserDataId(userName);
				if (userDataId != 0)
				{
					if (validateCompanyData.GetUserType(userDataId) == nameof(tblManager))
					{
						return;
					}
					if (validateCompanyData.GetUserType(userDataId) == nameof(tblAdministrator))
					{
						return;
					}
					if (validateCompanyData.GetUserType(userDataId) == nameof(tblEmployee))
					{
						return;
					}
				}
					
			}
			else
			{
				WarningView warning = new WarningView(loginView);
				warning.Show("User name or password are not correct!");
				return;
			}
		}

		//registrate
		private ICommand registrateCommand;
		public ICommand RegistrateCommand
		{
			get
			{
				if (registrateCommand == null)
				{
					registrateCommand = new RelayCommand(Registrate);
					return registrateCommand;
				}
				return registrateCommand;
			}
		}

		private void Registrate(object obj)
		{
			RegistrationView registrateView = new RegistrationView(true);
			loginView.Close();
			registrateView.Show();
			return;
		}
	}
}
