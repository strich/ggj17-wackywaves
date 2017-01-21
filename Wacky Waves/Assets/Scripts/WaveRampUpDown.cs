using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WaveRampUpDown : MonoBehaviour
{
	private WaterTypeResolver _resolver;
	public WaterTypeTransition CurrentWaterTypeTransition;
	public WaterTypeTransition NextWaterTypeTransition;

	void Start ()
	{
		_resolver = gameObject.GetComponent<WaterTypeResolver>();
		_resolver.OnWaterTypeChanged += OnWaterTypeChanged;
	}

	void OnDestroy()
	{
		_resolver.OnWaterTypeChanged -= OnWaterTypeChanged;
	}

	private void OnWaterTypeChanged(WaterType waterType)
	{
		switch (_resolver.PrevWaterType)
		{
			case WaterType.None:
				break;
			case WaterType.Deep:
				if(_resolver.CurrentWaterType == WaterType.Shallow) NextWaterTypeTransition = WaterTypeTransition.DeepToShallow;
				if(_resolver.CurrentWaterType == WaterType.Ground)	NextWaterTypeTransition = WaterTypeTransition.DeepToGround;
				break;
			case WaterType.Shallow:
				if (_resolver.CurrentWaterType == WaterType.Deep) NextWaterTypeTransition = WaterTypeTransition.ShallowToDeep;
				if (_resolver.CurrentWaterType == WaterType.Ground) NextWaterTypeTransition = WaterTypeTransition.ShallowToGround;
				break;
			case WaterType.Ground:
				if (_resolver.CurrentWaterType == WaterType.Deep) NextWaterTypeTransition = WaterTypeTransition.GroundToDeep;
				if (_resolver.CurrentWaterType == WaterType.Shallow) NextWaterTypeTransition = WaterTypeTransition.GroundToShallow;
				break;
			default:
				throw new ArgumentOutOfRangeException();
		}

		StartCoroutine(StartTransition(NextWaterTypeTransition));
	}

	void Update()
	{

	}

	private IEnumerator StartTransition(WaterTypeTransition transition)
	{
		//yield return new WaitForSeconds(.1f);
		// TODO spawn some wave types, particles, etc
		// TODO audio here
		
		gameObject.GetComponentInChildren<Renderer>().sharedMaterial.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f); // Temp
		CurrentWaterTypeTransition = transition;

		yield return null;
	}
}

public enum WaterTypeTransition
{
	DeepToShallow,
	DeepToGround,
	ShallowToDeep,
	ShallowToGround,
	GroundToShallow,
	GroundToDeep
}
