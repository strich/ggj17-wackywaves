using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	private PlayerController _player;
	public float RotateFollowSmoothing = 10.0f;
	public GameObject CameraTarget;

	public float ZoomMultiplier = 1f;
	private Vector3 _zoomOffset;

	void Start ()
	{
		_player = GameObject.Find("Player").GetComponent<PlayerController>();
	}
	
	void Update ()
	{
		transform.position = CameraTarget.transform.position + (_zoomOffset* ZoomMultiplier);

		transform.rotation = Quaternion.Slerp(
			transform.rotation,
			CameraTarget.transform.rotation,
			Time.deltaTime * RotateFollowSmoothing);

		AdjustZoom();
	}

	void AdjustZoom()
	{
		_zoomOffset =  - (CameraTarget.transform.forward * _player.GetSize());
	}
}
