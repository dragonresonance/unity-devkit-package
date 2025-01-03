#if UNITY_EDITOR


using PossumScream.Constants;
using PossumScream.Editor.Editors;
using PossumScream.Mathematics;
using UnityEditor;
using UnityEngine;




namespace PossumScream.Editor.Debugging
{
	[CustomEditor(typeof(GizmoDrawer))]
	public class GizmoDrawEditor : ScriptlessEditor { }




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


			private void OnDrawGizmos()
			{
				if (!_visible) return;


				TransformPoint transformPoint = new(base.transform);
				Vector3 xNegativeGizmoEnd = transformPoint.Position - (transformPoint.Right * _gizmoSize);
				Vector3 xPositiveGizmoEnd = transformPoint.Position + (transformPoint.Right * _gizmoSize);
				Vector3 yNegativeGizmoEnd = transformPoint.Position - (transformPoint.Up * _gizmoSize);
				Vector3 yPositiveGizmoEnd = transformPoint.Position + (transformPoint.Up * _gizmoSize);
				Vector3 zNegativeGizmoEnd = transformPoint.Position - (transformPoint.Forward * _gizmoSize);
				Vector3 zPositiveGizmoEnd = transformPoint.Position + (transformPoint.Forward * _gizmoSize);


				// +X
				Gizmos.color = _xAxisColor;
				if (_positiveAxeFactors.x != 0) {
					Vector3 xPositiveVectorEnd;

					// Body
					Gizmos.DrawLine(
						transformPoint.Position,
						(xPositiveVectorEnd = Vector3.LerpUnclamped(
							transformPoint.Position,
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
						transformPoint.Position,
						(xNegativeVectorEnd = Vector3.LerpUnclamped(
							transformPoint.Position,
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
						transformPoint.Position,
						(yPositiveVectorEnd = Vector3.LerpUnclamped(
							transformPoint.Position,
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
						transformPoint.Position,
						(yNegativeVectorEnd = Vector3.LerpUnclamped(
							transformPoint.Position,
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
						transformPoint.Position,
						(zPositiveVectorEnd = Vector3.LerpUnclamped(
							transformPoint.Position,
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
						transformPoint.Position,
						(zNegativeVectorEnd = Vector3.LerpUnclamped(
							transformPoint.Position,
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


		#endregion
	}
}


#endif




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