using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaveCameraController : MonoBehaviour
{
	private GameObject _player;
	public float RotateFollowSmoothing = 1.0f;
    public float CameraAngle = 45;
    public Vector3 CameraOffset = new Vector3(0f,20f,-10f);
    void Start ()
	{
		_player = GameObject.Find("Dave Player");

		transform.position = new Vector3(
			_player.transform.position.x+ CameraOffset.x, 
			_player.transform.position.y + CameraOffset.y, 
			_player.transform.position.z+ CameraOffset.z);

		transform.rotation = Quaternion.Euler(
            CameraAngle, 
			_player.transform.rotation.y, 
			_player.transform.rotation.z);
	}
	
	void Update ()
	{
		transform.position = new Vector3(
			_player.transform.position.x+ CameraOffset.x,
			_player.transform.position.y + CameraOffset.y,
			_player.transform.position.z+ CameraOffset.z);

		transform.rotation = Quaternion.Slerp(
			transform.rotation,
			Quaternion.Euler(CameraAngle,
				_player.transform.rotation.y,
				_player.transform.rotation.z),
			Time.deltaTime * RotateFollowSmoothing);
	}
}
