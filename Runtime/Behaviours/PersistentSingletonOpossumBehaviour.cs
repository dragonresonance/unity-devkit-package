#if UNITY_NGO


using UnityEngine;




namespace PossumScream.Behaviours
{
	public abstract class PersistentSingletonOpossumBehaviour<T> : InstantiableOpossumBehaviour<T> where T : Component
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
				else {
					DontDestroyOnLoad(this.gameObject);
				}

				LateAwake();
			}


		#endregion




		#region Publics


			public new static T GetInstance()
			{
				if (m_instance == null) {
					m_instance = FindObjectOfType(typeof(T)) as T;
					DontDestroyOnLoad(m_instance);
				}

				return m_instance;
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