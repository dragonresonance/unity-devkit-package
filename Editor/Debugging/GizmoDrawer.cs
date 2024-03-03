using PossumScream.Constants;
using PossumScream.Mathematics;
using UnityEngine;

#if UNITY_EDITOR
using PossumScream.Editor.Editors;
using UnityEditor;
#endif




namespace PossumScream.Editor.Debugging
{
	#if UNITY_EDITOR
	[CustomEditor(typeof(GizmoDrawer))]
	public class GizmoDrawEditor : ScriptlessEditor { }
	#endif




	[RequireComponent(typeof(Transform))]
	public class GizmoDrawer : MonoBehaviour
	{
		[SerializeField] private bool _visible = true;

		[SerializeField] private Vector3Int _positiveAxeFactors = Vector3Int.one;
		[SerializeField] private Vector3Int _negativeAxeFactors = Vector3Int.zero;

		[SerializeField] [Min(0f)] private float _gizmoSize = 1f;
		[SerializeField] [Range(0f, 1f)] private float _arrowHeadPercentage = 0.15f;

		[SerializeField] private Color _xAxisColor = MoreColors.pastelred;
		[SerializeField] private Color _yAxisColor = MoreColors.pastelgreen;
		[SerializeField] private Color _zAxisColor = MoreColors.pastelblue;




		#region Events


			#if UNITY_EDITOR
			private void OnDrawGizmos()
			{
				if (!_visible) return;


				TransformPoint transformPoint = new(base.transform);
				Vector3 xNegativeGizmoEnd = transformPoint.position - (transformPoint.right * _gizmoSize);
				Vector3 xPositiveGizmoEnd = transformPoint.position + (transformPoint.right * _gizmoSize);
				Vector3 yNegativeGizmoEnd = transformPoint.position - (transformPoint.up * _gizmoSize);
				Vector3 yPositiveGizmoEnd = transformPoint.position + (transformPoint.up * _gizmoSize);
				Vector3 zNegativeGizmoEnd = transformPoint.position - (transformPoint.forward * _gizmoSize);
				Vector3 zPositiveGizmoEnd = transformPoint.position + (transformPoint.forward * _gizmoSize);


				// +X
				Gizmos.color = _xAxisColor;
				if (_positiveAxeFactors.x != 0) {
					Vector3 xPositiveVectorEnd;

					// Body
					Gizmos.DrawLine(
						transformPoint.position,
						(xPositiveVectorEnd = Vector3.LerpUnclamped(
							transformPoint.position,
							xPositiveGizmoEnd,
							_positiveAxeFactors.x)));

					// Head
					Gizmos.DrawLine(
						xPositiveVectorEnd,
						Vector3.LerpUnclamped(
							xPositiveVectorEnd,
							zPositiveGizmoEnd,
							_arrowHeadPercentage));
					Gizmos.DrawLine(
						xPositiveVectorEnd,
						Vector3.LerpUnclamped(
							xPositiveVectorEnd,
							zNegativeGizmoEnd,
							_arrowHeadPercentage));
				}


				// -X
				Gizmos.color = _xAxisColor;
				if (_negativeAxeFactors.x != 0) {
					Vector3 xNegativeVectorEnd;

					// Body
					Gizmos.DrawLine(
						transformPoint.position,
						(xNegativeVectorEnd = Vector3.LerpUnclamped(
							transformPoint.position,
							xNegativeGizmoEnd,
							_negativeAxeFactors.x)));

					// Head
					Gizmos.DrawLine(
						xNegativeVectorEnd,
						Vector3.LerpUnclamped(
							xNegativeVectorEnd,
							zPositiveGizmoEnd,
							_arrowHeadPercentage));
					Gizmos.DrawLine(
						xNegativeVectorEnd,
						Vector3.LerpUnclamped(
							xNegativeVectorEnd,
							zNegativeGizmoEnd,
							_arrowHeadPercentage));
				}


				// +Y
				Gizmos.color = _yAxisColor;
				if (_positiveAxeFactors.y != 0) {
					Vector3 yPositiveVectorEnd;

					// Body
					Gizmos.DrawLine(
						transformPoint.position,
						(yPositiveVectorEnd = Vector3.LerpUnclamped(
							transformPoint.position,
							yPositiveGizmoEnd,
							_positiveAxeFactors.y)));

					// Head
					Gizmos.DrawLine(
						yPositiveVectorEnd,
						Vector3.LerpUnclamped(
							yPositiveVectorEnd,
							xPositiveGizmoEnd,
							_arrowHeadPercentage));
					Gizmos.DrawLine(
						yPositiveVectorEnd,
						Vector3.LerpUnclamped(
							yPositiveVectorEnd,
							xNegativeGizmoEnd,
							_arrowHeadPercentage));
				}


				// -Y
				Gizmos.color = _yAxisColor;
				if (_negativeAxeFactors.y != 0) {
					Vector3 yNegativeVectorEnd;

					// Body
					Gizmos.DrawLine(
						transformPoint.position,
						(yNegativeVectorEnd = Vector3.LerpUnclamped(
							transformPoint.position,
							yNegativeGizmoEnd,
							_negativeAxeFactors.y)));

					// Head
					Gizmos.DrawLine(
						yNegativeVectorEnd,
						Vector3.LerpUnclamped(
							yNegativeVectorEnd,
							xPositiveGizmoEnd,
							_arrowHeadPercentage));
					Gizmos.DrawLine(
						yNegativeVectorEnd,
						Vector3.LerpUnclamped(
							yNegativeVectorEnd,
							xNegativeGizmoEnd,
							_arrowHeadPercentage));
				}


				// +Z
				Gizmos.color = _zAxisColor;
				if (_positiveAxeFactors.z != 0) {
					Vector3 zPositiveVectorEnd;

					// Body
					Gizmos.DrawLine(
						transformPoint.position,
						(zPositiveVectorEnd = Vector3.LerpUnclamped(
							transformPoint.position,
							zPositiveGizmoEnd,
							_positiveAxeFactors.z)));

					// Head
					Gizmos.DrawLine(
						zPositiveVectorEnd,
						Vector3.LerpUnclamped(
							zPositiveVectorEnd,
							yPositiveGizmoEnd,
							_arrowHeadPercentage));
					Gizmos.DrawLine(
						zPositiveVectorEnd,
						Vector3.LerpUnclamped(
							zPositiveVectorEnd,
							yNegativeGizmoEnd,
							_arrowHeadPercentage));
				}


				// -Z
				Gizmos.color = _zAxisColor;
				if (_negativeAxeFactors.z != 0) {
					Vector3 zNegativeVectorEnd;

					// Body
					Gizmos.DrawLine(
						transformPoint.position,
						(zNegativeVectorEnd = Vector3.LerpUnclamped(
							transformPoint.position,
							zNegativeGizmoEnd,
							_negativeAxeFactors.z)));

					// Head
					Gizmos.DrawLine(
						zNegativeVectorEnd,
						Vector3.LerpUnclamped(
							zNegativeVectorEnd,
							yPositiveGizmoEnd,
							_arrowHeadPercentage));
					Gizmos.DrawLine(
						zNegativeVectorEnd,
						Vector3.LerpUnclamped(
							zNegativeVectorEnd,
							yNegativeGizmoEnd,
							_arrowHeadPercentage));
				}
			}
			#endif


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
/*        David Tabernero M. @ PossumScream                      Copyright © 2021-2024        */
/*        GitLab - GitHub: possumscream                            All rights reserved        */
/*        - - - - - - - - - - - - -                                  - - - - - - - - -        */
/*                                                                                            */