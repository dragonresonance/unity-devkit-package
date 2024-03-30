using UnityEngine;


namespace PossumScream.Extensions
{
	public static class Vector2Extensions
	{
		#region Value Operations

			public static float Lerp(this Vector2 vector, float t)
			{
				return Mathf.Lerp(vector.x, vector.y, t);
			}

			public static float InverseLerp(this Vector2 vector, float value)
			{
				return Mathf.InverseLerp(vector.x, vector.y, value);
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
/*        David Tabernero M. @ PossumScream                      Copyright © 2021-2024        */
/*        GitLab - GitHub: possumscream                            All rights reserved        */
/*        - - - - - - - - - - - - -                                  - - - - - - - - -        */
/*                                                                                            */