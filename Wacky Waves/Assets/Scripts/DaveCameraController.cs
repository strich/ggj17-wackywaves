using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaveCameraController : MonoBehaviour
{
	private GameObject _player;
    private GameObject _target;
    public float RotateFollowSmoothing = 1.0f;
    public float CameraAngle = 45;
    public Vector3 CameraOffset = new Vector3(0f,20f,-10f);
    public float SmoothTime = 3;

    Vector3 targetPos;
    Vector3 targetRot;
    void Start ()
	{
		_player = GameObject.Find("Player");
        _target = new GameObject("Camera Target");

       
        _target.transform.parent = _player.transform;
        _target.transform.localPosition = CameraOffset;

        transform.position = _target.transform.position;


       
    }

    private Vector3 smoothVelocity = Vector3.zero;

    void Update ()
	{
        //transform.position = _target.transform.position;
        //transform.rotation = Quaternion.Euler(CameraAngle,
        //   _target.transform.eulerAngles.y,
        //   _target.transform.eulerAngles.z);
        //targetPos = new Vector3(
        //    _target.transform.position.x,
        //    _target.transform.position.y,
        //    _target.transform.position.z);

        // transform.position = _target.transform.position;
        //transform.position = Vector3.SmoothDamp(transform.position, _target.transform.position, ref smoothVelocity, SmoothTime );
        ////Vector3 temp = Vector3.SmoothDamp(transform.rotation, _target.transform.position, ref smoothVelocity, SmoothTime);
        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(CameraAngle,
        //   _target.transform.eulerAngles.y,
        //   _target.transform.eulerAngles.z), RotateFollowSmoothing);
        ////transform.rotation = Quaternion.Slerp(
        //  transform.rotation = _target.transform.rotation;
        //transform.Rotate( CameraAngle,
        //    0,
        //    0);//,
        //  Time.deltaTime* RotateFollowSmoothing);
        //transform.position = _target.transform.position;
        //transform.rotation = Quaternion.Euler(CameraAngle,
        //   _target.transform.eulerAngles.y,
        //   _target.transform.eulerAngles.z);
        //transform.rotation = Quaternion.Euler(CameraAngle,
        //  _target.transform.eulerAngles.y,
        //  _target.transform.eulerAngles.z);
        //transform.position = _target.transform.position;

        transform.position = Vector3.SmoothDamp(transform.position, _target.transform.position, ref smoothVelocity, SmoothTime);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(CameraAngle,
           _target.transform.eulerAngles.y,
           _target.transform.eulerAngles.z), RotateFollowSmoothing);
    }

    void LateUpdate()
    {
       
       
        //transform.position = _target.transform.position;
        // transform.position = Vector3.Lerp(transform.position, _target.transform.position, SmoothTime*Time.deltaTime);
        //  transform.position = Vector3.SmoothDamp(transform.position, _target.transform.position, ref smoothVelocity, SmoothTime);
        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(CameraAngle,
        //   _target.transform.eulerAngles.y,
        //   _target.transform.eulerAngles.z), RotateFollowSmoothing);
    }
}
