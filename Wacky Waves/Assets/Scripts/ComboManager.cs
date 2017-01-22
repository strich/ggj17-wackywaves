using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboManager : MonoBehaviour {

    // Tags
    public static readonly string MULTIPLIER = "MULTIPLIER";
    public static readonly string POINTS = "POINTS";
   //  public static readonly string SPEEDUP = "SPEEDUP"; ?

    public delegate void ComboHandler(int value, string tag);
    public event ComboHandler ScoreHandlers;

    public float ComboCountdown;
    private float countdown;
     
    private Dictionary<string, int> CurrentCombo;
    private Dictionary<string, ComboElement> ComboElements;



    private static ComboManager instance;
    public static ComboManager Instance
    {
        get
        {
            if (!instance)
            {
                instance = new GameObject("ComboManager").AddComponent<ComboManager>();
            }
            return instance;
        }
        private set { instance = value; }
    }

    public struct Combo
    {
        string Name;
        Dictionary<ComboElement, int> RequiredElements;
        int Points;
    }

    public struct ComboElement
    {
        public string  Name;       //dolphin / surfer etc?
        public bool Instant;    // or continuous
        public int Points;     // instant points, or points per second
      //  int Quantity;       // number of elements / lenght of grind
    }

    void Awake()
    {
        ComboElements = new Dictionary<string, ComboElement>();
        CurrentCombo = new Dictionary<string, int>();


    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}



    /// <summary>
    /// Add a comboelement to current combo
    /// </summary>
    /// <param name="element"></param>
    public void AddComboElement(string element)
    {
        int count = 0;
        if (CurrentCombo.TryGetValue(element, out count))
        {
            CurrentCombo[element] = count + 1;
        }
        else
        {
            CurrentCombo.Add(element, 1);
        }
        countdown = ComboCountdown;
       //heckCombos();
    }

    ///// <summary>
    ///// Check the combos dictionary for 
    ///// </summary>
    //private void CheckCombos()
    //{
        
    //}

    /// <summary>
    /// Add combo Type to the Manager? 
    /// </summary>
    /// <param name="element"></param>
    public void CreateComboElement(ComboElement element)
    {
        if(!ComboElements.ContainsKey(element.Name))
        {
            ComboElements.Add(element.Name, element);
        }
        else
        {
            Debug.LogWarning("ComboElement " + element.Name + " already exisists!");
        }
    }
}
