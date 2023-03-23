using System.IO;
using UnityEngine;




namespace PossumScream.SickScripts.PlayerPreferences
{
	public static class PlayerPrefsFB
	{
		#region Setup Controls


			public static void setupFileBasedPlayerPrefs(string saveFileDirectory, string saveFileName, bool autoSave, bool encryptData, string encryptionPassphrase)
			{
				if (prepareSaveDirectory(saveFileDirectory)) {
					FBPP.Start(new FBPPConfig()
					{
						SaveFileName = saveFileName,
						SaveFilePath = saveFileDirectory,

						AutoSaveData = autoSave,

						ScrambleSaveData = encryptData,
						EncryptionSecret = encryptionPassphrase,

						OnLoadError = recreateSavedataFile,
					});
				}
				else {
					Debug.LogError("FATAL ERROR: Saving directory could not be created");
				}
			}


			public static void recreateSavedataFile()
			{
				Debug.Log("Recreating save file...");
				{
					FBPP.Save();
				}
			}


			public static void deleteSavedataContent()
			{
				Debug.Log("Deleting save content...");
				{
					FBPP.DeleteAll();
				}
			}


			public static void deleteSavedataFile()
			{
				Debug.Log("Deleting save file...");
				{
					File.Delete(FBPP.GetSaveFilePath());
				}
			}


		#endregion




		#region General Controls


			public static bool hasKey(string key)
			{
				return FBPP.HasKey(key);
			}


			public static void deleteKey(string key)
			{
				FBPP.DeleteKey(key);
			}




			public static void saveAll()
			{
				FBPP.Save();
			}


			public static void deleteAll()
			{
				FBPP.DeleteAll();
			}


		#endregion




		#region Integer Controls


			public static int getIntKey(string key)
			{
				return getIntKey(key, 0);
			}


			public static int getIntKey(string key, int defaultValue)
			{
				if (hasKey(key)) {
					return FBPP.GetInt(key);
				}
				else {
					return defaultValue;
				}
			}


			public static void setIntKey(string key, int value, bool saveAllKeys = false)
			{
				FBPP.SetInt(key, value);

				if (saveAllKeys) {
					saveAll();
				}
			}


		#endregion




		#region Float Controls


			public static float getFloatKey(string key)
			{
				return getFloatKey(key, 0f);
			}


			public static float getFloatKey(string key, float defaultValue)
			{
				if (hasKey(key)) {
					return FBPP.GetFloat(key);
				}
				else {
					return defaultValue;
				}
			}


			public static void setFloatKey(string key, float value, bool saveAllKeys = false)
			{
				FBPP.SetFloat(key, value);

				if (saveAllKeys) {
					saveAll();
				}
			}


		#endregion




		#region String Controls


			public static string getStringKey(string key)
			{
				return getStringKey(key, "");
			}


			public static string getStringKey(string key, string defaultValue)
			{
				if (hasKey(key)) {
					return FBPP.GetString(key);
				}
				else {
					return defaultValue;
				}
			}


			public static void setStringKey(string key, string value, bool saveAllKeys = false)
			{
				FBPP.SetString(key, value);

				if (saveAllKeys) {
					saveAll();
				}
			}


		#endregion




		#region Boolean Controls


			public static bool getBoolKey(string key)
			{
				return getBoolKey(key, false);
			}


			public static bool getBoolKey(string key, bool defaultValue)
			{
				if (hasKey(key)) {
					return FBPP.GetBool(key);
				}
				else {
					return defaultValue;
				}
			}


			public static void setBoolKey(string key, bool value, bool saveAllKeys = false)
			{
				FBPP.SetBool(key, value);

				if (saveAllKeys) {
					saveAll();
				}
			}


		#endregion




		#region Generic Controls


			public static T getKey<T>(string key, T defaultValue = default)
			{
				if (hasKey(key)) {
					return deserializeObject<T>(FBPP.GetString(key));
				}
				else {
					return defaultValue;
				}
			}


			public static void setKey<T>(string key, T value, bool saveAllKeys = false)
			{
				FBPP.SetString(key, serializeObject(value));

				if (saveAllKeys) {
					saveAll();
				}
			}


		#endregion




		#region Utilities


			private static bool prepareSaveDirectory(string saveFileDirectory)
			{
				if (!Directory.Exists(saveFileDirectory)) {
					return Directory.CreateDirectory(saveFileDirectory).Exists;
				}
				else {
					return true;
				}
			}




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




/*                                                                                */
/*        David Tabernero M. @ PossumScream          Copyright © 2021-2022        */
/*        https://gitlab.com/possumscream             All rights reserved.        */
/*                                                                                */