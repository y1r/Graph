using System;
using System.Windows.Media;
using Microsoft.Practices.Prism.Mvvm;

namespace Graph.ViewModels
{
	public class NodeViewModel : BindableBase
	{
		public NodeViewModel()
		{
			_color = new SolidColorBrush(Colors.Black);
		}

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
					SetProperty(ref _xPos, value);
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
					SetProperty(ref _yPos, value);
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
				if (_size != value)
				{
					SetProperty(ref _size, value);
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
				if (_key != value)
				{
					SetProperty(ref _key, value);
				}
			}
		}

		private Brush _color;
		public Brush Color
		{
			get
			{
				return _color;
			}
			set
			{
				if (_color != value)
				{
					SetProperty(ref _color, value);
				}
			}
		}
	}
}
