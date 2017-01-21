using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    public static readonly string WavePoints = "Wave";
    public static readonly string DolphinPoints = "Dolphin";
    public static readonly string SurferPoints = "Surfer";
    public static readonly string TrashMonster = "TrashMonster";
    public static readonly string Shark = "Shark";
    public static readonly string Tree = "Tree";
    public static readonly string Boat = "Boat";
    public static readonly string Clicked = "Clicked";

    private static ScoreManager instance;
    public static ScoreManager Instance {
        get {
            if (!instance)

            {
                instance = new GameObject("ScoreManager").AddComponent<ScoreManager>();
            }
            return instance  ;
        } private set { instance = value; } }
    
    public delegate void ScoreHandler(int points, string tag);
    public event ScoreHandler ScoreHandlers;

    private int score;
    
    private Dictionary<string, int> scores;

    void Awake ()
    {
        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this);
        }
        scores = new Dictionary<string, int>();
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UpdateScore(int points, string tag)
    {
        int dscore=0;
        score += points;
        if (!scores.TryGetValue(tag, out dscore))
        {
            scores.Add(tag, points);
        }
        else
        {
            scores[tag] = points + dscore;
        }

        if (ScoreHandlers!=null)
        {
            ScoreHandlers.Invoke(points, tag);
        }
    }

    public bool  GetSubScore (string tag, out int score)
    {
        return scores.TryGetValue(tag, out score);
    }
   



}
