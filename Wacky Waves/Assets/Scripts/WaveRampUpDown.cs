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

    StateController _StateController;

	void Start ()
	{
		_StateController = GetComponent<StateController>();
		_StateController.OnStateChanged += OnStateChanged;
	}

	void OnDestroy()
	{
		_StateController.OnStateChanged -= OnStateChanged;
	}

    void OnStateChanged(StateController.State currentState, StateController.State prevState)
    {
		switch (currentState)
		{
            case StateController.State.DEEP:
				if(_resolver.CurrentWaterType == WaterType.Shallow) NextWaterTypeTransition = WaterTypeTransition.DeepToShallow;
				if(_resolver.CurrentWaterType == WaterType.Ground)	NextWaterTypeTransition = WaterTypeTransition.DeepToGround;
				break;
            case StateController.State.WET_GRIND:
                break;
            case StateController.State.SHALLOW:
				if (_resolver.CurrentWaterType == WaterType.Deep) NextWaterTypeTransition = WaterTypeTransition.ShallowToDeep;
				if (_resolver.CurrentWaterType == WaterType.Ground) NextWaterTypeTransition = WaterTypeTransition.ShallowToGround;
				break;
            case StateController.State.DRY_GRIND:
                break;
            case StateController.State.GROUND:
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
