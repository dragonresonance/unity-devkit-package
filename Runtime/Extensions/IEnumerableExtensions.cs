using System.Collections.Generic;
using System.Linq;




namespace PossumScream.Extensions
{
	public static class IEnumerableExtensions
	{
		public static bool MatchesAny<T>(this IEnumerable<T> enumerableA, IEnumerable<T> enumerableB)
		{
			T[] arrayA = enumerableA.ToArray();
			T[] arrayB = enumerableB.ToArray();


			return arrayB.Any(bValue => arrayA.Contains(bValue));
		}


		public static int Matches<T>(this IEnumerable<T> enumerableA, IEnumerable<T> enumerableB)
		{
			T[] arrayA = enumerableA.ToArray();
			T[] arrayB = enumerableB.ToArray();
			int matches = 0;


			foreach (T bValue in arrayB) {
				if (arrayA.Contains(bValue)) {
					matches++;
				}
			}


			return matches;
		}




		public static int IndexOf<T>(this IEnumerable<T> enumerable, T value)
		{
			return IndexOf(enumerable, value, EqualityComparer<T>.Default);
		}


		public static int IndexOf<T>(this IEnumerable<T> enumerable, T value, EqualityComparer<T> comparer)
		{
			int index = 0;


			foreach (T item in enumerable) {
				if (comparer.Equals(item, value)) {
					return index;
				}
				index++;
			}


			return -1;
		}




		public static T Random<T>(this IEnumerable<T> enumerable)
		{
			IEnumerable<T> array = enumerable as T[] ?? enumerable.ToArray();
			return array.ElementAt(UnityEngine.Random.Range(0, array.Count() - 1));
		}
	}
}




/*                                                                                            */
/*          ______                               _______                                      */
/*          \  __ \____  ____________  ______ ___\  ___/_____________  ____  ____ ___         */
/*          / /_/ / __ \/ ___/ ___/ / / / __ \__ \\__ \/ ___/ ___/ _ \/ __ \/ __ \__ \        */
/*         / ____/ /_/ /__  /__  / /_/ / / / / / /__/ / /__/ /  / ___/ /_/ / / / / / /        */
/*        /_/    \____/____/____/\____/_/ /_/ /_/____/\___/_/   \___/\__/_/_/ /_/ /__\        */
/*                                                                                            */
/*        Licensed under the Apache License, Version 2.0. See LICENSE.md for more info        */
/*        David Tabernero M. @ PossumScream                      Copyright © 2021-2024        */
/*        GitLab - GitHub: possumscream                            All rights reserved        */
/*        - - - - - - - - - - - - -                                  - - - - - - - - -        */
/*                                                                                            */