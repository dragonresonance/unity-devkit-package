using NaughtyAttributes;
using PossumScream.BlazingBehaviours;
using PossumScream.CoolComponents.Savedata;
using PossumScream.SickScripts.Calculations;
using UnityEngine.Audio;
using UnityEngine;


#if USING_UNITY_URP
using UnityEngine.Rendering.Universal;
#elif USING_UNITY_HDRP
using UnityEngine.Rendering.HighDefinition;
#endif




namespace PossumScream.CoolComponents.Settings
{
	public class SettingsManager : ScriptablePersistentSingleton<SettingsManager>
	{
		[Header("Components")]
		[Required] [SerializeField] private AudioMixer _audioMixer = null;


		#pragma warning disable 0414


		[Header("Graphics")]

		[SerializeField] [Label("Quality Level")] private bool _enableQualityLevel = true;
		[ShowIf("_enableQualityLevel")] [Required] [SerializeField] [Label("Quality Level Savedata")] private SOIntegerSavedata _graphicsSavedata_qualityLevel = null;

		[SerializeField] [Label("Custom Resolution")] private bool _enableCustomResolution = true;
		/* 0 */ [ShowIf("_enableCustomResolution")] [Required] [SerializeField] [Label("Custom Resolution Savedata")] private SOBooleanSavedata _graphicsSavedata_customResolution = null;
		/* 1 */ [ShowIf("_enableCustomResolution")] [Required] [SerializeField] [Label("Resolution Width Savedata")] private SOIntegerSavedata _graphicsSavedata_resolutionWidth = null;
		/* 2 */ [ShowIf("_enableCustomResolution")] [Required] [SerializeField] [Label("Resolution Height Savedata")] private SOIntegerSavedata _graphicsSavedata_resolutionHeight = null;
		/* 3 */ [ShowIf("_enableCustomResolution")] [Required] [SerializeField] [Label("Refresh Rate Savedata")] private SOIntegerSavedata _graphicsSavedata_refreshRate = null;
		/* 4 */ [ShowIf("_enableCustomResolution")] [Required] [SerializeField] [Label("Full Screen Mode Savedata")] private SOIntegerSavedata _graphicsSavedata_fullScreenMode = null;

		[SerializeField] [Label("Anti-Aliasing Level")] private bool _enableAntialiasingLevel = true;
		[ShowIf("_enableAntialiasingLevel")] [Required] [SerializeField] [Label("Anti-Aliasing Level Savedata")] private SOIntegerSavedata _graphicsSavedata_antialiasingLevel = null;


		[Header("Audio")]

		[SerializeField] [Label("Master Volume")] private bool _enableMasterVolume = true;
		[ShowIf("_enableMasterVolume")] [Required] [SerializeField] [Label("Master Volume Savedata")] private SOFloatSavedata _audioSavedata_masterVolume = null;
		[ShowIf("_enableMasterVolume")] [SerializeField] [Label("Master Volume Mixer Param")] private string _audioMixerParam_masterVolume = "Master/Volume";

		[SerializeField] [Label("Sound Volume")] private bool _enableSoundVolume = true;
		[ShowIf("_enableSoundVolume")] [Required] [SerializeField] [Label("Sound Volume Savedata")] private SOFloatSavedata _audioSavedata_soundVolume = null;
		[ShowIf("_enableSoundVolume")] [SerializeField] [Label("Sound Volume Mixer Param")] private string _audioMixerParam_soundVolume = "Sound/Volume";

		[SerializeField] [Label("Music Volume")] private bool _enableMusicVolume = true;
		[ShowIf("_enableMusicVolume")] [Required] [SerializeField] [Label("Music Volume Savedata")] private SOFloatSavedata _audioSavedata_musicVolume = null;
		[ShowIf("_enableMusicVolume")] [SerializeField] [Label("Music Volume Mixer Param")] private string _audioMixerParam_musicVolume = "Music/Volume";

