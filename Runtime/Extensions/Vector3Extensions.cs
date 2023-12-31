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