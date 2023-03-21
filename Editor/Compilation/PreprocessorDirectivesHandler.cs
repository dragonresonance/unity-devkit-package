#if UNITY_EDITOR


using PossumScream.Enhancements;
using PossumScream.Extensions;
using System.Collections.Generic;
using System.Linq;
using System;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine.Rendering;




namespace PossumScream.Editor.Compilation
{
	[InitializeOnLoad]
	public class PreprocessorDirectivesHandler
	{
		private const char DefineSymbolsSeparatorChar = ';';

		private static readonly string[] DevelopmentValidDefines = {
			/* 0 */ "_DEVELOPMENT_BUILD", // Default
			/* 1 */ "DEVELOPMENT_BUILD",
		};

		private static readonly string[] DemonstrationValidDefines = {
			/* 0 */ "_DEMO_BUILD", // Default
			/* 1 */ "DEMO_BUILD",
		};

		private static readonly string[] LoggingValidDefines = {
			/* 0 */ "_NO_LOGGING", // Default
			/* 1 */ "NO_LOGGING",
		};

		private static readonly string[] RenderPipelineValidDefines = {
			/* 0 */ "UNITY_BRP", // Fallback
			/* 1 */ "UNITY_URP",
			/* 2 */ "UNITY_HDRP",
		};


		private static readonly HashSet<string> CurrentDefinedSymbols = new HashSet<string>();




		#region Listeners


			static PreprocessorDirectivesHandler()
			{
				ValidatePreprocessorDirectives();
			}


		#endregion




		#region Controls


			[MenuItem("Tools/PossumScream/Compilation/Sort Preprocessor Directives alphabetically")]
			public static void SortPreprocessorDirectivesAlphabetically()
			{
				HLogger.LogInfo("Sorting Preprocessor Directives...", typeof(PreprocessorDirectivesHandler));
				{
					string[] currentDefineSymbols = PlayerSettings.GetScriptingDefineSymbolsForGroup(EditorUserBuildSettings.selectedBuildTargetGroup).Split(DefineSymbolsSeparatorChar);


					Array.Sort(currentDefineSymbols);

					PlayerSettings.SetScriptingDefineSymbolsForGroup(EditorUserBuildSettings.selectedBuildTargetGroup, currentDefineSymbols);
				}
				HLogger.LogInfo("Done!", typeof(PreprocessorDirectivesHandler));
			}


			[MenuItem("Tools/PossumScream/Compilation/Validate Preprocessor Directives")]
			public static void ValidatePreprocessorDirectives()
			{
				HLogger.LogInfo("Updating Preprocessor Directives...", typeof(PreprocessorDirectivesHandler));
				{
					bool needDefineRevalidation = false;


					CurrentDefinedSymbols.Clear();
					CurrentDefinedSymbols.AddRange(PlayerSettings.GetScriptingDefineSymbolsForGroup(EditorUserBuildSettings.selectedBuildTargetGroup).Split(DefineSymbolsSeparatorChar));

					{
						setupForAnyValidDefine(DevelopmentValidDefines, ref needDefineRevalidation);
						setupForAnyValidDefine(DemonstrationValidDefines, ref needDefineRevalidation);
						setupForAnyValidDefine(LoggingValidDefines, ref needDefineRevalidation);
						setupRenderPipeline(ref needDefineRevalidation);
					}

					if (needDefineRevalidation) {
						PlayerSettings.SetScriptingDefineSymbolsForGroup(EditorUserBuildSettings.selectedBuildTargetGroup, CurrentDefinedSymbols.ToArray());
					}
				}
				HLogger.LogInfo("Done!", typeof(PreprocessorDirectivesHandler));
			}


		#endregion




		#region Actions


			private static bool checkIfAllCurrentPreprocessorDirectivesAreValid()
			{
				CurrentDefinedSymbols.Clear();
				CurrentDefinedSymbols.AddRange(PlayerSettings.GetScriptingDefineSymbolsForGroup(EditorUserBuildSettings.selectedBuildTargetGroup).Split(DefineSymbolsSeparatorChar));

				{
					if (!CurrentDefinedSymbols.MatchesAny(DevelopmentValidDefines)) return false;
					if (!CurrentDefinedSymbols.MatchesAny(DemonstrationValidDefines)) return false;
					if (!CurrentDefinedSymbols.MatchesAny(LoggingValidDefines)) return false;
					if (!CurrentDefinedSymbols.MatchesAny(RenderPipelineValidDefines)) return false;
				}


				return true;
			}




			private static void setupForAnyValidDefine(string[] validDefines, ref bool needDefineRevalidation)
			{
				if (CurrentDefinedSymbols.Matches(validDefines) != 1) {
					removeEveryOtherDefineButFirst(validDefines);
					needDefineRevalidation = true;
				}
			}


			private static void setupRenderPipeline(ref bool needDefineRevalidation)
			{
				string currentRPPreprocessorDirective = PreprocessorDirectivesHandler.getCurrentRPPreprocessorDirective();


				if (!CurrentDefinedSymbols.Contains(currentRPPreprocessorDirective) ||
				    (CurrentDefinedSymbols.Matches(RenderPipelineValidDefines) != 1)) {
					{
						foreach (string define in RenderPipelineValidDefines) {
							CurrentDefinedSymbols.Remove(define);
						}

						CurrentDefinedSymbols.Add(currentRPPreprocessorDirective);
					}
					needDefineRevalidation = true;
				}
			}




			private static void removeEveryOtherDefineButFirst(string[] validDefines)
			{
				foreach (string define in validDefines) {
					CurrentDefinedSymbols.Remove(define);
				}

				CurrentDefinedSymbols.Add(validDefines[0]);
			}




			private static string getCurrentRPPreprocessorDirective()
			{
				if (GraphicsSettings.currentRenderPipeline is null) return RenderPipelineValidDefines[0];


				switch (GraphicsSettings.currentRenderPipeline.GetType().Name) {

					default: {
						return RenderPipelineValidDefines[0];
					}

					case "UniversalRenderPipelineAsset": {
						return RenderPipelineValidDefines[1];
					}

					case "HDRenderPipelineAsset": {
						return RenderPipelineValidDefines[2];
					}

				}
			}


		#endregion
	}
}


#endif




/*                                                                                            */
/*            ____                                 _____                                      */
/*           / __ \____  ____________  ______ ___ / ___/_____________  ____ _____ ___         */
/*          / /_/ / __ \/ ___/ ___/ / / / __ `__ \\__ \/ ___/ ___/ _ \/ __ `/ __ `__ \        */
/*         / ____/ /_/ (__  |__  ) /_/ / / / / / /__/ / /__/ /  /  __/ /_/ / / / / / /        */
/*        /_/    \____/____/____/\__,_/_/ /_/ /_/____/\___/_/   \___/\__,_/_/ /_/ /_/         */
/*                                                                                            */
/*        Licensed under the Apache License, Version 2.0. See LICENSE.md for more info        */
/*        David Tabernero M. @ PossumScream                      Copyright © 2021-2023        */
/*        https://gitlab.com/possumscream                          All rights reserved        */
/*                                                                                            */
/*                                                                                            */