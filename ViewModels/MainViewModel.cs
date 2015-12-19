using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Shapes;
using System.Windows.Input;

using Microsoft.TeamFoundation.MVVM;


namespace Graph.ViewModels
{
	public class MainViewModel : INotifyPropertyChanged
	{
		private ObservableCollection<Ellipse> _nodes;
		public ObservableCollection<Ellipse> Nodes
		{
			get { return _nodes; }
			set
			{
				_nodes = value;
				NotifyPropertyChanged("Nodes");
			}
		}

		private ObservableCollection<Line> _edges;
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

		public MainViewModel()
		{
			GraphBackGroundClick = new RelayCommand(
				(parameter) =>
				{
					Logs.Add("GraphCanvasClicked");
				}
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
