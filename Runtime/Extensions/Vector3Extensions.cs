using System;
using UnityEngine;




namespace PossumScream.Extensions
{
	public static class Vector3Extensions
	{
		public static void NormalizeComponents(this ref Vector3 vector3)
		{
			vector3 = (new Vector3(
				Math.Sign(vector3.x),
				Math.Sign(vector3.y),
				Math.Sign(vector3.z)));
		}


		public static Vector3 CalculateNormalizedComponents(this Vector3 vector3)
		{
			vector3.NormalizeComponents();


			return vector3;
		}




		public static void AbsoluteComponents(this ref Vector3 vector3)
		{
			vector3 = (new Vector3(
				Mathf.Abs(vector3.x),
				Mathf.Abs(vector3.y),
				Mathf.Abs(vector3.z)));
		}


		public static Vector3 CalculateAbsoluteComponents(this Vector3 vector3)
		{
			vector3.AbsoluteComponents();


			return vector3;
		}
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