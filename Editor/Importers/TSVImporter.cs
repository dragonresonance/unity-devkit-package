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