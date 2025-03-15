using System;
using UnityEngine;


namespace DragonResonance.Extensions
{
	public static class Vector3Extensions
	{
		#region Publics - Operations

			public static Vector3 ProjectOntoPlane(this Vector3 vector, Vector3 planeNormal)
			{
				return vector - Vector3.Dot(vector, planeNormal) * planeNormal;
			}

		#endregion


		#region Publics - Components

			public static Vector3 NormalizedComponents(this Vector3 vector)
			{
				return new Vector3(Math.Sign(vector.x), Math.Sign(vector.y), Math.Sign(vector.z));
			}

			public static Vector3 AbsoluteComponents(this Vector3 vector)
			{
				return new Vector3(Mathf.Abs(vector.x), Mathf.Abs(vector.y), Mathf.Abs(vector.z));
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