using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour {
    public GameObject Title;

	void Start () {
        GameManager.OnStateChanged += OnStateChanged;
	}

    void OnDestroy()
    {
    }

    void OnStateChanged(GameManager.State state)
    {
        switch (state)
        {
            case GameManager.State.TITLE:
                Title.SetActive(true);
                break;
            case GameManager.State.LIVE:
                Title.SetActive(false);
                break;
            case GameManager.State.GAME_OVER:
                Title.SetActive(false);
                break;
        }
    }
}
