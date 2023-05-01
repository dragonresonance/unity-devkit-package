#if !DISABLESTEAMWORKS
using PossumScream.Integration.Steamworks;
using Steamworks;
#endif


#if !EOS_DISABLE
using PossumScream.Integration.EOS;
#endif




namespace PossumScream.Integration
{
	public partial class IntegrationMaster // Social
	{
		#region Controls


			public string GetPersonaName()
			{
				#if !DISABLESTEAMWORKS
					// Steamworks
					return SteamFriends.GetPersonaName();
				#elif !EOS_DISABLE
					// Epic Online Services
					return null;
				#else
					// No integration
					return null;
				#endif
			}


			public int GetFriendCount()
			{
				#if !DISABLESTEAMWORKS
					// Steamworks
					return SteamFriends.GetFriendCount(EFriendFlags.k_EFriendFlagAll);
				#elif !EOS_DISABLE
					// Epic Online Services
					return -1;
				#else
					// No integration
					return -1;
				#endif
			}


			public string[] GetFriendList()
			{
				#if !DISABLESTEAMWORKS
					// Steamworks
					int friendCount = GetFriendCount();
					string[] friendList = new string[friendCount];

					for (int friendIndex = 0; friendIndex < friendCount; friendIndex++) {
						CSteamID steamId = SteamFriends.GetFriendByIndex(friendIndex, EFriendFlags.k_EFriendFlagAll);
						friendList[friendIndex] = SteamFriends.GetFriendPersonaName(steamId);
					}

					return friendList;
				#elif !EOS_DISABLE
					// Epic Online Services
					return null;
				#else
					// No integration
					return null;
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