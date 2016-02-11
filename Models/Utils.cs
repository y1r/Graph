using System;
using System.Collections.Generic;
using System.Linq;

namespace Graph.Models
{
	static class Utils
	{
		public static T Max<T, Value>(IEnumerable<T> collect, Func<T, Value> toValue)
			where Value : IComparable
		{
			return collect.Aggregate(
				(i, j) =>
					toValue(i).CompareTo(toValue(j)) > 0 ? i : j);
		}

		public static T Min<T, Value>(IEnumerable<T> collect, Func<T, Value> toValue)
	where Value : IComparable
		{
			return collect.Aggregate(
				(i, j) =>
					toValue(i).CompareTo(toValue(j)) < 0 ? i : j);
		}
	}
}
