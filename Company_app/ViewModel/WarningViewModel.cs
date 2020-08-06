using Company_app.Command;
using Company_app.View;
using System.Windows;
using System.Windows.Input;

namespace Company_app.ViewModel
{
	class WarningViewModel : ViewModelBase
	{
		WarningView view;
		Window backView;
		public WarningViewModel(WarningView warningView, Window backView)
		{
			view = warningView;
			this.backView = backView;
		}

		private ICommand okCommand;
		public ICommand OkCommand
		{
			get
			{
				if (okCommand == null)
				{
					okCommand = new RelayCommand(Ok);
					return okCommand;
				}
				return okCommand;
			}
		}

		private void Ok(object obj)
		{
			view.Close();
			backView.Show();
		}
	}
}
