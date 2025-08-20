using DragonResonance.Behaviours;
using UnityEngine.Events;
using UnityEngine;


namespace DragonResonance.Miscellany
{
	public class AppPropertiesSetter : PossumBehaviour
	{
		[SerializeField] private string _format = "{0}";
		[SerializeField] private EAppProperty _property = default;
		[SerializeField] private UnityEvent<string> _targets = null;


		#region Events

			private void Start() => SetTargets();

		#endregion


		#region Publics

			[ContextMenu(nameof(SetTargets))]
			public void SetTargets()
			{
				_targets?.Invoke(string.Format(_format, GetProperty()));
			}

			public string GetProperty() => GetProperty(_property);
			public static string GetProperty(EAppProperty property)
			{
				return property switch {
					EAppProperty.ProductName => Application.productName,
					EAppProperty.CompanyName => Application.companyName,
					EAppProperty.Version => Application.version,
					_ => null
				};
			}

		#endregion


		#region Enums

			public enum EAppProperty
			{
				ProductName,
				CompanyName,
				Version,
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