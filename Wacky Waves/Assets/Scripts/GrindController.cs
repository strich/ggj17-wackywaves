using UnityEngine;

[RequireComponent(typeof(PlayerController), typeof(WaterTypeResolver))]
public class GrindController : MonoBehaviour
{
    const float GRIND_WIDTH = 2f;

    PlayerController _PlayerController;
    WaterTypeResolver _WaterTypeResolver;

    bool _Grinding;
    Buff _GrindBuff;

	void Start ()
    {
        _PlayerController = GetComponent<PlayerController>();
        _WaterTypeResolver = GetComponent<WaterTypeResolver>();
        _GrindBuff = new IncreasingBuff(2f, 1.1f, 10f);
	}
	
	void Update ()
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
        bool leftOverGround = GetOverGround(transform.position - transform.right * GRIND_WIDTH);
        bool rightOverGround = GetOverGround(transform.position + transform.right * GRIND_WIDTH);

        return (leftOverGround && !rightOverGround) ||
                (!leftOverGround && rightOverGround);
    }

    bool GetOverGround(Vector3 position)
    {
        return _WaterTypeResolver.GetWaterTypeAt(position) == WaterType.Ground;
    }
}
