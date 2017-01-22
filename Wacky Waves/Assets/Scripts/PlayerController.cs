﻿using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float ForwardSpeedModifier = 1.0f;

	public float AngleSmoothing = 2.0f;
	public float PotentialDropOff = 2f;

	public GameObject FollowerObjectsContainer;

    [Tooltip("For debug only")]
    public float INSPECTOR_SPEED;

    [SerializeField]
    float _Rotation;

    //NOTE: Testing vars
    [SerializeField]
    float _Potential; //range 0 to 1

    BuffManager _BuffManager;
    WaterTypeResolver _WaterTypeResolver;
    StateController _StateController;

    /* Buffs */
    Buff _GrindSpeedBuff;
    Buff _OffGrindSpeedBuff;

    Buff _GrindTurnBuff;
    Buff _OffGrindTurnBuff;

    Dictionary<StateController.State, Buff> _SpeedBuffs = new Dictionary<StateController.State, Buff>();
    Dictionary<StateController.State, Buff> _TurnSpeedBuffs = new Dictionary<StateController.State, Buff>();

    void Awake()
    {
        _BuffManager = gameObject.AddComponent<BuffManager>();
        _WaterTypeResolver = GetComponent<WaterTypeResolver>();
        _StateController = GetComponent<StateController>();
        _StateController.OnStateChanged += OnStateChanged;

        CreateBuffs();
    }

    void Update()
    {
        ApplyInput();
        Move();

    }

    void OnDestroy()
    {
        _StateController.OnStateChanged -= OnStateChanged;
    }

    void OnStateChanged(StateController.State currentState, StateController.State prevState)
    {
        _BuffManager.Wipe(BuffManager.KEY_LOCAL_SPEED);

        ConsolidateIntoSingleBuff(BuffManager.KEY_GLOBAL_SPEED, _SpeedBuffs[currentState]);
        ConsolidateIntoSingleBuff(BuffManager.KEY_GLOBAL_TURN_SPEED, _TurnSpeedBuffs[currentState]);

        switch (currentState)
        {
            case StateController.State.DEEP:
                OnDeep(prevState);
                break;
            case StateController.State.WET_GRIND:
                OnWetGrind(prevState);
                break;
            case StateController.State.SHALLOW:
                OnShallow(prevState);
                break;
            case StateController.State.DRY_GRIND:
                OnDryGrind(prevState);
                break;
            case StateController.State.GROUND:
                OnGround(prevState);
                break;
        }
    }

	public void AddFollowerPart(GameObject go)
	{
		go.transform.SetParent(FollowerObjectsContainer.transform, false);
		Destroy(go.GetComponent<Collider>());
		go.AddComponent<WaveFollower>();
	}

	void OnGround(StateController.State prevState)
    {
        //_BuffManager.Wipe(BuffManager.KEY_GLOBAL_SPEED);

        GetComponentInChildren<Renderer>().material.color = Color.white;
    }

    void OnDryGrind(StateController.State prevState)
    {
        /*
        ConsolidateIntoSingleBuff(BuffManager.KEY_GLOBAL_SPEED, _GrindSpeedBuff);
        ConsolidateIntoSingleBuff(BuffManager.KEY_GLOBAL_TURN_SPEED, _GrindTurnBuff);
        */

        GetComponentInChildren<Renderer>().material.color = Color.blue;
    }
    void OnShallow(StateController.State prevState)
    {
        /*
        if (prevState == StateController.State.DRY_GRIND)
        {
            _OffGrindSpeedBuff.SetModifier(_BuffManager.Wipe(BuffManager.KEY_GLOBAL_SPEED));
            AddBuff(BuffManager.KEY_GLOBAL_SPEED, _OffGrindSpeedBuff);
        }
        else if (prevState == StateController.State.WET_GRIND)
        {
        }
        */

        //GetComponentInChildren<Renderer>().material.color = Color.white;
    }

    void OnWetGrind(StateController.State prevState)
    {
        //GetComponentInChildren<Renderer>().material.color = Color.blue;
    }

    void OnDeep(StateController.State prevState)
    {
        /*
        _BuffManager.AddBuff(BuffManager.KEY_LOCAL_SPEED, new DecreasingBuff(_Potential * GameUtils.POTENTIAL_MODIFIER, 0.99f));
        SetPotential(0f);
        UpdateView();
        */

        //GetComponentInChildren<Renderer>().material.color = Color.white;
    }

    public void AddRotation(float yRotation)
    {
        _Rotation += yRotation;
    }

    public void AddBuff(string key, Buff buff)
    {
        _BuffManager.AddBuff(key, buff);
    }

    public void RemoveBuff(string key, Buff buff)
    {
        _BuffManager.RemoveBuff(key, buff);
    }

    public void HitCliff(Collider collider)
    {
        Debug.Log("Hit Cliff");
    }

    void ApplyInput()
    {
        _Rotation += Input.GetAxisRaw("Horizontal") * GetTurnSpeed();
    }

	public float GetRawRotInput()
	{
		return Input.GetAxis("Horizontal");
	}

    void ConsolidateIntoSingleBuff(string key, Buff buff)
    {
        buff.SetModifier(_BuffManager.Wipe(key));
        AddBuff(key, buff);
    }

    void CreateBuffs()
    {
        _SpeedBuffs.Add(StateController.State.DEEP, new DecreasingBuff(1f, 0.999f));
        _SpeedBuffs.Add(StateController.State.WET_GRIND, new IncreasingBuff(1f, 1.0025f, 3f));
        _SpeedBuffs.Add(StateController.State.SHALLOW, new DecreasingBuff(1f, 0.9965f));
        _SpeedBuffs.Add(StateController.State.DRY_GRIND, new IncreasingBuff(1f, 1.0025f, 3f));
        _SpeedBuffs.Add(StateController.State.GROUND, new DecreasingBuff(1f, 0.9f));

        _TurnSpeedBuffs.Add(StateController.State.DEEP, new DecreasingBuff(1f, 0.9f));
        _TurnSpeedBuffs.Add(StateController.State.WET_GRIND, new IncreasingBuff(1f, 1.01f, 2f));
        _TurnSpeedBuffs.Add(StateController.State.SHALLOW, new DecreasingBuff(1f, 0.999f));
        _TurnSpeedBuffs.Add(StateController.State.DRY_GRIND, new IncreasingBuff(1f, 1.01f, 2f));
        _TurnSpeedBuffs.Add(StateController.State.GROUND, new DecreasingBuff(1f, 0.9f));
	}

    float GetForwardSpeed()
    {
        INSPECTOR_SPEED =
            ForwardSpeedModifier * _BuffManager.Modify(BuffManager.KEY_GLOBAL_SPEED, _BuffManager.Modify(BuffManager.KEY_LOCAL_SPEED, GameUtils.GetStateSpeed(_StateController.CurrentState)));
        return INSPECTOR_SPEED;
    }

    float GetTurnSpeed()
    {
        return GameUtils.GetStateTurnSpeed(_StateController.CurrentState);
    }

	public float GetSize()
	{
		return _BuffManager.Modify(BuffManager.KEY_GLOBAL_SIZE, GameUtils.WAVE_SIZE);
	}

    void Move()
    {
		transform.Translate(Vector3.forward * GetForwardSpeed(), Space.Self);
		transform.rotation = Quaternion.Slerp(transform.rotation,
            Quaternion.Euler(0f, _Rotation, 0f),
            Time.deltaTime * AngleSmoothing);
    }

    void SetPotential(float power)
    {
        _Potential = Mathf.Clamp01(power);
        UpdateView();
    }

    void UpdateView()
    {
        transform.localScale = Vector3.one + Vector3.one * _Potential;
    }
}
