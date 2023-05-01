#if UNITY_EDITOR


namespace PossumScream.Editor.Compilation
{
	public partial class BuildDefinitionsHandler // Integration
	{
		private static readonly string[] SteamworksValidDefinitions = {
			/* 0 */ "DISABLESTEAMWORKS", // Default
			/* 1 */ "_DISABLESTEAMWORKS",
		};

		private static readonly string[] EpicOnlineServicesValidDefinitions = {
			/* 0 */ "EOS_DISABLE", // Default
			/* 1 */ "_EOS_DISABLE",
		};




		#region Actions


			private static void checkIntegrationDefinitions()
			{
				checkAndReplenishDefinitionFromList(EpicOnlineServicesValidDefinitions, 0);
				checkAndReplenishDefinitionFromList(SteamworksValidDefinitions, 0);
			}


		#endregion
	}
}


#endif




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