using UnityEngine;




namespace PossumScream.Databases
{
	public partial class DynamicSheet<T>
	{
		#region Controls


			public bool TryImportTSV(TextAsset textAsset, string separator = "\t", string delimiter = "'")
			{
				return TryImportCSV(textAsset, separator, delimiter);
			}


			public bool TryImportTSV(string content, string separator = "\t", string delimiter = "'")
			{
				return TryImportCSV(content, separator, delimiter);
			}




			public bool TryJoinTSV(TextAsset textAsset, string separator = "\t", string delimiter = "'")
			{
				return TryJoinCSV(textAsset, separator, delimiter);
			}


			public bool TryJoinTSV(string content, string separator = "\t", string delimiter = "'")
			{
				return TryJoinCSV(content, separator, delimiter);
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