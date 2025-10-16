using UnityEngine;


namespace DragonResonance.Extensions
{
	public static class ColorExtensions
	{
		#region Publics - Value Operations


			public static Color Mask(this Color color, Color mask)
			{
				return new Color(
					color.r * mask.r,
					color.g * mask.g,
					color.b * mask.b,
					color.a * mask.a
				);
			}


			public static Color AddHSVBrightness(this Color color, float amount)
			{
				Color.RGBToHSV(color, out float h, out float s, out float v);
				v = Mathf.Clamp01(v + amount);
				return Color.HSVToRGB(h, s, v);
			}

			public static Color AddLinearBrightness(this Color color, float amount)
			{
				return new Color(
					Mathf.Clamp01(color.r + amount),
					Mathf.Clamp01(color.g + amount),
					Mathf.Clamp01(color.b + amount),
					color.a
				);
			}


			public static Color ToGreyscale(this Color color)
			{
				float luminance = (color.r * 0.2126f) + (color.g * 0.7152f) + (color.b * 0.0722f);
				return new Color(luminance, luminance, luminance, color.a);
			}


			public static Color WithAlpha(this Color color, float alpha)
			{
				color.a = alpha;
				return color;
			}


		#endregion




		#region Publics - Randomizations


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