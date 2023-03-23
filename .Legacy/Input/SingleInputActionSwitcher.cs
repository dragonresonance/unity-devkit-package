#if ENABLE_INPUT_SYSTEM


using NaughtyAttributes;
using PossumScream.BlazingBehaviours;
using PossumScream.ExtremeExtensions;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine;




namespace PossumScream.CoolComponents.Input
{
	public class SingleInputActionSwitcher : ScriptableBehaviour
	{
		[Header("Input")]
		[SerializeField] private InputAction _inputAction = null;


		[Header("Action")]
		[SerializeField] [Min(0)] private int _inputActionState = 0;
		[SerializeField] private UnityEvent[] _inputActionStatePerformers = {};




		#region Events


			private void Awake()
			{
				this._inputAction.performed += performInputActionEvents;
				this._inputAction.Enable();
			}


			private void OnValidate()
			{
				this._inputActionState = Mathf.Clamp(
					this._inputActionState,
					0,
					((this._inputActionStatePerformers.Length > 0) ? (this._inputActionStatePerformers.Length - 1) : 0));
			}


			private void OnDestroy()
			{
				this._inputAction.Disable();
				this._inputAction.performed -= performInputActionEvents;
			}


		#endregion




		#region Controls


			[Button("Perform InputAction Events", EButtonEnableMode.Playmode)]
			public void performInputActionEvents(InputAction.CallbackContext _ = default)
			{
				if (this._inputActionStatePerformers.Length > 0) {
					base.logInfo($"Performing state {this._inputActionState} InputAction events...", this);
					{
						this._inputActionStatePerformers[this._inputActionState]?.Invoke();
						this._inputActionState.IncreaseCyclically(this._inputActionStatePerformers.Length);
					}
				}
				else {
					base.logError("There are no event states.", this);
				}
			}


		#endregion
	}
}


#endif




/*                                                                                */
/*        David Tabernero M. @ PossumScream          Copyright © 2021-2022        */
/*        https://gitlab.com/possumscream             All rights reserved.        */
/*                                                                                */