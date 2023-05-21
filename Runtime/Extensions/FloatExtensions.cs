using UnityEngine;




namespace PossumScream.Extensions
{
	public static class FloatExtensions
	{
		#region Controls: Verification


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




		#region Controls: Operation


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




			public static float AddToAverage(this ref float currentAverage, float newValue, ref int currentSamples, int maxSamples)
			{
				float totalValue = currentAverage * currentSamples;


				{
					if (currentSamples >= maxSamples) {
						currentSamples--;
						totalValue -= currentAverage;
					}

					{
						totalValue += newValue;
						currentSamples++;
					}

					if (currentSamples > maxSamples) {
						currentSamples--;
						totalValue -= currentAverage;
					}
				}

				return (currentAverage = (totalValue / currentSamples));
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