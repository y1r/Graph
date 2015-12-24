using Graph.Containers;
using System;
using System.Windows.Media;

namespace Graph.ViewModels
{
	public class EdgeViewModel : ViewModelBase, IEquatable<EdgeViewModel>
	{
		public SwapablePair<NodeViewModel> Pos
		{
			get;
			private set;
		}

		public EdgeViewModel( SwapablePair<NodeViewModel> pos )
		{
			Pos = pos;
			Pos.First.PropertyChanged += NodeViewPropertyChanged;
			Pos.Second.PropertyChanged += NodeViewPropertyChanged;
			_weight = 1;
			_color = new SolidColorBrush(Colors.Black);
		}

		void NodeViewPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			RaisePropertyChanged("");
		}

		public double OriginX
		{
			get
			{
				return System.Math.Min(Pos.First.xPos, Pos.Second.xPos) + 25;
			}
		}

		public double OriginY
		{
			get
			{
				return System.Math.Min(Pos.First.yPos, Pos.Second.yPos) + 25;
			}
		}

		public double FirstX
		{
			get
			{
				return Pos.First.xPos - OriginX + 25;
			}
		}

		public double FirstY
		{
			get
			{
				return Pos.First.yPos - OriginY + 25;
			}
		}

		public double SecondX
		{
			get
			{
				return Pos.Second.xPos - OriginX + 25;
			}
		}

		public double SecondY
		{
			get
			{
				return Pos.Second.yPos - OriginY + 25;
			}
		}

		public int? _weight
		{
			get;
			private set;
		}

		public string Weight
		{
			get
			{
				if (_weight == null)
					return "";
				else
					return _weight.ToString();
			}
			set
			{
				int input;

				if( value == "" )
				{
					_weight = null;
					RaisePropertyChanged("Weight");
				}
				else if( int.TryParse(value, out input ))
				{
					if( _weight != input )
					{
						_weight = input;
						RaisePropertyChanged("Weight");
					}
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
					_color = value;
					RaisePropertyChanged("Color");
				}
			}
		}

		public bool Equals( EdgeViewModel other )
		{
			return Pos == other.Pos;
		}
	}
}
