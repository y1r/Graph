using Microsoft.TeamFoundation.MVVM;
using System;

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

		private double _size;
		public double Size
		{
			get
			{
				return _size;
			}
			set
			{
				if( _size != value )
				{
					_size = value;
					RaisePropertyChanged("Size");
				}
			}
		}

		private int _key;
		public int Key
		{
			get
			{
				return _key;
			}
			set
			{
				if( _key != value )
				{
					_key = value;
					RaisePropertyChanged("Key");
				}
			}
		}

		private string _name;
		public string Name
		{
			get
			{
				if (_name == null)
					return _key.ToString();
				else
					return _name;
			}
			set
			{
				if( _name != value )
				{
					_name = value;
					RaisePropertyChanged("Name");
				}
			}
		}
	}
}
