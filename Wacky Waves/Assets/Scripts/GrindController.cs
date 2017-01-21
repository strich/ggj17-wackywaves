using UnityEngine;

[RequireComponent(typeof(PlayerController), typeof(WaterTypeResolver))]
public class GrindController : MonoBehaviour
{
    const float GRIND_WIDTH = 2f;

    public Transform LeftSensor;
    public Transform RightSensor;

    PlayerController _PlayerController;
    WaterTypeResolver _WaterTypeResolver;

    bool _Grinding;
    Buff _GrindBuff;

	void Start()
    {
        _PlayerController = GetComponent<PlayerController>();
        _WaterTypeResolver = GetComponent<WaterTypeResolver>();
        _GrindBuff = new IncreasingBuff(1f, 1.001f, 10f);
	}
	
	void Update()
    {
        if (IsGrinding() != _Grinding)
        {
            _Grinding = !_Grinding;
            UpdateGrinding();
        }
	}

    void UpdateGrinding()
    {
        if (_Grinding)
        {
            _PlayerController.AddBuff(BuffManager.KEY_GLOBAL_SPEED, _GrindBuff);
        }
        else
        {
            _PlayerController.RemoveBuff(BuffManager.KEY_GLOBAL_SPEED, _GrindBuff);
        }

        GetComponentInChildren<Renderer>().material.color = _Grinding ? Color.blue : Color.white;
    }

    bool IsGrinding()
    {
        bool leftOverGround = GetOverGround(LeftSensor.position);
        bool rightOverGround = GetOverGround(RightSensor.position);

        return (leftOverGround && !rightOverGround) ||
                (!leftOverGround && rightOverGround);
    }

    bool GetOverGround(Vector3 position)
    {
        return _WaterTypeResolver.GetWaterTypeAt(position) == WaterType.Ground;
    }
}
