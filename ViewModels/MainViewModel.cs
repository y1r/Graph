using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Shapes;
using System.Windows.Input;

using Microsoft.TeamFoundation.MVVM;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Graph.ViewModels
{
	public class MainViewModel : INotifyPropertyChanged
	{
		private ObservableCollection<NodeViewModel> _nodes = new ObservableCollection<NodeViewModel>();
		public ObservableCollection<NodeViewModel> Nodes
		{
			get { return _nodes; }
			set
			{
				_nodes = value;
				NotifyPropertyChanged("Nodes");
			}
		}

		private ObservableCollection<Line> _edges = new ObservableCollection<Line>();
		public ObservableCollection<Line> Edges
		{
			get { return _edges; }
			set
			{
				_edges = value;
				NotifyPropertyChanged("Edges");
			}
		}

		private ObservableCollection<String> _logs = new ObservableCollection<string>();
		public ObservableCollection<String> Logs
		{
			get { return _logs; }
			set
			{
				_logs = value;
				NotifyPropertyChanged("Logs");
			}
		}

		public ICommand GraphBackGroundClick { get; private set; }

		void _graphBackGroundClick(Object parameter)
		{
			var canvas = (Canvas)parameter;
			var ptr = Mouse.GetPosition(canvas);
			Logs.Add("GraphCanvasClicked:(" + ptr.ToString() + ")");

			/*
			var newNode = new Ellipse();			

			newNode.Width = 10;
			newNode.Height = 10;

			Canvas.SetLeft(newNode, 5 + ptr.X);
			Canvas.SetTop(newNode, 5 + ptr.Y);

			newNode.Fill = Brushes.Black;
			Nodes.Add(newNode);
			 */
			var newNode = new NodeViewModel();
			newNode.width = 50;
			newNode.height = 50;
			newNode.xPos = ptr.X - 25;
			newNode.yPos = ptr.Y - 25;
			Nodes.Add(newNode);
		}

		public MainViewModel()
		{
			GraphBackGroundClick = new RelayCommand(
_graphBackGroundClick
				);
		}

		public event PropertyChangedEventHandler PropertyChanged;
		private void NotifyPropertyChanged(String info)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(info));
			}
		}
	}
}
