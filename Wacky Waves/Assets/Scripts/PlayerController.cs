using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float ForwardSpeed = 1.0f;
	public float TurnSpeed = 30.0f;
	public float AngleSmoothing = 2.0f;
    private float direction;
	void Start ()
	{

	}
	
	void Update ()
	{
		transform.Translate(Vector3.forward* ForwardSpeed, Space.Self);
        direction += Input.GetAxisRaw("Horizontal");
		Quaternion target = Quaternion.Euler(0, direction * TurnSpeed, 0);
		transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * AngleSmoothing);

	}
}
