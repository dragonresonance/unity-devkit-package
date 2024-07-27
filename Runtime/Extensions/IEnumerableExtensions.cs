using System.Collections.Generic;
using System.Linq;




namespace DragonResonance.Extensions
{
	public static class IEnumerableExtensions
	{
		#region Publics - Verification


			public static bool IsEmpty<T>(this IEnumerable<T> enumerable)
			{
				return !enumerable.Any();
			}

			public static int LastIndex<T>(this IEnumerable<T> enumerable)
			{
				return (enumerable.Count() - 1);
			}




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
				return arrayB.Count(bValue => arrayA.Contains(bValue));
			}


		#endregion




		#region Publics - Search


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


			public static int IndexOf<T>(this IEnumerable<T> source, IEnumerable<T> match)
			{
				T[] sourceArray = source.ToArray();
				T[] matchArray = match.ToArray();

				foreach (T matchItem in matchArray) {
					int index = sourceArray.IndexOf(matchItem);
					if (index != -1) return index;
				}

				return -1;
			}




			public static T Random<T>(this IEnumerable<T> enumerable)
			{
				IEnumerable<T> array = enumerable as T[] ?? enumerable.ToArray();
				return array.ElementAt(UnityEngine.Random.Range(0, array.Count()));
			}


			public static int RandomIndex<T>(this IEnumerable<T> enumerable)
			{
				return UnityEngine.Random.Range(0, enumerable.Count());
			}


		#endregion
	}
}




/*       ________________________________________________________________       */
/*           _________   _______ ________  _______  _______  ___    _           */
/*           |        \ |______/ |______| |  _____ |       | |  \   |           */
/*           |________/ |     \_ |      | |______| |_______| |   \__|           */
/*           ______ _____ _____ _____ __   _ _____ __   _ _____ _____           */
/*           |____/ |____ [___  |   | | \  | |___| | \  | |     |____           */
/*           |    \ |____ ____] |___| |  \_| |   | |  \_| |____ |____           */
/*       ________________________________________________________________       */
/*                                                                              */
/*           David Tabernero M.  <https://github.com/davidtabernerom>           */
/*           Dragon Resonance    <https://github.com/dragonresonance>           */
/*                  Copyright © 2021-2024. All rights reserved.                 */
/*                Licensed under the Apache License, Version 2.0.               */
/*                         See LICENSE.md for more info.                        */
/*       ________________________________________________________________       */
/*                                                                              */