using System;

namespace Graph.Containers
{
	public class Pair<T1, T2> : IEquatable<Pair<T1, T2>>
	{
		protected T1 _first;
		protected T2 _second;

		public T1 First
		{
			get
			{
				return _first;
			}
			set
			{
				_first = value;
			}
		}

		public T2 Second
		{
			get
			{
				return _second;
			}
			set
			{
				_second = value;
			}
		}

		public Pair(T1 first, T2 second)
		{
			_first = first;
			_second = second;
		}

		public override bool Equals(Object obj)
		{
			if (obj == null)
				return false;

			Pair<T1, T2> p = obj as Pair<T1, T2>;
			if ((System.Object)p == null)
				return false;

			return _first.Equals(p);
		}

		public bool Equals(Pair<T1, T2> obj)
		{
			return
				_first.Equals(obj.First) && _second.Equals(obj.Second);
		}

		public override int GetHashCode()
		{
			return _first.GetHashCode() ^ _second.GetHashCode();
		}

		public static bool operator ==(Pair<T1, T2> obj1, Pair<T1, T2> obj2)
		{
			if (ReferenceEquals(obj1, obj2))
				return true;

			return obj1.Equals(obj2);
		}

		public static bool operator !=(Pair<T1, T2> obj1, Pair<T1, T2> obj2)
		{
			return !(obj1 == obj2);
		}
	}

	public class SwapablePair<T> : Pair<T, T>
	{
		public SwapablePair(T first, T second) : base(first, second) { }
		public bool Equals(SwapablePair<T> obj)
		{
			return
				(_first.Equals(obj.First) && _second.Equals(obj.Second)) ||
				(_second.Equals(obj.First) && _first.Equals(obj.Second));
		}
	}
}
