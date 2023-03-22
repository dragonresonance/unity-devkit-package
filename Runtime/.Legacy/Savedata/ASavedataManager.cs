using NaughtyAttributes;
using PossumScream.BlazingBehaviours;
using PossumScream.SickScripts.PlayerPreferences;
using SimpleJSON;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System;
using UnityEngine;


#if UNITY_EDITOR
using UnityEditor;
#endif




namespace PossumScream.CoolComponents.Savedata
{
	public abstract class ASavedataManager<T> : ScriptableOptableSingleton<T> where T : Component
	{
		[Header("Behaviour")]
		/* 0 */ [SerializeField] private bool _loadOnAwake = true;
		/* 1 */ [SerializeField] private bool _alwaysPerformSaveAfterReset = false;


		[Header("Formatting")]
		[SerializeField] protected string _prefix = "";
		[SerializeField] protected string _suffix = "";


		[Header("Platform-Specific Configuration Profile")]
		[Required] [Expandable] [SerializeField] [Label("General")] private SOSavedataConfig _savedataConfig_general = null;

		#pragma warning disable 0414
		[Expandable] [SerializeField] [Label("Android Override")] private SOSavedataConfig _savedataConfig_androidOverride = null;
		[Expandable] [SerializeField] [Label("Linux Override")] private SOSavedataConfig _savedataConfig_linuxOverride = null;
		[Expandable] [SerializeField] [Label("Mac OSX Override")] private SOSavedataConfig _savedataConfig_osxOverride = null;
		[Expandable] [SerializeField] [Label("PlayStation 4 Override")] private SOSavedataConfig _savedataConfig_ps4Override = null;
		[Expandable] [SerializeField] [Label("PlayStation 5 Override")] private SOSavedataConfig _savedataConfig_ps5Override = null;
		[Expandable] [SerializeField] [Label("Switch Override")] private SOSavedataConfig _savedataConfig_switchOverride = null;
		[Expandable] [SerializeField] [Label("WebGL Override")] private SOSavedataConfig _savedataConfig_webglOverride = null;
		[Expandable] [SerializeField] [Label("Windows Override")] private SOSavedataConfig _savedataConfig_windowsOverride = null;
		[Expandable] [SerializeField] [Label("Xbox One Override")] private SOSavedataConfig _savedataConfig_xoneOverride = null;
		[Expandable] [SerializeField] [Label("Xbox Series Override")] private SOSavedataConfig _savedataConfig_xseriesOverride = null;
		[Expandable] [SerializeField] [Label("iOS Override")] private SOSavedataConfig _savedataConfig_iosOverride = null;
		#pragma warning restore 0414


		[Header("Savedatas")]
		[SerializeField] protected SSavedataGroup[] _savedataGroups = null;




		[ShowNonSerializedField] private SOSavedataConfig _currentPlatformSavedataConfig = null;
		[ShowNonSerializedField] private int _timesLoaded = 0;
		[ShowNonSerializedField] private int _timesSaved = 0;
		private HashSet<string> _cachedSavedataUids = new HashSet<string>();
		protected JSONObject _dataTree = new JSONObject();




		#region Events


			protected override void LateAwake()
			{
				cacheEverything();

				if (this._loadOnAwake) {
					performFullLoad();
				}
			}


			private void OnValidate()
			{
				this._prefix = this._prefix.Trim().ToUpper();
				this._suffix = this._suffix.Trim().ToUpper();
			}


		#endregion




		#region Controls


			[Button("Perform Full Load", EButtonEnableMode.Always)]
			public void performFullLoad()
			{
				cacheEverything();
				loadSmartFromSource();
				saveToSavedatas();

				this._timesLoaded++;
			}


			[Button("Perform Full Save", EButtonEnableMode.Always)]
			public void performFullSave()
			{
				loadFromSavedatas();
				saveSmartToSource();

				this._timesSaved++;
			}




			[Button("Perform Quick Reset", EButtonEnableMode.Always)]
			public void performQuickReset()
			{
				resetSavedatas();
				loadFromSavedatas();
			}


			[Button("Perform Full Reset", EButtonEnableMode.Always)]
			public void performFullReset()
			{
				performQuickReset();
				saveSmartToSource();
			}


		#endregion




		#region Actions: Caching


			[Button("DEBUG: Cache everything", EButtonEnableMode.Always)]
			private void cacheEverything()
			{
				cacheCurrentPlatformSavedataConfig();
				cacheSavedataUidArray();
			}




