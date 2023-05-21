#if !UNITY_EDITOR && !DEVELOPMENT_BUILD
	#define LOGGING_DISABLED
#endif


using System;
using UnityEngine;
using UnityObject = UnityEngine.Object;




namespace PossumScream.Enhancements
{
	public static class HLogger
	{
		public const string EmphasisColor = "#64c8fa";
		public const string ErrorColor = "#fa6464";
		public const string ExceptionColor = "#c864fa";
		public const string InfoColor = "#fafafa";
		public const string WarningColor = "#fac864";




		#region Controls


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
				#endif
			}


			public static void LogInfo(string message, Type context)
			{
				#if !LOGGING_DISABLED
					Debug.Log(composeFormattedMessage(message, context, InfoColor));
				#endif
			}


			public static void LogInfo(string message, UnityObject context)
			{
				#if !LOGGING_DISABLED
					Debug.Log(composeFormattedMessage(message, context, InfoColor), context);
				#endif
			}




			public static void LogEmphasis(string message)
			{
				#if !LOGGING_DISABLED
					Debug.Log(message);
				#endif
			}


			public static void LogEmphasis(string message, Type context)
			{
				#if !LOGGING_DISABLED
					Debug.Log(composeFormattedMessage(message, context, EmphasisColor));
				#endif
			}


			public static void LogEmphasis(string message, UnityObject context)
			{
				#if !LOGGING_DISABLED
					Debug.Log(composeFormattedMessage(message, context, EmphasisColor), context);
				#endif
			}




			public static void LogWarning(string message)
			{
				#if !LOGGING_DISABLED
					Debug.LogWarning(message);
				#endif
			}


			public static void LogWarning(string message, Type context)
			{
				#if !LOGGING_DISABLED
					Debug.LogWarning(composeFormattedMessage(message, context, WarningColor));
				#endif
			}


			public static void LogWarning(string message, UnityObject context)
			{
				#if !LOGGING_DISABLED
					Debug.LogWarning(composeFormattedMessage(message, context, WarningColor), context);
				#endif
			}




			public static void LogError(string message)
			{
				#if !LOGGING_DISABLED
					Debug.LogError(message);
				#endif
			}


			public static void LogError(string message, Type context)
			{
				#if !LOGGING_DISABLED
					Debug.LogError(composeFormattedMessage(message, context, ErrorColor));
				#endif
			}


			public static void LogError(string message, UnityObject context)
			{
				#if !LOGGING_DISABLED
					Debug.LogError(composeFormattedMessage(message, context, ErrorColor), context);
				#endif
			}




			public static void LogException(Exception exception)
			{
				#if !LOGGING_DISABLED
					Debug.LogException(exception);
				#endif
			}


			public static void LogException(Exception exception, Type context)
			{
				#if !LOGGING_DISABLED
					Debug.LogError(composeFormattedMessage(exception.Message, context, ExceptionColor));
					Debug.LogException(exception);
				#endif
			}


			public static void LogException(Exception exception, UnityObject context)
			{
				#if !LOGGING_DISABLED
					Debug.LogError(composeFormattedMessage(exception.Message, context, ExceptionColor), context);
					Debug.LogException(exception);
				#endif
			}


		#endregion




		#region Utilities


			public static string composeFormattedMessage(string message, Type context, string color)
			{
				return $"<color={color}><b>{context.Name} → </b></color>{message}";
			}


			public static string composeFormattedMessage(string message, UnityObject context, string color)
			{
				return $"<color={color}><b>{context.name} → </b></color>{message}";
			}


		#endregion
	}
}




/*                                                                                            */
/*          ______                               _______                                      */
/*          \  __ \____  ____________  ______ ___\  ___/_____________  ____  ____ ___         */
/*          / /_/ / __ \/ ___/ ___/ / / / __ \__ \\__ \/ ___/ ___/ _ \/ __ \/ __ \__ \        */
/*         / ____/ /_/ /__  /__  / /_/ / / / / / /__/ / /__/ /  / ___/ /_/ / / / / / /        */
/*        /_/    \____/____/____/\____/_/ /_/ /_/____/\___/_/   \___/\__/_/_/ /_/ /__\        */
/*                                                                                            */
/*        Licensed under the Apache License, Version 2.0. See LICENSE.md for more info        */
/*        David Tabernero M. @ PossumScream                      Copyright © 2021-2023        */
/*        GitLab - GitHub: possumscream                            All rights reserved        */
/*        -------------------------                                  -----------------        */
/*                                                                                            */