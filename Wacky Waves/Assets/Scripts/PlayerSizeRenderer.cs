using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSizeRenderer : MonoBehaviour
{
	private PlayerController _playerController;

	void Start ()
	{
		_playerController = GetComponent<PlayerController>();
	}
	
	void Update ()
	{
		var size = _playerController.GetSize();

		transform.localScale = Vector3.one * size;
	}
}
