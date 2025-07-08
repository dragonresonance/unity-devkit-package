using UnityEngine;


namespace PossumScream.Extensions
{
	public static class ColorExtensions
	{
		#region Publics

			public static void RandomizeR(this ref Color currentValue) => currentValue.r = generateRandom01();
			public static void RandomizeG(this ref Color currentValue) => currentValue.g = generateRandom01();
			public static void RandomizeB(this ref Color currentValue) => currentValue.b = generateRandom01();
			public static void RandomizeA(this ref Color currentValue) => currentValue.a = generateRandom01();


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

			private static float generateRandom01() => Random.Range(0f, 1f);

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