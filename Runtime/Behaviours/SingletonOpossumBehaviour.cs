#if UNITY_NGO


using System;
using UnityEngine;


namespace DragonResonance.Behaviours
{
	[DisallowMultipleComponent]
	public abstract class SingletonOpossumBehaviour<T> : OpossumBehaviour where T : Component
	{
		internal static T _instance = null;
		public static event Action OnInstanced = null;
		public static event Action OnSpawned = null;
		public static event Action OnDespawned = null;


		#region Events

			protected void Awake() => AssessInstance();

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

			public static bool TryGetInstance(out T instance) => ((instance = GetInstance()) != null);

			public static T GetInstance()
			{
				if ((_instance == null) && (FindAnyObjectByType(typeof(T)) is SingletonOpossumBehaviour<T> instance))
					instance.AssessInstance();

				return _instance;
			}

		#endregion


		#region Privates

			protected void InvokeInstantiationEvent() => OnInstanced?.Invoke();

			protected void AssessInstance()
			{
				if (_instance == null) {
					_instance = this as T;
					InvokeInstantiationEvent();
				}
				else if (_instance != this) {
					Destroy(this);
				}
			}

		#endregion


		#region Properties

			public static T CachedInstance => _instance;

		#endregion
	}
}


#endif


/*       ________________________________________________________________       */
/*           _________   _______ ________  _______  _______  ___    _           */
/*           |        \ |______/ |______| |  _____ |       | |  \   |           */
/*           |________/ |     \_ |      | |______| |_______| |   \__|           */
/*           ______ _____ _____ _____ __   _ _____ __   _ _____ _____           */
/*           |____/ |____ [___  |   | | \  | |___| | \  | |     |____           */
/*           |    \ |____ ____] |___| |  \_| |   | |  \_| |____ |____           */
/*       ________________________________________________________________       */
/*                                                                              */
/*           David Tabernero M.  <https://github.com/davidtabernerom>           */
/*           Dragon Resonance    <https://github.com/dragonresonance>           */
/*                  Copyright © 2021-2025. All rights reserved.                 */
/*                Licensed under the Apache License, Version 2.0.               */
/*                         See LICENSE.md for more info.                        */
/*       ________________________________________________________________       */
/*                                                                              */