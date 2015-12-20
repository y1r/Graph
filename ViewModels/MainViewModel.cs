using System;
using System.ComponentModel;
using System.Windows.Input;
using Microsoft.TeamFoundation.MVVM;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Collections.ObjectModel;

namespace Graph.ViewModels
{
	public class MainViewModel : ViewModelBase
	{
		private ObservableCollection<NodeViewModel> _nodes = new ObservableCollection<NodeViewModel>();
		public ObservableCollection<NodeViewModel> Nodes
		{
			get { return _nodes; }
			set
			{
				_nodes = value;
				RaisePropertyChanged("Nodes");
			}
		}

		private ObservableCollection<NodeViewModel> _edges = new ObservableCollection<NodeViewModel>();
		public ObservableCollection<NodeViewModel> Edges
		{
			get { return _edges; }
			set
			{
				_edges = value;
				RaisePropertyChanged("Edges");
			}
		}

		private ObservableCollection<LogViewModel> _logs = new ObservableCollection<LogViewModel>();
		public ObservableCollection<LogViewModel> Logs
		{
			get { return _logs; }
			set
			{
				_logs = value;
				RaisePropertyChanged("Logs");
			}
		}

		public ICommand GraphBackGroundClick { get; private set; }

		void _graphBackGroundClick(Object parameter)
		{
			var canvas = (Canvas)parameter;
			var ptr = Mouse.GetPosition(canvas);
			Logs.Add(new LogViewModel("GraphCanvasClicked:(" + ptr.ToString() + ")"));

			var newNode = new NodeViewModel();
			newNode.width = 50;
			newNode.height = 50;
			newNode.xPos = ptr.X - 25;
			newNode.yPos = ptr.Y - 25;
			Nodes.Add(newNode);

			if (Nodes.Count >= 3)
				Nodes[0].xPos += 100;
		}

		public MainViewModel()
		{
			GraphBackGroundClick = new RelayCommand( _graphBackGroundClick );
		}
	}
}
