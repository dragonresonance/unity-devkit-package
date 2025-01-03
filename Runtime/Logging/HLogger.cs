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


			public static void Log(string message)
			{
				#if !LOGGING_DISABLED
					LogInfo(message);
				#endif
			}

			public static void Log(string message, Type context)
			{
				#if !LOGGING_DISABLED
					LogInfo(message, context);
				#endif
			}

			public static void Log(string message, UnityObject context)
			{
				#if !LOGGING_DISABLED
					LogInfo(message, context);
				#endif
			}




			public static void LogInfo(string message)
			{
				#if !LOGGING_DISABLED
					Debug.Log(message);
					Console.Out.WriteLine(message);
				#endif
			}

			public static void LogInfo(string message, Type context)
			{
				#if !LOGGING_DISABLED
					Debug.Log(FormatDebugMessage(message, Severity.INFO, context));
					Console.Out.WriteLine(FormatConsoleMessage(message, Severity.INFO, context));
				#endif
			}

			public static void LogInfo(string message, UnityObject context)
			{
				#if !LOGGING_DISABLED
					Debug.Log(FormatDebugMessage(message, Severity.INFO, context));
					Console.Out.WriteLine(FormatConsoleMessage(message, Severity.INFO, context));
				#endif
			}




			public static void LogEmphasis(string message)
			{
				#if !LOGGING_DISABLED
					Debug.Log(message);
					Console.Out.WriteLine(message);
				#endif
			}

			public static void LogEmphasis(string message, Type context)
			{
				#if !LOGGING_DISABLED
					Debug.Log(FormatDebugMessage(message, Severity.EMPHA, context));
					Console.Out.WriteLine(FormatConsoleMessage(message, Severity.EMPHA, context));
				#endif
			}

			public static void LogEmphasis(string message, UnityObject context)
			{
				#if !LOGGING_DISABLED
					Debug.Log(FormatDebugMessage(message, Severity.EMPHA, context));
					Console.Out.WriteLine(FormatConsoleMessage(message, Severity.EMPHA, context));
				#endif
			}




			public static void LogWarning(string message)
			{
				#if !LOGGING_DISABLED
					Debug.LogWarning(message);
					Console.Out.WriteLine(message);
				#endif
			}

			public static void LogWarning(string message, Type context)
			{
				#if !LOGGING_DISABLED
					Debug.LogWarning(FormatDebugMessage(message, Severity.WARN, context));
					Console.Out.WriteLine(FormatConsoleMessage(message, Severity.WARN, context));
				#endif
			}

			public static void LogWarning(string message, UnityObject context)
			{
				#if !LOGGING_DISABLED
					Debug.LogWarning(FormatDebugMessage(message, Severity.WARN, context));
					Console.Out.WriteLine(FormatConsoleMessage(message, Severity.WARN, context));
				#endif
			}




			public static void LogError(string message)
			{
				#if !LOGGING_DISABLED
					Debug.LogError(message);
					Console.Error.WriteLine(message);
				#endif
			}

			public static void LogError(string message, Type context)
			{
				#if !LOGGING_DISABLED
					Debug.LogError(FormatDebugMessage(message, Severity.ERROR, context));
					Console.Error.WriteLine(FormatConsoleMessage(message, Severity.ERROR, context));
				#endif
			}

			public static void LogError(string message, UnityObject context)
			{
				#if !LOGGING_DISABLED
					Debug.LogError(FormatDebugMessage(message, Severity.ERROR, context));
					Console.Error.WriteLine(FormatConsoleMessage(message, Severity.ERROR, context));
				#endif
			}




			public static void LogException(Exception exception)
			{
				#if !LOGGING_DISABLED
					Debug.LogException(exception);
					Console.Error.WriteLine(exception);
				#endif
			}

			public static void LogException(Exception exception, Type context)
			{
				#if !LOGGING_DISABLED
					Debug.LogError(FormatDebugMessage(exception.Message, Severity.EXCEP, context));
					Debug.LogException(exception);
					Console.Error.WriteLine(FormatConsoleMessage(exception.Message, Severity.EXCEP, context));
					Console.Error.WriteLine(exception);
				#endif
			}

			public static void LogException(Exception exception, UnityObject context)
			{
				#if !LOGGING_DISABLED
					Debug.LogError(FormatDebugMessage(exception.Message, Severity.EXCEP, context));
					Debug.LogException(exception);
					Console.Error.WriteLine(FormatConsoleMessage(exception.Message, Severity.EXCEP, context));
					Console.Error.WriteLine(exception);
				#endif
			}


		#endregion




		#region Privates


			private static string FormatConsoleMessage(string message, Severity type, Type context)
			{
				return $"{$"[{type}]", -6} {context.Name} → {message}";
			}

			private static string FormatConsoleMessage(string message, Severity type, UnityObject context)
			{
				return $"{$"[{type}]", -6} {context.name} → {message}";
			}


			private static string FormatDebugMessage(string message, Severity type, Type context)
			{
				return $"<color=#{(int)type:X}><b>{context.Name} → </b></color>{message}";
			}

			private static string FormatDebugMessage(string message, Severity type, UnityObject context)
			{
				return $"<color=#{(int)type:X}><b>{context.name} → </b></color>{message}";
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