using UnityEngine.SceneManagement;
using UnityEngine;




namespace PossumScream.BlazingBehaviours
{
	[DisallowMultipleComponent]
	public abstract class ScriptableOptableSingleton<T> : ScriptableBehaviour where T : Component
	{
		[SerializeField] private bool _makePersistentOnAwake = false;




		private static T m_instance = null;




		#region Events


			protected void Awake()
			{
				if (m_instance == null) {
					m_instance = this as T;

					if (this._makePersistentOnAwake) {
						makePersistent();
					}
				}

				if (m_instance != this) {
					Destroy(this);
					return;
				}

				LateAwake();
			}


			protected virtual void LateAwake()
			{
				return;
			}


		#endregion




		#region Controls


			public static bool tryGetInstance(out T instance)
			{
				if (m_instance == null) {
					m_instance = FindObjectOfType(typeof(T)) as T;
				}


				instance = m_instance;
				return (m_instance is not null);
			}


		#endregion




		#region Actions


			public void makePersistent()
			{
				DontDestroyOnLoad(this.gameObject);
			}


			public void makeEphemeral()
			{
				SceneManager.MoveGameObjectToScene(this.gameObject, SceneManager.GetActiveScene());
			}


		#endregion




		#region Getters and Setters


			public static T Instance => m_instance;


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