using Company_app.View.User;

namespace Company_app.ViewModel.User
{
	class RegistrationViewModel : ViewModelBase
    {
		#region Fields
		readonly RegistrationView view;
		#endregion

		#region Constructor
		internal RegistrationViewModel(RegistrationView view)
		{
			this.view = view;
		}
		#endregion
	}
}
