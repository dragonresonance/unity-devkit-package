#if !DISABLESTEAMWORKS
using PossumScream.Integration.Steamworks;
using Steamworks;
#endif


#if !EOS_DISABLE
using PossumScream.Integration.EOS;
#endif




namespace PossumScream.Integration
{
	public partial class IntegrationMaster // Achievements
	{
		#region Controls


			public bool CheckIfAchievementExists(string name)
			{
				#if !DISABLESTEAMWORKS
					// Steamworks
					return SteamUserStats.GetAchievement(name, out _);
				#elif !EOS_DISABLE
					// Epic Online Services
					return false;
				#else
					// No integration
					return false;
				#endif
			}


			public bool CheckIfAchievementAchieved(string name)
			{
				#if !DISABLESTEAMWORKS
					// Steamworks
					return SteamUserStats.GetAchievement(name, out bool achieved) && achieved;
				#elif !EOS_DISABLE
					// Epic Online Services
					return false;
				#else
					// No integration
					return false;
				#endif
			}




			public bool SetAchievement(string name)
			{
				#if !DISABLESTEAMWORKS
					// Steamworks
					return SteamUserStats.SetAchievement(name);
				#elif !EOS_DISABLE
					// Epic Online Services
					return false;
				#else
					// No integration
					return false;
				#endif
			}


			public bool UnsetAchievement(string name)
			{
				#if !DISABLESTEAMWORKS
					// Steamworks
					return SteamUserStats.ClearAchievement(name);
				#elif !EOS_DISABLE
					// Epic Online Services
					return false;
				#else
					// No integration
					return false;
				#endif
			}




			public bool StoreStats()
			{
				#if !DISABLESTEAMWORKS
					// Steamworks
					return SteamUserStats.StoreStats();
				#elif !EOS_DISABLE
					// Epic Online Services
					return false;
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
/*         / ____/ /_/ /__  /__  / /_/ / / / / / /__/ / /__/ /  /  __/ /_/ / / / / / /        */
/*        /_/    \____/____/____/\____/_/ /_/ /_/____/\___/_/   \___/\__/_/_/ /_/ /__\        */
/*                                                                                            */
/*        Licensed under the Apache License, Version 2.0. See LICENSE.md for more info        */
/*        David Tabernero M. @ PossumScream                      Copyright © 2021-2023        */
/*        GitLab / GitHub: possumscream                            All rights reserved        */
/*        -------------------------                                  -----------------        */
/*                                                                                            */