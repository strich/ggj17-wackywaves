using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	private GameObject _player;
	public float RotateFollowSmoothing = 10.0f;
	public GameObject CameraTarget;

	void Start ()
	{
		_player = GameObject.Find("Player");
	}
	
	void Update ()
	{
		transform.position = CameraTarget.transform.position;

		transform.rotation = Quaternion.Slerp(
			transform.rotation,
			CameraTarget.transform.rotation,
			Time.deltaTime * RotateFollowSmoothing);
	}
}
