using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTypeResolver : MonoBehaviour
{
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
		WaterTypeRanges.Add(WaterType.Deep,		20); // 0 to 20
		WaterTypeRanges.Add(WaterType.Shallow,	23); // 22 to 23
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

		CurrentTerrainHeight = _currentTerrain.terrainData.GetHeight((int) transform.position.x, (int) transform.position.z);


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
		if(CurrentTerrainHeight <= WaterTypeRanges[WaterType.Deep]) return WaterType.Deep;
		if(CurrentTerrainHeight <= WaterTypeRanges[WaterType.Shallow]) return WaterType.Shallow;
		return WaterType.Ground;
	}
}

public enum WaterType
{
	None,
	Deep,
	Shallow,
	Ground
}
