using PossumScream.ExtremeExtensions;
using UnityEngine;




namespace PossumScream.SickScripts.PlayerPreferences
{
	public static class PlayerPrefsX
	{
		#region Controls: General


			public static bool hasEntry(string key)
			{
				return PlayerPrefs.HasKey(key);
			}


			public static void deleteEntry(string key)
			{
				PlayerPrefs.DeleteKey(key);
			}




			public static void saveAll()
			{
				PlayerPrefs.Save();
			}


			public static void deleteAll()
			{
				PlayerPrefs.DeleteAll();
			}


		#endregion




		#region Controls: Integers


			public static int getIntEntry(string key)
			{
				return getIntEntry(key, 0);
			}


			public static int getIntEntry(string key, int defaultValue)
			{
				if (hasEntry(key)) {
					return PlayerPrefs.GetInt(key);
				}
				else {
					return defaultValue;
				}
			}


			public static void setIntEntry(string key, int value, bool saveAllEntries = false)
			{
				PlayerPrefs.SetInt(key, value);

				if (saveAllEntries) {
					saveAll();
				}
			}


		#endregion




		#region Controls: Floats


			public static float getFloatEntry(string key)
			{
				return getFloatEntry(key, 0f);
			}


			public static float getFloatEntry(string key, float defaultValue)
			{
				if (hasEntry(key)) {
					return PlayerPrefs.GetFloat(key);
				}
				else {
					return defaultValue;
				}
			}


			public static void setFloatEntry(string key, float value, bool saveAllEntries = false)
			{
				PlayerPrefs.SetFloat(key, value);

				if (saveAllEntries) {
					saveAll();
				}
			}


		#endregion




		#region Controls: Strings


			public static string getStringEntry(string key)
			{
				return getStringEntry(key, "");
			}


			public static string getStringEntry(string key, string defaultValue)
			{
				if (hasEntry(key)) {
					return PlayerPrefs.GetString(key);
				}
				else {
					return defaultValue;
				}
			}


			public static void setStringEntry(string key, string value, bool saveAllEntries = false)
			{
				PlayerPrefs.SetString(key, value);

				if (saveAllEntries) {
					saveAll();
				}
			}


		#endregion




		#region Controls: Booleans


			public static bool getBoolEntry(string key)
			{
				return getBoolEntry(key, false);
			}


			public static bool getBoolEntry(string key, bool defaultValue)
			{
				if (hasEntry(key)) {
					return PlayerPrefs.GetInt(key).AsBool();
				}
				else {
					return defaultValue;
				}
			}


			public static void setBoolEntry(string key, bool value, bool saveAllEntries = false)
			{
				PlayerPrefs.SetInt(key, value.AsInteger());

				if (saveAllEntries) {
					saveAll();
				}
			}


		#endregion




		#region Controls: Generic Types


			public static T getEntry<T>(string key, T defaultValue = default)
			{
				if (PlayerPrefs.HasKey(key)) {
					return deserializeObject<T>(PlayerPrefs.GetString(key));
				}
				else {
					return defaultValue;
				}
			}


			public static void setEntry<T>(string key, T value, bool saveAllEntries = false)
			{
				PlayerPrefs.SetString(key, serializeObject(value));

				if (saveAllEntries) {
					saveAll();
				}
			}


		#endregion




		#region Actions


			private static string serializeObject(object serializableValue)
			{
				return JsonUtility.ToJson(serializableValue);
			}


			private static T deserializeObject<T>(string serializedValue)
			{
				return JsonUtility.FromJson<T>(serializedValue);
			}


		#endregion
	}
}




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