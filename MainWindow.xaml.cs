using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Windows.Controls.Primitives;

using Graph.ViewModels;

namespace Graph
{
	/// <summary>
	/// MainWindow.xaml の相互作用ロジック
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			var main = new MainViewModel();
			this.DataContext = main;
		}

		private bool _mouseDown = false;
		private int _lastCtrlClicked = -1;
		private Point _last;

		private async void Node_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			await ((MainViewModel)DataContext).exactStop();
			int nowClicked = -1;
			var grid = sender as Grid;
			if (grid == null) return;
			grid.CaptureMouse();

			if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl))
			{
				// Ctrl is pressed
				var node = grid.DataContext as NodeViewModel;
				if (node == null) return;
				nowClicked = node.Key;
			}

			if (nowClicked != -1 && _lastCtrlClicked != -1 && nowClicked != _lastCtrlClicked)
			{
				// Connect
				var main = DataContext as MainViewModel;
				if (main == null) return;
				main.Connect(_lastCtrlClicked, nowClicked);
				_lastCtrlClicked = -1;
			}
			else
				_lastCtrlClicked = nowClicked;

			_last = e.GetPosition(grid);
			_mouseDown = true;

			e.Handled = true;
		}

		private void Node_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
			if (_mouseDown)
			{
				_mouseDown = false;
				var grid = sender as Grid;
				if (grid == null) return;
				grid.ReleaseMouseCapture();
			}

			e.Handled = true;
		}

		private void Node_MouseMove(object sender, MouseEventArgs e)
		{
			if (_mouseDown)
			{
				Point pt = Mouse.GetPosition(GraphCanvas);

				var grid = sender as Grid;
				if (grid == null)
					return;

				Canvas.SetLeft(grid, pt.X - _last.X);
				Canvas.SetTop(grid, pt.Y - _last.Y);
			}

			e.Handled = true;
		}
	}
}
