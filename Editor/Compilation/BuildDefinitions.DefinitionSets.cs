#if UNITY_EDITOR


namespace PossumScream.Editor.Compilation
{
	public partial class BuildDefinitions // Build Type
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

		private static readonly string[] SteamworksIntegrationValidDefinitions = {
			/* 0 */ "_DISABLESTEAMWORKS", // Default
			/* 1 */ "DISABLESTEAMWORKS",
		};

		private static readonly string[] EOSIntegrationValidDefinitions = {
			/* 0 */ "_EOS_DISABLE", // Default
			/* 1 */ "EOS_DISABLE",
		};
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
/*        David Tabernero M. @ PossumScream                      Copyright © 2021-2024        */
/*        GitLab - GitHub: possumscream                            All rights reserved        */
/*        - - - - - - - - - - - - -                                  - - - - - - - - -        */
/*                                                                                            */