using DragonResonance.Behaviours;
using DragonResonance.Extensions;
using UnityEngine.UI;
using UnityEngine;




namespace DragonResonance.GUI
{
	[ExecuteAlways]
	[DisallowMultipleComponent]
	[RequireComponent(typeof(Image))]
	public class ImageSpritesheetPlayer : PossumBehaviour
	{
		[SerializeField] private bool _autoplay = true;
		[SerializeField] private bool _loop = true;
		[SerializeField] private float _speed = 30f;
		[SerializeField] private Sprite[] _sprites = { };


		private bool _playing = true;
		private Image _image_internal = null;	// Caching only, use the property instead
		private float _spriteDuration = 0f;
		private int _spritesOffset = 0;




		#region Events


			private void OnValidate() => Start();
			private void Start()
			{
				if (_autoplay)
					Play();
				CacheCalculations();
			}


			private void Update()
			{
				if (!_playing) return;

				int spriteIndex = GetCurrentSpriteIndex().NextCyclic(_sprites.Length, _spritesOffset);
				this.Image.sprite = _sprites[spriteIndex];

				if ((spriteIndex == _sprites.LastIndex()) && !_loop)
					_playing = false;
			}


		#endregion




		#region Publics


			public void Play()
			{
				_spritesOffset = _sprites.Length - GetCurrentSpriteIndex();
				_playing = true;
			}

			public void Stop()
			{
				_playing = false;
			}


		#endregion




		#region Privates


			private int GetCurrentSpriteIndex() => (this.SpritesPassed % _sprites.Length);
			private void CacheCalculations() => _spriteDuration = (1 / _speed);


		#endregion




		#region Properties


			public Image Image => (_image_internal = GetComponentIfNull<Image>(_image_internal));

			public bool Playing => _playing;
			public float SpriteDuration => _spriteDuration;
			public int SpritesOffset => _spritesOffset;
			public int SpritesPassed => (int)(Time.realtimeSinceStartup / _spriteDuration);


		#endregion
	}




	#if UNITY_EDITOR
	[UnityEditor.CustomEditor(typeof(ImageSpritesheetPlayer), true)]
	public class ImageSpriteSheetPlayerEditor : UnityEditor.Editor
	{
		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();
			ImageSpritesheetPlayer imageSpritesheetPlayer = (ImageSpritesheetPlayer)base.target;

			UnityEditor.EditorGUILayout.LabelField("Playing", $"{imageSpritesheetPlayer.Playing}");
			UnityEditor.EditorGUILayout.LabelField("Sprite Duration", $"{imageSpritesheetPlayer.SpriteDuration}");
			UnityEditor.EditorGUILayout.LabelField("Sprites Offset", $"{imageSpritesheetPlayer.SpritesOffset}");
			UnityEditor.EditorGUILayout.LabelField("Sprites Passed", $"{imageSpritesheetPlayer.SpritesPassed}");

			UnityEditor.EditorGUILayout.Separator();
			if (GUILayout.Button(nameof(ImageSpritesheetPlayer.Play)))
				imageSpritesheetPlayer.Play();
			if (GUILayout.Button(nameof(ImageSpritesheetPlayer.Stop)))
				imageSpritesheetPlayer.Stop();
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