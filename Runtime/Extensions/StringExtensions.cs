using System;




namespace PossumScream.Extensions
{
	public static class StringExtensions
	{
		public static int IndexOfOccurrence(this string input, string value, int startIndex, int occurrence)
		{
			int currentIndex = input.IndexOf(value, startIndex, StringComparison.Ordinal);


			if ((occurrence == 1) || (currentIndex == -1)) return currentIndex;


			return input.IndexOfOccurrence(value, (currentIndex + 1), (occurrence - 1));
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