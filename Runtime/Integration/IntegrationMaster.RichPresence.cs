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
	public partial class IntegrationMaster // Rich Presence
	{
		[Header("Rich Presence")]
		[SerializeField] private string _steamworks_richPresenceCompositeKey = "steam_display";
		[SerializeField] private string _steamworks_richPresenceCompositeRegex = "#{0}";
		[SerializeField] private string _steamworks_richPresenceParameterKey = "steam_parameter";
		[SerializeField] private string _steamworks_richPresenceParameterRegex = "{0}";




		#region Controls


			public bool SetRichPresence(string compositeKey)
			{
				#if !DISABLESTEAMWORKS
					// Steamworks
					return (SteamFriends.SetRichPresence(
							this._steamworks_richPresenceCompositeKey,
							string.Format(this._steamworks_richPresenceCompositeRegex, compositeKey)));
				#elif !EOS_DISABLE
					// Epic Online Services
					return false;
				#else
					// No integration
					return false;
				#endif
			}


			public bool SetRichPresence(string compositeKey, string compositeParameter)
			{
				#if !DISABLESTEAMWORKS
					// Steamworks
					return (SteamFriends.SetRichPresence(
							this._steamworks_richPresenceParameterKey,
							string.Format(this._steamworks_richPresenceParameterRegex, compositeParameter)) &&
						SteamFriends.SetRichPresence(
							this._steamworks_richPresenceCompositeKey,
							string.Format(this._steamworks_richPresenceCompositeRegex, compositeKey)));
				#elif !EOS_DISABLE
					// Epic Online Services
					return false;
				#else
					// No integration
					return false;
				#endif
			}




			public void UnsetRichPresence()
			{
				#if !DISABLESTEAMWORKS
					// Steamworks
					SteamFriends.ClearRichPresence();
				#elif !EOS_DISABLE
					// Epic Online Services
					return;
				#else
					// No integration
					return;
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