using UnityEngine;


namespace DragonResonance.Extensions
{
	public static class TransformExtensions
	{
		public static void TranslateLocal(this Transform transform, float x, float y, float z) => TranslateLocal(transform, new Vector3(x, y, z));
		public static void TranslateLocal(this Transform transform, Vector3 translation)
		{
			Vector3 localPosition = transform.localPosition;
			transform.localPosition = new Vector3(
				localPosition.x + translation.x,
				localPosition.y + translation.y,
				localPosition.z + translation.z);
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