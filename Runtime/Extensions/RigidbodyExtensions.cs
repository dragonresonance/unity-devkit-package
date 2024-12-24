using UnityEngine;


namespace DragonResonance.Extensions
{
	public static class RigidbodyExtensions
	{
		public static void SyncMovement(this Rigidbody source, Rigidbody target)
		{
			SetMovement(source, target.position, target.rotation, target.linearVelocity, target.angularVelocity);
		}

		public static void SyncPoint(this Rigidbody source, Rigidbody target)
		{
			SetPoint(source, target.position, target.rotation);
		}

		public static void SyncVelocity(this Rigidbody source, Rigidbody target)
		{
			SetVelocity(source, target.linearVelocity, target.angularVelocity);
		}


		public static void SetMovement(this Rigidbody source, Vector3 position, Quaternion rotation, Vector3 linearVelocity, Vector3 angularVelocity)
		{
			source.position = position;
			source.rotation = rotation;
			source.linearVelocity = linearVelocity;
			source.angularVelocity = angularVelocity;
		}

		public static void SetPoint(this Rigidbody source, Vector3 position, Quaternion rotation)
		{
			source.position = position;
			source.rotation = rotation;
		}

		public static void SetVelocity(this Rigidbody source, Vector3 linearVelocity, Vector3 angularVelocity)
		{
			source.linearVelocity = linearVelocity;
			source.angularVelocity = angularVelocity;
		}
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
/*                  Copyright © 2021-2024. All rights reserved.                 */
/*                Licensed under the Apache License, Version 2.0.               */
/*                         See LICENSE.md for more info.                        */
/*       ________________________________________________________________       */
/*                                                                              */