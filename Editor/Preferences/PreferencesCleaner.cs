#if UNITY_EDITOR


using PossumScream.Enhancements;
using UnityEditor;
using UnityEngine;




namespace PossumScream.Editor.Preferences
{
	public static class PreferencesCleaner
	{
		#region Controls


			[MenuItem("Tools/PossumScream/Preferences/Clear all PlayerPrefs")]
			public static void ClearAllPlayerPrefs()
			{
				if (displayClearingDialog("PlayerPrefs")) {
					HLogger.LogInfo("Clearing all PlayerPrefs...", typeof(PreferencesCleaner));
					{
						PlayerPrefs.DeleteAll();
					}
					HLogger.LogInfo("Done!", typeof(PreferencesCleaner));
				}
			}


			[MenuItem("Tools/PossumScream/Preferences/Clear all EditorPrefs")]
			public static void ClearAllEditorPrefs()
			{
				if (displayClearingDialog("EditorPrefs")) {
					HLogger.LogInfo("Clearing all EditorPrefs...", typeof(PreferencesCleaner));
					{
						EditorPrefs.DeleteAll();
					}
					HLogger.LogInfo("Done!", typeof(PreferencesCleaner));
				}
			}


		#endregion




		#region Actions


			private static bool displayClearingDialog(string prefsTypeName)
			{
				return EditorUtility.DisplayDialog($"Clear all {prefsTypeName}?", $"Are you COMPLETELY sure you want to clear ALL {prefsTypeName}? This CANNOT BE UNDONE.", "Yes, clear", "No, cancel");
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