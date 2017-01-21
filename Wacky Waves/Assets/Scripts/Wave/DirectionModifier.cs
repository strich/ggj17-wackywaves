using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WaterTypeResolver))]
public class DirectionModifier : MonoBehaviour {
    public const float STEP_BACK = 1f;

    public float RotationAmount;

    WaterTypeResolver _WaterTypeResolver;

    void Awake()
    {
        _WaterTypeResolver = GetComponent<WaterTypeResolver>();
        _WaterTypeResolver.OnWaterTypeChanged += OnWaterTypeChanged;
    }

    void Update()
    {
        if (Input.GetKeyDown("c"))
        {
            CheckWave();
        }
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
        Vector2 collapsedNormal = new Vector2(bedNormal.x, bedNormal.y).normalized;
        float dot = Vector2.Dot(transform.forward, collapsedNormal);

        Debug.LogFormat("Dot: {0}", dot);

        transform.rotation *= Quaternion.Euler(0f, RotationAmount * dot, 0f);
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
            return GetBedNormal(backDownHit, transform.forward);
        }
        else if (backDownHit.point.y > directDownHit.point.y)
        {
            return GetBedNormal(directDownHit, -transform.forward);
        }
        else
        {
            Debug.LogError("[DirectionModifier] Couldn't get height differential");
            return Vector3.zero;
        }
    }

    Vector3 GetBedNormal(RaycastHit hit, Vector3 forward)
    {
        return Vector3.zero;
    }
}
