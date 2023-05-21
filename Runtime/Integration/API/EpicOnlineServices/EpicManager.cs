#if !(UNITY_STANDALONE_WIN || UNITY_STANDALONE_LINUX || UNITY_STANDALONE_OSX || EOS_PREVIEW_PLATFORM)
#define EOS_DISABLE
#endif


using NaughtyAttributes;
using PossumScream.Behaviours;
using UnityEngine;


#if !EOS_DISABLE
//
#endif




namespace PossumScream.Integration.EOS
{
	public class EpicManager : PersistentSingletonBehaviour<EpicManager>
	{
		[Header("Configuration")]
		#pragma warning disable CS0414
		// ReSharper disable once NotAccessedField.Local
		[SerializeField] [Label("[DANGER!] Edit Critical Configuration")] private bool _editCriticalConfiguration = false;
		#pragma warning restore CS0414

		[EnableIf("_editCriticalConfiguration")] [SerializeField] private bool _initialized = false;




		#region Properties


			public bool Initialized => this._initialized;


		#endregion
	}
}




/*                                                                                            */
/*          ______                               _______                                      */
/*          \  __ \____  ____________  ______ ___\  ___/_____________  ____  ____ ___         */
/*          / /_/ / __ \/ ___/ ___/ / / / __ \__ \\__ \/ ___/ ___/ _ \/ __ \/ __ \__ \        */
/*         / ____/ /_/ /__  /__  / /_/ / / / / / /__/ / /__/ /  / ___/ /_/ / / / / / /        */
/*        /_/    \____/____/____/\____/_/ /_/ /_/____/\___/_/   \___/\__/_/_/ /_/ /__\        */
/*                                                                                            */
/*        Licensed under the Apache License, Version 2.0. See LICENSE.md for more info        */
/*        David Tabernero M. @ PossumScream                      Copyright © 2021-2023        */
/*        GitLab - GitHub: possumscream                            All rights reserved        */
/*        -------------------------                                  -----------------        */
/*                                                                                            */