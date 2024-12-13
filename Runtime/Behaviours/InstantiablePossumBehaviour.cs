using System;
using UnityEngine;




namespace DragonResonance.Behaviours
{
	[DisallowMultipleComponent]
	public abstract class InstantiablePossumBehaviour<T> : PossumBehaviour where T : Component
	{
		internal static T _instance = null;
		public static event Action OnInstanced = null;




		#region Events


			protected virtual void Awake()
			{
				AssessInstance();
				LateAwake();
			}

			[Obsolete]
			protected virtual void LateAwake() { }


		#endregion




		#region Publics


			public static T GetInstance()
			{
				if ((_instance == null) && (FindAnyObjectByType(typeof(T)) is InstantiablePossumBehaviour<T> instance))
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
/*                  Copyright © 2021-2024. All rights reserved.                 */
/*                Licensed under the Apache License, Version 2.0.               */
/*                         See LICENSE.md for more info.                        */
/*       ________________________________________________________________       */
/*                                                                              */