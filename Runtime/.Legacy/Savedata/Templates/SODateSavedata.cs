using NaughtyAttributes;
using SimpleJSON;
using System;
using UnityEngine;




namespace PossumScream.CoolComponents.Savedata
{
	[CreateAssetMenu(menuName = "PossumScream/Components/Savedata/Date Savedata File", fileName = "New DateSavedata")]
	public class SODateSavedata : ASavedataScriptableObject
	{
		[Header("Value")]
		/* 0 */ [SerializeField] [Min(0)] private long _initial = default;
		/* 9 */ [SerializeField] [Min(0)] private long _value = default;




		#region Controls


			public override void importData(JSONObject dataObject)
			{
				{
					this.value = dataObject["value"];
				}
				base.invokeValueLoadEvent();
			}


			public override void exportData(out JSONObject dataObject)
			{
				dataObject = new JSONObject();
				{
					dataObject.Add("value", this._value);
				}
				base.invokeValueSaveEvent();
			}




			[Button("Reset Value", EButtonEnableMode.Always)]
			public override void resetValue()
			{
				{
					this.value = this._initial;
				}
				base.invokeValueResetEvent();
			}




			public override bool equalsInitial()
			{
				return (this._initial == this._value);
			}




			[Button("Set Value to Now", EButtonEnableMode.Always)]
			public void setValueToNow()
			{
				this.value = DateTimeOffset.Now.ToUnixTimeSeconds();
			}


			public string getISODate()
			{
				return DateTimeOffset.FromUnixTimeSeconds(this._value).ToString("yyyy-MM-dd T HH:mm:ss Z");
			}


		#endregion




		#region Getters and Setters


			public long initial
			{
				get => this._initial;
			}


			public long value
			{
				get => this._value;
				set
				{
					{
						this._value = value;
					}
					base.invokeValueChangeEvent();
				}
			}


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