using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Graph.Containers;

namespace Graph.Models
{
	public class Path : IEquatable<Path>
	{
		public SwapablePair<int> Target { get; set; }
		public int Weight { get; set; }

		public Path( int node1, int node2 )
		{
			Target = new SwapablePair<int>(node1, node2);
			Weight = 0;
		}

		public Path(int node1, int node2, int weight)
		{
			Target = new SwapablePair<int>(node1, node2);
			Weight = weight;
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
				return false;

			Path p = obj as Path;
			if ((System.Object)p == null)
				return false;

			return this.Equals(p);
		}

		public override int GetHashCode()
		{
			return Target.GetHashCode() ^ Weight.GetHashCode();
		}

		public bool Equals(Path obj)
		{
			return Target == obj.Target;
		}
	}
}
