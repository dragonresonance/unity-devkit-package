using DragonResonance.Behaviours;
using DragonResonance.Extensions;
using System.Collections.Generic;
using System;
using UnityEngine;


namespace DragonResonance.Enhancements
{
	public class PlatformDefinitionGameobjectDestroyer : PossumBehaviour
	{
		[SerializeField] private string[] _definitions = { };


		private readonly HashSet<string> _definedDefinitions = new();


		#region Events

			private void Awake()
			{
				AddDefinitions();
				if (_definedDefinitions.MatchesAny(_definitions))
					PerformingAction.Invoke(this.gameObject);
			}

		#endregion


		#region Privates

			protected virtual Action<GameObject> PerformingAction => Destroy;

			private void AddDefinitions()
			{
				#if UNITY_EDITOR
					_definedDefinitions.Add("UNITY_EDITOR");
				#endif
				#if UNITY_STANDALONE
					_definedDefinitions.Add("UNITY_STANDALONE");
				#endif
				#if UNITY_STANDALONE_WIN
					_definedDefinitions.Add("UNITY_STANDALONE_WIN");
				#endif
				#if UNITY_STANDALONE_OSX
					_definedDefinitions.Add("UNITY_STANDALONE_OSX");
				#endif
				#if UNITY_STANDALONE_LINUX
					_definedDefinitions.Add("UNITY_STANDALONE_LINUX");
				#endif
				#if UNITY_ANDROID
					_definedDefinitions.Add("UNITY_ANDROID");
				#endif
				#if UNITY_IOS
					_definedDefinitions.Add("UNITY_IOS");
				#endif
				#if UNITY_WEBGL
					_definedDefinitions.Add("UNITY_WEBGL");
				#endif
				#if UNITY_PS4
					_definedDefinitions.Add("UNITY_PS4");
				#endif
				#if UNITY_PS5
					_definedDefinitions.Add("UNITY_PS5");
				#endif
				#if UNITY_XBOXONE
					_definedDefinitions.Add("UNITY_XBOXONE");
				#endif
				#if UNITY_SWITCH
					_definedDefinitions.Add("UNITY_SWITCH");
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