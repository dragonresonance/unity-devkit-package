using DragonResonance.Attributes;
using DragonResonance.Behaviours;
using DragonResonance.Extensions;
using Unity.Netcode;
using UnityEngine;




namespace DragonResonance.Networking
{
	public class NetworkPhysicsRigidbody : OpossumBehaviour
	{
		[Header("Settings")]
		[SerializeField] private float _latencyFactor = 0.5f;
		[SerializeField] private bool _alwaysCompensate = false;
		[HideIf(nameof(_alwaysCompensate))] [SerializeField] private Vector3 _compensationOffset = Vector3.one;

		[Header("Components")]
		[SerializeField] private Transform _animaTransform = null;
		[SerializeField] private Rigidbody _animaRigidbody = null;
		[SerializeField] private Transform _corpusTransform = null;
		[SerializeField] private Rigidbody _corpusRigidbody = null;




		#region Events


			private void FixedUpdate()
			{
				if (!base.IsSpawned) return;
				if (this.IsFrozen) return;
				if (base.IsOwner) OwnerFixedUpdate();
				else ObserverFixedUpdate();
				if (base.IsServer) ServerFixedUpdate();
			}


			private void OwnerFixedUpdate()
			{
				UpdateAnimaRigidbodyAtServerRpc(_corpusRigidbody.position, _corpusRigidbody.rotation,
					_corpusRigidbody.linearVelocity, _corpusRigidbody.angularVelocity);
			}

			private void ObserverFixedUpdate()
			{
				if (CheckForNeededCompensation(_animaRigidbody, _corpusRigidbody))
					MatchRigidbodyCorpusToAnima();
			}

			private void ServerFixedUpdate()
			{
				UpdateAnimaRigidbodyAtClientRpc(_animaRigidbody.position, _animaRigidbody.rotation,
					_animaRigidbody.linearVelocity, _animaRigidbody.angularVelocity);
			}


		#endregion




		#region Publics


			public void Freeze()
			{
				_animaRigidbody.isKinematic = true;
				_corpusRigidbody.isKinematic = true;
			}


			public void Unfreeze()
			{
				_animaRigidbody.isKinematic = false;
				_corpusRigidbody.isKinematic = false;
			}


			public void Teleport(Vector3 position) => Teleport(position, _corpusRigidbody.rotation);
			public void Teleport(Vector3 position, Quaternion rotation)
			{
				Log($"{nameof(Teleport)} | position:{position}, rotation:{rotation.eulerAngles}");
				_animaRigidbody.SetPoint(position, rotation);
				_corpusRigidbody.SetPoint(position, rotation);
			}


		#endregion




		#region Privates


			[Rpc(SendTo.Server)]
			private void UpdateAnimaRigidbodyAtServerRpc(Vector3 position, Quaternion rotation,
				Vector3 linearVelocity, Vector3 angularVelocity, RpcParams rpcParams = default)
			{
				float latency = _latencyFactor * GetPlayerRTT(rpcParams.Receive.SenderClientId);
				_animaRigidbody.SetPoint(
					position + (latency * linearVelocity),
					rotation * Quaternion.Euler(latency * angularVelocity));
				_animaRigidbody.SetVelocity(linearVelocity, angularVelocity);
			}


			[Rpc(SendTo.ClientsAndHost)]
			private void UpdateAnimaRigidbodyAtClientRpc(Vector3 position, Quaternion rotation,
				Vector3 linearVelocity, Vector3 angularVelocity, RpcParams rpcParams = default)
			{
				float latency = _latencyFactor * GetPlayerRTT(rpcParams.Receive.SenderClientId);
				_animaRigidbody.SetPoint(
					position + (latency * linearVelocity),
					rotation * Quaternion.Euler(latency * angularVelocity));
				_animaRigidbody.SetVelocity(linearVelocity, angularVelocity);
			}


			private void MatchRigidbodyCorpusToAnima()
			{
				_corpusRigidbody.SyncMovement(_animaRigidbody);
			}




			private bool CheckForNeededCompensation(Rigidbody rigidbodyA, Rigidbody rigidbodyB)
			{
				if (_alwaysCompensate) return true;

				Vector3 delta = rigidbodyA.position - rigidbodyB.position;
				return (Mathf.Abs(delta.x) > _compensationOffset.x) ||
				       (Mathf.Abs(delta.y) > _compensationOffset.y) ||
				       (Mathf.Abs(delta.z) > _compensationOffset.z);
			}


			public float GetPlayerRTT(ulong playerClientId)
			{
				return (base.NetworkManager.NetworkConfig.NetworkTransport.GetCurrentRtt(playerClientId) / 1000f);
			}


		#endregion




		#region Properties


			public Transform AnimaTransform => _animaTransform;
			public Rigidbody AnimaRigidbody => _animaRigidbody;
			public Transform CorpusTransform => _corpusTransform;
			public Rigidbody CorpusRigidbody => _corpusRigidbody;


			public bool IsFrozen => (_corpusRigidbody.isKinematic && _animaRigidbody.isKinematic);


		#endregion
	}
}




/*                                                                                */
/*        Proto√olKers                               Copyright © 2022-2025        */
/*        Dragon Resonance                             All rights reserved        */
/*                                                                                */