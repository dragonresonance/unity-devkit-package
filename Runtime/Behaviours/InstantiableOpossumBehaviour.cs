#if UNITY_NGO


using System;
using UnityEngine;




namespace PossumScream.Behaviours
{
	[DisallowMultipleComponent]
	public abstract class InstantiableOpossumBehaviour<T> : OpossumBehaviour where T : Component
	{
		internal static T _instance = null;
		public static event Action OnInstanced = null;
		public static event Action OnSpawned = null;
		public static event Action OnDespawned = null;




		#region Events


			protected void Awake()
			{
				AssessInstance();
				LateAwake();
			}

			protected virtual void LateAwake()
			{
				return;
			}


			public override void OnNetworkSpawn()
			{
				base.OnNetworkSpawn();
				OnSpawned?.Invoke();
			}

			public override void OnNetworkDespawn()
			{
				base.OnNetworkDespawn();
				OnDespawned?.Invoke();
			}


		#endregion




		#region Publics


			public static T GetInstance()
			{
				if ((_instance == null) && (FindAnyObjectByType(typeof(T)) is InstantiableOpossumBehaviour<T> instance))
					instance.AssessInstance();

				return _instance;
			}


			public static bool TryGetInstance(out T instance)
			{
				return ((instance = GetInstance()) != null);
			}


		#endregion




		#region Privates


			protected virtual void AssessInstance() { }

			protected void InvokeInstantiationEvent() => OnInstanced?.Invoke();


		#endregion




		#region Properties


			public static T CachedInstance => _instance;


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