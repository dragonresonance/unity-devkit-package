#if UNITY_EDITOR


using PossumScream.Enhancements;
using PossumScream.Extensions;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;




namespace PossumScream.Editor.Compilation
{
	[InitializeOnLoad]
	public partial class BuildDefinitionsHandler
	{
		private const char DefinitionsSeparatorChar = ';';


		private static readonly SortedSet<string> m_currentDefinitions = new();




		#region Delegates


			private delegate void HandlerAction();

			private static event HandlerAction d_setChecking;


		#endregion




		#region Listeners


			static BuildDefinitionsHandler()
			{
				d_setChecking += checkBuildTypeDefinitions;
				d_setChecking += checkIntegrationDefinitions;
				d_setChecking += checkLoggingDefinitions;
				d_setChecking += checkRenderPipelineDefinitions;

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
					m_currentDefinitions.AddRange(GetBuildTargetDefinitions());

					d_setChecking?.Invoke();

					SetBuildTargetDefinitions(m_currentDefinitions.ToArray());
				}
				HLogger.LogInfo("Done!", typeof(BuildDefinitionsHandler));
			}




			public static void AddBuildTargetDefinition(string definition)
			{
				AddBuildTargetDefinition(new[] { definition });
			}


			public static void AddBuildTargetDefinition(IEnumerable<string> definitions)
			{
				m_currentDefinitions.Clear();
				m_currentDefinitions.AddRange(GetBuildTargetDefinitions());

				foreach (string definition in definitions) {
					m_currentDefinitions.Add(definition);
				}

				SetBuildTargetDefinitions(m_currentDefinitions.ToArray());
			}




			public static void RemoveBuildTargetDefinition(string definition)
			{
				RemoveBuildTargetDefinition(new[] { definition });
			}


			public static void RemoveBuildTargetDefinition(IEnumerable<string> definitions)
			{
				m_currentDefinitions.Clear();
				m_currentDefinitions.AddRange(GetBuildTargetDefinitions());

				foreach (string definition in definitions) {
					m_currentDefinitions.Remove(definition);
				}

				SetBuildTargetDefinitions(m_currentDefinitions.ToArray());
			}




			public static IEnumerable<string> GetBuildTargetDefinitions()
			{
				return PlayerSettings.GetScriptingDefineSymbolsForGroup(EditorUserBuildSettings.selectedBuildTargetGroup).Split(DefinitionsSeparatorChar);
			}


			public static void SetBuildTargetDefinitions(IEnumerable<string> definitions)
			{
				SetBuildTargetDefinitions(definitions.ToArray());
			}


			public static void SetBuildTargetDefinitions(string[] definitions)
			{
				PlayerSettings.SetScriptingDefineSymbolsForGroup(EditorUserBuildSettings.selectedBuildTargetGroup, definitions);
			}


		#endregion




		#region Actions


			private static void checkAndReplenishDefinitionFromList(IReadOnlyList<string> definitions, int fallbackDefinitionIndex = 0)
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
				m_currentDefinitions.AddRange(GetBuildTargetDefinitions());

				foreach (string definition in definitions) {
					m_currentDefinitions.Remove(definition);
				}

				m_currentDefinitions.Add(forcedDefinition);

				SetBuildTargetDefinitions(m_currentDefinitions.ToArray());
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