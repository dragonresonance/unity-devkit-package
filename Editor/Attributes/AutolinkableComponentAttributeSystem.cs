#if UNITY_EDITOR


using PossumScream.Attributes;
using PossumScream.Enhancements;
using System.Reflection;
using System;
using UnityEditor;
using UnityEngine;




namespace PossumScream.Editor.Attributes
{
	[InitializeOnLoad]
	public class ComponentAutolinkingReflectionSystem
	{
		#region Listeners


			static ComponentAutolinkingReflectionSystem()
			{
				ObjectFactory.componentWasAdded += FillComponentFields;
			}


		#endregion




		#region Publics


			[MenuItem("Tools/PossumScream/Autolinking/Autolink Components to all in scene")]
			public static void AutolinkAllSceneComponents()
			{
				HLogger.Log("Autolinking all Components...");
				FillGameobjectsComponentFields(UnityEngine.Object.FindObjectsOfType<Transform>(true));
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




/*                                                                                            */
/*          ______                               _______                                      */
/*          \  __ \____  ____________  ______ ___\  ___/_____________  ____  ____ ___         */
/*          / /_/ / __ \/ ___/ ___/ / / / __ \__ \\__ \/ ___/ ___/ _ \/ __ \/ __ \__ \        */
/*         / ____/ /_/ /__  /__  / /_/ / / / / / /__/ / /__/ /  / ___/ /_/ / / / / / /        */
/*        /_/    \____/____/____/\____/_/ /_/ /_/____/\___/_/   \___/\__/_/_/ /_/ /__\        */
/*                                                                                            */
/*        Licensed under the Apache License, Version 2.0. See LICENSE.md for more info        */
/*        David Tabernero M. @ PossumScream                      Copyright © 2021-2024        */
/*        GitLab - GitHub: possumscream                            All rights reserved        */
/*        - - - - - - - - - - - - -                                  - - - - - - - - -        */
/*                                                                                            */