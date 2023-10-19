#if !(UNITY_STANDALONE_WIN || UNITY_STANDALONE_LINUX || UNITY_STANDALONE_OSX || STEAMWORKS_WIN || STEAMWORKS_LIN_OSX)
#define DISABLESTEAMWORKS
#endif


using NaughtyAttributes;
using PossumScream.Behaviours;
using UnityEngine;


#if !DISABLESTEAMWORKS
using Steamworks;
#endif




namespace PossumScream.Integration.Steamworks
{
	//
	// The SteamManager provides a base implementation of Steamworks.NET on which you can build upon.
	// It handles the basics of starting up and shutting down the SteamAPI for use.
	//
	//[DisallowMultipleComponent]
	public class SteamManager : PersistentSingletonBehaviour<SteamManager>
	{
		[Header("Configuration")]
		#pragma warning disable CS0414
		// ReSharper disable once NotAccessedField.Local
		[SerializeField] [Label("[DANGER!] Edit Critical Configuration")] private bool _editCriticalConfiguration = false;
		#pragma warning restore CS0414

		[EnableIf("_editCriticalConfiguration")] [SerializeField] private uint _appId = 480;




		[ShowNonSerializedField] private bool _initialized = false;
		[ShowNonSerializedField] private bool _everInitialized = false;


		#if !DISABLESTEAMWORKS
		private SteamAPIWarningMessageHook_t _steamAPIWarningMessageHook = null;
		#endif




		#region Events


			#if !DISABLESTEAMWORKS
			[Button("DEBUG: Initialize in Editor")]
			protected override void LateAwake()
			{
				if (this._everInitialized) {
					// This is almost always an error.
					// The most common case where this happens is when SteamManager gets destroyed because of Application.Quit(),
					// and then some Steamworks code in some other OnDestroy gets called afterwards, creating a new SteamManager.
					// You should never call Steamworks functions in OnDestroy, always prefer OnDisable if possible.
					throw new System.Exception("Tried to Initialize the SteamAPI twice in one session!");
				}

				if (!Packsize.Test()) {
					Debug.LogError("[Steamworks.NET] Packsize Test returned false, the wrong version of Steamworks.NET is being run in this platform.", this);
				}

				if (!DllCheck.Test()) {
					Debug.LogError("[Steamworks.NET] DllCheck Test returned false, One or more of the Steamworks binaries seems to be the wrong version.", this);
				}

				try {
					// If Steam is not running or the game wasn't started through Steam, SteamAPI_RestartAppIfNecessary starts the
					// Steam client and also launches this game again if the User owns it. This can act as a rudimentary form of DRM.

					// Once you get a Steam AppID assigned by Valve, you need to replace AppId_t.Invalid with it and
					// remove steam_appid.txt from the game depot. eg: "(AppId_t)480" or "new AppId_t(480)".
					// See the Valve documentation for more information: https://partner.steamgames.com/doc/sdk/api#initialization_and_shutdown
					if (SteamAPI.RestartAppIfNecessary(new AppId_t(this._appId))) {
						Application.Quit();
						return;
					}
				}
				catch (System.DllNotFoundException e) { // We catch this exception here, as it will be the first occurrence of it.
					Debug.LogError("[Steamworks.NET] Could not load [lib]steam_api.dll/so/dylib. It's likely not in the correct location. Refer to the README for more details.\n" + e, this);

					Application.Quit();
					return;
				}

				// Initializes the Steamworks API.
				// If this returns false then this indicates one of the following conditions:
				// [*] The Steam client isn't running. A running Steam client is required to provide implementations of the various Steamworks interfaces.
				// [*] The Steam client couldn't determine the App ID of game. If you're running your application from the executable or debugger directly then you must have a [code-inline]steam_appid.txt[/code-inline] in your game directory next to the executable, with your app ID in it and nothing else. Steam will look for this file in the current working directory. If you are running your executable from a different directory you may need to relocate the [code-inline]steam_appid.txt[/code-inline] file.
				// [*] Your application is not running under the same OS user context as the Steam client, such as a different user or administration access level.
				// [*] Ensure that you own a license for the App ID on the currently active Steam account. Your game must show up in your Steam library.
				// [*] Your App ID is not completely set up, i.e. in Release State: Unavailable, or it's missing default packages.
				// Valve's documentation for this is located here:
				// https://partner.steamgames.com/doc/sdk/api#initialization_and_shutdown
				this._initialized = SteamAPI.Init();
				if (!this._initialized) {
					Debug.LogError("[Steamworks.NET] SteamAPI_Init() failed. Refer to Valve's documentation or the comment above this line for more information.", this);

					return;
				}

				this._everInitialized = true;
			}
			#endif




			#if !DISABLESTEAMWORKS
			//[Button]
			private void Update()
			{
				if (!this._initialized) {
					return;
				}

				// Run Steam client callbacks
				SteamAPI.RunCallbacks();
			}
			#endif




			#if !DISABLESTEAMWORKS
			// This should only ever get called on first load and after an Assembly reload, You should never Disable the Steamworks Manager yourself.
			private void OnEnable()
			{
				if (!this._initialized) return;
				if (this._steamAPIWarningMessageHook != null) return;


				// Set up our callback to receive warning messages from Steam.
				// You must launch with "-debug_steamapi" in the launch args to receive warnings.
				//this._steamAPIWarningMessageHook = new SteamAPIWarningMessageHook_t(SteamAPIDebugTextHook);
				this._steamAPIWarningMessageHook = SteamAPIDebugTextHook;
				SteamClient.SetWarningMessageHook(this._steamAPIWarningMessageHook);
			}
			#endif


			#if !DISABLESTEAMWORKS
			// OnApplicationQuit gets called too early to shutdown the SteamAPI.
			// Because the SteamManager should be persistent and never disabled or destroyed we can shutdown the SteamAPI here.
			// Thus it is not recommended to perform any Steamworks work in other OnDestroy functions as the order of execution can not be guarenteed upon Shutdown. Prefer OnDisable().
			private void OnDestroy()
			{
				if (!this._initialized) {
					return;
				}

				SteamAPI.Shutdown();
			}
			#endif


		#endregion




		#region Actions


			#if !DISABLESTEAMWORKS
			[AOT.MonoPInvokeCallback(typeof(SteamAPIWarningMessageHook_t))]
			private static void SteamAPIDebugTextHook(int nSeverity, System.Text.StringBuilder pchDebugText) {
				Debug.LogWarning(pchDebugText);
			}
			#endif


			#if !DISABLESTEAMWORKS && UNITY_2019_3_OR_NEWER
				// In case of disabled Domain Reload, reset static members before entering Play Mode.
				[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
				private static void InitOnPlayMode()
				{
					SteamManager instance = GetInstance();


					PurgeInstance();
					Instantiate(instance);
					Destroy(instance.gameObject);
				}
			#endif


		#endregion




		#region Properties


			public bool EverInitialized => this._everInitialized;
			public bool Initialized => this._initialized;
			public uint AppId => this._appId;


		#endregion
	}
}




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