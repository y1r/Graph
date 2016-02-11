using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Graph.Containers;

namespace Graph.Models
{
	public static class Dijkstra
	{
		public static List<Pair<int, int>> Run( GraphModel graph, int startPos, int endPos)
		{
			var dist = new List<Pair<int, int>>();
			var prev = new List<Pair<int, int>>();
			var nodes = new List<int>();

			var pair = new Dictionary<int, int>();
			for (int i = 0; i < graph.V.Count; i++)
				pair.Add(graph.V[i], i);

			foreach(var node in graph.V)
			{
				dist.Add(new Pair<int, int>(
					node,
					startPos == node ? 0 : int.MaxValue));
				prev.Add(new Pair<int, int>(node,-1));
				nodes.Add(node);
			}

			while( nodes.Count() != 0 )
			{
				var u = Utils.Min(dist.Where(k => nodes.Contains(k.First)), (val) => val.Second).First;

				nodes.Remove(u);
				foreach (var v in graph.ConnectedNodes(u))
				{
					int d_v = dist[pair[v]].Second;
					int d_u = dist[pair[u]].Second;
					int len = graph.Weight( v, u);
					if( d_v > d_u + len )
					{
						dist[pair[v]].Second = d_u + len;
						prev[pair[v]].Second = u;
					}
				}
			}

			var result = new List<Pair<int, int>>();
			int now = endPos;
			while( now != startPos )
			{
				int next = prev[pair[now]].Second;
				result.Add(new Pair<int, int>(next, now));
				now = next;
				if (now == -1)
					return null;
			}

			result.Reverse();
			return result;
		}
	}
}
