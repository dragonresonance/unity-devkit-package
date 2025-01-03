using UnityEngine;


namespace DragonResonance.Attributes
{
	public class MinMaxRangeAttribute : PropertyAttribute
	{
		private readonly float _min;
		private readonly float _max;
		private readonly bool _roundToInt;

		public MinMaxRangeAttribute(float min, float max, bool roundToInt = false)
		{
			_min = min;
			_max = max;
			_roundToInt = roundToInt;
		}

		public float Min => _min;
		public float Max => _max;
		public bool RoundToInt => _roundToInt;
	}
}


/*                                                                              */
/*            |>  Based on the script made by Unity Technologies. <|            */
/*                                                                              */
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