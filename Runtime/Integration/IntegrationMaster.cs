#if !(UNITY_STANDALONE_WIN || UNITY_STANDALONE_LINUX || UNITY_STANDALONE_OSX || STEAMWORKS_WIN || STEAMWORKS_LIN_OSX) || !EOS_DISABLE
#define DISABLESTEAMWORKS
#endif
#if !(UNITY_STANDALONE_WIN || UNITY_STANDALONE_LINUX || UNITY_STANDALONE_OSX || EOS_PREVIEW_PLATFORM) || !DISABLESTEAMWORKS
#define EOS_DISABLE
#endif


using PossumScream.Behaviours;
using UnityEngine;


#if !DISABLESTEAMWORKS
using PossumScream.Integration.Steamworks;
using Steamworks;
#endif


#if !EOS_DISABLE
using PossumScream.Integration.EOS;
#endif




namespace PossumScream.Integration
{
	public partial class IntegrationMaster : PersistentSingletonBehaviour<IntegrationMaster>
	{
		[Header("Components")]
		[SerializeField] private IntegrationTester _integrationTester = null;




		#region Events


			#if !DISABLESTEAMWORKS || !EOS_DISABLE
			private void Start()
			{
				if (this._integrationTester == null) return;

				this._integrationTester.TestInitialization();
			}
			#endif


		#endregion




		#region Controls


			//


		#endregion
	}
}




/*                                                                                            */
/*          ______                               _______                                      */
/*          \  __ \____  ____________  ______ ___\  ___/_____________  ____  ____ ___         */
/*          / /_/ / __ \/ ___/ ___/ / / / __ \__ \\__ \/ ___/ ___/ _ \/ __ \/ __ \__ \        */
/*         / ____/ /_/ /__  /__  / /_/ / / / / / /__/ / /__/ /  /  __/ /_/ / / / / / /        */
/*        /_/    \____/____/____/\____/_/ /_/ /_/____/\___/_/   \___/\__/_/_/ /_/ /__\        */
/*                                                                                            */
/*        Licensed under the Apache License, Version 2.0. See LICENSE.md for more info        */
/*        David Tabernero M. @ PossumScream                      Copyright © 2021-2023        */
/*        GitLab / GitHub: possumscream                            All rights reserved        */
/*        -------------------------                                  -----------------        */
/*                                                                                            */