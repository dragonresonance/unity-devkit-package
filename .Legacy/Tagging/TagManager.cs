using NaughtyAttributes;
using System.Collections.Generic;
using UnityEngine;


#if UNITY_EDITOR
using UnityEditor;
#endif




namespace PossumScream.CoolComponents.Tagging
{
	public class TagManager : MonoBehaviour
	{
		private const string defaultTagSeparator = ";";


		//[Header("Tags")]
		[Tag] [SerializeField] private List<string> _tags = new();




		#region Controls


			public bool add(string tag)
			{
				if (!this._tags.Contains(tag)) {
					this._tags.Add(tag);
					return true;
				}


				return false;
			}


			public bool remove(string tag)
			{
				return this._tags.Remove(tag);
			}


		#endregion




		#region Utilities


			public bool contains(string tag)
			{
				return this._tags.Contains(tag);
			}


			public bool containsAny(IEnumerable<string> tags)
			{
				foreach (string tag in tags) {
					if (this._tags.Contains(tag)) {
						return true;
					}
				}


				return false;
			}


			public bool containsAll(IEnumerable<string> tags)
			{
				foreach (string tag in tags) {
					if (!this._tags.Contains(tag)) {
						return false;
					}
				}


				return true;
			}


		#endregion




		#region Properties


			public int count
			{
				get => this._tags.Count;
			}


		#endregion




		#region Getters and Setters


			public List<string> tags
			{
				get => this._tags;
				set => this._tags = value;
			}


		#endregion




		#region Overrides


			public override string ToString()
			{
				return ToString(defaultTagSeparator);
			}


			public string ToString(string tagSeparator)
			{
				return ($"Tags: ({this._tags.Count}) {string.Join(tagSeparator, this._tags)}");
			}


		#endregion
	}








	#if UNITY_EDITOR
	[CustomEditor(typeof(TagManager))]
	public class TagManagerEditor : Editor
	{
		private string[] _excludedFields = { "m_Script" };




		public override void OnInspectorGUI()
		{
			base.serializedObject.Update();
			{
				DrawPropertiesExcluding(base.serializedObject, this._excludedFields);
			}
			base.serializedObject.ApplyModifiedProperties();
		}
	}
	#endif
}




/*                                                                                */
/*        David Tabernero M. @ PossumScream          Copyright © 2021-2022        */
/*        https://gitlab.com/possumscream             All rights reserved.        */
/*                                                                                */