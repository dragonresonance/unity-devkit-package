#if ENABLE_INPUT_SYSTEM


using NaughtyAttributes;
using PossumScream.BlazingBehaviours;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine;




namespace PossumScream.CoolComponents.Input
{
	public class SingleInputActionPerformer : ScriptableBehaviour
	{
		[Header("Input")]
		[SerializeField] private InputAction _inputAction = null;


		[Header("Action")]
		[SerializeField] private UnityEvent _inputActionPerformed = null;




		public delegate void InputActionAction();
		public event InputActionAction inputActionPerform;




		#region Events


			private void Awake()
			{
				this._inputAction.performed += performInputActionEvents;
				this._inputAction.Enable();
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
				base.logInfo("Performing InputAction events...", this);
				{
					this.inputActionPerform?.Invoke();
					this._inputActionPerformed?.Invoke();
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