using UnityEngine;


namespace PossumScream.Databases
{
	public partial class DynamicSheet<T> // TSV Handler
	{
		#region Publics

			public bool TryImportTSV(TextAsset textAsset, string separator = "\t", string delimiter = "'", Formatting formatting = null)
			{
				return TryImportCSV(textAsset, separator, delimiter, formatting);
			}

			public bool TryImportTSV(string content, string separator = "\t", string delimiter = "'", Formatting formatting = null)
			{
				return TryImportCSV(content, separator, delimiter, formatting);
			}


			public bool TryJoinTSV(TextAsset textAsset, string separator = "\t", string delimiter = "'", Formatting formatting = null)
			{
				return TryJoinCSV(textAsset, separator, delimiter, formatting);
			}

			public bool TryJoinTSV(string content, string separator = "\t", string delimiter = "'", Formatting formatting = null)
			{
				return TryJoinCSV(content, separator, delimiter, formatting);
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
/*                  Copyright © 2021-2024. All rights reserved.                 */
/*                Licensed under the Apache License, Version 2.0.               */
/*                         See LICENSE.md for more info.                        */
/*       ________________________________________________________________       */
/*                                                                              */