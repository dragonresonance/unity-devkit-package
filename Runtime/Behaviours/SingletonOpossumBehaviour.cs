#if UNITY_NGO


using UnityEngine;


namespace PossumScream.Behaviours
{
	public abstract class SingletonOpossumBehaviour<T> : InstantiableOpossumBehaviour<T> where T : Component
	{
		#region Privates

			protected override void AssessInstance()
			{
				if (_instance == null) {
					_instance = this as T;
					base.InvokeInstantiationEvent();
				}
				else if (_instance != this) {
					Destroy(this);
				}
			}

		#endregion
	}
}


#endif


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