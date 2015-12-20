using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph.Containers
{
	public class Pair<T> : IEquatable<Pair<T>>
	{
		private T _first;
		private T _second;

		public T First { get; set; }
		public T Second { get; set; }

		public Pair( T first, T second )
		{
			_first = first;
			_second = second;
		}

		public override bool Equals(Object obj)
		{
			if (obj == null)
				return false;

			Pair<T> p = obj as Pair<T>;
			if ((System.Object)p == null)
				return false;

			return _first.Equals(p);
		}

		public bool Equals(Pair<T> obj)
		{
			return
				_first.Equals(obj.First) && _second.Equals(obj.Second) ||
				_first.Equals(obj.Second) && _second.Equals(obj.First);
		}

		public override int GetHashCode()
		{
			return _first.GetHashCode() ^ _second.GetHashCode();
		}

		public static bool operator ==(Pair<T> obj1, Pair<T> obj2)
		{
			if (ReferenceEquals(obj1, obj2))
				return true;

			return obj1.Equals(obj2);
		}

		public static bool operator !=(Pair<T> obj1, Pair<T> obj2)
		{
			return !(obj1 == obj2);
		}
	}
}
