using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerNetworkSetup : NetworkBehaviour 
{
	private MovementHuman _movementHumanScript;

	void Awake()
	{
		_movementHumanScript = GetComponent<MovementHuman>();
	}

	void Start()
	{
		CheckForLocalPlayer();
	}

	void Update()
	{
		
	}

//	public override void OnStartServer()
//	{
//		GetComponent<SpriteRenderer>().color = Color.red;
//	}
//
//	public override void OnStartClient()
//	{
//		GetComponent<SpriteRenderer>().color = Color.blue;
//	}

	private void CheckForLocalPlayer()
	{
		if(isLocalPlayer)
		{
			_movementHumanScript.enabled = true;
		}
	}


}