using System;
using UnityEngine;

[RequireComponent(typeof(PlayerController), typeof(WaterTypeResolver))]
public class StateController : MonoBehaviour
{
    public enum State { NONE, DEEP, WET_GRIND, SHALLOW, DRY_GRIND, GROUND }

    const float GRIND_WIDTH = 2f;

    public Transform LeftSensor;
    public Transform RightSensor;

    public delegate void StateHandler(State currentState, State prevState);
    public event StateHandler OnStateChanged;

    WaterTypeResolver _WaterTypeResolver;

    bool _Grinding;

    [SerializeField]
    State _State = State.NONE;
    public State CurrentState
    {
        get
        {
            return _State;
        }
    }

	void Start()
    {
        _WaterTypeResolver = GetComponent<WaterTypeResolver>();
	}
	
	void Update()
    {
        State state = GetCurrentState();

        if (_State != state)
        {
            if (OnStateChanged != null)
            {
                OnStateChanged(state, _State);
            }

            _State = state;
        }

        switch (GetCurrentState())
        {
            case StateController.State.DRY_GRIND:
                ComboManager.Instance.AddComboElement(GrindHandler.DRY_GRIND);
                break;
            case StateController.State.WET_GRIND:
                ComboManager.Instance.AddComboElement(GrindHandler.WET_GRIND);
                break;
            default:
                //nothing doing
                break;


        }
    }

    State GetCurrentState()
    {
        if (IsDryGrinding())
        {
            return State.DRY_GRIND;
        }
        else if (IsWetGrinding())
        {
            return State.WET_GRIND;
        }

        switch (_WaterTypeResolver.CurrentWaterType)
        {
            case WaterType.Deep:
                return State.DEEP;
            case WaterType.Shallow:
                return State.SHALLOW;
            case WaterType.Ground:
                return State.GROUND;
            default:
                return State.NONE;
        }
    }

    bool IsDryGrinding()
    {
        return IsStraddling(WaterType.Shallow, WaterType.Ground);
    }

    bool IsWetGrinding()
    {
        return IsStraddling(WaterType.Deep, WaterType.Shallow);
    }

    bool IsStraddling(WaterType typeA, WaterType typeB)
    {
        return (IsOver(LeftSensor.position, typeA) && IsOver(RightSensor.position, typeB)) ||
                (IsOver(RightSensor.position, typeA) && IsOver(LeftSensor.position, typeB));
    }

    bool IsOver(Vector3 position, WaterType type)
    {
        return _WaterTypeResolver.GetWaterTypeAt(position) == type;
    }
}