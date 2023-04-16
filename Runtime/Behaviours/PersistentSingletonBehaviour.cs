using UnityEngine;




namespace PossumScream.Behaviours
{
	public abstract class PersistentSingletonBehaviour<T> : InstantiableBehaviour<T> where T : Component
	{
		#region Events


			protected void Awake()
			{
				if (m_instance == null) {
					m_instance = this as T;
					DontDestroyOnLoad(this.gameObject);
				}
				else if (m_instance != this) {
					Destroy(this);
					return;
				}

				base.LateAwake();
			}


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