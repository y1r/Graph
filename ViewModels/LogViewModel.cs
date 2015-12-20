namespace Graph.ViewModels
{
	public class LogViewModel : ViewModelBase
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
					_log = value;
					RaisePropertyChanged("Log");
				}
			}
		}
	}
}
