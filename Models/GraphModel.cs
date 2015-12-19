using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Graph.Models
{
	class GraphModel
	{
		public List<int> V { get; set; }
		public List<Path> E { get; set; }

		public void Connect( int node1, int node2 )
		{
			if (!isExists(node1) || !isExists(node2))
				throw new ArgumentException();

			if (!isExists(new Path(node1, node2)))
			{
				E.Add(new Path(node1, node2));
			}
		}

		public void Disconnect( int node1, int node2 )
		{
			if (!isExists(node1) || !isExists(node2))
				throw new ArgumentException();

			if (isExists(new Path(node1, node2)))
				E.Remove(new Path(node1, node2));
			else
				throw new ArgumentException();
		}

		public void SetWeight( int node1, int node2, int weight )
		{
			E[E.IndexOf(new Path(node1, node2))].Weight = weight;
		}

		private bool isExists( int node )
		{
			return V.Contains(node);
		}

		private bool isExists( Path path )
		{
			return E.Contains(path);
		}
	}
}
