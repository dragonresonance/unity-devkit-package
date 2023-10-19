#if UNITY_EDITOR


using PossumScream.Enhancements;
using PossumScream.Extensions;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;




namespace PossumScream.Editor.Compilation
{
	[InitializeOnLoad]
	public partial class BuildDefinitionsHandler
	{
		private const char DEFINITIONS_SEPARATOR = ';';


		private static readonly List<string> m_currentDefinitions = new();




		#region Delegates


			private delegate void HandlerAction();
			private static event HandlerAction d_setChecking;


		#endregion




		#region Listeners


			static BuildDefinitionsHandler()
			{
				d_setChecking += CheckBuildTypeDefinitions;
				d_setChecking += CheckIntegrationDefinitions;
				d_setChecking += CheckLoggingDefinitions;
				OrganizeBuildDefinitions();
			}


		#endregion




		#region Controls


			[MenuItem("Tools/PossumScream/Compilation/Organize Build Definitions")]
			public static void OrganizeBuildDefinitions()
			{
				HLogger.LogInfo("Organizing Build Definitions...", typeof(BuildDefinitionsHandler));
				{
					m_currentDefinitions.Clear();
					m_currentDefinitions.AddRange(BuildDefinitionsHandler.definitions);

					d_setChecking?.Invoke();

					SetDefinitions(m_currentDefinitions.ToArray());
				}
				HLogger.LogInfo("Done!", typeof(BuildDefinitionsHandler));
			}




			public static void AddDefinitions(string definition)
			{
				AddDefinitions(new[] { definition });
			}


			public static void AddDefinitions(IEnumerable<string> definitions)
			{
				m_currentDefinitions.Clear();
				m_currentDefinitions.AddRange(BuildDefinitionsHandler.definitions);

				foreach (string definition in definitions) {
					m_currentDefinitions.Add(definition);
				}

				SetDefinitions(new SortedSet<string>(m_currentDefinitions));
			}




			public static void RemoveDefinitions(string definition)
			{
				RemoveDefinitions(new[] { definition });
			}


			public static void RemoveDefinitions(IEnumerable<string> definitions)
			{
				m_currentDefinitions.Clear();
				m_currentDefinitions.AddRange(BuildDefinitionsHandler.definitions);

				foreach (string definition in definitions) {
					m_currentDefinitions.Remove(definition);
				}

				SetDefinitions(new SortedSet<string>(m_currentDefinitions));
			}




			public static void SetDefinitions(IEnumerable<string> definitions)
			{
				SetDefinitions(definitions.ToArray());
			}


			public static void SetDefinitions(string[] definitions)
			{
				PlayerSettings.SetScriptingDefineSymbolsForGroup(EditorUserBuildSettings.selectedBuildTargetGroup, definitions);
			}


		#endregion




		#region Actions


			private static void CheckAndReplenishDefinitions(IReadOnlyList<string> definitions, int fallbackDefinitionIndex = 0)
			{
				if (!m_currentDefinitions.MatchesAny(definitions)) {
					m_currentDefinitions.Add(definitions[fallbackDefinitionIndex]);
				}
			}


			private static void forceDefinitionFromList(IReadOnlyList<string> definitions, int definitionIndex)
			{
				forceDefinitionFromList(definitions, definitions[definitionIndex]);
			}


			private static void forceDefinitionFromList(IReadOnlyList<string> definitions, string forcedDefinition)
			{
				m_currentDefinitions.Clear();
				m_currentDefinitions.AddRange(BuildDefinitionsHandler.definitions);

				foreach (string definition in definitions) {
					m_currentDefinitions.Remove(definition);
				}

				m_currentDefinitions.Add(forcedDefinition);

				SetDefinitions(m_currentDefinitions.ToArray());
			}


		#endregion




		#region Properties


			public static IEnumerable<string> definitions => PlayerSettings.GetScriptingDefineSymbolsForGroup(EditorUserBuildSettings.selectedBuildTargetGroup).Split(DEFINITIONS_SEPARATOR);


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