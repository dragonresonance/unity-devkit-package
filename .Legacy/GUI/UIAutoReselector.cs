#if ENABLE_INPUT_SYSTEM


using NaughtyAttributes;
using PossumScream.BlazingBehaviours;
using PossumScream.CoolComponents.Input;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;




namespace PossumScream.CoolComponents.GUI
{
	[DisallowMultipleComponent]
	public class UIAutoReselector : ScriptableBehaviour
	{
		[Header("Components")]
		[InfoBox(@"At least 1 item is required.
Will attempt to select in order.
If no valid Selectable is found, will not select anything.", EInfoBoxType.Warning)]
		[SerializeField] private List<Selectable> _reselectionTargets = null;


		[Header("Devices")]
		[SerializeField] private string[] _devicesWithoutReselection = { "Mouse" };


		[Header("Reselection")]
		/* 1 */ [SerializeField] private bool _tryReselectionOnEnable = true;
		/* 2 */ [SerializeField] private bool _tryReselectionOnDeviceSwitch = true;

		[SerializeField] private ReselectionCondition _reselectionCondition = ReselectionCondition.IfNotInReselectionTargets;


		[Header("Deselection")]
		[SerializeField] private bool _deselectOnDisable = true;


		[Header("Troubleshooting")]
		[SerializeField] [Min(0)] private int _yieldedFramesBeforeReselection = 1;




		#region Events


			private void OnEnable()
			{
				InputDeviceSwitchingManager.Instance.inputDeviceSwitch += OnDeviceSwitch;

				if (this._tryReselectionOnEnable) {
					assessReselection();
				}
			}


			private void OnDisable()
			{
				InputDeviceSwitchingManager.Instance.inputDeviceSwitch -= OnDeviceSwitch;

				if (this._deselectOnDisable) {
					base.logInfo("Deselecting...", this);
					{
						if (EventSystem.current != null) {
							EventSystem.current.SetSelectedGameObject(null);
						}
					}
				}
			}




			private void OnDeviceSwitch()
			{
				if (this._tryReselectionOnDeviceSwitch) {
					assessReselection();
				}
			}


		#endregion




		#region Controls


			[Button("Assess Reselection", EButtonEnableMode.Playmode)]
			public void assessReselection()
			{
				base.logInfo("Checking for reselection...", this);
				{
					if (this._devicesWithoutReselection.Contains(InputDeviceSwitchingManager.Instance.currentDeviceName)) return;

					if ((EventSystem.current.currentSelectedGameObject is not null) &&
					    EventSystem.current.currentSelectedGameObject.TryGetComponent<Selectable>(out Selectable currentSelectedSelectable)) {
						switch (this._reselectionCondition) {

							/*default:
							case ReselectionCondition.AlwaysReselect: {
								// Always continue
							} break;*/

							case ReselectionCondition.IfInReselectionTargets: {
								if (!this._reselectionTargets.Contains(currentSelectedSelectable)) return;
							} break;

							case ReselectionCondition.IfNotInReselectionTargets: {
								if (this._reselectionTargets.Contains(currentSelectedSelectable)) return;
							} break;

						}
					}

					StartCoroutine(performReselection());
				}
			}




			[Button("(Force to) Perform Reselection", EButtonEnableMode.Playmode)]
			public IEnumerator performReselection()
			{
				base.logInfo($"Performing reselection...", this);
				{
					for (int yieldedFrame = 1; yieldedFrame <= this._yieldedFramesBeforeReselection; yieldedFrame++) {
						yield return null;
					}

					foreach (Selectable reselectionTarget in this._reselectionTargets) {
						if (UIAutoReselector.isSelectableSelectable(reselectionTarget)) {
							base.logInfo($"Reselecting the selectable {reselectionTarget.name} target...", this);
							{
								EventSystem.current.SetSelectedGameObject(reselectionTarget.gameObject);
							}
							break;
						}
					}
				}
			}


		#endregion




		#region Utilities


			public static bool isSelectableSelectable(Selectable selectable)
			{
				return (selectable.interactable && selectable.isActiveAndEnabled);
			}


		#endregion




		#region Getters and Setters


			public List<Selectable> reselectionTargets => this._reselectionTargets;


		#endregion




		#region Enums


			private enum ReselectionCondition
			{
				AlwaysReselect,
				IfInReselectionTargets,
				IfNotInReselectionTargets,
			}


		#endregion
	}
}


#endif




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