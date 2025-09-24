using UnityEngine;


namespace DragonResonance.Extensions
{
	public static class ComponentExtensions
	{
		public static void AssignComponentInSelf<T>(this Component field) where T : Component => field = field.GetComponent<T>();
		public static void AssignComponentInChildren<T>(this Component field) where T : Component => field = field.GetComponentInChildren<T>();
		public static void AssignComponentInParent<T>(this Component field) where T : Component => field = field.GetComponentInParent<T>();

		public static Component FindAndGet<T>(this Component field) where T : Component => Retrieve<T>(field, FindObjectsInactive.Include);
		public static Component FindAndGet<T>(this Component field, bool includeInactive) where T : Component => Retrieve<T>(field, (includeInactive ? FindObjectsInactive.Include : FindObjectsInactive.Exclude));
		public static Component FindAndGet<T>(this Component field, FindObjectsInactive includeInactive) where T : Component => Retrieve<T>(field, includeInactive);
		public static Component Retrieve<T>(this Component field) where T : Component => Retrieve<T>(field, FindObjectsInactive.Include);
		public static Component Retrieve<T>(this Component field, bool includeInactive) where T : Component => Retrieve<T>(field, (includeInactive ? FindObjectsInactive.Include : FindObjectsInactive.Exclude));
		public static Component Retrieve<T>(this Component field, FindObjectsInactive includeInactive) where T : Component
		{
			if (field == null)
				field = Object.FindAnyObjectByType<T>(includeInactive);
			return field;
		}
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