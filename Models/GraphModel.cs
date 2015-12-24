using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Graph.Models
{
	public class GraphModel
	{
		public List<int> V { get; private set; }
		public List<Path> E { get; private set; }

		public GraphModel()
		{
			V = new List<int>();
			E = new List<Path>();
		}

		public void AddNode(int node)
		{
			if (isExists(node))
			{
				throw new ArgumentException();
			}

			V.Add(node);
		}

		public void RemoveNode(int node)
		{
			if (!isExists(node))
			{
				throw new ArgumentException();
			}

			V.Remove(node);

			foreach (var edge in E)
			{
				if (edge.Target.First == node || edge.Target.Second == node)
				{
					E.Remove(edge);
				}
			}
		}

		public void Connect(int node1, int node2)
		{
			if (!isExists(node1) || !isExists(node2))
				throw new ArgumentException();

			if (!isExists(new Path(node1, node2)))
			{
				E.Add(new Path(node1, node2));
			}
		}

		public void Disconnect(int node1, int node2)
		{
			if (!isExists(node1) || !isExists(node2))
				throw new ArgumentException();

			if (isExists(new Path(node1, node2)))
				E.Remove(new Path(node1, node2));
			else
				throw new ArgumentException();
		}

		public void SetWeight(int node1, int node2, int weight)
		{
			E[E.IndexOf(new Path(node1, node2))].Weight = weight;
		}

		private bool isExists(int node)
		{
			return V.Contains(node);
		}

		private bool isExists(Path path)
		{
			return E.Contains(path);
		}

		public IEnumerable<int> ConnectedNodes( int key )
		{
			return
				from node in E
				where node.Target.First == key || node.Target.Second == key
				select node.Target.First != key ? node.Target.First : node.Target.Second;
		}
	}
}
