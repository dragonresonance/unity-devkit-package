using System.Collections.Generic;
using UnityEngine;




namespace PossumScream.Extensions
{
	public static class AnimationCurveExtensions
	{
		#region Generators: Classics


			public static AnimationCurve GenerateEaseToExpoCurve(float timeStart, float valueStart, float timeEnd, float valueEnd)
			{
				AnimationCurve animationCurve = new AnimationCurve();

				{
					Keyframe[] keyframes = {
						new(timeStart, valueStart, 0f, 0f, 0f, 1f),
						new(timeEnd, valueEnd, 0f, 0f, 0f, 0f),
					};

					animationCurve.AddKeys(keyframes);
				}

				return animationCurve;
			}


			public static AnimationCurve GenerateExpoToEaseCurve(float timeStart, float valueStart, float timeEnd, float valueEnd)
			{
				AnimationCurve animationCurve = new AnimationCurve();

				{
					Keyframe[] keyframes = {
						new(timeStart, valueStart, 0f, 0f, 0f, 0f),
						new(timeEnd, valueEnd, 0f, 0f, 1f, 0f),
					};

					animationCurve.AddKeys(keyframes);
				}

				return animationCurve;
			}


		#endregion




		#region Generators: Loops


			public static AnimationCurve GeneratePeakLoopCurve(float timeStart, float timePeak, float timeEnd, float valueStartEnd, float valuePeak)
			{
				AnimationCurve animationCurve = new();
				{
					Keyframe[] keyframes = {
						new(timeStart, valueStartEnd, 0f, 0f),
						new(timePeak, valuePeak, 0f, 0f),
						new(timeEnd, valueStartEnd, 0f, 0f),
					};

					animationCurve.AddKeys(keyframes);
				}
				return animationCurve;
			}


		#endregion




		#region Controls: Time


			public static float CalculateAnimationTimeInterval(this AnimationCurve animationCurve)
			{
				return (animationCurve.GetLatestKey().time - animationCurve.GetEarliestKey().time);
			}


		#endregion




		#region Controls: Value


			public static float CalculateAnimationValueDelta(this AnimationCurve animationCurve)
			{
				return (animationCurve.GetLatestKey().value - animationCurve.GetEarliestKey().value);
			}


		#endregion




		#region Controls: Keyframe


			public static Keyframe GetEarliestKey(this AnimationCurve animationCurve)
			{
				return animationCurve.keys[0];
			}


			public static Keyframe GetLatestKey(this AnimationCurve animationCurve)
			{
				return animationCurve.keys[animationCurve.length - 1];
			}


			public static void AddKeys(this AnimationCurve animationCurve, IEnumerable<Keyframe> keyframes)
			{
				foreach (Keyframe keyframe in keyframes)
					animationCurve.AddKey(keyframe);
			}


		#endregion
	}
}




/*                                                                                            */
/*          ______                               _______                                      */
/*          \  __ \____  ____________  ______ ___\  ___/_____________  ____  ____ ___         */
/*          / /_/ / __ \/ ___/ ___/ / / / __ \__ \\__ \/ ___/ ___/ _ \/ __ \/ __ \__ \        */
/*         / ____/ /_/ /__  /__  / /_/ / / / / / /__/ / /__/ /  / ___/ /_/ / / / / / /        */
/*        /_/    \____/____/____/\____/_/ /_/ /_/____/\___/_/   \___/\__/_/_/ /_/ /__\        */
/*                                                                                            */
/*        Licensed under the Apache License, Version 2.0. See LICENSE.md for more info        */
/*        David Tabernero M. @ PossumScream                      Copyright © 2021-2023        */
/*        GitLab - GitHub: possumscream                            All rights reserved        */
/*        -------------------------                                  -----------------        */
/*                                                                                            */