using UnityEngine;




namespace PossumScream.Mathematics
{
	public readonly struct TransformPoint
	{
		private readonly Quaternion _rotation;
		private readonly Vector3 _backward;
		private readonly Vector3 _down;
		private readonly Vector3 _forward;
		private readonly Vector3 _left;
		private readonly Vector3 _position;
		private readonly Vector3 _right;
		private readonly Vector3 _up;




		#region Constructors


			public TransformPoint(Transform sourceTransform)
			{
				this._forward = sourceTransform.forward;
				this._position = sourceTransform.position;
				this._right = sourceTransform.right;
				this._rotation = sourceTransform.rotation;
				this._up = sourceTransform.up;

				this._backward = -this._forward;
				this._down = -this._up;
				this._left = -this._right;
			}


		#endregion




		#region Getters and Setters


			public Quaternion rotation => this._rotation;
			public Vector3 backward => this._backward;
			public Vector3 down => this._down;
			public Vector3 forward => this._forward;
			public Vector3 left => this._left;
			public Vector3 position => this._position;
			public Vector3 right => this._right;
			public Vector3 up => this._up;


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