using NaughtyAttributes;
using PossumScream.BlazingBehaviours;
using UnityEngine;




namespace PossumScream.CoolComponents.Debugging
{
	[RequireComponent(typeof(Transform))]
	public class GizmoDraw : ScriptableBehaviour
	{
		[Header("Components")]
		[Required] [SerializeField] private Transform _transform = null;


		[Header("Debugging")]
		[SerializeField] private Color _componentColorX = Color.red;
		[SerializeField] private Color _componentColorY = Color.green;
		[SerializeField] private Color _componentColorZ = Color.blue;
		[SerializeField] private Vector3 _gizmoDistances = Vector3.one;




		#region Events


			private void OnValidate()
			{
				if (this._transform == null) {
					this._transform = GetComponent<Transform>();
				}
			}


			private void OnDrawGizmos()
			{
				Quaternion cachedRotation = this._transform.rotation;
				Vector3 cachedPosition = this._transform.position;


				/* x */Debug.DrawRay(cachedPosition, (cachedRotation * (new Vector3(this._gizmoDistances.x, 0f, 0f))), this._componentColorX);
				/* y */Debug.DrawRay(cachedPosition, (cachedRotation * (new Vector3(0f, this._gizmoDistances.y, 0f))), this._componentColorY);
				/* z */Debug.DrawRay(cachedPosition, (cachedRotation * (new Vector3(0f, 0f, this._gizmoDistances.z))), this._componentColorZ);
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