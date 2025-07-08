using DragonResonance.Attributes;
using DragonResonance.Behaviours;
using DragonResonance.Extensions;
using System.Collections.Generic;
using System;
using UnityEngine;


namespace DragonResonance.Enhancements
{
	[DisallowMultipleComponent]
	[RequireComponent(typeof(Transform))]
	public class ObjectPersistence : PossumBehaviour
	{
		[SerializeField] private bool _makeGameobjectUnique = true;
		[ShowIf(nameof(_makeGameobjectUnique))] [SerializeField] private string _guid = "";


		private static readonly HashSet<string> _guids = new();


		#region Events

			private void OnValidate()
			{
				_guid = _guid.Trim();
				if (string.IsNullOrEmpty(_guid)) _guid = Guid.NewGuid().ToString().ToUpperInvariant();
			}

			private void Awake()
			{
				if (_makeGameobjectUnique && _guids.Contains(_guid)) {
					//Log($"Destroying this object with GUID {_guid} ...");
					DestroyImmediate(this.gameObject);
				}
				else {
					//Log($"Persisting this object with GUID {_guid} ...");
					DontDestroyOnLoad(this.gameObject);
					_guids.Add(_guid);
				}
			}

			private void OnDestroy()
			{
				if (this.gameObject.IsPersistent())
					_guids.Remove(_guid);
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