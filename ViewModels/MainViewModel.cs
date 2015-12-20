using System;
using System.ComponentModel;
using System.Windows.Input;
using Microsoft.TeamFoundation.MVVM;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Collections.ObjectModel;
using System.Windows.Controls.Primitives;

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
		private int _nodesCount = 0;
		private int NodesCount
		{
			get
			{
				_nodesCount++;
				return _nodesCount;
			}
		}

		private ObservableCollection<EdgeViewModel> _edges = new ObservableCollection<EdgeViewModel>();
		public ObservableCollection<EdgeViewModel> Edges
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
			newNode.Size = 50;
			newNode.xPos = ptr.X - 25;
			newNode.yPos = ptr.Y - 25;
			newNode.Name = NodesCount.ToString();
			Nodes.Add(newNode);
		}

		public ICommand NodeClick { get; private set; }

		void _nodeClick(Object parameter)
		{
			Console.WriteLine("hoge");
			return;
		}

		public MainViewModel()
		{
			GraphBackGroundClick = new RelayCommand(_graphBackGroundClick);
		}
	}
}
