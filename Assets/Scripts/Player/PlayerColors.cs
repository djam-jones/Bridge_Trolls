using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class PlayerColors : MonoBehaviour {

	private string _playerName = "";
	private NetworkInstanceId _playerNetId;

	void Start()
	{
		_playerName = gameObject.name;
		CheckColor();
	}

	public void CheckColor ()
	{
		if(_playerName == "Player 1")
		{
			GetComponent<SpriteRenderer>().color = Color.red;
		}
		else if(_playerName == "Player 2")
		{
			GetComponent<SpriteRenderer>().color = Color.blue;
		}
		else if(_playerName == "Player 3")
		{
			GetComponent<SpriteRenderer>().color = Color.green;
		}
		else if(_playerName == "Player 4")
		{
			GetComponent<SpriteRenderer>().color = Color.yellow;
		}
		else if(_playerName == "Player 5")
		{
			GetComponent<SpriteRenderer>().color = Color.magenta;
		}
		else
		{
			GetComponent<SpriteRenderer>().color = Color.black;
		}
	}

}
