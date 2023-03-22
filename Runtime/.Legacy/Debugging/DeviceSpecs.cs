using PossumScream.BlazingBehaviours;
using System.Text;
using UnityEngine;




namespace PossumScream.CoolComponents.Debugging
{
	public class DeviceSpecs : ScriptableSceneSingleton<DeviceSpecs>
	{
		private StringBuilder _toStringOutput = new StringBuilder();




		#region Overrides


			public override string ToString()
			{
				Resolution currentMonitorResolution = Screen.currentResolution;


				this._toStringOutput.Clear();
				{
					this._toStringOutput.AppendLine($"OSVersion:  {SystemInfo.operatingSystem}");
					this._toStringOutput.AppendLine($"DevType:    {SystemInfo.deviceType}");
					this._toStringOutput.AppendLine($"Monitor:    {currentMonitorResolution.width} × {currentMonitorResolution.height} @ {currentMonitorResolution.refreshRate}");
					this._toStringOutput.AppendLine();
					this._toStringOutput.AppendLine($"ViewRes:    {Screen.width} × {Screen.height}");
					this._toStringOutput.AppendLine($"Quality:    {QualitySettings.GetQualityLevel()} ({QualitySettings.names[QualitySettings.GetQualityLevel()]})");
					this._toStringOutput.AppendLine();
					this._toStringOutput.AppendLine($"CPUModel:   {SystemInfo.processorType}");
					this._toStringOutput.AppendLine($"CPUCores:   {SystemInfo.processorCount} @ {SystemInfo.processorFrequency}");
					this._toStringOutput.AppendLine();
					this._toStringOutput.AppendLine($"GPUModel:   {SystemInfo.graphicsDeviceVendor} {SystemInfo.graphicsDeviceName}");
					this._toStringOutput.AppendLine($"GPUVersion: {SystemInfo.graphicsDeviceVersion}");
					this._toStringOutput.AppendLine($"GPUMemSize: {SystemInfo.graphicsMemorySize}");
					this._toStringOutput.AppendLine($"ShaderLvl:  {SystemInfo.graphicsShaderLevel}");
					this._toStringOutput.AppendLine($"MaxTexSize: {SystemInfo.maxTextureSize}");
					this._toStringOutput.AppendLine($"MaxCmapSiz: {SystemInfo.maxCubemapSize}");
					this._toStringOutput.AppendLine();
					this._toStringOutput.AppendLine($"RAMSize:    {SystemInfo.systemMemorySize}");
				}


				return this._toStringOutput.ToString();
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