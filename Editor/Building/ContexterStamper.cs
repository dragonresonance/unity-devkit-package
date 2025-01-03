#if UNITY_EDITOR && ENABLE_CONTEXTER


using DragonResonance.Logging;
using System.Diagnostics;
using System;
using UnityEditor.Build.Reporting;
using UnityEditor.Build;
using UnityEditor;
using UnityEngine;




namespace DragonResonance.Editor.Building
{
	public class ContexterStamper : IPreprocessBuildWithReport
	{
		private const string APP_NAME_KEY = "application_name";
		private const string APP_VERSION_KEY = "application_version";
		private const string BUILD_DATETIME_KEY = "build_datetime";
		private const string BUILD_TIMESTAMP_KEY = "build_timestamp";
		private const string COMPANY_NAME_KEY = "company_name";
		private const string ENGINE_NAME_KEY = "engine_name";
		private const string ENGINE_VERSION_KEY = "engine_version";




		#region Events


			public void OnPreprocessBuild(BuildReport report)
			{
				StampBuildingData();
			}


		#endregion




		#region Publics


			public static string GetFormattedTimestampDatetime() => $"{DateTimeOffset.UtcNow:yyMMddHHmmss}";


			[MenuItem("Tools/Dragon Resonance/Building/Stamp Contexter Data")]
			public static void StampBuildingData()
			{
				HLogger.Log($"{nameof(StampBuildingData)} to the Contexter database...", typeof(ContexterStamper));
				{
					ExecuteContexterSetter(APP_NAME_KEY, Application.productName);
					ExecuteContexterSetter(APP_VERSION_KEY, Application.version);
					ExecuteContexterSetter(BUILD_DATETIME_KEY, $"{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}");
					ExecuteContexterSetter(BUILD_TIMESTAMP_KEY, GetFormattedTimestampDatetime());
					ExecuteContexterSetter(COMPANY_NAME_KEY, Application.companyName);
					ExecuteContexterSetter(ENGINE_NAME_KEY, "Unity");
					ExecuteContexterSetter(ENGINE_VERSION_KEY, Application.unityVersion);
				}
				HLogger.Log("Done!", typeof(ContexterStamper));
			}


		#endregion




		#region Privates


			private static void ExecuteContexterSetter(string key, string value)
			{
				ExecuteContexterCommand(new [] {
					"SET", $"\"{key}\"", $"\"{value}\""
				});
			}


			private static void ExecuteContexterCommand(string[] command)
			{
				Process contexter = new();

				contexter.StartInfo.FileName = "contexter";
				contexter.StartInfo.Arguments = string.Join(" ", command);

				contexter.StartInfo.CreateNoWindow = true;
				//contexter.StartInfo.RedirectStandardOutput = true;
				contexter.StartInfo.UseShellExecute = false;

				contexter.Start();
				contexter.WaitForExit();

				//HLogger.Log(contexter.StandardOutput.ReadToEnd());
			}


		#endregion




		#region Properties


			public int callbackOrder => 0; // Implicit override


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
/*                  Copyright © 2021-2025. All rights reserved.                 */
/*                Licensed under the Apache License, Version 2.0.               */
/*                         See LICENSE.md for more info.                        */
/*       ________________________________________________________________       */
/*                                                                              */