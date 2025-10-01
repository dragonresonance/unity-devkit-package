using UnityEngine;


namespace DragonResonance.Extensions
{
	public static class Vector2IntExtensions
	{
		#region Properties - Operations

			public static Vector2Int SortedLow2High(this Vector2Int vector) => ((vector.x > vector.y) ? (new Vector2Int(vector.y, vector.x)) : vector);
			public static Vector2Int SortedHigh2Low(this Vector2Int vector) => (vector.x < vector.y) ? (new Vector2Int(vector.y, vector.x)) : vector;

			public static float Lerp(this Vector2Int vector, float t) => Mathf.Lerp(vector.x, vector.y, t);
			public static float InverseLerp(this Vector2Int vector, float value) => Mathf.InverseLerp(vector.x, vector.y, value);

		#endregion


		#region Properties - Search

			public static int Random(this Vector2Int vector) => UnityEngine.Random.Range(vector.x, vector.y);
			public static int RandomInclusive(this Vector2Int vector) => UnityEngine.Random.Range(vector.x, (vector.y + 1));
			public static int RandomExclusive(this Vector2Int vector) => UnityEngine.Random.Range((vector.x + 1), vector.y);

		#endregion


		#region Properties - Components

			public static float AverageOfTheTwo(this Vector2Int vector) => ((vector.x + vector.y) / 2f);

		#endregion


		#region Properties - Casts

			public static Vector2 ToVector2(this Vector2Int vector) => new Vector2(vector.x, vector.y);
			public static Vector2Int ToVector2Int(this Vector2Int vector) => new Vector2Int(vector.x, vector.y);
			public static Vector3 ToVector3(this Vector2Int vector) => new Vector3(vector.x, vector.y, 0f);
			public static Vector3Int ToVector3Int(this Vector2Int vector) => new Vector3Int(vector.x, vector.y, 0);

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