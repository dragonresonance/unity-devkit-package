#if !DISABLESTEAMWORKS
using PossumScream.Integration.Steamworks;
#endif


#if !EOS_DISABLE
using PossumScream.Integration.EOS;
#endif




namespace PossumScream.Integration
{
	public partial class IntegrationMaster // Initialization
	{
		#region Controls


			public bool CheckInitialization()
			{
				#if !DISABLESTEAMWORKS
					// Steamworks
					return SteamManager.TryGetInstance(out SteamManager steamManagerInstance) && steamManagerInstance.Initialized;
				#elif !EOS_DISABLE
					// Epic Online Services
					return EpicManager.TryGetInstance(out EpicManager epicManagerInstance) && epicManagerInstance.Initialized;
				#else
					// No integration
					return false;
				#endif
			}


		#endregion




		#region Actions


			//


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