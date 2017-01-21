using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTypeResolver : MonoBehaviour
{
    public const float WATER_HEIGHT_DEEP = 20; // 0 to 20
    public const float WATER_HEIGHT_SHALLOW = 23; // 22 to 23
    public const float WATER_HEIGHT_GROUND = 25; // 24 to 25

    public delegate void WaterTypeHandler(WaterType waterType);
    public event WaterTypeHandler OnWaterTypeChanged;

	private Terrain _currentTerrain;
	public float CurrentTerrainHeight;
	private int _prevTerrainHeightPosX;
	private int _prevTerrainHeightPosY;
	public float PrevTerrainHeight;
	public Dictionary<WaterType, float> WaterTypeRanges = new Dictionary<WaterType, float>();
	public WaterType PrevWaterType; 
	public WaterType CurrentWaterType = WaterType.None; 

	void Start () {
		WaterTypeRanges.Add(WaterType.Deep, WATER_HEIGHT_DEEP); 
		WaterTypeRanges.Add(WaterType.Shallow,WATER_HEIGHT_SHALLOW);
		//WaterTypeRanges.Add(WaterType.Ground,	23); // 23 to infin

		var ray = new Ray(transform.position, transform.TransformDirection(Vector3.down));
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, 50, LayerMask.GetMask("Ground")))
		{
			_currentTerrain = hit.transform.GetComponent<Terrain>();
		}
		else
		{
			Debug.LogError("Fuck me sideways I could find a terrain under me!");
		}
	}
	
	void Update ()
	{
		// Store last height
		if (_prevTerrainHeightPosX != (int)transform.position.x ||
			_prevTerrainHeightPosY != (int)transform.position.z)
		{
			_prevTerrainHeightPosX = (int) transform.position.x;
			_prevTerrainHeightPosY = (int) transform.position.z;
			PrevTerrainHeight = CurrentTerrainHeight;
		}

        CurrentTerrainHeight = GetTerrainHeightAt(transform.position);

		var wt = FindWaterType();
		if (wt != CurrentWaterType)
		{
			PrevWaterType = CurrentWaterType;
			CurrentWaterType = wt;

            if (OnWaterTypeChanged != null)
            {
                OnWaterTypeChanged(CurrentWaterType);
            }
		}
	}

	public WaterType FindWaterType()
	{
        return FindWaterType(CurrentTerrainHeight);
	}

	public WaterType FindWaterType(float height)
	{
		if (height <= WaterTypeRanges[WaterType.Deep]) return WaterType.Deep;
		if (height <= WaterTypeRanges[WaterType.Shallow]) return WaterType.Shallow;
		return WaterType.Ground;
	}

    public WaterType GetWaterTypeAt(Vector3 position)
    {
		return FindWaterType(GetTerrainHeightAt(position));
    }

    public float GetTerrainHeightAt(Vector3 position)
    {
        return _currentTerrain.terrainData.GetHeight(
            (int) (position.x / _currentTerrain.terrainData.heightmapScale.x),
            (int) (position.z / _currentTerrain.terrainData.heightmapScale.z));
    }

}

public enum WaterType
{
	None,
	Deep,
	Shallow,
	Ground
}
