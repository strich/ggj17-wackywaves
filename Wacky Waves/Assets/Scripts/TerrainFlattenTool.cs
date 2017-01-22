using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainFlattenTool : MonoBehaviour {

    Terrain _Terrain;

	public void Flatten()
    {
        _Terrain = GetComponent<Terrain>();

        float[,] heights = _Terrain.terrainData.GetHeights(0, 0, _Terrain.terrainData.heightmapWidth, _Terrain.terrainData.heightmapHeight);
        for (int i = 0; i < heights.GetLength(0); ++i)
        {
            for (int j = 0; j < heights.GetLength(1); ++j)
            {
                float height = heights[i, j];
                float clampedHeight = Clamp(_Terrain.terrainData.size.y * height);
                float adjustedClampedHeight = clampedHeight / _Terrain.terrainData.size.y;
                heights[i, j] = adjustedClampedHeight;
            }
        }
        _Terrain.terrainData.SetHeights(0, 0, heights);
	}

    float Clamp(float value)
    {
        if (value <= WaterTypeResolver.WATER_HEIGHT_DEEP)
        {
            return 0;
        }
        else if (value <= WaterTypeResolver.WATER_HEIGHT_SHALLOW)
        {
            return 22.5f;
        }
        else if (value <= WaterTypeResolver.WATER_HEIGHT_GROUND)
        {
            return 24;
        }

        return value;
    }

}
