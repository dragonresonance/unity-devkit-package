#if DEVELOPMENT_MODE_ENABLED && ENABLE_INPUT_SYSTEM


using NaughtyAttributes;
using PossumScream.BlazingBehaviours;
using UnityEngine.InputSystem;
using UnityEngine;


#if USING_UNITY_URP
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;
#elif USING_UNITY_HDRP
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.Rendering;
#endif




namespace PossumScream.CoolComponents.Debugging
{
	public class GameplayAssetToggler : ScriptableOptableSingleton<ViewportStats>
	{
		[Header("Configuration")]
		[SerializeField] private bool _includeInactive = true;


		[Header("Input")]
		[SerializeField] private InputAction _toggleRenderersInputAction = null;
		[SerializeField] private InputAction _toggleVolumesInputAction = null;




		[ShowNonSerializedField] private bool _renderersEnabled = true;


		#if USING_UNITY_URP || USING_UNITY_HDRP
		[ShowNonSerializedField] private bool _volumesEnabled = true;
		#endif




		#region Events


			protected override void LateAwake()
			{
				this._toggleRenderersInputAction.performed += toggleRenderers;
				this._toggleVolumesInputAction.performed += toggleVolumes;

				this._toggleRenderersInputAction.Enable();
				this._toggleVolumesInputAction.Enable();
			}


			private void OnDestroy()
			{
				this._toggleRenderersInputAction.Disable();
				this._toggleVolumesInputAction.Disable();

				this._toggleRenderersInputAction.performed -= toggleRenderers;
				this._toggleVolumesInputAction.performed -= toggleVolumes;
			}


		#endregion




		#region Controls


			[Button("Toggle Renderers", EButtonEnableMode.Playmode)]
			public void toggleRenderers(InputAction.CallbackContext _ = default)
			{
				Renderer[] foundRenderers = FindObjectsOfType<Renderer>(this._includeInactive);


				this._renderersEnabled = !this._renderersEnabled;

				foreach (Renderer foundRenderer in foundRenderers) {
					foundRenderer.enabled = this._renderersEnabled;
				}
			}


			[Button("Toggle Volumes", EButtonEnableMode.Playmode)]
			public void toggleVolumes(InputAction.CallbackContext _ = default)
			{
				#if USING_UNITY_BRP
					base.logError("Built-in Render Pipeline has no Volume Component.");
				#elif USING_UNITY_URP || USING_UNITY_HDRP
					Volume[] foundVolumes = FindObjectsOfType<Volume>(this._includeInactive);


					this._volumesEnabled = !this._volumesEnabled;

					foreach (Volume foundVolume in foundVolumes) {
						foundVolume.enabled = this._volumesEnabled;
					}
				#endif
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