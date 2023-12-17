#if UNITY_EDITOR && !DISABLE_CONTEXTER


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
		private const string CONTEXTER_APPLICATIONNAME_KEY = "application_name";
		private const string CONTEXTER_APPLICATIONVERSION_KEY = "application_version";
		private const string CONTEXTER_COMPANYNAME_KEY = "company_name";
		private const string CONTEXTER_ENGINENAME_KEY = "engine_name";
		private const string CONTEXTER_ENGINEVERSION_KEY = "engine_version";
		private const string CONTEXTER_COMPILATIONTIMESTAMP_KEY = "compilation_timestamp";




		#region Events


			public void OnPreprocessBuild(BuildReport report)
			{
				StampBuildingData();
			}


		#endregion




		#region Publics


			[MenuItem("Tools/PossumScream/Compilation/Stamp Building Data")]
			public static void StampBuildingData()
			{
				ExecuteContexterSetter(CONTEXTER_APPLICATIONNAME_KEY, Application.productName);
				ExecuteContexterSetter(CONTEXTER_APPLICATIONVERSION_KEY, Application.version);
				ExecuteContexterSetter(CONTEXTER_COMPANYNAME_KEY, Application.companyName);
				ExecuteContexterSetter(CONTEXTER_ENGINENAME_KEY, "Unity");
				ExecuteContexterSetter(CONTEXTER_ENGINEVERSION_KEY, Application.unityVersion);
				ExecuteContexterSetter(CONTEXTER_COMPILATIONTIMESTAMP_KEY, $"{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}");
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