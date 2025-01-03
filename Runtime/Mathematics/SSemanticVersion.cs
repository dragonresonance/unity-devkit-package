using DragonResonance.Logging;
using System.Text.RegularExpressions;




namespace DragonResonance.Mathematics
{
	public struct SSemanticVersion
	{
		private static readonly Regex SEMVER_REGEX = new(
			@"^(?<major>\d+)\.(?<minor>\d+)\.(?<patch>\d+)(?:-(?<label>[0-9A-Za-z\-\.]+))?$",
			RegexOptions.Compiled
		);

		private int _major;
		private int _minor;
		private int _patch;
		private string _label;




		#region Constructors


			public SSemanticVersion(int major, int minor, int patch, string label = null)
			{
				_major = major;
				_minor = minor;
				_patch = patch;
				_label = label;
			}


			public SSemanticVersion(string version)
			{
				Match match = SEMVER_REGEX.Match(version);
				if (match.Success) {
					_major = int.Parse(match.Groups["major"].Value);
					_minor = int.Parse(match.Groups["minor"].Value);
					_patch = int.Parse(match.Groups["patch"].Value);
					_label = match.Groups["label"].Success ? match.Groups["label"].Value : null;
				}
				else {
					HLogger.LogError($"Version {version} is not semantic", typeof(SSemanticVersion));
					_major = _minor = _patch = 0;
					_label = null;
				}
			}


		#endregion




		#region Publics


			public SSemanticVersion MajorUp() => new((_major + 1), _minor, _patch, _label);
			public SSemanticVersion MinorUp() => new(_major, (_minor + 1), _patch, _label);
			public SSemanticVersion PatchUp() => new(_major, _minor, (_patch + 1), _label);


		#endregion




		#region Properties


			public override string ToString() => $"{_major}.{_minor}.{_patch}" + (_label != null ? $"-{_label}" : "");


			public int Major => _major;
			public int Minor => _minor;
			public int Patch => _patch;
			public string Label => _label;


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