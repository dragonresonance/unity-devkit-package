using UnityEngine;


namespace DragonResonance.Behaviours
{
	public abstract class PersistentSingletonPossumBehaviour<T> : SingletonPossumBehaviour<T> where T : Component
	{
		#region Privates

			protected new void AssessInstance()
			{
				if (_instance == null) {
					_instance = this as T;
					DontDestroyOnLoad(base.gameObject);
					base.InvokeInstantiationEvent();
				}
				else if (_instance != this) {
					Destroy(this);
				}
			}

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
/*                  Copyright © 2021-2025. All rights reserved.                 */
/*                Licensed under the Apache License, Version 2.0.               */
/*                         See LICENSE.md for more info.                        */
/*       ________________________________________________________________       */
/*                                                                              */