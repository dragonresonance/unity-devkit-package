#if UNITY_NGO


using DragonResonance.Logging;
using System;
using UnityEngine;
using UnityObject = UnityEngine.Object;




namespace DragonResonance.Behaviours
{
	public abstract partial class OpossumBehaviour
	{
		[SerializeField] private ELogLevel _loggingMask = ELogLevel.Info | ELogLevel.Emphasis | ELogLevel.Warning |
		                                                  ELogLevel.Error | ELogLevel.Exception;




		#region Publics


			protected bool Log(string message = "")
			{
				return Log(message, this);
			}

			protected bool Log(string message, UnityObject context)
			{
				return LogInfo(message, context);
			}


			protected bool Info(string message = "")
			{
				return LogInfo(message, this);
			}

			protected bool LogInfo(string message = "")
			{
				return LogInfo(message, this);
			}

			protected bool LogInfo(string message, UnityObject context)
			{
				if (!_loggingMask.HasFlag(ELogLevel.Info)) return false;
				HLogger.LogInfo(message, context);
				return true;
			}


			protected bool Emphasis(string message = "")
			{
				return LogEmphasis(message, this);
			}

			protected bool LogEmphasis(string message = "")
			{
				return LogEmphasis(message, this);
			}

			protected bool LogEmphasis(string message, UnityObject context)
			{
				if (!_loggingMask.HasFlag(ELogLevel.Emphasis)) return false;
				HLogger.LogEmphasis(message, context);
				return true;
			}


			protected bool Warning(string message = "")
			{
				return LogWarning(message, this);
			}

			protected bool LogWarning(string message = "")
			{
				return LogWarning(message, this);
			}

			protected bool LogWarning(string message, UnityObject context)
			{
				if (!_loggingMask.HasFlag(ELogLevel.Warning)) return false;
				HLogger.LogWarning(message, context);
				return true;
			}


			protected bool Error(string message = "")
			{
				return LogError(message, this);
			}

			protected bool LogError(string message = "")
			{
				return LogError(message, this);
			}

			protected bool LogError(string message, UnityObject context)
			{
				if (!_loggingMask.HasFlag(ELogLevel.Error)) return false;
				HLogger.LogError(message, context);
				return true;
			}


			protected bool Exception(Exception exception)
			{
				return LogException(exception, this);
			}

			protected bool LogException(Exception exception)
			{
				return LogException(exception, this);
			}

			protected bool LogException(Exception exception, UnityObject context)
			{
				if (!_loggingMask.HasFlag(ELogLevel.Exception)) return false;
				HLogger.LogException(exception, context);
				return true;
			}


		#endregion




		#region Properties


			protected ELogLevel LoggingMask => _loggingMask;


		#endregion
	}
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
/*                  Copyright © 2021-2024. All rights reserved.                 */
/*                Licensed under the Apache License, Version 2.0.               */
/*                         See LICENSE.md for more info.                        */
/*       ________________________________________________________________       */
/*                                                                              */