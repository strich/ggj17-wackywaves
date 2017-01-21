using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using Random = System.Random;

public class AmbAudioController : MonoBehaviour
{
	public List<AudioClip> ShallowAudioClips;
	public List<AudioClip> DeepAudioClips;
	public List<AudioClip> GroundAudioClips;
	public AudioSource SourceA;
	public AudioSource SourceB;

	private GameObject _player;
    StateController _StateController;

	static Random rnd = new Random();

	void Start () {
		_player = GameObject.Find("Player");
		_StateController = _player.GetComponent<StateController>();
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
                ChangeClip(DeepAudioClips[rnd.Next(DeepAudioClips.Count)]);
                break;
            case StateController.State.WET_GRIND:
                break;
            case StateController.State.SHALLOW:
				ChangeClip(ShallowAudioClips[rnd.Next(ShallowAudioClips.Count)]);
                break;
            case StateController.State.DRY_GRIND:
                break;
            case StateController.State.GROUND:
				ChangeClip(GroundAudioClips[rnd.Next(GroundAudioClips.Count)]);
                break;
			default:
				throw new ArgumentOutOfRangeException("state", currentState, null);
		}
	}

	private void ChangeClip(AudioClip clip)
	{
		SourceA.clip = clip;
		SourceA.Play();
	}
}
