using UnityEngine;


namespace DragonResonance.Attributes
{
	public class SpritePreviewAttribute : PropertyAttribute
	{
	    private readonly int _width;
	    private readonly int _height;

	    public SpritePreviewAttribute(int size = 64) : this(size, size) { }
	    public SpritePreviewAttribute(int width, int height)
	    {
		    _width = width;
		    _height = height;
	    }

	    public float Width => _width;
	    public float Height => _height;
	}
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