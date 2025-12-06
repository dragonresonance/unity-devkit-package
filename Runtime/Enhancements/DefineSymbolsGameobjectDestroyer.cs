using DragonResonance.Behaviours;
using DragonResonance.Extensions;
using System.Collections.Generic;
using System;
using UnityEngine;


namespace DragonResonance.Enhancements
{
	public class DefineSymbolsGameobjectDestroyer : PossumBehaviour
	{
		[SerializeField] private bool _blacklistMode = false;
		[SerializeField] private string[] _definitions = { };


		private readonly HashSet<string> _definedDefinitions = new();


		#region Events

			private void Awake()
			{
				AddDefinitions();
				if (!_blacklistMode == _definedDefinitions.MatchesAny(_definitions))
					PerformingAction.Invoke(this.gameObject);
			}

		#endregion


		#region Privates

			protected virtual Action<GameObject> PerformingAction => Destroy;

			private void AddDefinitions()
			{
				#if CSHARP_7_3_OR_NEWER
					_definedDefinitions.Add("CSHARP_7_3_OR_NEWER");
				#endif
				#if DEVELOPMENT_BUILD
					_definedDefinitions.Add("DEVELOPMENT_BUILD");
				#endif
				#if ENABLE_IL2CPP
					_definedDefinitions.Add("ENABLE_IL2CPP");
				#endif
				#if ENABLE_INPUT_SYSTEM
					_definedDefinitions.Add("ENABLE_INPUT_SYSTEM");
				#endif
				#if ENABLE_LEGACY_INPUT_MANAGER
					_definedDefinitions.Add("ENABLE_LEGACY_INPUT_MANAGER");
				#endif
				#if ENABLE_MONO
					_definedDefinitions.Add("ENABLE_MONO");
				#endif
				#if ENABLE_VR
					_definedDefinitions.Add("ENABLE_VR");
				#endif
				#if ENABLE_WINMD_SUPPORT
					_definedDefinitions.Add("ENABLE_WINMD_SUPPORT");
				#endif
				#if NET_2_0
					_definedDefinitions.Add("NET_2_0");
				#endif
				#if NET_2_0_SUBSET
					_definedDefinitions.Add("NET_2_0_SUBSET");
				#endif
				#if NET_4_6
					_definedDefinitions.Add("NET_4_6");
				#endif
				#if NET_LEGACY
					_definedDefinitions.Add("NET_LEGACY");
				#endif
				#if NET_STANDARD
					_definedDefinitions.Add("NET_STANDARD");
				#endif
				#if NET_STANDARD_2_0
					_definedDefinitions.Add("NET_STANDARD_2_0");
				#endif
				#if NET_STANDARD_2_1
					_definedDefinitions.Add("NET_STANDARD_2_1");
				#endif
				#if NETSTANDARD
					_definedDefinitions.Add("NETSTANDARD");
				#endif
				#if NETSTANDARD2_1
					_definedDefinitions.Add("NETSTANDARD2_1");
				#endif
				#if UNITY_6000
					_definedDefinitions.Add("UNITY_6000");
				#endif
				#if UNITY_6000_0
					_definedDefinitions.Add("UNITY_6000_0");
				#endif
				#if UNITY_6000_0_33
					_definedDefinitions.Add("UNITY_6000_0_33");
				#endif
				#if UNITY_64
					_definedDefinitions.Add("UNITY_64");
				#endif
				#if UNITY_ANALYTICS
					_definedDefinitions.Add("UNITY_ANALYTICS");
				#endif
				#if UNITY_ANDROID
					_definedDefinitions.Add("UNITY_ANDROID");
				#endif
				#if UNITY_ASSERTIONS
					_definedDefinitions.Add("UNITY_ASSERTIONS");
				#endif
				#if UNITY_CLOUD_BUILD
					_definedDefinitions.Add("UNITY_CLOUD_BUILD");
				#endif
				#if UNITY_EDITOR
					_definedDefinitions.Add("UNITY_EDITOR");
				#endif
				#if UNITY_EDITOR_LINUX
					_definedDefinitions.Add("UNITY_EDITOR_LINUX");
				#endif
				#if UNITY_EDITOR_OSX
					_definedDefinitions.Add("UNITY_EDITOR_OSX");
				#endif
				#if UNITY_EDITOR_WIN
					_definedDefinitions.Add("UNITY_EDITOR_WIN");
				#endif
				#if UNITY_EMBEDDED_LINUX
					_definedDefinitions.Add("UNITY_EMBEDDED_LINUX");
				#endif
				#if UNITY_FACEBOOK_INSTANT_GAMES
					_definedDefinitions.Add("UNITY_FACEBOOK_INSTANT_GAMES");
				#endif
				#if UNITY_IOS
					_definedDefinitions.Add("UNITY_IOS");
				#endif
				#if UNITY_QNX
					_definedDefinitions.Add("UNITY_QNX");
				#endif
				#if UNITY_SERVER
					_definedDefinitions.Add("UNITY_SERVER");
				#endif
				#if UNITY_STANDALONE
					_definedDefinitions.Add("UNITY_STANDALONE");
				#endif
				#if UNITY_STANDALONE_LINUX
					_definedDefinitions.Add("UNITY_STANDALONE_LINUX");
				#endif
				#if UNITY_STANDALONE_OSX
					_definedDefinitions.Add("UNITY_STANDALONE_OSX");
				#endif
				#if UNITY_STANDALONE_WIN
					_definedDefinitions.Add("UNITY_STANDALONE_WIN");
				#endif
				#if UNITY_TVOS
					_definedDefinitions.Add("UNITY_TVOS");
				#endif
				#if UNITY_VISIONOS
					_definedDefinitions.Add("UNITY_VISIONOS");
				#endif
				#if UNITY_WEBGL
					_definedDefinitions.Add("UNITY_WEBGL");
				#endif
				#if UNITY_WSA
					_definedDefinitions.Add("UNITY_WSA");
				#endif
				#if UNITY_WSA_10_0
					_definedDefinitions.Add("UNITY_WSA_10_0");
				#endif
			}

		#endregion
	}
}


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