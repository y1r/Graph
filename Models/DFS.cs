using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Graph.Containers;

namespace Graph.Models
{
	public static class DFS
	{
		public static List<Pair<int, int>> Run( GraphModel graph, int startNode )
		{
			var result = new List<Pair<int, int>>();
			var visited = new List<Pair<int, bool>>();

			foreach (var node in graph.V)
				visited.Add(new Pair<int, bool>(node, false));

			visit(graph, startNode, visited, result);

			return result;
		}

		static void visit( GraphModel graph, int startNode, List<Pair<int, bool>> visited, List<Pair<int, int>> result )
		{
			foreach (var node in visited.Where(i => i.First == startNode))
				node.Second = true;

			var connectedNodes = graph.ConnectedNodes(startNode);

			var movableNodes =
				from node in visited
				where node.Second == false
				select node.First;

			foreach (var node in connectedNodes)
			{
				if (movableNodes.Contains(node))
				{
					result.Add(new Pair<int, int>(startNode, node));
					visit(graph, node, visited, result);
				}
			}
		}
	}
}