		[SerializeField] [Label("Voice Volume")] private bool _enableVoiceVolume = false;
		[ShowIf("_enableVoiceVolume")] [Required] [SerializeField] [Label("Voice Volume Savedata")] private SOFloatSavedata _audioSavedata_voiceVolume = null;
		[ShowIf("_enableVoiceVolume")] [SerializeField] [Label("Voice Volume Mixer Param")] private string _audioMixerParam_voiceVolume = "Voice/Volume";

		[SerializeField] [Label("Environment Volume")] private bool _enableEnvironmentVolume = false;
		[ShowIf("_enableEnvironmentVolume")] [Required] [SerializeField] [Label("Environment Volume Savedata")] private SOFloatSavedata _audioSavedata_environmentVolume = null;
		[ShowIf("_enableEnvironmentVolume")] [SerializeField] [Label("Environment Volume Mixer Param")] private string _audioMixerParam_environmentVolume = "Environment/Volume";


		#pragma warning restore 0414




		#region Controls: General


			[Button("Load All Settings", EButtonEnableMode.Playmode)]
			public void loadAllSettings()
			{
				base.logInfo("Loading all settings...", this);
				{
					loadAudioSettings();
					loadGraphicsSettings();
				}
			}


			[Button("Apply All Settings", EButtonEnableMode.Playmode)]
			public void applyAllSettings()
			{
				base.logInfo("Applying all settings...", this);
				{
					applyAudioSettings();
					applyGraphicsSettings();
				}
			}




			[Button("Load Graphics Settings", EButtonEnableMode.Playmode)]
			public void loadGraphicsSettings()
			{
				base.logInfo("Loading graphics settings...", this);
				{
					loadQualityLevel();
					loadScreenResolution();
					loadAntialiasingLevel();
				}
			}


			[Button("Apply Graphics Settings", EButtonEnableMode.Playmode)]
			public void applyGraphicsSettings()
			{
				base.logInfo("Applying graphics settings...", this);
				{
					applyQualityLevel();
					applyScreenResolution();
					applyAntialiasingLevel();
				}
			}




			[Button("Load Audio Settings", EButtonEnableMode.Playmode)]
			public void loadAudioSettings()
			{
				base.logInfo("Loading audio settings...", this);
				{
					loadAudioMixerParams();
				}
			}


			[Button("Apply Audio Settings", EButtonEnableMode.Playmode)]
			public void applyAudioSettings()
			{
				base.logInfo("Applying audio settings...", this);
				{
					applyAudioMixerParams();
				}
			}


		#endregion




		#region Controls: Graphics


			[Button("Graphics: Load Quality Level", EButtonEnableMode.Playmode)]
			public void loadQualityLevel()
			{
				if (this._enableQualityLevel) {
					this._graphicsSavedata_qualityLevel.value = QualitySettings.GetQualityLevel();
				}
			}


			[Button("Graphics: Apply Quality Level", EButtonEnableMode.Playmode)]
			public void applyQualityLevel(bool applyExpensiveChanges = true)
			{
				if (this._enableQualityLevel) {
					QualitySettings.SetQualityLevel(this._graphicsSavedata_qualityLevel.value, applyExpensiveChanges);
				}
			}




			[Button("Graphics: Load Screen Resolution", EButtonEnableMode.Playmode)]
			public void loadScreenResolution()
			{
				if (this._enableCustomResolution) {
					this._graphicsSavedata_fullScreenMode.value = (int)Screen.fullScreenMode;
					this._graphicsSavedata_refreshRate.value = Screen.currentResolution.refreshRate;
					this._graphicsSavedata_resolutionHeight.value = Screen.currentResolution.height;
					this._graphicsSavedata_resolutionWidth.value = Screen.currentResolution.width;
				}
			}


