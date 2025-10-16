#if ENABLE_INPUT_SYSTEM


using DragonResonance.Attributes;
using DragonResonance.Behaviours;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine;


[RequireComponent(typeof(Button))]
public class ButtonInputShortcut : PossumBehaviour
{
	[SerializeField] private bool _autoEnableInput = false;
	[SerializeField] private bool _autoDisableInput = false;
	[SerializeField] private bool _invokeEventsDirectly = false;
	[SerializeField] private bool _useInputActionReference = false;
	[HideIf(nameof(_useInputActionReference))] [SerializeField] private InputAction _clickInput = null;
	[ShowIf(nameof(_useInputActionReference))] [SerializeField] private InputActionReference _clickInputReference = null;


	#region Events

		private void OnEnable()
		{
			if (!_useInputActionReference) {
				_clickInput.performed += OnClickInputPerformed;
				if (_autoEnableInput) _clickInput.Enable();
			}
			else {
				_clickInputReference.action.performed += OnClickInputPerformed;
				if (_autoEnableInput) _clickInputReference.action.Enable();
			}
		}

		private void OnDisable()
		{
			if (!_useInputActionReference) {
				if (_autoDisableInput) _clickInput.Disable();
				_clickInput.performed -= OnClickInputPerformed;
			}
			else {
				if (_autoDisableInput) _clickInputReference.action.Disable();
				_clickInputReference.action.performed -= OnClickInputPerformed;
			}
		}


		private void OnClickInputPerformed(InputAction.CallbackContext _)
		{
			Button button = GetComponent<Button>();
			if (!_invokeEventsDirectly)
				ExecuteEvents.Execute(button.gameObject, new BaseEventData(EventSystem.current), ExecuteEvents.submitHandler);
			else
				button.onClick.Invoke();
		}

	#endregion
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
/*                  Copyright © 2021-2025. All rights reserved.                 */
/*                Licensed under the Apache License, Version 2.0.               */
/*                         See LICENSE.md for more info.                        */
/*       ________________________________________________________________       */
/*                                                                              */