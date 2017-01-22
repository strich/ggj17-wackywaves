using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
	public List<AudioClip> MusicTracks;
	private List<AudioSource> _sources = new List<AudioSource>();
	private int _intensityLevel = 1;

	void Start () {
		foreach (var musicTrack in MusicTracks)
		{
			var src = gameObject.AddComponent<AudioSource>();
			src.clip = musicTrack;
			_sources.Add(src);
		}

		_sources.ForEach(s => s.Play());
	}

	public void IncreaseIntensity()
	{
		_intensityLevel = Mathf.Clamp(_intensityLevel + 1, 1, MusicTracks.Count);
		ChangeTrack();
	}

	public void DecreaseIntensity()
	{
		_intensityLevel = Mathf.Clamp(_intensityLevel - 1, 1, MusicTracks.Count);
		ChangeTrack();
	}

	private void ChangeTrack()
	{
		_sources.ForEach(s => s.volume = 0f);

		_sources[_intensityLevel].volume = 1f;
	}
}
