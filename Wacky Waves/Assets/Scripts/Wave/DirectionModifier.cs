using UnityEngine;

[RequireComponent(typeof(PlayerController), typeof(WaterTypeResolver))]
public class DirectionModifier : MonoBehaviour
{
    public const float STEP_BACK = 1f;

    public float RotationAmount;

    PlayerController _PlayerController;
    WaterTypeResolver _WaterTypeResolver;

    void Awake()
    {
        _PlayerController = GetComponent<PlayerController>();
        _WaterTypeResolver = GetComponent<WaterTypeResolver>();
        _WaterTypeResolver.OnWaterTypeChanged += OnWaterTypeChanged;
    }

    void Update()
    {
        //_PlayerController.AddRotation();
    }

    void OnDestroy()
    {
        _WaterTypeResolver.OnWaterTypeChanged -= OnWaterTypeChanged;
    }

    void OnWaterTypeChanged(WaterType waterType)
    {
        CheckWave();
    }

    void CheckWave()
    {
        Vector3 bedNormal = GetBedNormal();

        if (bedNormal == Vector3.zero)
        {
            return;
        }

        Vector2 collapsedNormal = new Vector2(bedNormal.x, bedNormal.z).normalized;
        Vector2 forward = new Vector2(transform.forward.x, transform.forward.z);
        float dot = Vector2.Dot(forward, collapsedNormal);

        bool flipped = false;
        if (dot < 0)
        {
            flipped = true;
            collapsedNormal = -collapsedNormal;
        }

        if (GetAngle(forward, collapsedNormal) < 0)
        {
            flipped = !flipped;
        }

        _PlayerController.AddRotation(
            flipped ? - RotationAmount : RotationAmount);
    }

    float GetAngle(Vector2 v1, Vector2 v2)
    {
        var sign = Mathf.Sign(v1.x * v2.y - v1.y * v2.x);
        return Vector2.Angle(v1, v2) * sign;
    }

    Vector3 GetBedNormal()
    {
		RaycastHit directDownHit;
		RaycastHit backDownHit;
        if (Physics.Raycast(transform.position, Vector3.down, out directDownHit, Mathf.Infinity, LayerMask.GetMask("Ground")) &&
            Physics.Raycast(transform.position - (transform.forward * STEP_BACK), Vector3.down, out backDownHit, Mathf.Infinity, LayerMask.GetMask("Ground")))
        {
            return GetBedNormal(directDownHit, backDownHit);
        }
        else
        {
            Debug.LogError("[DirectionModifier] Couldn't raycast to get front and back bed hits");
        }

        return Vector3.zero;
    }

    Vector3 GetBedNormal(RaycastHit directDownHit, RaycastHit backDownHit)
    {
        //NOTE: Need to raycast from the lowest point to the highest
        if (directDownHit.point.y > backDownHit.point.y)
        {
            return GetBedNormal(GetRaycastSource(backDownHit.point, directDownHit.point), transform.forward);
        }
        else if (backDownHit.point.y > directDownHit.point.y)
        {
            return GetBedNormal(GetRaycastSource(directDownHit.point, backDownHit.point), -transform.forward);
        }
        else
        {
            Debug.LogErrorFormat("[DirectionModifier] Couldn't get height differential, both at {0}, {1}", directDownHit.point, backDownHit.point);
            return Vector3.zero;
        }
    }

    Vector3 GetRaycastSource(Vector3 mainSource, Vector3 heightModifierSource)
    {
        return new Vector3(mainSource.x, (mainSource.y + heightModifierSource.y) / 2f, mainSource.z);
    }

    Vector3 GetBedNormal(Vector3 source, Vector3 forward)
    {
        RaycastHit hit;
        if (Physics.Raycast(source, forward, out hit, Mathf.Infinity, LayerMask.GetMask("Ground")))
        {
            return hit.normal;
        }
        else
        {
            Debug.LogError("[DirectionModifier] All went wrong at the last hurdle");
            return Vector3.zero;
        }
    }
}