using System;
using UnityEngine;


namespace PossumScream.Mathematics
{
	[Serializable]
	public struct TransformPoint
	{
		[SerializeField] private Vector3 _position;
		[SerializeField] private Quaternion _rotation;


		#region Constructors

			public TransformPoint(Transform source)
			{
				this._position = source.position;
				this._rotation = source.rotation;
			}

		#endregion


		#region Properties

			public Vector3 Position => _position;
			public Quaternion Rotation => _rotation;
			public Vector3 Forward => _rotation * Vector3.forward;
			public Vector3 Backward => -this.Forward;
			public Vector3 Up => _rotation * Vector3.up;
			public Vector3 Down => -this.Up;
			public Vector3 Right => _rotation * Vector3.right;
			public Vector3 Left => -this.Right;

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
/*                  Copyright © 2021-2024. All rights reserved.                 */
/*                Licensed under the Apache License, Version 2.0.               */
/*                         See LICENSE.md for more info.                        */
/*       ________________________________________________________________       */
/*                                                                              */