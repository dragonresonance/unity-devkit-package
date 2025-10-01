using UnityEngine;


namespace DragonResonance.Extensions
{
	public static class Vector2Extensions
	{
		#region Properties - Operations

			public static bool Approximately(this Vector2 vectorA, Vector2 vectorB) => ((vectorB - vectorA).sqrMagnitude <= Mathf.Epsilon);

			public static Vector2 SortedLow2High(this Vector2 vector) => (vector.x > vector.y) ? (new Vector2(vector.y, vector.x)) : vector;
			public static Vector2 SortedHigh2Low(this Vector2 vector) => (vector.x < vector.y) ? (new Vector2(vector.y, vector.x)) : vector;

			public static float Lerp(this Vector2 vector, float t) => Mathf.Lerp(vector.x, vector.y, t);
			public static float InverseLerp(this Vector2 vector, float value) => Mathf.InverseLerp(vector.x, vector.y, value);

		#endregion


		#region Properties - Search

			public static float Random(this Vector2 vector) => UnityEngine.Random.Range(vector.x, vector.y);

		#endregion


		#region Properties - Components

			public static float AverageOfTheTwo(this Vector2 vector) => ((vector.x + vector.y) / 2f);

		#endregion


		#region Properties - Casts

			public static Vector2 ToVector2(this Vector2 vector) => new Vector2(vector.x, vector.y);
			public static Vector2Int ToVector2Int(this Vector2 vector) => new Vector2Int((int)vector.x, (int)vector.y);
			public static Vector3 ToVector3(this Vector2 vector) => new Vector3(vector.x, vector.y, 0f);
			public static Vector3Int ToVector3Int(this Vector2 vector) => new Vector3Int((int)vector.x, (int)vector.y, 0);

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