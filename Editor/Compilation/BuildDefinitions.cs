#if UNITY_EDITOR


using PossumScream.Enhancements;
using PossumScream.Extensions;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;




namespace PossumScream.Editor.Compilation
{
	[InitializeOnLoad]
	public partial class BuildDefinitions
	{
		private const char DEFINITIONS_SEPARATOR = ';';
		private static readonly List<string> _currentDefinitions = new();




		#region Constructors


			static BuildDefinitions()
			{
				OrganizeBuildDefinitions();
			}


		#endregion




		#region Publics


			[MenuItem("Tools/PossumScream/Compilation/Organize Build Definitions")]
			public static void OrganizeBuildDefinitions()
			{
				HLogger.Log("Organizing Build Definitions...", typeof(BuildDefinitions));
				{
					_currentDefinitions.Clear();
					_currentDefinitions.AddRange(BuildDefinitions.definitions);

					{
						ReplenishDefinitionSet(DemonstrationValidDefinitions);
						ReplenishDefinitionSet(LoggingValidDefinitions);

						ReplenishDefinitionSet(ContexterIntegrationValidDefinitions);

						#if STEAMWORKS_INTEGRATION
							ReplenishDefinitionSet(SteamworksIntegrationValidDefinitions);
						#endif

						#if EOS_INTEGRATION
							ReplenishDefinitionSet(EOSIntegrationValidDefinitions);
						#endif
					}

					ApplyDefinitions(new SortedSet<string>(_currentDefinitions));
				}
				HLogger.Log("Done!", typeof(BuildDefinitions));
			}




			public static void ApplyDefinitions(IEnumerable<string> definitionList)
			{
				ApplyDefinitions(definitionList.ToArray());
			}


			public static void ApplyDefinitions(string[] definitionList)
			{
				PlayerSettings.SetScriptingDefineSymbolsForGroup(
					EditorUserBuildSettings.selectedBuildTargetGroup,
					definitionList);
			}


		#endregion




		#region Privates


			private static void ReplenishDefinitionSet(IReadOnlyList<string> definitionSet, int fallbackIndex = 0)
			{
				if (definitionSet.Count == 0) return;
				int validSetDefinitionIndex = definitionSet.IndexOf(_currentDefinitions);
				_currentDefinitions.RemoveAll(definitionSet.Contains);
				_currentDefinitions.Add((validSetDefinitionIndex != -1) ? definitionSet[validSetDefinitionIndex] : definitionSet[fallbackIndex]);
			}


		#endregion




		#region Properties


			public static IEnumerable<string> definitions => PlayerSettings
				.GetScriptingDefineSymbolsForGroup(EditorUserBuildSettings.selectedBuildTargetGroup)
				.Split(DEFINITIONS_SEPARATOR);


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
/*        David Tabernero M. @ PossumScream                      Copyright © 2021-2024        */
/*        GitLab - GitHub: possumscream                            All rights reserved        */
/*        - - - - - - - - - - - - -                                  - - - - - - - - -        */
/*                                                                                            */