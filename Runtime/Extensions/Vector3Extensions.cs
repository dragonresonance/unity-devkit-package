using System;
using UnityEngine;


namespace DragonResonance.Extensions
{
	public static class Vector3Extensions
	{
		#region Properties - Operations

			public static bool Approximately(this Vector3 vectorA, Vector3 vectorB) => ((vectorB - vectorA).sqrMagnitude <= Mathf.Epsilon);
			public static Vector3 ProjectOntoPlane(this Vector3 vector, Vector3 planeNormal) => (vector - Vector3.Dot(vector, planeNormal) * planeNormal);
			public static Vector3 ClampMagnitude(this Vector3 vector, float maxMagnitude) => (vector.normalized * Mathf.Min(vector.magnitude, maxMagnitude));

		#endregion


		#region Properties - Components

			public static Vector3 NormalizedComponents(this Vector3 vector) => new(Math.Sign(vector.x), Math.Sign(vector.y), Math.Sign(vector.z));
			public static Vector3 AbsoluteComponents(this Vector3 vector) => new(Mathf.Abs(vector.x), Mathf.Abs(vector.y), Mathf.Abs(vector.z));
			public static float AverageOfTheThree(this Vector3 vector) => ((vector.x + vector.y + vector.z) / 3f);

		#endregion


		#region Properties - Casts

			public static Vector2 ToVector2(this Vector3 vector) => new Vector2(vector.x, vector.y);
			public static Vector2Int ToVector2Int(this Vector3 vector) => new Vector2Int((int)vector.x, (int)vector.y);
			public static Vector3 ToVector3(this Vector3 vector) => new Vector3(vector.x, vector.y, vector.z);
			public static Vector3Int ToVector3Int(this Vector3 vector) => new Vector3Int((int)vector.x, (int)vector.y, (int)vector.z);

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