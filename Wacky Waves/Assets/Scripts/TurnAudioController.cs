using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class TurnAudioController : MonoBehaviour {
	public List<AudioClip> LeftTurnSmall;
	public List<AudioClip> LeftTurnMed;
	public List<AudioClip> LeftTurnBig;
	public List<AudioClip> RightTurnSmall;
	public List<AudioClip> RightTurnMed;
	public List<AudioClip> RightTurnBig;

	private PlayerController _player;
	private AudioCrossFader _crossFader;

	static Random rnd = new Random();

	public float rotInput;

	private bool _isPlayingLeft = false;
	private bool _isPlayingRight = false;

	void Start () {
		_player = GameObject.Find("Player").GetComponent<PlayerController>();
		_crossFader = GetComponent<AudioCrossFader>();
	}
	
	void Update ()
	{
		rotInput = _player.GetRawRotInput();

		if (Math.Abs(rotInput) < 0.001f)
		{
			_isPlayingLeft = false;
			_isPlayingRight = false;
			_crossFader.StopAll();
		}
		else if (rotInput < 0 && !_isPlayingLeft)
		{
			_isPlayingLeft = true;
			_isPlayingRight = false;
			_crossFader.CrossFade(LeftTurnSmall[rnd.Next(LeftTurnSmall.Count)], 1f, 1f);
		}
		else if (rotInput > 0 && !_isPlayingRight)
		{
			_isPlayingLeft = false;
			_isPlayingRight = true;
			_crossFader.CrossFade(RightTurnSmall[rnd.Next(RightTurnSmall.Count)], 1f, 1f);
		}
	}
}