			[Button("Graphics: Apply Screen Resolution", EButtonEnableMode.Playmode)]
			public void applyScreenResolution()
			{
				if (this._enableCustomResolution) {
					Screen.SetResolution(
						this._graphicsSavedata_resolutionWidth.value,
						this._graphicsSavedata_resolutionHeight.value,
						(FullScreenMode)this._graphicsSavedata_fullScreenMode.value,
						this._graphicsSavedata_refreshRate.value);
				}
			}




			[Button("Graphics: Load anti-aliasing level", EButtonEnableMode.Playmode)]
			public void loadAntialiasingLevel()
			{
				if (this._enableAntialiasingLevel) {
					#if USING_UNITY_BRP
						this._graphicsSavedata_antialiasingLevel.value = MathX.TimesDivisible(QualitySettings.antiAliasing, 2);
					#elif USING_UNITY_URP
						UniversalAdditionalCameraData universalAdditionalCameraData = FindObjectOfType<UniversalAdditionalCameraData>(false);
						this._graphicsSavedata_antialiasingLevel.value = (int)universalAdditionalCameraData.antialiasing;
					#elif USING_UNITY_HDRP
						HDAdditionalCameraData hdAdditionalCameraData = FindObjectOfType<HDAdditionalCameraData>(false);
						this._graphicsSavedata_antialiasingLevel.value = (int)hdAdditionalCameraData.antialiasing;
					#endif
				}
			}


			[Button("Graphics: Apply anti-aliasing Level", EButtonEnableMode.Playmode)]
			public void applyAntialiasingLevel()
			{
				if (this._enableAntialiasingLevel) {
					#if USING_UNITY_BRP
						QualitySettings.antiAliasing = (int)Mathf.Pow(2f, this._graphicsSavedata_antialiasingLevel.value);
					#elif USING_UNITY_URP
						UniversalAdditionalCameraData universalAdditionalCameraData = FindObjectOfType<UniversalAdditionalCameraData>(false);
						universalAdditionalCameraData.antialiasing = (AntialiasingMode)this._graphicsSavedata_antialiasingLevel.value;
					#elif USING_UNITY_HDRP
						HDAdditionalCameraData hdAdditionalCameraData = FindObjectOfType<HDAdditionalCameraData>(false);
						hdAdditionalCameraData.antialiasing = (HDAdditionalCameraData.AntialiasingMode)this._graphicsSavedata_antialiasingLevel.value;
					#endif
				}
			}


		#endregion




		#region Controls: Audio


			[Button("Audio: Load AudioMixer Params", EButtonEnableMode.Playmode)]
			public void loadAudioMixerParams()
			{
				if (this._enableMasterVolume) {
					this._audioMixer.GetFloat(this._audioMixerParam_masterVolume, out float value);
					this._audioSavedata_masterVolume.value = SettingsManager.calculateMixerToLinearVolume(value);
				}

				if (this._enableSoundVolume) {
					this._audioMixer.GetFloat(this._audioMixerParam_soundVolume, out float value);
					this._audioSavedata_soundVolume.value = SettingsManager.calculateMixerToLinearVolume(value);
				}

				if (this._enableMusicVolume) {
					this._audioMixer.GetFloat(this._audioMixerParam_musicVolume, out float value);
					this._audioSavedata_musicVolume.value = SettingsManager.calculateMixerToLinearVolume(value);
				}

				if (this._enableVoiceVolume) {
					this._audioMixer.GetFloat(this._audioMixerParam_voiceVolume, out float value);
					this._audioSavedata_voiceVolume.value = SettingsManager.calculateMixerToLinearVolume(value);
				}

				if (this._enableEnvironmentVolume) {
					this._audioMixer.GetFloat(this._audioMixerParam_environmentVolume, out float value);
					this._audioSavedata_environmentVolume.value = SettingsManager.calculateMixerToLinearVolume(value);
				}
			}


