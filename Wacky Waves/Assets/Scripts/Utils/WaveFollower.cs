using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveFollower : MonoBehaviour {
	public float xCoef = 0.5f, xBase = -90, xModif = 90;
	public float yCoef = 0.3f, yBase = 8, yModif = 180;
	public float zCoef = 0.1f, zBase = 64, zModif = -90;

	public float BaseHeight = -1f;
	public float HeightModif = 3f;
	public float HeightSpeed = 1f;

	public float BaseWidth = -1f;
	public float WidthModif = 0.01f;
	public float WidthSpeed = 1f;

	private float startTime;

	void Awake()
	{
		startTime = Time.time + 100 * Random.value;
	}

	void Update()
	{
		float t = Time.realtimeSinceStartup + startTime;

		float x = xModif * Mathf.Cos(xCoef * t + xBase);
		float y = yModif * Mathf.Sin(yCoef * t + yBase);
		float z = zModif * Mathf.Sin(zCoef * t + zBase);
		transform.rotation = Quaternion.Euler(x, y, z);

		if (HeightSpeed > 0)
		{
			t *= HeightSpeed;
			//\cos \left(1.2x\right)+\left(\sin \left(0.2x\right)\right)\ +\ 0.5\cos \left(2x\right)
			//
			float height = BaseHeight + HeightModif * 0.4f * (Mathf.Cos(1.2f * t) + Mathf.Sin(0.2f * t) + 0.5f * Mathf.Cos(2 * t));
			float width = /*BaseWidth +*/ WidthModif * 0.4f * (Mathf.Cos(1.2f * t) + Mathf.Sin(0.2f * t) + 0.5f * Mathf.Cos(2 * t));
			var loc = transform.position;
			loc.y = height;
			loc.x += width;
			transform.position = loc;
		}
	}
}