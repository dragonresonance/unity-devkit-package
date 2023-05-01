using NaughtyAttributes;
using PossumScream.Behaviours;
using UnityEngine;


#if !DISABLESTEAMWORKS
//
#endif


#if !EOS_DISABLE
//
#endif




namespace PossumScream.Integration
{
	public class IntegrationTester : PossumBehaviour
	{
		[Header("Testing")]
		[SerializeField] private string _richPresenceKey = "";
		[SerializeField] private string _richPresenceParameter = "";
		[SerializeField] private string[] _achievementsToTest = {};




		#region Events


			private void OnValidate()
			{
				for (int achievementIndex = 0; achievementIndex < this._achievementsToTest.Length; achievementIndex++) {
					this._achievementsToTest[achievementIndex] = this._achievementsToTest[achievementIndex].Trim();
				}
			}


		#endregion




		#region Controls


			[Button]
			public void TestInitialization()
			{
				if (IntegrationMaster.TryGetInstance(out IntegrationMaster integrationMasterInstance)) {
					if (integrationMasterInstance.CheckInitialization()) {
						#if !DISABLESTEAMWORKS
							// Steamworks
							LogEmphasis("Steamworks is initialized");
						#elif !EOS_DISABLE
							// Epic Online Services
							LogEmphasis("Epic Online Services is initialized");
						#else
							// Unknown integration
							LogError("Unknown integration is initialized");
						#endif
					}
					else {
						#if !DISABLESTEAMWORKS
							// Steamworks
							LogError("Steamworks is uninitialized");
						#elif !EOS_DISABLE
							// Epic Online Services
							LogError("Epic Online Services is uninitialized");
						#else
							// No integration
							LogError("No integration is initialized");
						#endif
					}
				}
				else {
					LogError("IntegrationMaster not found");
				}
			}




			[Button]
			public void TestPersona()
			{
				if (IntegrationMaster.TryGetInstance(out IntegrationMaster integrationMasterInstance)) {
					if (integrationMasterInstance.CheckInitialization()) {
						LogInfo($"My persona is {integrationMasterInstance.GetPersonaName()}");
					}
					else {
						LogError("No integration is initialized");
					}
				}
				else {
					LogError("IntegrationMaster not found");
				}
			}


			[Button]
			public void TestFriends()
			{
				if (IntegrationMaster.TryGetInstance(out IntegrationMaster integrationMasterInstance)) {
					if (integrationMasterInstance.CheckInitialization()) {
						string[] friendList = integrationMasterInstance.GetFriendList();

						LogInfo($"I have {friendList.Length} friends...");
						for (int friendIndex = 0; friendIndex < friendList.Length; friendIndex++) {
							LogInfo($"Friend #{friendIndex}: {friendList[friendIndex]}");
						}
					}
					else {
						LogError("No integration is initialized");
					}
				}
				else {
					LogError("IntegrationMaster not found");
				}
			}




			[Button]
			public void TestAchievementList()
			{
				if (IntegrationMaster.TryGetInstance(out IntegrationMaster integrationMasterInstance)) {
					if (integrationMasterInstance.CheckInitialization()) {
						foreach (string achievementName in this._achievementsToTest) {
							if (integrationMasterInstance.CheckIfAchievementExists(achievementName)) {
								if (integrationMasterInstance.CheckIfAchievementAchieved(achievementName)) {
									LogEmphasis($"Achievement {achievementName} achieved");
								}
								else {
									LogInfo($"Achievement {achievementName} not achieved");
								}
							}
							else {
								LogWarning($"Achievement {achievementName} does not exist");
							}
						}
					}
					else {
						LogError("No integration is initialized");
					}
				}
				else {
					LogError("IntegrationMaster not found");
				}
			}


			[Button]
			public void TestSetAchievementList()
			{
				if (IntegrationMaster.TryGetInstance(out IntegrationMaster integrationMasterInstance)) {
					if (integrationMasterInstance.CheckInitialization()) {
						foreach (string achievementName in this._achievementsToTest) {
							if (integrationMasterInstance.SetAchievement(achievementName)) {
								LogEmphasis($"Achievement {achievementName} set");
							}
							else {
								LogWarning($"Achievement {achievementName} could not be set");
							}
						}
					}
					else {
						LogError("No integration is initialized");
					}
				}
				else {
					LogError("IntegrationMaster not found");
				}
			}


			[Button]
			public void TestUnsetAchievementList()
			{
				if (IntegrationMaster.TryGetInstance(out IntegrationMaster integrationMasterInstance)) {
					if (integrationMasterInstance.CheckInitialization()) {
						foreach (string achievementName in this._achievementsToTest) {
							if (integrationMasterInstance.UnsetAchievement(achievementName)) {
								LogEmphasis($"Achievement {achievementName} unset");
							}
							else {
								LogWarning($"Achievement {achievementName} could not be unset");
							}
						}
					}
					else {
						LogError("No integration is initialized");
					}
				}
				else {
					LogError("IntegrationMaster not found");
				}
			}




			[Button]
			public void TestStatsStoring()
			{
				if (IntegrationMaster.TryGetInstance(out IntegrationMaster integrationMasterInstance)) {
					if (integrationMasterInstance.CheckInitialization()) {
						if (integrationMasterInstance.StoreStats()) {
							LogEmphasis("Stats stored");
						}
						else {
							LogError("Stats could not be stored");
						}
					}
					else {
						LogError("No integration is initialized");
					}
				}
				else {
					LogError("IntegrationMaster not found");
				}
			}




			[Button]
			public void TestSetRichPresence()
			{
				if (IntegrationMaster.TryGetInstance(out IntegrationMaster integrationMasterInstance)) {
					if (integrationMasterInstance.CheckInitialization()) {
						if (integrationMasterInstance.SetRichPresence(this._richPresenceKey, this._richPresenceParameter)) {
							LogEmphasis("Rich Presence set");
						}
						else {
							LogError("Rich Presence could not be set");
						}
					}
					else {
						LogError("No integration is initialized");
					}
				}
				else {
					LogError("IntegrationMaster not found");
				}
			}


			[Button]
			public void TestUnsetRichPresence()
			{
				if (IntegrationMaster.TryGetInstance(out IntegrationMaster integrationMasterInstance)) {
					if (integrationMasterInstance.CheckInitialization()) {
						integrationMasterInstance.UnsetRichPresence();
						LogInfo("Rich Presence unset");
					}
					else {
						LogError("No integration is initialized");
					}
				}
				else {
					LogError("IntegrationMaster not found");
				}
			}


		#endregion
	}
}




/*                                                                                            */
/*          ______                               _______                                      */
/*          \  __ \____  ____________  ______ ___\  ___/_____________  ____  ____ ___         */
/*          / /_/ / __ \/ ___/ ___/ / / / __ \__ \\__ \/ ___/ ___/ _ \/ __ \/ __ \__ \        */
/*         / ____/ /_/ /__  /__  / /_/ / / / / / /__/ / /__/ /  /  __/ /_/ / / / / / /        */
/*        /_/    \____/____/____/\____/_/ /_/ /_/____/\___/_/   \___/\__/_/_/ /_/ /__\        */
/*                                                                                            */
/*        Licensed under the Apache License, Version 2.0. See LICENSE.md for more info        */
/*        David Tabernero M. @ PossumScream                      Copyright © 2021-2023        */
/*        GitLab / GitHub: possumscream                            All rights reserved        */
/*        -------------------------                                  -----------------        */
/*                                                                                            */