#if UNITY_EDITOR


using DragonResonance.Logging;
using UnityEditor;
using UnityEngine;




namespace DragonResonance.Editor.Preferences
{
	public static class PreferencesCleaner
	{
		#region Publics


			[MenuItem("Tools/PossumScream/Preferences/Clear all PlayerPrefs")]
			public static void AskClearAllPlayerPrefs()
			{
				if (!ShowClearingDialog("PlayerPrefs")) return;
				HLogger.LogInfo("Clearing all PlayerPrefs...", typeof(PreferencesCleaner));
				PlayerPrefs.DeleteAll();
				HLogger.LogInfo("Done!", typeof(PreferencesCleaner));
			}


			[MenuItem("Tools/PossumScream/Preferences/Clear all EditorPrefs")]
			public static void AskClearAllEditorPrefs()
			{
				if (!ShowClearingDialog("EditorPrefs")) return;
				HLogger.LogInfo("Clearing all EditorPrefs...", typeof(PreferencesCleaner));
				EditorPrefs.DeleteAll();
				HLogger.LogInfo("Done!", typeof(PreferencesCleaner));
			}


		#endregion




		#region Privates


			private static bool ShowClearingDialog(string prefsTypeName)
			{
				return EditorUtility.DisplayDialog($"Clear all {prefsTypeName}?",
					$"Are you COMPLETELY sure you want to clear ALL {prefsTypeName}? THIS CANNOT BE UNDONE.",
					"Yes, clear",
					"No, cancel");
			}


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