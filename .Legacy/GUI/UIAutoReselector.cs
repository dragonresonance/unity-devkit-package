#if ENABLE_INPUT_SYSTEM


using NaughtyAttributes;
using PossumScream.BlazingBehaviours;
using PossumScream.CoolComponents.Input;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;
using UnityEngine;




namespace PossumScream.CoolComponents.GUI
{
	[DisallowMultipleComponent]
	public class UIAutoReselector : ScriptableBehaviour
	{
		[Header("Components")]
		[SerializeField] [FormerlySerializedAs("_reselectionTargets")] private List<Selectable> _orderedReselectionTargets = null;
		[SerializeField] private bool _tryReselectChildIfNoTargets = false;


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




		private List<Selectable> _cachedSelectableChildren = new();




		#region Events


			private void OnEnable()
			{
				if (InputDeviceSwitchingManager.tryGetInstance(out InputDeviceSwitchingManager inputDeviceSwitchingManagerInstance)) {
					inputDeviceSwitchingManagerInstance.inputDeviceSwitch += OnDeviceSwitch;
				}

				cacheSelectableChildren();

				if (this._tryReselectionOnEnable) {
					assessReselection();
				}
			}


			private void OnDisable()
			{
				if (InputDeviceSwitchingManager.tryGetInstance(out InputDeviceSwitchingManager inputDeviceSwitchingManagerInstance)) {
					inputDeviceSwitchingManagerInstance.inputDeviceSwitch -= OnDeviceSwitch;
				}

				if (this._deselectOnDisable) {
					base.logInfo("Deselecting...", this);
					{
						if (EventSystem.current != null) {
							EventSystem.current.SetSelectedGameObject(null);
						}
					}
				}
			}




			private void OnTransformChildrenChanged()
			{
				cacheSelectableChildren();
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


					GameObject currentSelectedGameobject = EventSystem.current.currentSelectedGameObject;


					if ((currentSelectedGameobject != null) &&
					    currentSelectedGameobject.TryGetComponent(out Selectable currentSelectedSelectable)) {
						switch (this._reselectionCondition) {
							default:
							case ReselectionCondition.AlwaysReselect:
								// Always continue
								break;
							case ReselectionCondition.IfNotInReselectionTargets:
								if (this._orderedReselectionTargets.Contains(currentSelectedSelectable)) return;
								if (this._tryReselectChildIfNoTargets && this._cachedSelectableChildren.Contains(currentSelectedSelectable)) return;
								break;
							case ReselectionCondition.IfInReselectionTargets:
								if (!this._orderedReselectionTargets.Contains(currentSelectedSelectable)) return;
								if (this._tryReselectChildIfNoTargets && !this._cachedSelectableChildren.Contains(currentSelectedSelectable)) return;
								break;
						}
					}

					StartCoroutine(performReselection());
				}
			}




			[Button("(Force to) Perform Reselection", EButtonEnableMode.Playmode)]
			public IEnumerator performReselection()
			{
				base.logInfo($"Performing reselection over {this._orderedReselectionTargets.Count}|{this._cachedSelectableChildren.Count} items...", this);
				{
					for (int yieldedFrame = 1; yieldedFrame <= this._yieldedFramesBeforeReselection; yieldedFrame++) {
						yield return null;
					}

					foreach (Selectable reselectionTarget in this._orderedReselectionTargets) {
						if (UIAutoReselector.isSelectableSelectable(reselectionTarget)) {
							base.logInfo($"Reselecting the selectable {reselectionTarget.name} target...", this);
							{
								EventSystem.current.SetSelectedGameObject(reselectionTarget.gameObject);
							}
							break;
						}
					}

					if (!this._tryReselectChildIfNoTargets) yield break;

					foreach (Selectable reselectionTarget in this._cachedSelectableChildren) {
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




			public static bool isSelectableSelectable(Selectable selectable)
			{
				return (selectable.interactable && selectable.isActiveAndEnabled);
			}


		#endregion




		#region Actions


			private void cacheSelectableChildren()
			{
				this._cachedSelectableChildren.Clear();

				foreach (Transform childTransform in base.transform) {
					if (childTransform.TryGetComponent(out Selectable selectableTarget)) {
						this._cachedSelectableChildren.Add(selectableTarget);
					}
				}
			}


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