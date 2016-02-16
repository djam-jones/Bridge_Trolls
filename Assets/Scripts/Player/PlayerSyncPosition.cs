using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerSyncPosition : NetworkBehaviour {

	[SyncVar]
	private Vector2 _syncPosition;

	private Transform _myTransform;

	[SerializeField]
	private float _lerpRate = 15;

	void Awake()
	{
		_myTransform = GetComponent<Transform>();
	}

	void FixedUpdate()
	{
		TransmitPosition();
		LerpPosition();
	}

	void LerpPosition()
	{
		if(!isLocalPlayer)
			_myTransform.position = Vector2.Lerp(_myTransform.position, _syncPosition, _lerpRate * Time.deltaTime);
	}

	[Command]
	void CmdProvidePositionToServer(Vector2 pos)
	{
		_syncPosition = pos;
	}

	[ClientCallback]
	void TransmitPosition()
	{
		if(isLocalPlayer)
			CmdProvidePositionToServer(_myTransform.position);
	}

}