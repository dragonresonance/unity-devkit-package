using UnityEngine;




namespace PossumScream.Mathematics
{
	public struct MathX
	{
		#region General Operations


			public static int TimesDivisible(int dividend, int divisor)
			{
				return (((dividend / divisor != 0) && (dividend % divisor == 0)) ? (TimesDivisible((dividend / divisor), divisor) + 1) : 0);
			}


		#endregion




		#region Performance Operations


			public static float Framerate(int frames, float time)
			{
				return (frames / time);
			}


		#endregion




		#region Unity Components Operations


			public static float LinearToMixerVolume(float linearVolume)
			{
				return (Mathf.Log10(Mathf.Clamp(linearVolume, 0.0001f, 10f)) * 20f);
			}


			public static float MixerToLinearVolume(float mixerVolume)
			{
				return Mathf.Pow(10f, (Mathf.Clamp(mixerVolume, -80f, 20f) / 20f));
			}




			public static float SceneCorrectedProgress(AsyncOperation sceneLoadOperation)
			{
				return Mathf.Clamp01(sceneLoadOperation.progress / 0.9f);
			}


		#endregion




		#region Conversion Constants


			public const float Rad2Rev = 0.15915494f; // rev = rad / (2 * pi)rad/rev
			public const float Rev2Rad = 6.28318531f; // rad = rev * (2 * pi)rad/rev

			public const float RPM2RadSec = 0.10471976f; // rad/s = RPM / 60s/min * (2 * pi)rad/rev
			public const float RadSec2RPM = 9.54929659f; // RPM = rad/s / (2 * pi)rad/rev * 60s/min


		#endregion
	}
}




/*                                                                                            */
/*            ____                                 _____                                      */
/*           / __ \____  ____________  ______ ___ / ___/_____________  ____ _____ ___         */
/*          / /_/ / __ \/ ___/ ___/ / / / __ `__ \\__ \/ ___/ ___/ _ \/ __ `/ __ `__ \        */
/*         / ____/ /_/ (__  |__  ) /_/ / / / / / /__/ / /__/ /  /  __/ /_/ / / / / / /        */
/*        /_/    \____/____/____/\__,_/_/ /_/ /_/____/\___/_/   \___/\__,_/_/ /_/ /_/         */
/*                                                                                            */
/*        Licensed under the Apache License, Version 2.0. See LICENSE.md for more info        */
/*        David Tabernero M. @ PossumScream                      Copyright © 2021-2023        */
/*        https://gitlab.com/possumscream                          All rights reserved        */
/*                                                                                            */
/*                                                                                            */