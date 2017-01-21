using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	private GameObject _player;
	public float RotateFollowSmoothing = 1.0f;

	void Start ()
	{
		_player = GameObject.Find("Player");

		transform.position = new Vector3(
			_player.transform.position.x, 
			_player.transform.position.y + 10, 
			_player.transform.position.z);

		transform.rotation = Quaternion.Euler(
			90, 
			_player.transform.rotation.y, 
			_player.transform.rotation.z);
	}
	
	void Update ()
	{
		transform.position = new Vector3(
			_player.transform.position.x,
			_player.transform.position.y + 10,
			_player.transform.position.z);

		transform.rotation = Quaternion.Slerp(
			transform.rotation,
			Quaternion.Euler(90,
				_player.transform.rotation.y,
				_player.transform.rotation.z),
			Time.deltaTime * RotateFollowSmoothing);
	}
}
