using Graph.Containers;
using System;

namespace Graph.ViewModels
{
	public class EdgeViewModel : ViewModelBase
	{
		private Pair<NodeViewModel> _pos ; 

		public EdgeViewModel( Pair<NodeViewModel> pos )
		{
			_pos = pos;
			_pos.First.PropertyChanged += NodeViewPropertyChanged;
			_pos.Second.PropertyChanged += NodeViewPropertyChanged;
		}

		void NodeViewPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			RaisePropertyChanged("");
		}

		public double OriginX
		{
			get
			{
				return System.Math.Min(_pos.First.xPos, _pos.Second.xPos) + 25;
			}
		}

		public double OriginY
		{
			get
			{
				return System.Math.Min(_pos.First.yPos, _pos.Second.yPos) + 25;
			}
		}

		public double FirstX
		{
			get
			{
				return _pos.First.xPos - OriginX + 25;
			}
		}

		public double FirstY
		{
			get
			{
				return _pos.First.yPos - OriginY + 25;
			}
		}

		public double SecondX
		{
			get
			{
				return _pos.Second.xPos - OriginX + 25;
			}
		}

		public double SecondY
		{
			get
			{
				return _pos.Second.yPos - OriginY + 25;
			}
		}

		private double _weight;
		public double Weight
		{
			get
			{
				return _weight;
			}
			set
			{
				if( _weight != value )
				{
					_weight = value;
					RaisePropertyChanged("Weight");
				}
			}
		}
	}
}
