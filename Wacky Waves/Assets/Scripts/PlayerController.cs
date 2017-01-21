﻿using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float ForwardSpeedModifier = 1.0f;

	public float TurnSpeed = 30.0f;
	public float AngleSmoothing = 2.0f;
	public float PotentialDropOff = 2f;

    [SerializeField]
    float _Rotation;

    //NOTE: Testing vars
    [SerializeField]
    float _Potential; //range 0 to 1

    BuffManager _BuffManager;
    WaterTypeResolver _WaterTypeResolver;
    WaterType _CurrentWaterType;

    void Awake()
    {
        _BuffManager = gameObject.AddComponent<BuffManager>();
        _WaterTypeResolver = GetComponent<WaterTypeResolver>();
        _WaterTypeResolver.OnWaterTypeChanged += OnWaterTypeChanged;
    }

    void Update ()
	{
        ApplyInput();
        Move();
	}

    void OnDestroy()
    {
        _WaterTypeResolver.OnWaterTypeChanged -= OnWaterTypeChanged;
    }

    void OnWaterTypeChanged(WaterType waterType)
    {
        _BuffManager.Wipe(BuffManager.KEY_LOCAL_SPEED);

        switch (waterType)
        {
            case WaterType.Deep:
                OnDeep();
                break;
            case WaterType.Shallow:
                OnShallow();
                break;
            case WaterType.Ground:
                OnGround();
                break;
        }

        _CurrentWaterType = waterType;
    }

    void OnGround()
    {
    }

    void OnShallow()
    {
        if (_CurrentWaterType == WaterType.Deep)
        {
            float deviation = GameUtils.GetDeviation(transform);
            float potential = Mathf.Pow(((90f - deviation) / 90f), PotentialDropOff);
            SetPotential(potential);
        }
    }

    void OnDeep()
    {
        _BuffManager.AddBuff(BuffManager.KEY_LOCAL_SPEED, new DecreasingBuff(_Potential * GameUtils.POTENTIAL_MODIFIER, 0.99f));
        SetPotential(0f);
        UpdateView();
    }

    void ApplyInput()
    {
        _Rotation += Input.GetAxisRaw("Horizontal") * TurnSpeed;
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

    float GetForwardSpeed()
    {
        return ForwardSpeedModifier * _BuffManager.Modify(BuffManager.KEY_GLOBAL_SPEED, _BuffManager.Modify(BuffManager.KEY_LOCAL_SPEED, GameUtils.GetTerrainSpeed(_CurrentWaterType)));
    }
}
