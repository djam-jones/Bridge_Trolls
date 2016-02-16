using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class MovementHuman : MonoBehaviour {

	void Update()
	{
		Move();
	}

	private void Move()
	{
		float h = Input.GetAxis("Horizontal") * 6f * Time.deltaTime;
		float v = Input.GetAxis("Vertical") * 6f * Time.deltaTime;

		transform.Translate(new Vector3(h, v, 0));
	}
}