			[Button("Audio: Apply AudioMixer Params", EButtonEnableMode.Playmode)]
			public void applyAudioMixerParams()
			{
				if (this._enableMasterVolume) {
					this._audioMixer.SetFloat(this._audioMixerParam_masterVolume, SettingsManager.calculateLinearToMixerVolume(this._audioSavedata_masterVolume.value));
				}

				if (this._enableSoundVolume) {
					this._audioMixer.SetFloat(this._audioMixerParam_soundVolume, SettingsManager.calculateLinearToMixerVolume(this._audioSavedata_soundVolume.value));
				}

				if (this._enableMusicVolume) {
					this._audioMixer.SetFloat(this._audioMixerParam_musicVolume, SettingsManager.calculateLinearToMixerVolume(this._audioSavedata_musicVolume.value));
				}

				if (this._enableVoiceVolume) {
					this._audioMixer.SetFloat(this._audioMixerParam_voiceVolume, SettingsManager.calculateLinearToMixerVolume(this._audioSavedata_voiceVolume.value));
				}

				if (this._enableEnvironmentVolume) {
					this._audioMixer.SetFloat(this._audioMixerParam_environmentVolume, SettingsManager.calculateLinearToMixerVolume(this._audioSavedata_environmentVolume.value));
				}
			}


		#endregion




		#region Utilities


			public static float calculateLinearToMixerVolume(float linearVolume)
			{
				return (Mathf.Log10(Mathf.Clamp(linearVolume, 0.0001f, 10f)) * 20f);
			}


			public static float calculateMixerToLinearVolume(float mixerVolume)
			{
				return Mathf.Pow(10f, (Mathf.Clamp(mixerVolume, -80f, 20f) / 20f));
			}


		#endregion




		#region Properties


			public Resolution[] availableScreenResolutions => Screen.resolutions;
			public string[] availableQualitySettings => QualitySettings.names;


		#endregion




		#region Getters and Setters


			public SOBooleanSavedata graphicsSavedata_customResolution => this._graphicsSavedata_customResolution;
			public SOFloatSavedata audioSavedata_environmentVolume => this._audioSavedata_environmentVolume;
			public SOFloatSavedata audioSavedata_masterVolume => this._audioSavedata_masterVolume;
			public SOFloatSavedata audioSavedata_musicVolume => this._audioSavedata_musicVolume;
			public SOFloatSavedata audioSavedata_soundVolume => this._audioSavedata_soundVolume;
			public SOFloatSavedata audioSavedata_voiceVolume => this._audioSavedata_voiceVolume;
			public SOIntegerSavedata graphicsSavedata_fullScreenMode => this._graphicsSavedata_fullScreenMode;
			public SOIntegerSavedata graphicsSavedata_qualityLevel => this._graphicsSavedata_qualityLevel;
			public SOIntegerSavedata graphicsSavedata_refreshRate => this._graphicsSavedata_refreshRate;
			public SOIntegerSavedata graphicsSavedata_resolutionHeight => this._graphicsSavedata_resolutionHeight;
			public SOIntegerSavedata graphicsSavedata_resolutionWidth => this._graphicsSavedata_resolutionWidth;
			public bool isCustomResolutionEnabled => this._enableCustomResolution;
			public bool isEnvironmentVolumeEnabled => this._enableEnvironmentVolume;
			public bool isMasterVolumeEnabled => this._enableMasterVolume;
			public bool isMusicVolumeEnabled => this._enableMusicVolume;
			public bool isQualityLevelEnabled => this._enableQualityLevel;
			public bool isSoundVolumeEnabled => this._enableSoundVolume;
			public bool isVoiceVolumeEnabled => this._enableVoiceVolume;
			public string audioMixerParam_environmentVolume => this._audioMixerParam_environmentVolume;
			public string audioMixerParam_masterVolume => this._audioMixerParam_masterVolume;
			public string audioMixerParam_musicVolume => this._audioMixerParam_musicVolume;
			public string audioMixerParam_soundVolume => this._audioMixerParam_soundVolume;
			public string audioMixerParam_voiceVolume => this._audioMixerParam_voiceVolume;


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