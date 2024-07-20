#if ENABLE_INPUT_SYSTEM


using DragonResonance.Behaviours;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine;
using UnityObject = UnityEngine.Object;

#if UNITY_EDITOR
using UnityEditor;
#endif




namespace DragonResonance.Enhancements
{
	[DisallowMultipleComponent]
	[RequireComponent(typeof(EventSystem))]
	public class InputSystemAutoFocus : PossumBehaviour
	{
		[SerializeField] private InputActionReference _navigation = null;


		private Selectable _lastSelected = null;




		#region Events


			private void OnEnable()
			{
				UpdateLastSelected();
				this._navigation.action.performed += PerformNavigationCallback;
			}

			private void OnDisable()
			{
				this._navigation.action.performed -= PerformNavigationCallback;
			}


			private void PerformNavigationCallback(InputAction.CallbackContext _)
			{
				UpdateLastSelected();
				if (!IsCurrentlySelecting)
					TryFocusLastSelected();
			}


		#endregion




		#region Publics


			[ContextMenu(nameof(UpdateLastSelected))]
			public void UpdateLastSelected()
			{
				if (EventSystem.current.currentSelectedGameObject != null) {
					this._lastSelected = EventSystem.current.currentSelectedGameObject.GetComponent<Selectable>();
					Log($"Set currently selected");
				}

				if (this._lastSelected != null) return;

				if (EventSystem.current.firstSelectedGameObject != null) {
					this._lastSelected = EventSystem.current.firstSelectedGameObject.GetComponent<Selectable>();
					Log($"Set first configured");
				}
				else if ((this._lastSelected = FindAnyObjectByType<Selectable>(FindObjectsInactive.Exclude)) != null) {
					Log($"Set found Selectable");
				}
				else {
					Log($"No object could be set");
				}
			}


			[ContextMenu(nameof(TryFocusLastSelected))]
			public bool TryFocusLastSelected()
			{
				if (this._lastSelected == null) return false;
				EventSystem.current.SetSelectedGameObject(this._lastSelected.gameObject);
				return true;
			}


		#endregion




		#region Properties


			public Selectable LastSelected => _lastSelected;
			public static bool IsCurrentlySelecting => EventSystem.current.currentSelectedGameObject != null;


		#endregion
	}




	#if UNITY_EDITOR
	[CanEditMultipleObjects]
	[CustomEditor(typeof(InputSystemAutoFocus))]
	public class InputSystemAutoFocusEditor : UnityEditor.Editor
	{
		public override bool RequiresConstantRepaint() => true;

		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();
			if (base.targets.Length > 1) return;

			InputSystemAutoFocus targetInstance = base.target as InputSystemAutoFocus;

			EditorGUI.BeginDisabledGroup(true);
			EditorGUILayout.ObjectField("Last Selected", targetInstance!.LastSelected, typeof(Selectable), false);
			EditorGUI.EndDisabledGroup();
		}
	}
	#endif
}


#endif




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