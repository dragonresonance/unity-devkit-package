using Random = System.Random;
using System.Collections.Generic;


namespace DragonResonance.Extensions
{
	public static class ListExtensions
	{
		public static void Swap<T>(this IList<T> list, int indexA, int indexB)
		{
			(list[indexA], list[indexB]) = (list[indexB], list[indexA]);
		}

		public static void Shuffle<T>(this List<T> list)
		{
			Random random = new();
			for (int index = 0; index < list.Count; index++) {
				list.Swap(index, random.Next(index, list.Count));
			}
		}
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
/*                  Copyright © 2021-2025. All rights reserved.                 */
/*                Licensed under the Apache License, Version 2.0.               */
/*                         See LICENSE.md for more info.                        */
/*       ________________________________________________________________       */
/*                                                                              */