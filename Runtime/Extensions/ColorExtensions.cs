using UnityEngine;




namespace PossumScream.Extensions
{
	public static class ColorExtensions
	{
		#region Controls


			public static void RandomizeR(this ref Color currentValue)
			{
				currentValue.r = generateRandom01();
			}


			public static void RandomizeG(this ref Color currentValue)
			{
				currentValue.g = generateRandom01();
			}


			public static void RandomizeB(this ref Color currentValue)
			{
				currentValue.b = generateRandom01();
			}


			public static void RandomizeA(this ref Color currentValue)
			{
				currentValue.a = generateRandom01();
			}




			public static void RandomizeRGB(this ref Color currentValue)
			{
				currentValue.RandomizeR();
				currentValue.RandomizeG();
				currentValue.RandomizeB();
			}


			public static void RandomizeRGBA(this ref Color currentValue)
			{
				currentValue.RandomizeRGB();
				currentValue.RandomizeA();
			}


		#endregion




		#region Actions


			private static float generateRandom01()
			{
				return Random.Range(0f, 1f);
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