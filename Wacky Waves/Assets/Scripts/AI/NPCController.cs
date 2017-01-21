using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class NPCController : MonoBehaviour
{
	// TODO cbf so copied these:
	public const float WATER_HEIGHT_DEEP = 20; // 0 to 20
	public const float WATER_HEIGHT_SHALLOW = 23; // 22 to 23

	[SerializeField]
	private Vector3 _moveToTarget;

	private Terrain _currentTerrain;

	public GameObject RallyPoint;
	public float MoveRadius = 5f;

	public float TargetWaitTime = 5f;
	private float _lastTargetFindTime = 0f;

	public float ForwardSpeed = 1f;
	public float AngleSmoothing = 30.0f;

	private bool _targetFound = false;

	[SerializeField]
	private bool _isDead = false;

	private PlayerController _player;

	void Start () {
		_player = GameObject.Find("Player").GetComponent<PlayerController>();

		var ray = new Ray(RallyPoint.transform.position, Vector3.down);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, 50, LayerMask.GetMask("Ground")))
		{
			_currentTerrain = hit.transform.GetComponent<Terrain>();
		}
		else
		{
			Debug.LogError("Fuck me sideways I couldn't find a terrain under " + transform.name + " at " + RallyPoint);
		}
	}

	void Update ()
	{
		if (!_isDead)
		{
			if (Time.time > _lastTargetFindTime + TargetWaitTime)
			{
				_lastTargetFindTime = Time.time;

				FindNewMoveTarget();
			}

			MoveToTarget();
		}
	}

	private void FindNewMoveTarget()
	{
		var localPos = new Vector3(Random.Range(-MoveRadius, MoveRadius), 0, Random.Range(-MoveRadius, MoveRadius));
		var worldPos = RallyPoint.transform.position + localPos;
		var height = _currentTerrain.terrainData.GetHeight((int)worldPos.x, (int)worldPos.z);

		if (height > WATER_HEIGHT_SHALLOW) return;

		_targetFound = true;
		_moveToTarget = worldPos;
	}

	private void MoveToTarget()
	{
		if (!_targetFound) return;
		if (Math.Abs(transform.position.x - _moveToTarget.x) < 0.01f &&
		    Math.Abs(transform.position.z - _moveToTarget.z) < 0.01f) return;

		transform.position = Vector3.MoveTowards(transform.position, _moveToTarget, Time.deltaTime*ForwardSpeed);
		transform.LookAt(_moveToTarget);
		//transform.rotation = Quaternion.Slerp(transform.rotation,
		//	Quaternion.LookRotation(transform.position), 
		//	Time.deltaTime * AngleSmoothing);
	}

	public void TriggerDestroyed()
	{
		if (_isDead) return;

		_isDead = true;
		//GetComponentInChildren<Rigidbody>().isKinematic = false;
		//GetComponentInChildren<Rigidbody>().useGravity = true;
		ConsumeBrokenParts(GetComponentsInChildren<Collider>().Select(c => c.gameObject).ToList()); // Such hax
		Destroy(gameObject, 10f);
	}

	private void ConsumeBrokenParts(List<GameObject> gos)
	{
		foreach (var go in gos)
		{
			_player.AddFollowerPart(go);
		}
	}
}
