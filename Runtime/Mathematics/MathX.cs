using UnityEngine;




namespace DragonResonance.Mathematics
{
	public struct MathX
	{
		#region Publics - General


			public static int TimesDivisible(int dividend, int divisor)
			{
				return (((dividend / divisor != 0) && (dividend % divisor == 0)) ? (TimesDivisible((dividend / divisor), divisor) + 1) : 0);
			}


		#endregion




		#region Publics - Performance


			public static float Framerate(int frames, float time)
			{
				return (frames / time);
			}


		#endregion




		#region Publics - Unity-Specific


			public static float LinearToMixerAudioVolume(float linearValue)
			{
				return (Mathf.Log10(Mathf.Clamp(linearValue, 0.0001f, 10f)) * 20f);
			}


			public static float MixerToLinearAudioVolume(float mixerValue)
			{
				return Mathf.Pow(10f, (Mathf.Clamp(mixerValue, -80f, 20f) / 20f));
			}




			public static float SceneLoadPercentage(AsyncOperation sceneLoadOperation)
			{
				return Mathf.Clamp01(sceneLoadOperation.progress / 0.9f);
			}


		#endregion




		#region Properties - Conversion


			public const float Rad2Rev = 0.15915494f; // rev = rad / (2 * pi)rad/rev
			public const float Rev2Rad = 6.28318531f; // rad = rev * (2 * pi)rad/rev

			public const float RPM2RadSec = 0.10471976f; // rad/s = RPM / 60s/min * (2 * pi)rad/rev
			public const float RadSec2RPM = 9.54929659f; // RPM = rad/s / (2 * pi)rad/rev * 60s/min

			public const float RTT2Ping = 0.002f; // ping = RTT / 1000 * 2
			public const float Ping2RTT = 500f; // RTT = ping * 1000 / 2


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