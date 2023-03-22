#if ENABLE_INPUT_SYSTEM


using NaughtyAttributes;
using PossumScream.BlazingBehaviours;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine;




namespace PossumScream.CoolComponents.Input
{
	public class InputDeviceSwitchingManager : ScriptableSceneSingleton<InputDeviceSwitchingManager>
	{
		[Header("Input")]
		[SerializeField] private InputAction _switchInputDevice = null;


		[Header("Callback")]
		[SerializeField] private UnityEvent _inputDeviceSwitched = null;




		[ShowNonSerializedField] private int _currentDeviceId = -1;
		[ShowNonSerializedField] private string _currentDeviceName = "";




		public delegate void ControlSchemeAction();
		public event ControlSchemeAction inputDeviceSwitch;




		#region Events


			protected override void LateAwake()
			{
				this._switchInputDevice.performed += OnDeviceActionPerformed;
				this._switchInputDevice.Enable();
			}


			private void OnDestroy()
			{
				this._switchInputDevice.Disable();
				this._switchInputDevice.performed -= OnDeviceActionPerformed;
			}




			private void OnDeviceActionPerformed(InputAction.CallbackContext deviceCallbackContext)
			{
				InputDevice device = deviceCallbackContext.action.activeControl.device;


				if (!checkIfCurrentDevice(device)) {
					switchDevice(device);
				}
			}


		#endregion




		#region Controls


			public bool checkIfCurrentDevice(InputAction.CallbackContext deviceCallbackContext)
			{
				return checkIfCurrentDevice(deviceCallbackContext.action.activeControl.device);
			}


			public bool checkIfCurrentDevice(InputDevice inputDevice)
			{
				return (inputDevice.deviceId == this._currentDeviceId);
			}




			public void switchDevice(InputAction.CallbackContext newDeviceCallbackContext)
			{
				switchDevice(newDeviceCallbackContext.action.activeControl.device);
			}


			public void switchDevice(InputDevice newInputDevice)
			{
				switchDevice(newInputDevice.deviceId, newInputDevice.displayName);
			}


			public void switchDevice(int newDeviceId, string newDeviceName)
			{
				base.logInfo($"Switching device to [{newDeviceName}]:[ID.{newDeviceId}]...", this);
				{
					this._currentDeviceId = newDeviceId;
					this._currentDeviceName = newDeviceName;
				}
				{
					this.inputDeviceSwitch?.Invoke();
					this._inputDeviceSwitched?.Invoke();
				}
			}


		#endregion




		#region Getters and Setters


			public int currentDeviceId => this._currentDeviceId;
			public string currentDeviceName => this._currentDeviceName;


		#endregion




		#region Overrides


			public override string ToString()
			{
				return $"CurrentDevice: [{this._currentDeviceName}]:[ID.{this._currentDeviceId}]";
			}


		#endregion
	}
}


#endif




/*                                                                                */
/*        David Tabernero M. @ PossumScream          Copyright © 2021-2022        */
/*        https://gitlab.com/possumscream             All rights reserved.        */
/*                                                                                */