			[Button("DEBUG: Cache current platform SavedataConfig", EButtonEnableMode.Always)]
			private void cacheCurrentPlatformSavedataConfig()
			{
				#if UNITY_STANDALONE_WIN
					this._currentPlatformSavedataConfig = (this._savedataConfig_windowsOverride != null) ? this._savedataConfig_windowsOverride : this._savedataConfig_general;
				#elif UNITY_STANDALONE_LINUX
					this._currentPlatformSavedataConfig = (this._savedataConfig_linuxOverride != null) ? this._savedataConfig_linuxOverride : this._savedataConfig_general;
				#elif UNITY_STANDALONE_OSX
					this._currentPlatformSavedataConfig = (this._savedataConfig_osxOverride != null) ? this._savedataConfig_osxOverride : this._savedataConfig_general;
				#elif UNITY_WEBGL
					this._currentPlatformSavedataConfig = (this._savedataConfig_webglOverride != null) ? this._savedataConfig_webglOverride : this._savedataConfig_general;
				#elif UNITY_PS4
					this._currentPlatformSavedataConfig = (this._savedataConfig_ps4Override != null) ? this._savedataConfig_ps4Override : this._savedataConfig_general;
				#elif UNITY_PS5
					this._currentPlatformSavedataConfig = (this._savedataConfig_ps5Override != null) ? this._savedataConfig_ps5Override : this._savedataConfig_general;
				#elif UNITY_XBOXONE
					this._currentPlatformSavedataConfig = (this._savedataConfig_xoneOverride != null) ? this._savedataConfig_xoneOverride : this._savedataConfig_general;
				#elif UNITY_XBOXSERIES
					this._currentPlatformSavedataConfig = (this._savedataConfig_xseriesOverride != null) ? this._savedataConfig_xseriesOverride : this._savedataConfig_general;
				#elif UNITY_SWITCH
					this._currentPlatformSavedataConfig = (this._savedataConfig_switchOverride != null) ? this._savedataConfig_switchOverride : this._savedataConfig_general;
				#elif UNITY_ANDROID
					this._currentPlatformSavedataConfig = (this._savedataConfig_androidOverride != null) ? this._savedataConfig_androidOverride : this._savedataConfig_general;
				#elif UNITY_IOS
					this._currentPlatformSavedataConfig = (this._savedataConfig_iosOverride != null) ? this._savedataConfig_iosOverride : this._savedataConfig_general;
				#else
					this._currentPlatformSavedataConfig = this._savedataConfig_general;
				#endif
			}


			[Button("DEBUG: Cache savedata key array", EButtonEnableMode.Always)]
			private void cacheSavedataUidArray()
			{
				this._cachedSavedataUids.Clear();

				foreach (SSavedataGroup savedataGroup in this._savedataGroups) {
					foreach (ASavedataScriptableObject savedata in savedataGroup.savedatas) {
						this._cachedSavedataUids.Add(formatConcatenatedUid(savedata.uid));
					}
				}
			}


		#endregion




		#region Actions: Savedata Management


			[Button("DEBUG: Load from savedatas", EButtonEnableMode.Always)]
			private void loadFromSavedatas()
			{
				base.logInfo("Loading from savedatas...", this);
				{
					this._dataTree.Clear();

					foreach (SSavedataGroup savedataGroup in this._savedataGroups) {
						foreach (ASavedataScriptableObject savedata in savedataGroup.savedatas) {
							savedata.exportData(out JSONObject dataObject);
							this._dataTree.Add(formatConcatenatedUid(savedata.uid), dataObject);
						}
					}
				}
			}


			[Button("DEBUG: Save to savedatas", EButtonEnableMode.Always)]
			private void saveToSavedatas()
			{
				base.logInfo("Saving to savedatas...", this);
				{
					foreach (SSavedataGroup savedataGroup in this._savedataGroups) {
						foreach (ASavedataScriptableObject savedata in savedataGroup.savedatas) {
							if (this._dataTree[formatConcatenatedUid(savedata.uid)] is JSONObject dataObject) {
								savedata.importData(dataObject);
							}
						}
					}
				}
			}


			[Button("DEBUG: Reset savedatas", EButtonEnableMode.Always)]
			private void resetSavedatas(bool performSaveAfterReset = false)
			{
				base.logInfo("Resetting savedatas...", this);
				{
					foreach (SSavedataGroup savedataGroup in this._savedataGroups) {
						foreach (ASavedataScriptableObject savedata in savedataGroup.savedatas) {
							savedata.resetValue();

							#if UNITY_EDITOR
								EditorUtility.SetDirty(savedata);
							#endif
						}
					}
				}
				{
					if (performSaveAfterReset || this._alwaysPerformSaveAfterReset) {
						performFullSave();
					}
				}
			}


		#endregion




		#region Actions: Source Management


			[Button("DEBUG: Load smart from Source", EButtonEnableMode.Always)]
			private void loadSmartFromSource()
			{
				switch (this._currentPlatformSavedataConfig.storage) {

					case EStorage.PlayerPrefs: {
						loadFromPlayerPrefs();
					} break;

					case EStorage.SaveFile: {
						if (prepareSaveFile()) {
							loadFromSaveFile();
						}
					} break;

				}
			}


