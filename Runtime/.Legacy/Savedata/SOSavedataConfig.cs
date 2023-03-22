using NaughtyAttributes;
using System.IO;
using System.Text;
using System;
using UnityEngine;




namespace PossumScream.CoolComponents.Savedata
{
	[CreateAssetMenu(menuName = "PossumScream/Components/Savedata Config File", fileName = "New SavedataConfig")]
	public class SOSavedataConfig : ScriptableObject
	{
		[Header("Profile")]
		[SerializeField] private EStorage _storage = default;


		[Header("Path")]
		[InfoBox(@"System EnvVars:
%desktop% -> The User Desktop
%home% -> The User Profile
%local% -> The User Local Directory
%roaming% -> The User Roaming Directory

Application EnvVars:
%company% -> The Application Company
%product% -> The Application Name")]
		[ShowIf("_storage", EStorage.SaveFile)] [SerializeField] private string _saveFileDirectory = "%local%/%company%/%product%/";
		[ShowIf("_storage", EStorage.SaveFile)] [SerializeField] private string _saveFileName = "data.sav";




		#region Actions


			private string interpretPath(string path)
			{
				string[][] PATH_ENVVARS =
				{
					new[] { "%company%", Application.companyName },
					new[] { "%desktop%", Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) },
					new[] { "%home%", Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) },
					new[] { "%local%", Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) },
					new[] { "%product%", Application.productName },
					new[] { "%roaming%", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) },
				};

				string interpretedPath = path;


				foreach (string[] envVarPair in PATH_ENVVARS) {
					interpretedPath = interpretedPath.Replace(envVarPair[0], envVarPair[1]);
				}


				return interpretedPath;
			}




			[Button("Log ToString", EButtonEnableMode.Always)]
			private void logParameters()
			{
				Debug.Log(ToString());
			}


		#endregion




		#region Properties


			public string saveFileDirectory => Path.GetFullPath(interpretPath(this._saveFileDirectory));
			public string saveFileFullPath => Path.GetFullPath(string.Concat(interpretPath(this._saveFileDirectory), '/', this._saveFileName));


		#endregion




		#region Getters and Setters


			public EStorage storage => this._storage;
			public string saveFileName => this._saveFileName;


		#endregion




		#region Overrides


			public override string ToString()
			{
				StringBuilder toStringOutput = new StringBuilder();


				{
					toStringOutput.AppendLine($"Storage:    {this._storage}");

					if (this._storage is EStorage.SaveFile) {
						toStringOutput.AppendLine($"FullPath:   {this.saveFileFullPath}");
					}
				}


				return toStringOutput.ToString();
			}


		#endregion
	}
}




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