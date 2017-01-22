using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboManager : MonoBehaviour {

    // Tags
    public static readonly string MULTIPLIER = "MULTIPLIER";
    public static readonly string POINTS = "POINTS";
    public static readonly string COMBO_OVER = "COMBO_OVER";
    //  public static readonly string SPEEDUP = "SPEEDUP"; ?


    public delegate void ComboHandler(string tag, int quantity);
    public event ComboHandler ComboHandlers;

    public float ComboCountdown;
    private float countdown;
     
    private Dictionary<string, int> CurrentCombo;
    private int comboScore;
    private int comboMultiplier;
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
		if (countdown>0)
        {
            countdown -= Time.deltaTime;
            if (countdown <= 0)
            {
                countdown = 0;
                // Combo Over!

                // Send Points to ScoreManager
                ScoreManager.Instance.UpdateScore(comboMultiplier * comboScore, COMBO_OVER);
                // Clear Combos
                ResetCombo();
                

            }
        }
	}

    void ResetCombo()
    {
        ComboHandlers.Invoke(COMBO_OVER, 0);
        CurrentCombo    = new Dictionary<string, int> ();
        comboScore      = 0;
        comboMultiplier = 0;
    }



    /// <summary>
    /// Add a comboelement to current combo
    /// </summary>
    /// <param name="element"></param>
    public void AddComboElement(string element, bool end)
    {
        int count = 0;
        ComboElement elementT;
        if (!ComboElements.TryGetValue(element, out elementT))
        {
            Debug.LogError("ComboElement " + element + " does not exist!");
        }

        bool inCombo = CurrentCombo.TryGetValue(element, out count);

       // int increment;
        //if (elementT.Instant)
        //{
        //    increment = 1;
        //}
        // else a registered combo handler 
        // invocation will deal with it;
       
        if (inCombo)
        {
            CurrentCombo[element] = count + 1;
        }
        else
        {
            CurrentCombo.Add(element, 1);
            count = 1;
        }

        countdown = ComboCountdown;
        //heckCombos();
        // 
        // deal with any continous or other odd combo rules
        ComboHandlers.Invoke(element, count);
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
            Debug.LogWarning("ComboElement " + element.Name + " already exists!");
        }
    }
}
