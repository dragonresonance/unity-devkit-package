using Random = System.Random;
using System.Collections.Generic;




namespace PossumScream.Extensions
{
	public static class ListExtensions
	{
		public static void Swap<T>(this IList<T> list, int indexA, int indexB) {
			(list[indexA], list[indexB]) = (list[indexB], list[indexA]);
		}


		public static void Shuffle<T>(this List<T> list)
		{
			Random random = new Random();


			for (int index = 0; index < list.Count; index++) {
				list.Swap(index, random.Next(index, list.Count));
			}
		}
	}
}




/*                                                                                            */
/*            ____                                 _____                                      */
/*           / __ \____  ____________  ______ ___ / ___/_____________  ____ _____ ___         */
/*          / /_/ / __ \/ ___/ ___/ / / / __ `__ \\__ \/ ___/ ___/ _ \/ __ `/ __ `__ \        */
/*         / ____/ /_/ (__  |__  ) /_/ / / / / / /__/ / /__/ /  /  __/ /_/ / / / / / /        */
/*        /_/    \____/____/____/\__,_/_/ /_/ /_/____/\___/_/   \___/\__,_/_/ /_/ /_/         */
/*                                                                                            */
/*        Licensed under the Apache License, Version 2.0. See LICENSE.md for more info        */
/*        David Tabernero M. @ PossumScream                      Copyright © 2021-2023        */
/*        https://gitlab.com/possumscream                          All rights reserved        */
/*                                                                                            */
/*                                                                                            */