#if ENABLE_INPUT_SYSTEM


using PossumScream.Behaviours;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine;
using UnityObject = UnityEngine.Object;

#if UNITY_EDITOR
using UnityEditor;
#endif




namespace PossumScream.Enhancements
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
				if (IsCurrentlySelecting) {
					//
					UpdateLastSelected();
				}
				else {
					//
					UpdateLastSelected();
					FocusLastSelected();
				}
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
				else if ((this._lastSelected = FindObjectOfType<Selectable>(false)) != null) {
					Log($"Set found Selectable");
				}
				else {
					Log($"No object could be set");
				}
			}


			[ContextMenu(nameof(FocusLastSelected))]
			public void FocusLastSelected()
			{
				EventSystem.current.SetSelectedGameObject(this._lastSelected.gameObject);
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