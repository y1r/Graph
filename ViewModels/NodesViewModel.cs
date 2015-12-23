using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.ObjectModel;
using Graph.Models;

namespace Graph.ViewModels
{
	public class NodesViewModel : ObservableCollection<NodeViewModel>
	{
		public NodesViewModel(GraphModel graphModel)
		{
			_graphModel = graphModel;
		}

		public new void Add(NodeViewModel newVM)
		{
			//			newVM.PropertyChanged += newVM_PropertyChanged;
			base.Add(newVM);

			_graphModel.AddNode(newVM.Key);
		}

		public new void Remove(NodeViewModel targetVM)
		{
			base.Remove(targetVM);

			_graphModel.RemoveNode(targetVM.Key);
		}

		/*
		void newVM_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
		}
		 */

		private GraphModel _graphModel;
	}
}
