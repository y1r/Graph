using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.ObjectModel;
using Graph.Models;

namespace Graph.ViewModels
{
	public class EdgesViewModel: ObservableCollection<EdgeViewModel>
	{
		public EdgesViewModel(GraphModel graphModel)
		{
			_graphModel = graphModel;
		}

		public new void Add(EdgeViewModel newVM)
		{
			newVM.PropertyChanged += newVM_PropertyChanged;

			base.Add(newVM);
			_graphModel.Connect(newVM.Pos.First.Key, newVM.Pos.Second.Key);
		}

		public new void Remove(EdgeViewModel target)
		{
			base.Remove(target);
			_graphModel.Disconnect(target.Pos.First.Key, target.Pos.Second.Key);
		}

		void newVM_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			switch(e.PropertyName)
			{
				case "Weight":
					{
						var edge = sender as EdgeViewModel;
						if (edge == null) return;
						if (edge._weight == null) return;
						_graphModel.SetWeight(edge.Pos.First.Key, edge.Pos.Second.Key, (int)edge._weight);
						return;
					}

				default:
					return;
			}
		}

		private GraphModel _graphModel;
	}
}
