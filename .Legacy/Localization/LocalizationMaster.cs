using NaughtyAttributes;
using PossumScream.BlazingBehaviours;
using PossumScream.CoolComponents.Savedata;
using PossumScream.SickScripts.Databases;
using UnityEngine;




namespace PossumScream.CoolComponents.Localization
{
	public class LocalizationMaster : ScriptablePersistentSingleton<LocalizationMaster>
	{
		[Header("Assets")]
		[Required] [SerializeField] private SOStringSavedata _localeSavedata = null;
		[SerializeField] private TextAsset[] _csvAssets = {};


		[Header("Configuration")]
		[SerializeField] private string _separator = "	";




		private CSVBook _book = null;




		#region Events


			protected override void LateAwake()
			{
				regenerateBook();
			}


		#endregion




		#region Controls


			public bool tryRetrieveLocalizationField(string key, out string value)
			{
				return tryRetrieveCustomField(this._localeSavedata.value, key, out value);
			}


			public bool tryRetrieveCustomField(string header, string key, out string value)
			{
				return this._book.tryQuery(header, key, out value);
			}


		#endregion




		#region Actions


			[Button]
			private void regenerateBook()
			{
				this._book = new CSVBook();

				foreach (TextAsset csvAsset in this._csvAssets) {
					this._book.add(new CSVSheet(csvAsset, this._separator));
				}
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