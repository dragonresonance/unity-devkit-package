using DragonResonance.Logging;
using System.Runtime.CompilerServices;
using System;
using UnityEngine;
using UnityObject = UnityEngine.Object;




namespace DragonResonance.Behaviours
{
	public abstract partial class PossumBehaviour // Logging
	{
		[SerializeField] private ELogLevel _loggingMask = ELogLevel.Info | ELogLevel.Emphasis | ELogLevel.Warning | ELogLevel.Error | ELogLevel.Exception;




		#region Publics


			protected bool Log(string message = "", [CallerMemberName] string callerMember = null)
			{
				if (!_loggingMask.HasFlag(ELogLevel.Info)) return false;
				HLogger.Log(message, $"{this.name}::{callerMember}", this);
				return true;
			}


			protected bool Info(string message = "", [CallerMemberName] string callerMember = null) => LogInfo(message, callerMember);
			protected bool LogInfo(string message = "", [CallerMemberName] string callerMember = null)
			{
				if (!_loggingMask.HasFlag(ELogLevel.Info)) return false;
				HLogger.LogInfo(message, $"{this.name}::{callerMember}", this);
				return true;
			}


			protected bool Emphasis(string message = "", [CallerMemberName] string callerMember = null) => LogEmphasis(message, callerMember);
			protected bool LogEmphasis(string message = "", [CallerMemberName] string callerMember = null)
			{
				if (!_loggingMask.HasFlag(ELogLevel.Emphasis)) return false;
				HLogger.LogEmphasis(message, $"{this.name}::{callerMember}", this);
				return true;
			}


			protected bool Warning(string message = "", [CallerMemberName] string callerMember = null) => LogWarning(message, callerMember);
			protected bool LogWarning(string message = "", [CallerMemberName] string callerMember = null)
			{
				if (!_loggingMask.HasFlag(ELogLevel.Warning)) return false;
				HLogger.LogWarning(message, $"{this.name}::{callerMember}", this);
				return true;
			}


			protected bool Error(string message = "", [CallerMemberName] string callerMember = null) => LogError(message, callerMember);
			protected bool LogError(string message = "", [CallerMemberName] string callerMember = null)
			{
				if (!_loggingMask.HasFlag(ELogLevel.Error)) return false;
				HLogger.LogError(message, $"{this.name}::{callerMember}", this);
				return true;
			}


			protected bool Exception(Exception exception, [CallerMemberName] string callerMember = null) => LogException(exception, callerMember);
			protected bool LogException(Exception exception, [CallerMemberName] string callerMember = null)
			{
				if (!_loggingMask.HasFlag(ELogLevel.Exception)) return false;
				HLogger.LogException(exception, $"{this.name}::{callerMember}", this);
				return true;
			}


		#endregion




		#region Properties


			protected ELogLevel LoggingMask => _loggingMask;


		#endregion
	}
}




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