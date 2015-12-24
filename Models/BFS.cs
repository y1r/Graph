using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Graph.Containers;

namespace Graph.Models
{
	public static class BFS
	{
		public static List<Pair<int, int>> Run(GraphModel graph, int startNode)
		{
			var result = new List<Pair<int, int>>();
			var visited = new List<Pair<int, bool>>();

			foreach (var node in graph.V)
				visited.Add(new Pair<int, bool>(node, false));

			var queue = new Queue<int>();
			queue.Enqueue(startNode);
			
			foreach (var node in visited.Where(i => i.First == startNode))
				node.Second = true;

			var movableNodes =
				from node in visited
				where node.Second == false
				select node.First;

			while( queue.Count() != 0 )
			{
				int now = queue.Dequeue();
				var connectedNodes = graph.ConnectedNodes(now);
				foreach(var node in connectedNodes)
				{
					if( movableNodes.Contains(node))
					{
						result.Add(new Pair<int, int>(now, node));
						foreach (var i in visited.Where(i => i.First == node))
							i.Second = true;
						queue.Enqueue(node);
					}
				}
			}

			return result;
		}
	}
}
