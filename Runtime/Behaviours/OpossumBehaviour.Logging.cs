#if UNITY_NGO


using PossumScream.Enhancements;
using System;
using UnityEngine;
using UnityObject = UnityEngine.Object;




namespace PossumScream.Behaviours
{
	public abstract partial class OpossumBehaviour
	{
		[SerializeField] private bool _logging = true;




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
				if (!this._logging) return false;
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
				if (!this._logging) return false;
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
				if (!this._logging) return false;
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
				if (!this._logging) return false;
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
				if (!this._logging) return false;
				HLogger.LogException(exception, context);
				return true;
			}


		#endregion




		#region Properties


			protected bool Logging => _logging;


		#endregion
	}
}


#endif




/*                                                                                            */
/*          ______                               _______                                      */
/*          \  __ \____  ____________  ______ ___\  ___/_____________  ____  ____ ___         */
/*          / /_/ / __ \/ ___/ ___/ / / / __ \__ \\__ \/ ___/ ___/ _ \/ __ \/ __ \__ \        */
/*         / ____/ /_/ /__  /__  / /_/ / / / / / /__/ / /__/ /  / ___/ /_/ / / / / / /        */
/*        /_/    \____/____/____/\____/_/ /_/ /_/____/\___/_/   \___/\__/_/_/ /_/ /__\        */
/*                                                                                            */
/*        Licensed under the Apache License, Version 2.0. See LICENSE.md for more info        */
/*        David Tabernero M. @ PossumScream                      Copyright © 2021-2024        */
/*        GitLab - GitHub: possumscream                            All rights reserved        */
/*        - - - - - - - - - - - - -                                  - - - - - - - - -        */
/*                                                                                            */