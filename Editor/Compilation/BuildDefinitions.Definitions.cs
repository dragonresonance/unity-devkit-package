#if UNITY_EDITOR


namespace DragonResonance.Editor.Compilation
{
	public partial class BuildDefines // Definitions
	{
		private static readonly string[] DemonstrationValidDefinitions = {
			/* 0 */ "_DEMO_BUILD", // Default
			/* 1 */ "DEMO_BUILD",
		};

		private static readonly string[] LoggingValidDefinitions = {
			/* 0 */ "_NO_LOGGING", // Default
			/* 1 */ "NO_LOGGING",
		};

		private static readonly string[] ContexterIntegrationValidDefinitions = {
			/* 0 */ "_ENABLE_CONTEXTER", // Default
			/* 1 */ "ENABLE_CONTEXTER",
		};

		#if STEAMWORKS_INTEGRATION
		private static readonly string[] SteamworksIntegrationValidDefinitions = {
			/* 0 */ "_DISABLESTEAMWORKS", // Default
			/* 1 */ "DISABLESTEAMWORKS",
		};
		#endif

		#if EOS_INTEGRATION
		private static readonly string[] EOSIntegrationValidDefinitions = {
			/* 0 */ "_EOS_DISABLE", // Default
			/* 1 */ "EOS_DISABLE",
		};
		#endif
	}
}


#endif


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
/*                  Copyright © 2021-2024. All rights reserved.                 */
/*                Licensed under the Apache License, Version 2.0.               */
/*                         See LICENSE.md for more info.                        */
/*       ________________________________________________________________       */
/*                                                                              */