#if ENABLE_INPUT_SYSTEM


using PossumScream.Behaviours;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine;
using UnityObject = UnityEngine.Object;




namespace PossumScream.Enhancements
{
	[DisallowMultipleComponent]
	[RequireComponent(typeof(EventSystem))]
	public class InputSystemAutoFocus : PossumBehaviour
	{
		[SerializeField] private InputActionReference m_navigation = null;


		private GameObject m_lastSelected = null;




		#region Events

			private void OnEnable()
			{
				UpdateLastSelected();
				this.m_navigation.action.performed += PerformNavigationCallback;
			}

			private void OnDisable()
			{
				this.m_navigation.action.performed -= PerformNavigationCallback;
			}

		#endregion




		#region Event-Driven

			private void PerformNavigationCallback(InputAction.CallbackContext _)
			{
				if (!CheckForCurrentSelection())
					UpdateLastSelected();
				else
					FocusLastSelected();
			}

		#endregion




		#region Controls

			public bool CheckForCurrentSelection()
			{
				return (EventSystem.current.currentSelectedGameObject == null);
			}

			public void UpdateLastSelected()
			{
				GameObject selectedCandidate = null;

				if ((selectedCandidate = EventSystem.current.currentSelectedGameObject) != null) {}
				else if (this.m_lastSelected != null) {}
				else if ((selectedCandidate = FindObjectOfType<Selectable>(false).gameObject) != null) {}
				else selectedCandidate = EventSystem.current.firstSelectedGameObject;

				this.m_lastSelected = selectedCandidate;
			}

			public void FocusLastSelected()
			{
				EventSystem.current.SetSelectedGameObject(this.m_lastSelected);
			}

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