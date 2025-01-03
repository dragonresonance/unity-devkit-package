using System;


namespace DragonResonance.Extensions
{
	public static class StringExtensions
	{
		public static int IndexOfOccurrence(this string input, string value, int startIndex, int occurrence)
		{
			int currentIndex = input.IndexOf(value, startIndex, StringComparison.Ordinal);
			if ((occurrence == 1) || (currentIndex == -1)) return currentIndex;
			return input.IndexOfOccurrence(value, (currentIndex + 1), (occurrence - 1));
		}

		public static string Reverse(this string input)
		{
			return string.Create(input.Length, input, (chars, state) =>
			{
				state.AsSpan().CopyTo(chars);
				chars.Reverse();
			});
		}

		public static string ToUpperFirstLetter(this string source)
		{
			if (string.IsNullOrEmpty(source)) return string.Empty;
			char[] letters = source.ToCharArray();
			letters[0] = char.ToUpper(letters[0]);
			return new string(letters);
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