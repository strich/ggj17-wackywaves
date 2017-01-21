using System;
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
    StateController _StateController;

    /* Buffs */
    Buff _GrindBuff;
    Buff _OffGrindBuff;

    void Awake()
    {
        _BuffManager = gameObject.AddComponent<BuffManager>();
        _WaterTypeResolver = GetComponent<WaterTypeResolver>();
        _StateController = GetComponent<StateController>();
        _StateController.OnStateChanged += OnStateChanged;

        CreateBuffs();
    }

    void Update ()
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
                OnWetGrind(prevState);
                break;
            case StateController.State.GROUND:
                OnGround(prevState);
                break;
        }
    }

    void OnGround(StateController.State prevState)
    {
    }

    void OnDryGrind(StateController.State prevState)
    {
        _GrindBuff.SetModifier(1f);
        AddBuff(BuffManager.KEY_GLOBAL_SPEED, _GrindBuff);
        RemoveBuff(BuffManager.KEY_GLOBAL_SPEED, _OffGrindBuff);
    }

    void OnShallow(StateController.State prevState)
    {
        if (prevState == StateController.State.DRY_GRIND)
        {
            _OffGrindBuff.SetModifier(_GrindBuff.Modifier);
            AddBuff(BuffManager.KEY_GLOBAL_SPEED, _OffGrindBuff);
            RemoveBuff(BuffManager.KEY_GLOBAL_SPEED, _GrindBuff);
        }
        else if (prevState == StateController.State.WET_GRIND)
        {
        }
    }

    void OnWetGrind(StateController.State prevState)
    {
    }

    void OnDeep(StateController.State prevState)
    {
        _BuffManager.AddBuff(BuffManager.KEY_LOCAL_SPEED, new DecreasingBuff(_Potential * GameUtils.POTENTIAL_MODIFIER, 0.99f));
        SetPotential(0f);
        UpdateView();
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

    void ApplyInput()
    {
        _Rotation += Input.GetAxisRaw("Horizontal") * TurnSpeed;
    }

    void CreateBuffs()
    {
        _GrindBuff = new IncreasingBuff(1f, 1.005f, 5f);
        _OffGrindBuff = new DecreasingBuff(1f, 0.98f);
    }

    float GetForwardSpeed()
    {
        return ForwardSpeedModifier * _BuffManager.Modify(BuffManager.KEY_GLOBAL_SPEED, _BuffManager.Modify(BuffManager.KEY_LOCAL_SPEED, GameUtils.GetStateSpeed(_StateController.CurrentState)));
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
