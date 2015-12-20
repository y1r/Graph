using Graph.Containers;

namespace Graph.ViewModels
{
	public class EdgeViewModel : ViewModelBase
	{
		private Pair<int> _pos;
		public int First
		{
			get
			{
				return _pos.First;
			}
			set
			{
				if( _pos.First != value )
				{
					_pos.First = value;
					RaisePropertyChanged("First");
				}
			}
		}

		public int Second
		{
			get
			{
				return _pos.Second;
			}
			set
			{
				if (_pos.Second != value)
				{
					_pos.Second = value;
					RaisePropertyChanged("Second");
				}
			}
		}
	}
}
