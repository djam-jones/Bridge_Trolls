using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

public class PlayerRoles : NetworkBehaviour 
{
	[SyncVar]
	public string uniquePlayerName;
	private NetworkInstanceId _playerNetId;
	private Transform myTransform;

	void Awake()
	{
		myTransform = transform;
	}

	void Update()
	{
		if(myTransform.name == "" || myTransform.name == "Player(Clone)")
			SetIdentity();
	}

	public override void OnStartLocalPlayer ()
	{
		GetIdentity();
		SetIdentity();
	}

	[Client]
	private void GetIdentity()
	{
		_playerNetId = GetComponent<NetworkIdentity>().netId;
		CmdTellMyServerIdentity(MakeUniqueName());
	}

	[Client]
	private void SetIdentity()
	{
		if(!isLocalPlayer)
			myTransform.name = uniquePlayerName;
		else
			myTransform.name = MakeUniqueName();
	}

	string MakeUniqueName()
	{
		string uniqueName = "Player " + _playerNetId.ToString();
		return uniqueName;
	}

	[Command]
	void CmdTellMyServerIdentity(string name)
	{
		uniquePlayerName = name;
	}
}