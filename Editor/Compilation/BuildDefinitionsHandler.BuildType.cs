#if UNITY_EDITOR


namespace PossumScream.Editor.Compilation
{
	public partial class BuildDefinitionsHandler // Build Type
	{
		private static readonly string[] DevelopmentValidDefinitions = {
			/* 0 */ "_DEVELOPMENT_BUILD", // Default
			/* 1 */ "DEVELOPMENT_BUILD",
		};

		private static readonly string[] DemonstrationValidDefinitions = {
			/* 0 */ "_DEMO_BUILD", // Default
			/* 1 */ "DEMO_BUILD",
		};




		#region Actions


			private static void checkBuildTypeDefinitions()
			{
				checkAndReplenishDefinitionFromList(DemonstrationValidDefinitions, 0);
				checkAndReplenishDefinitionFromList(DevelopmentValidDefinitions, 0);
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