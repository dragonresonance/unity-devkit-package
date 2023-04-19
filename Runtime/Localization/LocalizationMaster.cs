using NaughtyAttributes;
using PossumScream.Behaviours;
using PossumScream.Databases;
using UnityEngine;




namespace PossumScream.Localization
{
	public class LocalizationMaster : PersistentSingletonBehaviour<LocalizationMaster>
	{
		[Header("Assets")]
		[SerializeField] private TextAsset[] _tsvLocalizationAssets = {};




		private CachedSheet<string> _localizationSheet;




		#region Events


			protected override void LateAwake()
			{
				ReimportLocalizationAssets();
			}


		#endregion




		#region Controls


			[Button(enabledMode:EButtonEnableMode.Always)]
			public void ReimportLocalizationAssets()
			{
				DynamicSheet<string> localizationDynamicSheet = new DynamicSheet<string>();


				foreach (TextAsset localizationAsset in this._tsvLocalizationAssets) {
					if (!localizationDynamicSheet.TryJoinTSV(localizationAsset)) {
						LogError($"Could not join the {localizationAsset.name} localization file", localizationAsset);
					}
				}


				this._localizationSheet = localizationDynamicSheet.ToCachedSheet();
			}




			public string GetTranslation(string rowKey, string columnKey)
			{
				return this._localizationSheet[rowKey, columnKey];
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