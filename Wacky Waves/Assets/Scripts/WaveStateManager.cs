using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveStateManager : MonoBehaviour {
    // Needs more everything

    //public static readonly string WavePoints = "Wave";
    //public static readonly string DolphinPoints = "Dolphin";
    //public static readonly string SurferPoints = "Surfer";
    //public static readonly string TrashMonster = "TrashMonster";
    //public static readonly string Shark = "Shark";
    //public static readonly string Tree = "Tree";
    //public static readonly string Boat = "Boat";
    //public static readonly string Clicked = "Clicked";

    private static WaveStateManager instance;
    public static WaveStateManager Instance { get { return instance; } private set { instance = value; } }

    public delegate void WaveHandler(float mass);
    public event WaveHandler WaveHandlers;

    private float mass;
    private Vector2 velocity;

   // private Dictionary<string, int> scores;

    void Awake()
    {
        instance = this;
        velocity = new Vector2(0, 0);
        mass = 0;
      // scores = new Dictionary<string, int>();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void IncreaseMass(float imass)
    {
        mass += imass;
        WaveHandlers.Invoke(mass);
        //int dscore = 0;
        //score += points;
        //if (!scores.TryGetValue(tag, out dscore))
        //{
        //    scores.Add(tag, points);
        //}
        //else
        //{
        //    scores[tag] = points + dscore;
        //}

        //if (ScoreHandlers != null)
        //{
        //    ScoreHandlers.Invoke(points, tag);
        //}
    }
    




}


