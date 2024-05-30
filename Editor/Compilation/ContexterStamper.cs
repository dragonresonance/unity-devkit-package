#if UNITY_EDITOR && ENABLE_CONTEXTER


using System.Diagnostics;
using System;
using UnityEditor.Build.Reporting;
using UnityEditor.Build;
using UnityEditor;
using UnityEngine;




namespace PossumScream.Editor.Compilation
{
	public class BuildingDataStamper : IPreprocessBuildWithReport
	{
		private const string APP_FULL_VERSION_KEY = "application_fullversion";
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


			public static string FormatTimestampDatetime() => $"{DateTimeOffset.UtcNow:yyMMddHH}";


			[MenuItem("Tools/PossumScream/Build/Stamp Contexter Data")]
			public static void StampBuildingData()
			{
				ExecuteContexterSetter(APP_FULL_VERSION_KEY, $"{Application.version}.{FormatTimestampDatetime()}");
				ExecuteContexterSetter(APP_NAME_KEY, Application.productName);
				ExecuteContexterSetter(APP_VERSION_KEY, Application.version);
				ExecuteContexterSetter(BUILD_DATETIME_KEY, $"{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}");
				ExecuteContexterSetter(BUILD_TIMESTAMP_KEY, FormatTimestampDatetime());
				ExecuteContexterSetter(COMPANY_NAME_KEY, Application.companyName);
				ExecuteContexterSetter(ENGINE_NAME_KEY, "Unity");
				ExecuteContexterSetter(ENGINE_VERSION_KEY, Application.unityVersion);
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


			public int callbackOrder => 0;


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