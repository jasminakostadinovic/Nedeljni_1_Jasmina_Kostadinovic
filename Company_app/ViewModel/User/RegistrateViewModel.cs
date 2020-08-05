using Company_app.View.User;

namespace Company_app.ViewModel.User
{
	class RegistrateViewModel : ViewModelBase
    {
		#region Fields
		readonly RegistrateView view;
		#endregion

		#region Constructor
		internal RegistrateViewModel(RegistrateView view)
		{
			this.view = view;
		}
		#endregion
	}
}
