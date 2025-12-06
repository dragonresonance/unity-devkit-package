using DragonResonance.Behaviours;
using UnityEngine.UI;
using UnityEngine;


namespace DragonResonance.Enhancements
{
	[DisallowMultipleComponent]
	[RequireComponent(typeof(CanvasScaler))]
	public class MobileCanvasAutoScaling : PossumBehaviour
	{
		[SerializeField] private float _dpiFallback = 96f;	// 96 is the Unity's default value


		private void Start()
		{
			CanvasScaler canvasScaler = GetComponent<CanvasScaler>();
			float dpi = ((Screen.dpi != 0) ? Screen.dpi : _dpiFallback);
			float scale = dpi / 72f;	// The DTP point is defined as 1⁄72 of an inch (or exactly 0.352777 mm)

			#if !UNITY_EDITOR && (UNITY_ANDROID || UNITY_IOS)
				canvasScaler.scaleFactor = scale * _configuration.MobilePanelScaleFactor;
			#else
				canvasScaler.scaleFactor = scale;
			#endif
		}
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