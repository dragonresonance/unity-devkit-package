#if UNITY_EDITOR


using System.IO;
using UnityEditor.AssetImporters;
using UnityEditor;
using UnityEngine;




namespace PossumScream.Editor.Importers
{
	[ScriptedImporter(1, "tsv")]
	public class TSVImporter : ScriptedImporter
	{
		public override void OnImportAsset(AssetImportContext context)
		{
			TextAsset textAsset = new TextAsset(File.ReadAllText(context.assetPath));


			context.AddObjectToAsset(Path.GetFileNameWithoutExtension(context.assetPath), textAsset);
			context.SetMainObject(textAsset);

			AssetDatabase.SaveAssets();
		}
	}
}


#endif




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