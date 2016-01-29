using System;
using System.ComponentModel;
using System.Windows.Input;
using Microsoft.TeamFoundation.MVVM;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Collections.ObjectModel;
using System.Windows.Controls.Primitives;

using Graph.Containers;
using Graph.Models;

namespace Graph.ViewModels
{
	public class MainViewModel : ViewModelBase
	{
		private GraphModel _graph;

		private NodesViewModel _nodes;
		public NodesViewModel Nodes
		{
			get { return _nodes; }
			set
			{
				_nodes = value;
				RaisePropertyChanged("Nodes");
			}
		}
		private int _nodesCount = 0;
		private int NodesCount
		{
			get
			{
				_nodesCount++;
				return _nodesCount;
			}
		}

		private EdgesViewModel _edges;
		public EdgesViewModel Edges
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
			Keyboard.ClearFocus();

			var canvas = (Canvas)parameter;
			var ptr = Mouse.GetPosition(canvas);
			Logs.Add(new LogViewModel("GraphCanvasClicked:(" + ptr.ToString() + ")"));

			var newNode = new NodeViewModel();
			newNode.Size = 50;
			newNode.xPos = ptr.X - 25;
			newNode.yPos = ptr.Y - 25;
			newNode.Key = NodesCount;
//			if (newNode.Key == 3)
//				newNode.Color = new SolidColorBrush(Colors.Red);
			Nodes.Add(newNode);
		}

		public ICommand DFSClick { get; private set; }
		void _DFS(Object parameter)
		{
			var results = DFS.Run(_graph, 1);
//			var results = Dijkstra.Run(_graph, 1, 10);
			foreach (var result in results)
				Logs.Add(new LogViewModel("(" + result.First.ToString() + "," + result.Second.ToString() + ")"));
		}

		public ICommand BFSClick { get; private set; }
		void _BFS(Object parameter)
		{
			var results = BFS.Run(_graph, 1);
			foreach (var result in results)
				Logs.Add(new LogViewModel("(" + result.First.ToString() + "," + result.Second.ToString() + ")"));
		}

		public ICommand DijkstraClick { get; private set; }
		void _Dijkstra(Object parameter)
		{
			var results = Dijkstra.Run(_graph, 1, 10);
			foreach (var result in results)
				Logs.Add(new LogViewModel("(" + result.First.ToString() + "," + result.Second.ToString() + ")"));
		}

		public ICommand KruskalClick { get; private set; }
		void _Kruskal(Object parameter)
		{
			var results = Kruskal.Run(_graph);
			foreach (var result in results)
				Logs.Add(new LogViewModel("(" + result.First.ToString() + "," + result.Second.ToString() + ")"));
		}

		public void Connect( int from, int to )
		{
			NodeViewModel fromNode = null, toNode = null;

			foreach (var node in Nodes)
			{
				if (node.Key == from)
					fromNode = node;
				if (node.Key == to)
					toNode = node;
			}

			if (fromNode == null || toNode == null) return;

			var edge = new EdgeViewModel(new SwapablePair<NodeViewModel>(fromNode, toNode));

			if( !Edges.Contains(edge) )
				Edges.Add(edge);
			else
				Edges.Remove(edge);
		}

		public MainViewModel()
		{
			_graph = new GraphModel();
			_nodes = new NodesViewModel(_graph);
			_edges = new EdgesViewModel(_graph);

			GraphBackGroundClick = new RelayCommand(_graphBackGroundClick);
			DFSClick = new RelayCommand(_DFS);
			BFSClick = new RelayCommand(_BFS);
			DijkstraClick = new RelayCommand(_Dijkstra);
			KruskalClick = new RelayCommand(_Kruskal);
		}
	}
}