			[Button("DEBUG: Save smart to Source", EButtonEnableMode.Always)]
			private void saveSmartToSource()
			{
				switch (this._currentPlatformSavedataConfig.storage) {

					case EStorage.PlayerPrefs: {
						saveToPlayerPrefs();
					} break;

					case EStorage.SaveFile: {
						saveToSaveFile();
					} break;

				}
			}




			[Button("DEBUG: Load from source: PlayerPrefs", EButtonEnableMode.Always)]
			private void loadFromPlayerPrefs()
			{
				base.logInfo("Loading from PlayerPrefs...", this);
				{
					this._dataTree.Clear();

					foreach (string uid in this._cachedSavedataUids) {
						this._dataTree.Add(uid, JSON.Parse(PlayerPrefsX.getStringEntry(uid)));
					}
				}
			}


			[Button("DEBUG: Save to source: PlayerPrefs", EButtonEnableMode.Always)]
			private void saveToPlayerPrefs()
			{
				base.logInfo("Saving to PlayerPrefs...", this);
				{
					foreach (KeyValuePair<string,JSONNode> dataEntry in this._dataTree) {
						PlayerPrefsX.setStringEntry(dataEntry.Key, dataEntry.Value.ToString());
					}
				}
			}


			[Button("DEBUG: Purge source: PlayerPrefs", EButtonEnableMode.Always)]
			private void purgePlayerPrefs()
			{
				base.logInfo("Purging PlayerPrefs...", this);
				{
					PlayerPrefsX.deleteAll();
				}
			}




			[Button("DEBUG: Prepare source: SaveFile", EButtonEnableMode.Always)]
			private bool prepareSaveFile()
			{
				base.logInfo("Preparing SaveFile...", this);
				{
					try {
						if (!File.Exists(this._currentPlatformSavedataConfig.saveFileFullPath)) {
							Directory.CreateDirectory(this._currentPlatformSavedataConfig.saveFileDirectory);

							using (StreamWriter streamWriter = File.CreateText(this._currentPlatformSavedataConfig.saveFileFullPath)) {
								streamWriter.Write("{}");
							}
						}


						return true;
					}
					catch (Exception e) {
						base.logException(e);
						return false;
					}
				}
			}


			[Button("DEBUG: Load from source: SaveFile", EButtonEnableMode.Always)]
			private void loadFromSaveFile()
			{
				base.logInfo("Loading from SaveFile...", this);
				{
					try {
						JSONNode jsonData = JSON.Parse(File.ReadAllText(this._currentPlatformSavedataConfig.saveFileFullPath, Encoding.UTF8));


						if (jsonData is JSONObject jsonObject) {
							this._dataTree = jsonObject;
						}
						else {
							throw new Exception("Parsed JSON is not a valid JSON Object.");
						}
					}
					catch (Exception e) {
						base.logException(e);
					}
				}
			}


			[Button("DEBUG: Save to source: SaveFile", EButtonEnableMode.Always)]
			private void saveToSaveFile()
			{
				base.logInfo("Saving to SaveFile...", this);
				{
					File.WriteAllText(this._currentPlatformSavedataConfig.saveFileFullPath, this._dataTree.ToString(), Encoding.UTF8);
				}
			}


			[Button("DEBUG: Purge source: SaveFile", EButtonEnableMode.Always)]
			private void purgeSaveFile()
			{
				base.logInfo("Purging SaveFile...", this);
				{
					File.Delete(this._currentPlatformSavedataConfig.saveFileFullPath);
				}
			}


		#endregion




		#region Actions: Other


			private string formatConcatenatedUid(string uid)
			{
				return string.Concat(this._prefix, uid, this._suffix);
			}


			[Button("DEBUG: Log DataTree")]
			private void logDataTree()
			{
				base.log(this._dataTree.ToString());
			}


		#endregion




		#region Properties


			public bool hasBeenLoaded => (this._timesLoaded != 0);
			public bool hasBeenSaved => (this._timesSaved != 0);


		#endregion




		#region Getters and Setters


			public SOSavedataConfig currentPlatformSavedataConfig => this._currentPlatformSavedataConfig;
			public bool isLoadingOnAwake => this._loadOnAwake;
			public bool isSavingSavedatasAfterResetting => this._alwaysPerformSaveAfterReset;
			public int timesLoaded => this._timesLoaded;
			public int timesSaved => this._timesSaved;


			public string prefix
			{
				get => this._prefix;
				set => this._prefix = value;
			}


			public string suffix
			{
				get => this._suffix;
				set => this._suffix = value;
			}


		#endregion




		#region Structs and Enums


			[Serializable]
			protected struct SSavedataGroup
			{
				public string label;

				public ASavedataScriptableObject[] savedatas;
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