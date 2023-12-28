#if UNITY_NGO


using UnityEngine;




namespace PossumScream.Behaviours
{
	[DisallowMultipleComponent]
	public abstract class InstantiableOpossumBehaviour<T> : OpossumBehaviour where T : Component
	{
		internal static T m_instance = null;




		#region Events


			protected virtual void LateAwake()
			{
				return;
			}


		#endregion




		#region Publics


			public static T GetInstance()
			{
				if (m_instance == null)
					m_instance = FindObjectOfType(typeof(T)) as T;

				return m_instance;
			}


			public static bool TryGetInstance(out T instance)
			{
				return ((instance = GetInstance()) != null);
			}


		#endregion




		#region Properties


			public static T CachedInstance => m_instance;


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