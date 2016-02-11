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
			base.Add(newVM);

			_graphModel.AddNode(newVM.Key);
		}

		public new void Remove(NodeViewModel targetVM)
		{
			base.Remove(targetVM);

			_graphModel.RemoveNode(targetVM.Key);
		}

		private GraphModel _graphModel;
	}
}
