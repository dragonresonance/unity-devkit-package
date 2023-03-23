#if ENABLE_INPUT_SYSTEM


using NaughtyAttributes;
using PossumScream.BlazingBehaviours;
using PossumScream.ExtremeExtensions;
using PossumScream.SickScripts.Calculations;
using System.Text;
using UnityEngine.InputSystem;
using UnityEngine;




namespace PossumScream.CoolComponents.Debugging
{
	public class FramerateCounter : ScriptableSceneSingleton<FramerateCounter>
	{
		[Header("Framerate Range")]
		[SerializeField] [Min(0)] private int _frameSnapshotsBeforeAnalyzing = 5;
		[SerializeField] [Min(0)] private int _maximumFramerateSnapshots = 15;
		[SerializeField] [Min(0.001f)] private float _framerateSnapshotInterval = 0.75f;
		[SerializeField] [MinMaxSlider(1, 999)] private Vector2Int _framerateCapRange = new Vector2Int(1, 999);


		[Header("Input")]
		[SerializeField] private InputAction _resetStatsInputAction = null;




		[ShowNonSerializedField] private float _latestCalculatedFramerate = 0f;
		private StringBuilder _toStringOutput = new StringBuilder();
		private float _averageCalculatedFramerate = default;
		private float _elapsedTimeInterval = default;
		private float _maximumCalculatedFramerate = default;
		private float _minimumCalculatedFramerate = default;
		private int _currentFramerateSnapshot = default;
		private int _startingSnapshotsBeforeAnalyzing = default;
		private int _takenFramerateSnapshots = default;




		#region Events


			protected override void LateAwake()
			{
				this._resetStatsInputAction.performed += resetStats;
				this._resetStatsInputAction.Enable();
				this._startingSnapshotsBeforeAnalyzing = this._frameSnapshotsBeforeAnalyzing;
			}


			private void Start()
			{
				resetStats();
			}


			private void Update()
			{
				if ((this._elapsedTimeInterval += Time.deltaTime) >= this._framerateSnapshotInterval) {
					{
						this._latestCalculatedFramerate = MathX.Framerate(this._currentFramerateSnapshot, this._elapsedTimeInterval);

						if (this._frameSnapshotsBeforeAnalyzing > 0) {
							this._frameSnapshotsBeforeAnalyzing--;
						}
						else {
							this._averageCalculatedFramerate.AddAsAverage(this._latestCalculatedFramerate, ref this._takenFramerateSnapshots, this._maximumFramerateSnapshots);

							this._maximumCalculatedFramerate = Mathf.Max(this._maximumCalculatedFramerate, this._latestCalculatedFramerate);
							this._minimumCalculatedFramerate = Mathf.Min(this._minimumCalculatedFramerate, this._latestCalculatedFramerate);
						}
					}
					this._currentFramerateSnapshot = 0;
					this._elapsedTimeInterval = 0f;
				}

				this._currentFramerateSnapshot++;
			}


			private void OnDestroy()
			{
				this._resetStatsInputAction.Disable();
				this._resetStatsInputAction.performed -= resetStats;
			}


		#endregion




		#region Controls


			[Button("Reset Stats", EButtonEnableMode.Always)]
			public void resetStats(InputAction.CallbackContext _ = default)
			{
				this._averageCalculatedFramerate = 0f;
				this._currentFramerateSnapshot = 0;
				this._elapsedTimeInterval = 0f;
				this._frameSnapshotsBeforeAnalyzing = this._startingSnapshotsBeforeAnalyzing;
				this._maximumCalculatedFramerate = this._framerateCapRange.x;
				this._minimumCalculatedFramerate = this._framerateCapRange.y;
				this._takenFramerateSnapshots = 0;
			}


		#endregion




		#region Getters and Setters


			public float averageCalculatedFramerate => this._averageCalculatedFramerate;
			public float framerateSnapshotInterval => this._framerateSnapshotInterval;
			public float latestCalculatedFramerate => this._latestCalculatedFramerate;
			public float maximumCalculatedFramerate => this._maximumCalculatedFramerate;
			public float maximumFramerateCap => this._framerateCapRange.y;
			public float minimumCalculatedFramerate => this._minimumCalculatedFramerate;
			public float minimumFramerateCap => this._framerateCapRange.x;
			public int frameSnapshotsBeforeAnalyzing => this._frameSnapshotsBeforeAnalyzing;
			public int maximumFramerateSnapshots => this._maximumFramerateSnapshots;


		#endregion




		#region Overrides


			public override string ToString()
			{
				this._toStringOutput.Clear();
				{
					this._toStringOutput.AppendLine($"DeltaTime:  {(Time.deltaTime * 1000f):0.0000}");
					this._toStringOutput.AppendLine($"CalcDTime:  {(1000f / this._latestCalculatedFramerate):0.0000}");

					this._toStringOutput.AppendLine();

					this._toStringOutput.AppendLine($"CurrFPS:    {this._latestCalculatedFramerate:000.0000}");
					this._toStringOutput.AppendLine($"MinFPS:     {this._minimumCalculatedFramerate:000.0000}");
					this._toStringOutput.AppendLine($"AvgFPS:     {this._averageCalculatedFramerate:000.0000} (T-{this._frameSnapshotsBeforeAnalyzing}:{this._takenFramerateSnapshots}/{this._maximumFramerateSnapshots})");
					this._toStringOutput.AppendLine($"MaxFPS:     {this._maximumCalculatedFramerate:000.0000}");
				}


				return this._toStringOutput.ToString();
			}


		#endregion
	}
}


#endif




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