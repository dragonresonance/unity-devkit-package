#if UNITY_EDITOR


using DragonResonance.Attributes;
using DragonResonance.Logging;
using System.Reflection;
using System;
using UnityEditor;
using UnityEngine;




namespace DragonResonance.Editor.Attributes
{
	[InitializeOnLoad]
	public class ComponentAutolinkingReflectionSystem
	{
		#region Listeners


			static ComponentAutolinkingReflectionSystem() => ObjectFactory.componentWasAdded += FillComponentFields;


		#endregion




		#region Publics


			[MenuItem("Tools/PossumScream/Autolinking/Autolink Components to all in scene")]
			public static void AutolinkAllSceneComponents()
			{
				HLogger.Log("Autolinking all Components...");
				FillGameobjectsComponentFields(UnityEngine.Object.FindObjectsByType<Transform>(
					FindObjectsInactive.Include, FindObjectsSortMode.None));
				HLogger.Log("Done!");
			}


			[MenuItem("Tools/PossumScream/Autolinking/Autolink Components to selected in scene")]
			public static void AutolinkSelectedSceneComponents()
			{
				HLogger.Log("Autolinking selected Components...");
				FillGameobjectsComponentFields(Selection.transforms);
				HLogger.Log("Done!");
			}


		#endregion




		#region Privates


			private static void FillGameobjectsComponentFields(Transform[] transforms)
			{
				foreach (Transform currentTransform in transforms)
					foreach (Component currentComponent in currentTransform.GetComponents<Component>())
						FillComponentFields(currentComponent);
			}


			private static void FillComponentFields(Component component)
			{
				if (component is not MonoBehaviour behaviourComponent) return;

				FieldInfo[] scriptFieldArchetypes = behaviourComponent.GetType()
					.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

				foreach (FieldInfo fieldArchetype in scriptFieldArchetypes) {
					if (Attribute.GetCustomAttribute(fieldArchetype, typeof(AutolinkableComponentAttribute)) is not
					    AutolinkableComponentAttribute) continue;
					if (fieldArchetype.GetValue(behaviourComponent) is not null &&
					    !fieldArchetype.GetValue(behaviourComponent).Equals(null)) continue;
					if (!behaviourComponent.TryGetComponent(fieldArchetype.FieldType, out Component valueComponent))
						continue;

					Undo.RegisterCompleteObjectUndo(component,
						$"Field {fieldArchetype.Name} linked in {behaviourComponent.GetType().Name}");
					fieldArchetype.SetValue(behaviourComponent, valueComponent);
					PrefabUtility.RecordPrefabInstancePropertyModifications(component);
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