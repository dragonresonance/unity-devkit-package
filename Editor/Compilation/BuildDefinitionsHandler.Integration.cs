#if UNITY_EDITOR


namespace PossumScream.Editor.Compilation
{
	public partial class BuildDefinitionsHandler // Integration
	{
		#if STEAMWORKS_INTEGRATION
		private static readonly string[] SteamworksValidDefinitions = {
			/* 0 */ "_DISABLESTEAMWORKS", // Default
			/* 1 */ "DISABLESTEAMWORKS",
		};
		#endif

		#if EOS_INTEGRATION
		private static readonly string[] EpicOnlineServicesValidDefinitions = {
			/* 0 */ "_EOS_DISABLE", // Default
			/* 1 */ "EOS_DISABLE",
		};
		#endif




		#region Actions


			private static void CheckIntegrationDefinitions()
			{
				#if STEAMWORKS_INTEGRATION
					CheckAndReplenishDefinitions(SteamworksValidDefinitions, 0);
				#endif

				#if EOS_INTEGRATION
					CheckAndReplenishDefinitions(EpicOnlineServicesValidDefinitions, 0);
				#endif
			}


		#endregion
	}
}


#endif




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