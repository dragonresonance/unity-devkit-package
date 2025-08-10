using UnityEngine;


namespace DragonResonance.Extensions
{
	public static class Vector2IntExtensions
	{
		public static int Random(this Vector2Int vector)
		{
			return UnityEngine.Random.Range(vector.x, vector.y);
		}

		public static int RandomInclusive(this Vector2Int vector)
		{
			return UnityEngine.Random.Range(vector.x, (vector.y + 1));
		}

		public static int RandomExclusive(this Vector2Int vector)
		{
			return UnityEngine.Random.Range((vector.x + 1), vector.y);
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