#if UNITY_EDITOR


using DragonResonance.Attributes;
using UnityEditor;
using UnityEngine;


namespace DragonResonance.Editor.Attributes
{
	[CustomPropertyDrawer(typeof(SpritePreviewAttribute))]
	public class SpritePreviewDrawer : PropertyDrawer
	{
		private const int SPACING = 4;


		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			SpritePreviewAttribute spritePreviewAttribute = (SpritePreviewAttribute)base.attribute;

			// Split in two: left for field, right for preview
			Rect fieldRect = new(
				position.x,
				position.y,
				position.width - spritePreviewAttribute.Size - SPACING,
				position.height);
			Rect previewRect = new(
				position.x + position.width - spritePreviewAttribute.Size,
				position.y + PREVIEW_VERTICAL_OFFSET,
				spritePreviewAttribute.Size,
				spritePreviewAttribute.Size);

			EditorGUI.PropertyField(fieldRect, property, label);
			if (property.objectReferenceValue is Sprite sprite) {
				Texture2D texture = AssetPreview.GetAssetPreview(sprite);
				if (texture != null)
					GUI.DrawTexture(previewRect, texture, ScaleMode.ScaleToFit);
			}
		}

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label) =>
			Mathf.Max(EditorGUIUtility.singleLineHeight, ((SpritePreviewAttribute)base.attribute).Size);
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