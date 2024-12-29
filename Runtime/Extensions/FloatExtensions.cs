using UnityEngine;




namespace PossumScream.Extensions
{
	public static class FloatExtensions
	{
		#region Publics - Verification


			public static bool IsPositive(this float testValue)
			{
				return (testValue > 0f);
			}

			public static bool IsPositiveOrZero(this float testValue)
			{
				return (testValue >= 0f);
			}

			public static bool IsNegative(this float testValue)
			{
				return (testValue < 0f);
			}

			public static bool IsNegativeOrZero(this float testValue)
			{
				return (testValue <= 0f);
			}


			public static bool IsBetween(this float testValue, int minInclusive, int maxExclusive)
			{
				return ((testValue >= minInclusive) && (testValue < maxExclusive));
			}

			public static bool IsBetweenInclusive(this float testValue, int minInclusive, int maxInclusive)
			{
				return ((testValue >= minInclusive) && (testValue <= maxInclusive));
			}

			public static bool IsBetweenExclusive(this float testValue, int minExclusive, int maxExclusive)
			{
				return ((testValue > minExclusive) && (testValue < maxExclusive));
			}


		#endregion




		#region Publics - Operations


			public static float Complementary(this float value)
			{
				return (1f - value);
			}


			public static float SumToAbsolute(this float currentValue, float addend)
			{
				return (Mathf.Sign(currentValue) * (Mathf.Abs(currentValue) + addend));
			}

			public static float SubtractToAbsolute(this float currentValue, float substrahend)
			{
				return (Mathf.Sign(currentValue) * (Mathf.Abs(currentValue) - substrahend));
			}

			public static float MultiplyToAbsolute(this float currentValue, float factor)
			{
				return (Mathf.Sign(currentValue) * (Mathf.Abs(currentValue) * factor));
			}

			public static float DivideToAbsolute(this float currentValue, float divisor)
			{
				return (Mathf.Sign(currentValue) * (Mathf.Abs(currentValue) / divisor));
			}


			public static float ClampAbsolute(this float currentValue, float maxAbsolute)
			{
				return (Mathf.Sign(currentValue) * UpperClamp(Mathf.Abs(currentValue), maxAbsolute));
			}

			public static float UpperClamp(this float currentValue, float maxValue)
			{
				return ((currentValue > maxValue) ? maxValue : currentValue);
			}

			public static float LowerClamp(this float currentValue, float minValue)
			{
				return ((currentValue < minValue) ? minValue : currentValue);
			}


			public static float AddToAverage(this float currentAverage, float newValue, ref int currentSamples, int maxSamples)
			{
				float totalValue = currentAverage * currentSamples;

				if (currentSamples >= maxSamples) {
					currentSamples--;
					totalValue -= currentAverage;
				}

				totalValue += newValue;
				currentSamples++;

				if (currentSamples > maxSamples) {
					currentSamples--;
					totalValue -= currentAverage;
				}

				return (totalValue / currentSamples);
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