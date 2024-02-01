namespace PossumScream.Extensions
{
	public static class IntExtensions
	{
		#region Controls: Casting


			public static bool AsBool(this int numericValue)
			{
				return (numericValue != 0);
			}


		#endregion




		#region Controls: Verification


			public static bool IsEven(this int testValue)
			{
				return ((testValue & 1) == 0);
			}


			public static bool IsOdd(this int testValue)
			{
				return !IsEven(testValue);
			}




			public static bool IsBetween(this int testValue, int minInclusive, int maxExclusive)
			{
				return ((testValue >= minInclusive) && (testValue < maxExclusive));
			}


			public static bool IsBetweenInclusive(this int testValue, int minInclusive, int maxInclusive)
			{
				return ((testValue >= minInclusive) && (testValue <= maxInclusive));
			}


			public static bool IsBetweenExclusive(this int testValue, int minExclusive, int maxExclusive)
			{
				return ((testValue > minExclusive) && (testValue < maxExclusive));
			}


		#endregion




		#region Controls: Cyclical Operations


			public static int NextCyclic(this int currentValue, int upperLimit, int absoluteIncreaseStep = 1)
			{
				return (currentValue = ((currentValue + absoluteIncreaseStep) % upperLimit));
			}


			public static int PreviousCyclic(this int currentValue, int upperLimit, int absoluteDecreaseStep = 1)
			{
				return (currentValue = (((currentValue - absoluteDecreaseStep) + upperLimit) % upperLimit));
			}


		#endregion
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
/*        David Tabernero M. @ PossumScream                      Copyright © 2021-2023        */
/*        GitLab - GitHub: possumscream                            All rights reserved        */
/*        -------------------------                                  -----------------        */
/*                                                                                            */