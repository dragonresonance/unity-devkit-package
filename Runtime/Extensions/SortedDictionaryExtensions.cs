using System.Collections.Generic;


namespace DragonResonance.Extensions
{
	public static class SortedDictionaryExtensions
	{
		public static int IndexOf<TKey, TValue>(this SortedDictionary<TKey, TValue> dictionary, TKey key)
		{
			int index = 0;

			foreach (TKey dictionaryKey in dictionary.Keys) {
				if (dictionaryKey.Equals(key))
					return index;
				else
					index++;
			}

			return -1;
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