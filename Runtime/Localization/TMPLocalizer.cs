#if TEST


using NaughtyAttributes;
using PossumScream.Behaviours;
using PossumScream.CoolComponents.Savedata;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System;
using TMPro;
using UnityEngine;




namespace PossumScream.Localization
{
	public class TMPLocalizer : PossumBehaviour
	{
		[Header("Assets")]
		[Required] [SerializeField] private SOStringSavedata _languageSavedata = null;


		[Header("Configuration")]
		[SerializeField] private TMP_Text[] _targetComponents = {};
		[SerializeField] private string _rowKey = "TEST_KEY";


		[Header("Settings")]
		[SerializeField] private List<string> _compositeStringParameters = new();




		#region Events


			private void OnEnable()
			{
				Translate();
			}


			private void OnValidate()
			{
				this._rowKey = Regex.Match(this._rowKey, @"[A-Za-z0-9-_]+").ToString();
			}


		#endregion




		#region Controls


			[Button]
			public void Translate()
			{
				#if UNITY_EDITOR
					if (this._targetComponents.Length == 0) {
						LogError("The list of components to be translated is empty", this);
					}
				#endif

				foreach (TMP_Text component in this._targetComponents) {
					try {
						string translation = LocalizationMaster.GetInstance().GetTranslation(
							this._rowKey,
							this._languageSavedata.value);

						component.text = (this._compositeStringParameters.Count == 0)
							? translation
							// ReSharper disable once CoVariantArrayConversion
							: string.Format(translation, this._compositeStringParameters.ToArray());
					}
					catch (IndexOutOfRangeException) {
						LogError($"Could not get translation for key \"{this._rowKey}\" in \"{this._languageSavedata.value}\"", this);
					}
				}
			}


		#endregion




		#region Parameters


			public List<string> compositeStringParameters => this._compositeStringParameters;


		#endregion
	}
}


#endif




/*                                                                                            */
/*          ______                               _______                                      */
/*          \  __ \____  ____________  ______ ___\  ___/_____________  ____  ____ ___         */
/*          / /_/ / __ \/ ___/ ___/ / / / __ \__ \\__ \/ ___/ ___/ _ \/ __ \/ __ \__ \        */
/*         / ____/ /_/ /__  /__  / /_/ / / / / / /__/ / /__/ /  / ___/ /_/ / / / / / /        */
/*        /_/    \____/____/____/\____/_/ /_/ /_/____/\___/_/   \___/\__/_/_/ /_/ /__\        */
/*                                                                                            */
/*        Licensed under the Apache License, Version 2.0. See LICENSE.md for more info        */
/*        David Tabernero M. @ PossumScream                      Copyright © 2021-2023        */
/*        GitLab - GitHub: possumscream                            All rights reserved        */
/*        -------------------------                                  -----------------        */
/*                                                                                            */