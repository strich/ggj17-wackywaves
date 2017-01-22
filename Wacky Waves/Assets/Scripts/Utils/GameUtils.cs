using UnityEngine;

public static class GameUtils
{
    public const float POTENTIAL_MODIFIER = 4f;

    const float STEP_BACK = 1f;

    const float WATER_SPEED_DEEP = 1.2f;
    const float WATER_SPEED_WET_GRIND = 1f;
    const float WATER_SPEED_SHALLOW = 1f;
    const float WATER_SPEED_BAR_GRIND = 1f;
    const float WATER_SPEED_DRY_GRIND = 1f;
    const float WATER_SPEED_GROUND = 0.5f;

    const float TURN_SPEED_DEEP = 0.75f;
    const float TURN_SPEED_SHALLOW = 0.85f;
    const float TURN_SPEED_WET_GRIND = 2.0f;
    const float TURN_SPEED_BAR_GRIND = 2.0f;
    const float TURN_SPEED_DRY_GRIND = 2.0f;
    const float TURN_SPEED_GROUND = 0.75f;

	public const float WAVE_SIZE = 1f;

    static Transform _Transform;

    public static float GetDeviation(Transform t)
    {
        _Transform = t;

        Vector3 bedNormal = GetBedNormal();

        if (bedNormal == Vector3.zero)
        {
            return 0f;
        }

        Vector2 collapsedNormal = new Vector2(bedNormal.x, bedNormal.z).normalized;
        Vector2 forward = new Vector2(_Transform.forward.x, _Transform.forward.z);
        float dot = Vector2.Dot(forward, collapsedNormal);

        if (dot < 0)
        {
            collapsedNormal = -collapsedNormal;
        }

        return Vector2.Angle(forward, collapsedNormal);
    }

    public static float GetStateSpeed(StateController.State state)
    {
        switch (state)
        {
            case StateController.State.DEEP:
                return WATER_SPEED_DEEP;
            case StateController.State.WET_GRIND:
                return WATER_SPEED_WET_GRIND;
            case StateController.State.SHALLOW:
                return WATER_SPEED_SHALLOW;
            case StateController.State.BAR_GRIND:
                return WATER_SPEED_BAR_GRIND;
            case StateController.State.DRY_GRIND:
                return WATER_SPEED_DRY_GRIND;
            case StateController.State.GROUND:
                return WATER_SPEED_GROUND;
        }

        return 0f;
    }

    public static float GetStateTurnSpeed(StateController.State state)
    {
        switch (state)
        {
            case StateController.State.DEEP:
                return TURN_SPEED_DEEP;
            case StateController.State.WET_GRIND:
                return TURN_SPEED_WET_GRIND;
            case StateController.State.SHALLOW:
                return TURN_SPEED_SHALLOW;
            case StateController.State.BAR_GRIND:
                return TURN_SPEED_BAR_GRIND;
            case StateController.State.DRY_GRIND:
                return TURN_SPEED_DRY_GRIND;
            case StateController.State.GROUND:
                return TURN_SPEED_GROUND;
        }
        return 0f;
    }

    static Vector3 GetBedNormal()
    {
		RaycastHit directDownHit;
		RaycastHit backDownHit;
        if (Physics.Raycast(_Transform.position, Vector3.down, out directDownHit, Mathf.Infinity, LayerMask.GetMask("Ground")) &&
            Physics.Raycast(_Transform.position - (_Transform.forward * STEP_BACK), Vector3.down, out backDownHit, Mathf.Infinity, LayerMask.GetMask("Ground")))
        {
            return GetBedNormal(directDownHit, backDownHit);
        }
        else
        {
            Debug.LogError("[DirectionModifier] Couldn't raycast to get front and back bed hits");
        }

        return Vector3.zero;
    }

    static Vector3 GetBedNormal(RaycastHit directDownHit, RaycastHit backDownHit)
    {
        //NOTE: Need to raycast from the lowest point to the highest
        if (directDownHit.point.y > backDownHit.point.y)
        {
            return GetBedNormal(GetRaycastSource(backDownHit.point, directDownHit.point), _Transform.forward);
        }
        else if (backDownHit.point.y > directDownHit.point.y)
        {
            return GetBedNormal(GetRaycastSource(directDownHit.point, backDownHit.point), -_Transform.forward);
        }
        else
        {
            Debug.LogErrorFormat("[DirectionModifier] Couldn't get height differential, both at {0}, {1}", directDownHit.point, backDownHit.point);
            return Vector3.zero;
        }
    }

    static Vector3 GetRaycastSource(Vector3 mainSource, Vector3 heightModifierSource)
    {
        return new Vector3(mainSource.x, (mainSource.y + heightModifierSource.y) / 2f, mainSource.z);
    }

    static Vector3 GetBedNormal(Vector3 source, Vector3 forward)
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

    //NOTE: For signed angle, currently unused
    static float GetAngle(Vector2 v1, Vector2 v2)
    {
        var sign = Mathf.Sign(v1.x * v2.y - v1.y * v2.x);
        return Vector2.Angle(v1, v2) * sign;
    }
}
