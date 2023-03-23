using NaughtyAttributes;
using SimpleJSON;
using System;
using UnityEngine;




namespace PossumScream.CoolComponents.Savedata
{
	public abstract class ASavedataScriptableObject : ScriptableObject
	{
		[Header("Key")]
		[SerializeField] protected string _uid = "";




		public delegate void SavedataScriptableObjectAction();
		public event SavedataScriptableObjectAction valueChange;
		public event SavedataScriptableObjectAction valueLoad;
		public event SavedataScriptableObjectAction valueReset;
		public event SavedataScriptableObjectAction valueSave;




		#region Events


			private void OnValidate()
			{
				if (string.IsNullOrWhiteSpace(this._uid)) {
					this._uid = ASavedataScriptableObject.generateGUID();
				}

				this._uid = this._uid.Trim().ToUpper();
			}


			private void Reset()
			{
				this._uid = ASavedataScriptableObject.generateGUID().ToUpper();
			}


		#endregion




		#region Controls


			public virtual void importData(JSONObject dataObject)
			{
				return;
			}


			public virtual void exportData(out JSONObject dataObject)
			{
				dataObject = null;
				return;
			}




			public virtual void resetValue()
			{
				return;
			}




			public virtual bool equalsInitial()
			{
				return false;
			}


		#endregion




		#region Actions


			[Button("DEBUG: Invoke ValueChange Event", EButtonEnableMode.Always)]
			protected void invokeValueChangeEvent()
			{
				this.valueChange?.Invoke();
			}


			[Button("DEBUG: Invoke ValueLoad Event", EButtonEnableMode.Always)]
			protected void invokeValueLoadEvent()
			{
				this.valueLoad?.Invoke();
			}


			[Button("DEBUG: Invoke ValueSave Event", EButtonEnableMode.Always)]
			protected void invokeValueSaveEvent()
			{
				this.valueSave?.Invoke();
			}


			[Button("DEBUG: Invoke ValueReset Event", EButtonEnableMode.Always)]
			protected void invokeValueResetEvent()
			{
				this.valueReset?.Invoke();
			}


		#endregion




		#region Utilities


			public static string generateGUID()
			{
				return Guid.NewGuid().ToString();
			}


		#endregion




		#region Getters and Setters


			public string uid => this._uid;


		#endregion
	}
}




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