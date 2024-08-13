#if UNITY_EDITOR


using DragonResonance.Extensions;
using DragonResonance.Logging;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Build;
using UnityEditor;




namespace DragonResonance.Editor.Building
{
	[InitializeOnLoad]
	public partial class BuildDefines
	{
		private const char DEFINITIONS_SEPARATOR = ';';
		private static readonly List<string> _currentDefinitions = new();




		#region Constructors


			static BuildDefines() => OrganizeBuildDefinitions();


		#endregion




		#region Publics


			[MenuItem("Tools/PossumScream/Compilation/Organize Build Definitions")]
			public static void OrganizeBuildDefinitions()
			{
				HLogger.Log("Organizing Build Definitions...", typeof(BuildDefines));
				{
					_currentDefinitions.Clear();
					_currentDefinitions.AddRange(BuildDefines.Values);

					{
						ReplenishDefinitions(DemonstrationValidDefinitions);
						ReplenishDefinitions(LoggingValidDefinitions);

						ReplenishDefinitions(ContexterIntegrationValidDefinitions);

						#if STEAMWORKS_INTEGRATION
							ReplenishDefinitions(SteamworksIntegrationValidDefinitions);
						#endif

						#if EOS_INTEGRATION
							ReplenishDefinitions(EOSIntegrationValidDefinitions);
						#endif
					}

					ApplyDefinitions(new SortedSet<string>(_currentDefinitions));
				}
				HLogger.Log("Done!", typeof(BuildDefines));
			}


			public static void ApplyDefinitions(IEnumerable<string> definitions)
			{
				ApplyDefinitions(definitions.ToArray());
			}

			public static void ApplyDefinitions(string[] definitions)
			{
				PlayerSettings.SetScriptingDefineSymbols(
					NamedBuildTarget.FromBuildTargetGroup(EditorUserBuildSettings.selectedBuildTargetGroup),
					definitions);
			}


		#endregion




		#region Privates


			private static void ReplenishDefinitions(IReadOnlyList<string> definitions, int fallbackIndex = 0)
			{
				if (definitions.Count == 0) return;
				int validSetDefinitionIndex = definitions.IndexOf(_currentDefinitions);
				_currentDefinitions.RemoveAll(definitions.Contains);
				_currentDefinitions.Add((validSetDefinitionIndex != -1) ?
					definitions[validSetDefinitionIndex] :
					definitions[fallbackIndex]);
			}


		#endregion




		#region Properties


			public static IEnumerable<string> Values => PlayerSettings
				.GetScriptingDefineSymbols(
					NamedBuildTarget.FromBuildTargetGroup(EditorUserBuildSettings.selectedBuildTargetGroup))
				.Split(DEFINITIONS_SEPARATOR);


		#endregion
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