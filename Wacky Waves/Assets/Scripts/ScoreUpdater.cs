using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdater : MonoBehaviour {
    private int score = 0;
    public int Score { get { return score; } private set { score = value; } }

    private Text scoreText;
    void Awake()
    {
        scoreText = GetComponent<Text>();
    }

    // Use this for initialization
    void Start() {
        //ScoreManager.Instance.ScoreHandlers += UpdateScore;
        // get instance of  ScoreManager
        // register our delegate as a handler for score update
        ScoreManager.Instance.ScoreHandlers += UpdateScore;
    }

    // Update is called once per frame
    void Update() {

    }

    void UpdateScore(int points, string tag)
    {
        score += points;
        scoreText.text = score.ToString();
        Debug.Log(tag + " scores " + points + " points");
    }

    void OnDestroy()
    {
        //ScoreManager.Instance.ScoreHandlers -= UpdateScore;
    }

    public void DelegateScoreUpdate(int points)
    {
        ScoreManager.Instance.UpdateScore(points, ScoreManager.Clicked);
    }

}
