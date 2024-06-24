#if UNITY_NGO


using System;
using Unity.Netcode;
using UnityEngine;




namespace PossumScream.Behaviours
{
	public abstract partial class OpossumBehaviour : NetworkBehaviour
	{
		#pragma warning disable 0414
		[SerializeField] private string _description = "";
		#pragma warning restore 0414


		public event Action OnSpawned = null;
		public event Action OnDespawned = null;




		#region Events


			public override void OnNetworkSpawn()
			{
				base.OnNetworkSpawn();
				OnSpawned?.Invoke();
			}

			public override void OnNetworkDespawn()
			{
				base.OnNetworkDespawn();
				OnDespawned?.Invoke();
			}


		#endregion




		#region Properties


			protected string Description => _description;


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