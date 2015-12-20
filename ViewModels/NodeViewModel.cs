using Microsoft.TeamFoundation.MVVM;

namespace Graph.ViewModels
{
	public class NodeViewModel : ViewModelBase
	{
		private double _xPos;
		public double xPos
		{
			get
			{
				return _xPos;
			}
			set
			{
				if (_xPos != value)
				{
					_xPos = value;
					RaisePropertyChanged("xPos");
				}
			}
		}

		private double _yPos;
		public double yPos
		{
			get
			{
				return _yPos;
			}
			set
			{
				if (_yPos != value)
				{
					_yPos = value;
					RaisePropertyChanged("yPos");
				}
			}
		}

		private double _width;
		public double width
		{
			get
			{
				return _width;
			}
			set
			{
				if (_width != value)
				{
					_width = value;
					RaisePropertyChanged("width");
				}
			}
		}

		private double _height;
		public double height
		{
			get
			{
				return _height;
			}
			set
			{
				if (_height != value)
				{
					_height = value;
					RaisePropertyChanged("height");
				}
			}
		}
	}
}
