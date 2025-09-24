using UnityEngine;


namespace DragonResonance.Behaviours
{
	public abstract partial class PossumBehaviour : MonoBehaviour
	{
		#if UNITY_EDITOR
		#pragma warning disable 0414
		// ReSharper disable once NotAccessedField.Local
		[SerializeField] private string _description = "";
		#pragma warning restore 0414
		#endif
		
		
		protected T GetComponentIfNull<T>(Component statement) where T : Component =>
			((statement == null) ? GetComponent<T>() : (T)statement);
		protected T GetComponentInChildrenIfNull<T>(Component statement) where T : Component =>
			((statement == null) ? GetComponentInChildren<T>() : (T)statement);
		protected T GetComponentInParentIfNull<T>(Component statement) where T : Component =>
			((statement == null) ? GetComponentInParent<T>() : (T)statement);
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