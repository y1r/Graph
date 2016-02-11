using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Collections.ObjectModel;

using Graph.Containers;
using Graph.Models;

namespace Graph.ViewModels
{
	public class MainViewModel : BindableBase
	{
		private GraphModel _graph;

		private CancellationTokenSource _cts;

		private NodesViewModel _nodes;
		public NodesViewModel Nodes
		{
			get { return _nodes; }
			set
			{
				SetProperty(ref _nodes, value);
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
				SetProperty(ref _edges, value);
			}
		}

		private ObservableCollection<LogViewModel> _logs = new ObservableCollection<LogViewModel>();
		public ObservableCollection<LogViewModel> Logs
		{
			get { return _logs; }
			set
			{
				SetProperty(ref _logs, value);
			}
		}

		private NodeViewModel _from;
		public NodeViewModel From
		{
			get { return _from; }
			set
			{
				SetProperty(ref _from, value);
			}
		}

		private NodeViewModel _to;
		public NodeViewModel To
		{
			get { return _to; }
			set
			{
				SetProperty(ref _to, value);
			}
		}

		public ICommand GraphBackGroundClick { get; private set; }

		async void _graphBackGroundClick(Object parameter)
		{
			await exactStop();
			Keyboard.ClearFocus();

			var canvas = (Canvas)parameter;
			var ptr = Mouse.GetPosition(canvas);
			Logs.Add(new LogViewModel("GraphCanvasClicked:(" + ptr.ToString() + ")"));

			var newNode = new NodeViewModel();
			newNode.Size = 50;
			newNode.xPos = ptr.X - 25;
			newNode.yPos = ptr.Y - 25;
			newNode.Key = NodesCount;
			Nodes.Add(newNode);
		}

		public ICommand DFSClick { get; private set; }
		async void _DFS()
		{
			Logs.Add(new LogViewModel("DFSClicked"));

			if (_from == null)
			{
				MessageBox.Show("始点が設定されていません");
				return;
			}

			var results = DFS.Run(_graph, _from.Key);

			await show(results, Colors.Red);
		}

		public ICommand BFSClick { get; private set; }

		async void _BFS()
		{
			Logs.Add(new LogViewModel("BFSClicked"));

			if (_from == null)
			{
				MessageBox.Show("始点が設定されていません");
				return;
			}

			var results = BFS.Run(_graph, _from.Key);

			await show(results, Colors.Red);
		}

		public ICommand DijkstraClick { get; private set; }
		async void _Dijkstra()
		{
			Logs.Add(new LogViewModel("DijkstraClicked"));

			if (_from == null)
			{
				MessageBox.Show("始点が設定されていません");
				return;
			}

			if (_to == null)
			{
				MessageBox.Show("終点が設定されていません");
				return;
			}

			var results = Dijkstra.Run(_graph, _from.Key, _to.Key);

			if (results == null)
			{
				MessageBox.Show("始点と終点が接続されていません");
				return;
			}

			await show(results, Colors.Red);
		}

		public ICommand KruskalClick { get; private set; }
		async void _Kruskal()
		{
			Logs.Add(new LogViewModel("KruskalClicked"));
			await exactStop();

			var results = Kruskal.Run(_graph);
			changeColor(results, Colors.Red);
		}

		public ICommand EraseClick { get; private set; }
		async void _Erase()
		{
			Logs.Add(new LogViewModel("EraseClicked"));

			await exactStop();
			_nodesCount = 0;
			_from = null;
			_to = null;
			_graph.E.Clear();
			_graph.V.Clear();
			_nodes.Clear();
			_edges.Clear();
		}

		public ICommand StopClick { get; private set; }
		async private void _Stop()
		{
			Logs.Add(new LogViewModel("StopClicked"));
			await exactStop();
			changeAllColor(Colors.Black);
		}

		private async Task exactStop()
		{
			while (_cts != null)
			{
				_cts.Cancel();
				await Task.Run(() => System.Threading.Thread.Sleep(100));
			}
		}

		public void Connect(int from, int to)
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

			if (!Edges.Contains(edge))
				Edges.Add(edge);
			else
				Edges.Remove(edge);
		}

		private async Task show(List<Pair<int, int>> target, Color color)
		{
			await exactStop();

			Logs.Add(new LogViewModel("start shower"));

			_cts = new CancellationTokenSource();

			try
			{
				changeAllColor(Colors.Black);

				await Task.Delay(500, _cts.Token);

				while (true)
				{
					foreach (var result in target)
					{
						var edge = Edges.First(i =>
							(i.Pos.First.Key == result.First && i.Pos.Second.Key == result.Second) ||
							(i.Pos.Second.Key == result.First && i.Pos.First.Key == result.Second));

						edge.Color = new SolidColorBrush(color);

						await Task.Delay(1000, _cts.Token);
					}

					changeAllColor(Colors.Black);

					await Task.Delay(1000, _cts.Token);
				}
			}
			catch (OperationCanceledException)
			{
				changeAllColor(Colors.Black);
				_cts = null;
				Logs.Add(new LogViewModel("stop shower"));
			}
		}

		private void changeColor(List<Pair<int, int>> target, Color color)
		{
			changeAllColor(Colors.Black);

			foreach (var result in target)
			{
				var edge = Edges.First(i =>
					(i.Pos.First.Key == result.First && i.Pos.Second.Key == result.Second) ||
					(i.Pos.Second.Key == result.First && i.Pos.First.Key == result.Second));

				edge.Color = new SolidColorBrush(color);
			}
		}

		private void changeAllColor(Color color)
		{
			foreach (var edge in Edges)
			{
				edge.Color = new SolidColorBrush(color);
			}
		}

		public MainViewModel()
		{
			_graph = new GraphModel();
			_nodes = new NodesViewModel(_graph);
			_edges = new EdgesViewModel(_graph);

			GraphBackGroundClick = new DelegateCommand<object>(_graphBackGroundClick);
			DFSClick = new DelegateCommand(_DFS);
			BFSClick = new DelegateCommand(_BFS);
			DijkstraClick = new DelegateCommand(_Dijkstra);
			KruskalClick = new DelegateCommand(_Kruskal);
			StopClick = new DelegateCommand(_Stop);
			EraseClick = new DelegateCommand(_Erase);
		}
	}
}
