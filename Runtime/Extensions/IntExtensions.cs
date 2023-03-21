using UnityEngine;




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


			public static int IncreaseCyclically(this ref int currentValue, int upperLimit, int absoluteIncreaseStep = 1)
			{
				return (currentValue = ((currentValue + absoluteIncreaseStep) % upperLimit));
			}


			public static int DecreaseCyclically(this ref int currentValue, int upperLimit, int absoluteDecreaseStep = 1)
			{
				return (currentValue = (((currentValue - absoluteDecreaseStep) + upperLimit) % upperLimit));
			}


		#endregion
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