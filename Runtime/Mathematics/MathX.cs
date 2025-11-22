using UnityEngine;


namespace DragonResonance.Mathematics
{
	public static class MathX
	{
		#region Operations

			public static int TimesDivisible(int dividend, int divisor) => (((dividend / divisor != 0) && (dividend % divisor == 0)) ? (TimesDivisible((dividend / divisor), divisor) + 1) : 0);

		#endregion


		#region Performance

			public static float Framerate(int frames, float time) => (frames / time);

		#endregion


		#region Audio

			public static float LinearToMixerAudioVolume(float linearValue) => (Mathf.Log10(Mathf.Clamp(linearValue, 0.0001f, 10f)) * 20f);
			public static float MixerToLinearAudioVolume(float mixerValue) => Mathf.Pow(10f, (Mathf.Clamp(mixerValue, -80f, 20f) / 20f));

		#endregion


		#region Audio

			public static float SceneLoadPercentage(AsyncOperation sceneLoadOperation) => Mathf.Clamp01(sceneLoadOperation.progress / 0.9f);

		#endregion


		#region Properties - Conversion

			public const float Rad2Rev = 0.15915494f; // rev = rad / (2*pi)rad/rev
			public const float Rev2Rad = 6.28318531f; // rad = rev * (2*pi)rad/rev

			public const float RPM2RadSec = 0.10471976f; // rad/s = RPM / 60s/min * (2*pi)rad/rev
			public const float RadSec2RPM = 9.54929659f; // RPM = rad/s / (2*pi)rad/rev * 60s/min

			public const float RTT2Ping = 0.002f; // ping = RTT / 1000 * 2
			public const float Ping2RTT = 500f; // RTT = ping * 1000 / 2

			public const float Cm2Inches = 0.39370079f; // inches = cm / 2.54
			public const float Inches2Cm = 2.54f; // cm = inches * 2.54
			public const float Meters2Miles = 0.00062137f; // miles = 15625/25146000
			public const float Miles2Meters = 1609.344f; // meters = 25146000/15625
			public const float Kilometers2Miles = 0.62137119f; // miles = 15625/25146
			public const float Miles2Kilometers = 1.609344f; // kilometers = 25146/15625

			public const float MetSec2Kmh = 3.6f; // km/h = m/s * 3600s/h / 1000m/km
			public const float Kmh2MetSec = 0.27777778f; // m/s = km/h * 1000m/km / 3600s/h
			public const float MetSec2Mph = 2.23693629f; // mph = m/s * 3600s/h / 1000m/km * 15625/25146
			public const float Mph2MetSec = 0.44704f; // m/s = mph * 25146/15625 * 1000m/km / 3600s/h

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