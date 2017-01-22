using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSizeRenderer : MonoBehaviour
{
	public GameObject SmallPrefab;
	public GameObject MediumPrefab;
	public GameObject BigPrefab;
	public GameObject SmallShallowPrefab;
	public GameObject MediumShallowPrefab;
	public GameObject BigShallowPrefab;

	public GameObject Renderer;

	public float SmallSizeWatermark = 3f;
	public float MedSizeWatermark = 6f;
	public float BigSizeWatermark = 9f;

	private float prevSize = 0f;
	private float currentSize = 0f;
	private PlayerWaveSize _currentWaveSize;
	private PlayerWaveSize _prevWaveSize;
	private bool _useShallowWave = false;

	private MusicManager _musicManager;
	private PlayerController _playerController;
	private StateController _stateController;
	public GameObject FollowerObjects;
	public GameObject ScaleTarget;

	void Start ()
	{
		_musicManager = GameObject.Find("Music Manager").GetComponent<MusicManager>(); // Deal with it yo
		_playerController = GetComponent<PlayerController>();
		_stateController = GetComponent<StateController>();
		_stateController.OnStateChanged += OnStateChanged;
	}

	private void OnStateChanged(StateController.State currentstate, StateController.State prevstate)
	{
		switch (currentstate)
		{
			case StateController.State.NONE:
				break;
			case StateController.State.DEEP:
				_useShallowWave = false;
				break;
			case StateController.State.WET_GRIND:
				break;
			case StateController.State.SHALLOW:
				_useShallowWave = true;
				break;
			case StateController.State.BAR_GRIND:
				break;
			case StateController.State.DRY_GRIND:
				break;
			case StateController.State.GROUND:
				_useShallowWave = true;
				break;
			default:
				throw new ArgumentOutOfRangeException("currentstate", currentstate, null);
		}

		ChangeWaveType();
	}

	void Update()
	{
		currentSize = _playerController.GetSize();
		if (Math.Abs(prevSize - currentSize) > 0.001f)
		{
			if (HasChangedMajorSize()) UpdateMajorSizeChange();

			prevSize = currentSize;
		}

		UpdateMinorSizeChange();
	}

	private void UpdateMinorSizeChange()
	{
		//float newMinorSize = 1f;

		//switch (_currentWaveSize)
		//{
		//	case PlayerWaveSize.Small:
		//		break;
		//	case PlayerWaveSize.Medium:
		//		break;
		//	case PlayerWaveSize.Big:
		//		break;
		//	default:
		//		throw new ArgumentOutOfRangeException();
		//}

		ScaleTarget.transform.localScale = Vector3.Lerp(ScaleTarget.transform.localScale, new Vector3(1.5f,1,1) * currentSize, Time.deltaTime);
		//FollowerObjects.transform.localScale = Vector3.Lerp(FollowerObjects.transform.localScale, Vector3.one / currentSize, Time.deltaTime);

	}

	private void UpdateMajorSizeChange()
	{
		_prevWaveSize = _currentWaveSize;
		if (currentSize < SmallSizeWatermark) _currentWaveSize = PlayerWaveSize.Small;
		else if (currentSize < MedSizeWatermark) _currentWaveSize = PlayerWaveSize.Medium;
		else if (currentSize < BigSizeWatermark) _currentWaveSize = PlayerWaveSize.Big;

		ChangeWaveType();
	}

	private void ChangeWaveType()
	{
		//_musicManager.SetIntensity((int)currentSize);
		//if(currentSize > 1.01f)_musicManager.IncreaseIntensity();

		for (int i = 0; i < Renderer.transform.childCount; i++)
		{
			Destroy(Renderer.transform.GetChild(i).gameObject);
		}

		switch (_currentWaveSize)
		{
			case PlayerWaveSize.Small:
				_musicManager.SetIntensity(1);
				Instantiate(_useShallowWave ? SmallShallowPrefab : SmallPrefab, Renderer.transform, false);
				break;
			case PlayerWaveSize.Medium:
				_musicManager.SetIntensity(2);
				Instantiate(_useShallowWave ? MediumShallowPrefab : MediumPrefab, Renderer.transform, false);
				break;
			case PlayerWaveSize.Big:
				_musicManager.SetIntensity(3);
				Instantiate(_useShallowWave ? BigShallowPrefab : BigPrefab, Renderer.transform, false);
				break;
			default:
				throw new ArgumentOutOfRangeException();
		}
	}

	private bool HasChangedMajorSize()
	{
		PlayerWaveSize newWaveSize = PlayerWaveSize.Small;
		if (currentSize < SmallSizeWatermark) newWaveSize = PlayerWaveSize.Small;
		else if (currentSize < MedSizeWatermark) newWaveSize = PlayerWaveSize.Medium;
		else if (currentSize < BigSizeWatermark) newWaveSize = PlayerWaveSize.Big;

		return newWaveSize != _currentWaveSize;
	}
}

public enum PlayerWaveSize
{
	Small,
	Medium,
	Big
}
