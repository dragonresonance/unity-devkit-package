#if ENABLE_INPUT_SYSTEM


using DragonResonance.Behaviours;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine;




namespace DragonResonance.Enhancements
{
	[DisallowMultipleComponent]
	[RequireComponent(typeof(EventSystem))]
	public class InputSystemAutoFocus : PossumBehaviour
	{
		[SerializeField] private InputActionReference _navigation = null;


		private GameObject _lastSelected = null;




		#region Events


			private void OnEnable()
			{
				UpdateLastSelected();
				_navigation.action.performed += PerformNavigationCallback;
			}

			private void OnDisable()
			{
				_navigation.action.performed -= PerformNavigationCallback;
			}


			private void PerformNavigationCallback(InputAction.CallbackContext _)
			{
				UpdateLastSelected();
				if (!CheckIfCurrentlySelecting())
					TryFocusLastSelected();
			}


		#endregion




		#region Publics


			public bool CheckIfCurrentlySelecting()
			{
				return CheckSelectableGameobject(EventSystem.current.currentSelectedGameObject);
			}

			public static bool CheckSelectableGameobject(GameObject gameobject)
			{
				if (gameobject == null) return false;
				if (!gameobject.activeSelf) return false;
				if (!gameobject.activeInHierarchy) return false;
				if (!gameobject.TryGetComponent(out Selectable selectable)) return false;
				if (!selectable.isActiveAndEnabled) return false;
				return true;
			}


			[ContextMenu(nameof(UpdateLastSelected))]
			public void UpdateLastSelected()
			{
				Selectable selectable = null;
				if (CheckSelectableGameobject(EventSystem.current.currentSelectedGameObject)) {
					_lastSelected = EventSystem.current.currentSelectedGameObject;
					Log($"Set currently selected");
				}
				else if (CheckSelectableGameobject(_lastSelected)) {
					Log($"Current last kept");
					return;
				}
				else if (CheckSelectableGameobject(EventSystem.current.firstSelectedGameObject)) {
					_lastSelected = EventSystem.current.firstSelectedGameObject;
					Log($"Set first configured");
				}
				else if ((selectable = FindAnyObjectByType<Selectable>(FindObjectsInactive.Exclude)) != null) {
					_lastSelected = selectable.gameObject;
					Log($"Set found Selectable");
				}
				else {
					_lastSelected = null;
					Log($"No object could be set");
				}
			}


			[ContextMenu(nameof(TryFocusLastSelected))]
			public bool TryFocusLastSelected()
			{
				if (!CheckSelectableGameobject(_lastSelected.gameObject)) return false;
				EventSystem.current.SetSelectedGameObject(this._lastSelected.gameObject);
				return true;
			}


		#endregion




		#region Properties


			public GameObject LastSelected => _lastSelected;


		#endregion
	}




	#if UNITY_EDITOR
	[UnityEditor.CanEditMultipleObjects]
	[UnityEditor.CustomEditor(typeof(InputSystemAutoFocus))]
	public class InputSystemAutoFocusEditor : UnityEditor.Editor
	{
		public override bool RequiresConstantRepaint() => true;

		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();
			if (base.targets.Length > 1) return;

			InputSystemAutoFocus targetInstance = base.target as InputSystemAutoFocus;

			UnityEditor.EditorGUI.BeginDisabledGroup(true);
			UnityEditor.EditorGUILayout.ObjectField("Last Selected", targetInstance!.LastSelected, typeof(GameObject), false);
			UnityEditor.EditorGUI.EndDisabledGroup();
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