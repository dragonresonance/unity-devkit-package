using DragonResonance.Behaviours;
using DragonResonance.Extensions;
using System.Linq;
using UnityEngine.UI;
using UnityEngine;


namespace DragonResonance.GUI
{
	[RequireComponent(typeof(Button))]
	public class ButtonAutoColoringTool : PossumBehaviour
	{
		[HideInInspector] [SerializeField] private Color _cachedBaseColor = Color.white;


		private Button _button_internal = null;	// Caching only, use the property instead


		#region Publics

			[ContextMenu(nameof(ApplyColoring))]
			public void ApplyColoring() => ApplyColoring(_cachedBaseColor);
			public void ApplyColoring(Color newBaseColor)
			{
				_cachedBaseColor = newBaseColor;
				this.Button.colors = new ColorBlock() {
					normalColor = newBaseColor.Mask(ColorBlock.defaultColorBlock.normalColor),
					highlightedColor = newBaseColor.Mask(ColorBlock.defaultColorBlock.highlightedColor).AddLinearBrightness(0.1f),
					pressedColor = newBaseColor.Mask(newBaseColor.Mask(ColorBlock.defaultColorBlock.pressedColor)).AddLinearBrightness(0.1f),
					selectedColor = newBaseColor.Mask(newBaseColor).AddLinearBrightness(0.1f),
					disabledColor = newBaseColor.Mask(ColorBlock.defaultColorBlock.disabledColor).ToGreyscale().AddLinearBrightness(0.05f),
					colorMultiplier = this.Button.colors.colorMultiplier,
					fadeDuration = this.Button.colors.fadeDuration,
				};

				#if UNITY_EDITOR
					UnityEditor.EditorUtility.SetDirty(this);
					UnityEditor.EditorUtility.SetDirty(this.Button);
				#endif
			}

		#endregion


		#region Properties

			public Color CachedBaseColor => _cachedBaseColor;
			public Button Button => (_button_internal = GetComponentIfNull<Button>(_button_internal));

		#endregion
	}


	#if UNITY_EDITOR
	[UnityEditor.CustomEditor(typeof(ButtonAutoColoringTool), true)]
	[UnityEditor.CanEditMultipleObjects]
	public class ButtonAutoColoringToolEditor : UnityEditor.Editor
	{
		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();
			ButtonAutoColoringTool selectedColoringTool = (ButtonAutoColoringTool)base.target;
			ButtonAutoColoringTool[] selectedColoringTools = base.targets.Cast<ButtonAutoColoringTool>().ToArray();

			UnityEditor.EditorGUI.BeginChangeCheck();
			Color newColor = UnityEditor.EditorGUILayout.ColorField("Pick Color", selectedColoringTool.CachedBaseColor);
			if (UnityEditor.EditorGUI.EndChangeCheck()) {
				foreach (ButtonAutoColoringTool coloringTool in selectedColoringTools) {
					UnityEditor.Undo.RecordObject(coloringTool, "Change Color");
					coloringTool.ApplyColoring(newColor);
				}
			}
		}
	}
	#endif
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
/*                  Copyright © 2021-2025. All rights reserved.                 */
/*                Licensed under the Apache License, Version 2.0.               */
/*                         See LICENSE.md for more info.                        */
/*       ________________________________________________________________       */
/*                                                                              */