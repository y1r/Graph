using System.Collections.Generic;
using System.Linq;

using Graph.Containers;

namespace Graph.Models
{
	public static class Kruskal
	{
		public static List<Pair<int, int>> Run(GraphModel graph)
		{
			var F = new List<Pair<List<int>, List<Path>>>();

			foreach (var vertice in graph.V)
			{
				var tmpE = new List<int>();
				tmpE.Add(vertice);

				F.Add(new Pair<List<int>, List<Path>>(tmpE, new List<Path>()));
			}

			var E = new List<Path>(graph.E);

			while (E.Count != 0)
			{
				var min = Utils.Min(E, (val) => val.Weight);
				E.Remove(min);
				var u = F.First((val) => val.First.Contains(min.Target.First));
				var v = F.First((val) => val.First.Contains(min.Target.Second));
				if (u != v)
				{
					u.First.AddRange(v.First);
					u.Second.AddRange(v.Second);
					u.Second.Add(min);
					F.Remove(v);
				}
			}

			var result = new List<Pair<int, int>>();

			foreach (var tree in F)
				result.AddRange(tree.Second.Select(val => val.Target));

			return result;
		}
	}
}
