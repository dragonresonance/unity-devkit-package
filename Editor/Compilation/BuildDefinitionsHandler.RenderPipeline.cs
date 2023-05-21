#if UNITY_EDITOR


using UnityEngine.Rendering;




namespace PossumScream.Editor.Compilation
{
	public partial class BuildDefinitionsHandler // Render Pipeline
	{
		private static readonly string[] RenderPipelineValidDefinitions = {
			/* 0 */ "UNITY_BRP", // Fallback
			/* 1 */ "UNITY_URP",
			/* 2 */ "UNITY_HDRP",
		};




		#region Actions


			private static void checkRenderPipelineDefinitions()
			{
				forceDefinitionFromList(RenderPipelineValidDefinitions, getCurrentRenderPipelineDefinition());
			}




			private static string getCurrentRenderPipelineDefinition()
			{
				if (GraphicsSettings.currentRenderPipeline is null) return RenderPipelineValidDefinitions[0];

				return GraphicsSettings.currentRenderPipeline.GetType().Name switch {
					"HDRenderPipelineAsset" => RenderPipelineValidDefinitions[2],
					"UniversalRenderPipelineAsset" => RenderPipelineValidDefinitions[1],
					_ => RenderPipelineValidDefinitions[0],
				};
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