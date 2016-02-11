using Microsoft.Practices.Prism.Mvvm;

namespace Graph.ViewModels
{
	public class LogViewModel : BindableBase
	{
		public LogViewModel(string log)
		{
			_log = log;
		}

		private string _log;
		public string Log
		{
			get
			{
				return _log;
			}

			set
			{
				if (Log != value)
				{
					SetProperty(ref _log, value);
				}
			}
		}
	}
}
