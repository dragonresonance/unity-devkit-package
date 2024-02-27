#if UNITY_EDITOR


using PossumScream.Constants;
using PossumScream.Editor.Editors;
using UnityEditor;
using UnityEngine;




namespace PossumScream.Editor.Debugging
{
	[CustomEditor(typeof(GizmoPincher))]
	public class GizmoPincherEditor : ScriptlessEditor { }




	[RequireComponent(typeof(Transform))]
	public class GizmoPincher : MonoBehaviour
	{
		[SerializeField] [Min(0f)] private float _forceFactor = 1f;
		[SerializeField] private Color _lineColor = MoreColors.pastellightgray;
		[SerializeField] private ForceMode _forceMode = ForceMode.Force;
		[SerializeField] private Rigidbody[] _bodies = {};




		#region Events


			private void FixedUpdate()
			{
				foreach (Rigidbody body in this._bodies) {
					Vector3 forceVector = base.transform.position - body.transform.position;
					body.AddForce((forceVector * this._forceFactor), this._forceMode);
				}
			}


			private void OnDrawGizmos()
			{
				Gizmos.color = this._lineColor;
				foreach (Rigidbody body in this._bodies) {
					Gizmos.DrawLine(body.transform.position, base.transform.position);
				}
			}


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
/*        David Tabernero M. @ PossumScream                      Copyright © 2021-2023        */
/*        GitLab - GitHub: possumscream                            All rights reserved        */
/*        -------------------------                                  -----------------        */
/*                                                                                            */