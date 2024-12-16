#if UNITY_EDITOR


using UnityEditor;
using UnityEngine;
using System;


namespace DragonResonance.Editor.Attributes
{
	public class ADropdownArrayAttributeDrawer : PropertyDrawer
	{
		protected virtual string[] GetItems() => Array.Empty<string>();


		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			string[] items = GetItems();

			if (items.Length == 0) {
				EditorGUI.HelpBox(position, $"{this.GetType().Name} has zero items", MessageType.Warning);
				return;
			}

			int currentIndex = Mathf.Max(0, Array.IndexOf(items, property.stringValue));
			int selectedIndex = EditorGUI.Popup(position, label.text, currentIndex, items);

			if (selectedIndex != currentIndex)
				property.stringValue = items[selectedIndex];
		}
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
/*                  Copyright © 2021-2024. All rights reserved.                 */
/*                Licensed under the Apache License, Version 2.0.               */
/*                         See LICENSE.md for more info.                        */
/*       ________________________________________________________________       */
/*                                                                              */