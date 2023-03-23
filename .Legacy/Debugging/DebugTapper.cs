using NaughtyAttributes;
using PossumScream.BlazingBehaviours;
using System.Text;
using System;
using UnityEngine.Events;
using UnityEngine;




namespace PossumScream.CoolComponents.Debugging
{
	public class DebugTapper : ScriptableOptableSingleton<DebugTapper>
	{
		[Header("Input")]
		/* 1 */ [SerializeField] private MonoBehaviour[] _tappedStatsBehaviours = {};
		/* 2 */ [SerializeField] private MonoBehaviour[] _tappedSpecsBehaviours = {};


		[Header("Settings")]
		[SerializeField] [Min(0f)] private float _minimumUpdateInterval = 0.05f;


		[Header("Output")]
		/* 1 */ [SerializeField] private UnityEvent<string> _outputStatsFields = null;
		/* 2 */ [SerializeField] private UnityEvent<string> _outputSpecsFields = null;




		private StringBuilder _composedBehavioursString = new StringBuilder();
		private StringBuilder _toStringOutput = new StringBuilder();
		private float _remainingUpdateInterval = 0f;




		#region Events


			private void Start()
			{
				printSpecsInfo();
				printStatsInfo();
			}


			private void Update()
			{
				if ((this._remainingUpdateInterval -= Time.deltaTime) <= 0f) {
					{
						printStatsInfo();
					}
					this._remainingUpdateInterval = this._minimumUpdateInterval;
				}
			}


		#endregion




		#region Controls


			[Button("Output Stats Info", EButtonEnableMode.Playmode)]
			public void printStatsInfo()
			{
				this._outputStatsFields?.Invoke(generateTappedBehavioursInfo(this._tappedStatsBehaviours));
			}


			[Button("Output Specs Info", EButtonEnableMode.Playmode)]
			public void printSpecsInfo()
			{
				this._outputSpecsFields?.Invoke(generateTappedBehavioursInfo(this._tappedSpecsBehaviours));
			}


		#endregion




		#region Actions


			private string generateTappedBehavioursInfo(MonoBehaviour[] tappedBehaviours)
			{
				this._composedBehavioursString.Clear();
				{
					foreach (MonoBehaviour tappedBehaviour in tappedBehaviours) {
						this._composedBehavioursString.AppendLine();
						this._composedBehavioursString.Append(tappedBehaviour.ToString());
					}
				}


				return this._composedBehavioursString.ToString().Substring(2, (this._composedBehavioursString.Length - 4)); // AppendLine adds 2+4 characters
			}


		#endregion




		#region Overrides


			public override string ToString()
			{
				float executionTime = Time.realtimeSinceStartup;

				TimeSpan timeSpan = TimeSpan.FromSeconds(executionTime);


				this._toStringOutput.Clear();
				{
					this._toStringOutput.AppendLine($"{Application.productName} ({Application.version})");

					this._toStringOutput.AppendLine($"ExecTime:   {timeSpan.TotalHours:0}:{timeSpan.Minutes:00}:{timeSpan.Seconds:00} ({executionTime:000.000})");
					this._toStringOutput.AppendLine($"UpdtTime:   {this._minimumUpdateInterval:0.000}");
				}


				return this._toStringOutput.ToString();
			}


		#endregion
	}
}




/*                                                                                */
/*        David Tabernero M. @ PossumScream          Copyright © 2021-2022        */
/*        https://gitlab.com/possumscream             All rights reserved.        */
/*                                                                                */