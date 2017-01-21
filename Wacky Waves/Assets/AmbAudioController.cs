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
	private WaterTypeResolver _resolver;

	static Random rnd = new Random();

	void Start () {
		_player = GameObject.Find("Player");
		_resolver = _player.GetComponent<WaterTypeResolver>();
		_resolver.OnWaterTypeChanged += OnWaterTypeChanged;
	}

	void OnDestroy()
	{
		_player.GetComponent<WaterTypeResolver>().OnWaterTypeChanged -= OnWaterTypeChanged;
	}

	private void OnWaterTypeChanged(WaterType waterType)
	{
		switch (waterType)
		{
			case WaterType.None:
				break;
			case WaterType.Deep:
				ChangeClip(DeepAudioClips[rnd.Next(DeepAudioClips.Count)]);
				break;
			case WaterType.Shallow:
				ChangeClip(ShallowAudioClips[rnd.Next(ShallowAudioClips.Count)]);
				break;
			case WaterType.Ground:
				ChangeClip(GroundAudioClips[rnd.Next(GroundAudioClips.Count)]);
				break;
			default:
				throw new ArgumentOutOfRangeException("waterType", waterType, null);
		}
	}

	private void ChangeClip(AudioClip clip)
	{
		SourceA.clip = clip;
		SourceA.Play();
	}
}
