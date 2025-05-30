using UnityEngine;


namespace DragonResonance.Extensions
{
	public static class Vector2Extensions
	{
		#region Publics - Operations

			public static float Lerp(this Vector2 vector, float t)
			{
				return Mathf.Lerp(vector.x, vector.y, t);
			}

			public static float InverseLerp(this Vector2 vector, float value)
			{
				return Mathf.InverseLerp(vector.x, vector.y, value);
			}

		#endregion


		#region Publics - Search

			public static float Random(this Vector2 vector)
			{
				return UnityEngine.Random.Range(vector.x, vector.y);
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