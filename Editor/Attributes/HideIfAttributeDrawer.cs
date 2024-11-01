#if UNITY_EDITOR


using DragonResonance.Attributes;
using UnityEditor;
using UnityEngine;




namespace DragonResonance.Editor.Attributes
{
	[CustomPropertyDrawer(typeof(HideIfAttribute))]
	public class HideIfAttributeDrawer : PropertyDrawer
	{
		private bool ShouldShow(SerializedProperty property)
		{
			HideIfAttribute conditionAttribute = (HideIfAttribute)base.attribute;
			string conditionPath = conditionAttribute.ConditionFieldName;

			string thisPropertyPath = property.propertyPath;
			int lastPropertySeparatorIndex = thisPropertyPath.LastIndexOf('.');
			if (lastPropertySeparatorIndex > 0) {
				string containerPath = thisPropertyPath.Substring(0, lastPropertySeparatorIndex + 1);
				conditionPath = containerPath + conditionAttribute.ConditionFieldName;
			}

			SerializedProperty conditionProperty = property.serializedObject.FindProperty(conditionPath);
			if (conditionProperty == null || conditionProperty.type != "bool")
				return false;
			else
				return !conditionProperty.boolValue;
		}

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
			if (ShouldShow(property))
				return EditorGUI.GetPropertyHeight(property, label, true);
			else
				return -EditorGUIUtility.standardVerticalSpacing;
		}

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
			if(ShouldShow(property))
				EditorGUI.PropertyField(position, property, label, true);
		}
	}
}


#endif




/*                                                                              */
/*  |>  Based on the script of DMGregory @ Game Development Stack Exchange. <|  */
/*                                                                              */
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