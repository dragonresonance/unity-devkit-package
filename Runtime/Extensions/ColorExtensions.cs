using UnityEngine;


namespace DragonResonance.Extensions
{
	public static class ColorExtensions
	{
		public static Color RandomizeR(this Color color)
		{
			color.r = Random.Range(0f, 1f);
			return color;
		}

		public static Color RandomizeG(this Color color)
		{
			color.g = Random.Range(0f, 1f);
			return color;
		}

		public static Color RandomizeB(this Color color)
		{
			color.b = Random.Range(0f, 1f);
			return color;
		}

		public static Color RandomizeA(this Color color)
		{
			color.a = Random.Range(0f, 1f);
			return color;
		}


		public static Color WithAlpha(this Color color, float alpha)
		{
			color.a = alpha;
			return color;
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