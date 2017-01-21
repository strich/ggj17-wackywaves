using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTypeResolver : MonoBehaviour
{
	private Terrain _currentTerrain;
	public float CurrentTerrainHeight;

	void Start () {
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
		CurrentTerrainHeight = _currentTerrain.terrainData.GetHeight((int) transform.position.x, (int) transform.position.z);
	}
}
