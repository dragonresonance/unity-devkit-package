namespace DragonResonance.Extensions
{
	public static class IntExtensions
	{
		#region Publics - Casting


			public static bool AsBool(this int numericValue)
			{
				return (numericValue != 0);
			}


		#endregion




		#region Publics - Verification


			public static bool IsPositive(this int testValue)
			{
				return (testValue > 0);
			}

			public static bool IsPositiveOrZero(this int testValue)
			{
				return (testValue >= 0);
			}

			public static bool IsNegative(this int testValue)
			{
				return (testValue < 0);
			}

			public static bool IsNegativeOrZero(this int testValue)
			{
				return (testValue <= 0);
			}

			public static bool IsZero(this int testValue)
			{
				return (testValue == 0);
			}


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




		#region Publics - Operations


			public static int UpperClamp(this int currentValue, int maxValue)
			{
				return ((currentValue > maxValue) ? maxValue : currentValue);
			}

			public static int LowerClamp(this int currentValue, int minValue)
			{
				return ((currentValue < minValue) ? minValue : currentValue);
			}

			public static int ClampUpperZero(this int currentValue)
			{
				return currentValue.UpperClamp(0);
			}

			public static int ClampLowerZero(this int currentValue)
			{
				return currentValue.LowerClamp(0);
			}

			public static int ClampUpperOne(this int currentValue)
			{
				return currentValue.UpperClamp(1);
			}

			public static int ClampLowerOne(this int currentValue)
			{
				return currentValue.LowerClamp(1);
			}


		#endregion




		#region Publics - Cyclical Operations


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