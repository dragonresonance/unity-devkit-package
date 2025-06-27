using System;
using UnityEngine;
using UnityObject = UnityEngine.Object;




namespace DragonResonance.Logging
{
	public static class HLogger
	{
		#region Enums


			public enum Severity
			{
				INFO = 0xfafafa,
				EMPHA = 0x64c8fa,
				WARN = 0xfac864,
				ERROR = 0xfa6464,
				EXCEP = 0xc864fa,
			}


		#endregion




		#region Publics


			public static void Log(string message) => LogInfo(message);
			public static void Log(string message, Type context) => Log(message, context.Name);
			public static void Log(string message, UnityObject context) => Log(message, context.name, context);
			public static void Log(string message, string caller, UnityObject context = null) => LogInfo(message, caller, context);


			public static void LogInfo(string message)
			{
				#if !LOGGING_DISABLED
					Debug.Log(message);
					Console.Out.WriteLine(message);
				#endif
			}
			public static void LogInfo(string message, Type context) => LogInfo(message, context.Name);
			public static void LogInfo(string message, UnityObject context) => LogInfo(message, context.name, context);
			public static void LogInfo(string message, string caller, UnityObject context = null)
			{
				#if !LOGGING_DISABLED
					Debug.Log(FormatDebugMessage(message, Severity.INFO, caller), context);
					Console.Out.WriteLine(FormatConsoleMessage(message, Severity.INFO, caller));
				#endif
			}


			public static void LogEmphasis(string message)
			{
				#if !LOGGING_DISABLED
					Debug.Log(message);
					Console.Out.WriteLine(message);
				#endif
			}
			public static void LogEmphasis(string message, Type context) => LogEmphasis(message, context.Name);
			public static void LogEmphasis(string message, UnityObject context) => LogEmphasis(message, context.name, context);
			public static void LogEmphasis(string message, string caller, UnityObject context = null)
			{
				#if !LOGGING_DISABLED
					Debug.Log(FormatDebugMessage(message, Severity.EMPHA, caller), context);
					Console.Out.WriteLine(FormatConsoleMessage(message, Severity.EMPHA, caller));
				#endif
			}


			public static void LogWarning(string message)
			{
				#if !LOGGING_DISABLED
					Debug.LogWarning(message);
					Console.Out.WriteLine(message);
				#endif
			}
			public static void LogWarning(string message, Type context) => LogWarning(message, context.Name);
			public static void LogWarning(string message, UnityObject context) => LogWarning(message, context.name, context);
			public static void LogWarning(string message, string caller, UnityObject context = null)
			{
				#if !LOGGING_DISABLED
					Debug.LogWarning(FormatDebugMessage(message, Severity.WARN, caller), context);
					Console.Out.WriteLine(FormatConsoleMessage(message, Severity.WARN, caller));
				#endif
			}


			public static void LogError(string message)
			{
				#if !LOGGING_DISABLED
					Debug.LogError(message);
					Console.Error.WriteLine(message);
				#endif
			}
			public static void LogError(string message, Type context) => LogError(message, context.Name);
			public static void LogError(string message, UnityObject context) => LogError(message, context.name, context);
			public static void LogError(string message, string caller, UnityObject context = null)
			{
				#if !LOGGING_DISABLED
					Debug.LogError(FormatDebugMessage(message, Severity.ERROR, caller), context);
					Console.Error.WriteLine(FormatConsoleMessage(message, Severity.ERROR, caller));
				#endif
			}


			public static void LogException(Exception exception)
			{
				#if !LOGGING_DISABLED
					Debug.LogException(exception);
					Console.Error.WriteLine(exception);
				#endif
			}
			public static void LogException(Exception exception, Type context) => LogException(exception, context.Name);
			public static void LogException(Exception exception, UnityObject context) => LogException(exception, context.name, context);
			public static void LogException(Exception exception, string caller, UnityObject context = null)
			{
				#if !LOGGING_DISABLED
					Debug.LogError(FormatDebugMessage(exception.Message, Severity.EXCEP, caller), context);
					Debug.LogException(exception, context);
					Console.Error.WriteLine(FormatConsoleMessage(exception.Message, Severity.EXCEP, caller));
					Console.Error.WriteLine(exception);
				#endif
			}


		#endregion




		#region Privates


			private static string FormatConsoleMessage(string message, Severity severity, string caller)
			{
				return $"{$"[{severity}]", -6} {caller} → {message}";
			}

			private static string FormatDebugMessage(string message, Severity severity, string caller)
			{
				return $"<color=#{(int)severity:X}><b>{caller} → </b></color>{message}";
			}


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