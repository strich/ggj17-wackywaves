using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboManager : MonoBehaviour {

    // Tags
    public static readonly string MULTIPLIER = "MULTIPLIER";
    public static readonly string POINTS = "POINTS";
    public static readonly string COMBO_OVER = "COMBO_OVER";
    //  public static readonly string SPEEDUP = "SPEEDUP"; ?


    public delegate void ComboHandler(string tag, int quantity);
    public event ComboHandler ComboHandlers;

    public float ComboCountdown = 1;
    private float countdown;
     
    private Dictionary<string, int> CurrentCombo;
    private int comboScore;
    private int comboMultiplier;
    private Dictionary<string, ComboElement> comboElements;
    private ComboElement activeComboElement;
    //private GameObject CloneComboGui;

    // text out stuff
    Text activeComboText;
    Text activeComboPoints;
    Text activeMultiplier;
    GameObject comboWindow;
    GameObject comboElementGUI;
    GameObject comboHolder;
    //List<GameObject> combos;

    public AudioClip PointPing;
    private  AudioSource ScoreSounds;


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

    public class ComboElement
    {
        public string  Name;       //dolphin / surfer etc?
  //      public bool Instant;    // or continuous - continuous now done by repeated sends
        public int Points;     // instant points, or points per second
        public int Multiplier;
        public GameObject guiText;// 
    }

    void Awake()
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
        comboElements = new Dictionary<string, ComboElement>();
        CurrentCombo = new Dictionary<string, int>();
    //    ScoreSounds = new AudioSource();
    }

   
    // Use this for initialization
    void Start () {
        ScoreSounds = GetComponent<AudioSource>();
        activeComboText = GameObject.Find("ComboElement").GetComponent<Text>();
        activeComboPoints = GameObject.Find("ComboPoints").GetComponent<Text>();
        activeMultiplier = GameObject.Find("Multiplier").GetComponent<Text>();
        comboWindow = GameObject.Find("Combo Panel");
        comboHolder = GameObject.Find("Combo Holder");
        comboElementGUI = GameObject.Find("Combo Element");
        //comboElementGUI.transform.parent = null;
        comboElementGUI.SetActive(false);
        ResetCombo();
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
                foreach (KeyValuePair<string,int> el in CurrentCombo)
                {
                    Debug.Log(el.Key + " - " + el.Value);
                   // comboScore += el.Value;
                }

                Debug.Log("COMBO OVER!!! " + comboScore + " x " + comboMultiplier + " = " +comboScore*comboMultiplier);
                // Send Points to ScoreManager
                ScoreManager.Instance.UpdateScore(comboMultiplier * comboScore, COMBO_OVER);
                // Clear Combos

                ResetCombo();
                

            }
        }
	}

    //

    void ResetCombo()
    {
        if (ComboHandlers != null)
        {
            ComboHandlers.Invoke(COMBO_OVER, 0);
        }
        CurrentCombo    = new Dictionary<string, int> ();
        comboScore      = 0;
        comboMultiplier = 1;
        comboWindow.SetActive(false);
        for (int i=1; i< comboHolder.transform.childCount; i++)
        {
          
            Destroy(comboHolder.transform.GetChild(i).gameObject);
        }
    }



    /// <summary>
    /// Add a comboelement to current combo
    /// </summary>
    /// <param name="element"></param>
    public void AddComboElement(string elementName)
    {
        if (countdown == 0)
        {
            // Combo Starting
        }
        comboWindow.SetActive(true);
        int count = 0;
        ComboElement element;
        if (!comboElements.TryGetValue(elementName, out element))
        {
            Debug.LogError("ComboElement " + elementName + " does not exist!");
            return;
        }
        
       
            bool inCombo = CurrentCombo.TryGetValue(elementName, out count);

            // int increment;
            //if (elementT.Instant)
            //{
            //    increment = 1;
            //}
            // else a registered combo handler 
            // invocation will deal with it;
            
            if (inCombo)
            {
                count++;    
                CurrentCombo[elementName] = count;
            }
            else
            {
            comboElements[elementName].guiText = Instantiate(comboElementGUI, comboHolder.transform);
            comboElements[elementName].guiText.SetActive(true);
          //element.guiText = Instantiate(comboElementGUI, comboWindow.transform);
                CurrentCombo.Add(elementName, 1);
                count = 1;
                
            }
            ScoreSounds.PlayOneShot(PointPing,0.1f);
        comboScore += element.Points;
        comboMultiplier += element.Multiplier;

        activeComboText.text = elementName;
        activeComboPoints.text = "x " + comboScore;
        activeMultiplier.text = "X "+ comboMultiplier;
        //if (element.guiText==null)
        //{
        //    Debug.Log("Arp@");
        //}
        Text[] labels = element.guiText.GetComponentsInChildren<Text>();
        labels[0].text = activeComboText.text;
        labels[1].text = activeComboPoints.text;
        countdown = ComboCountdown;
        //heckCombos();
        // 
        // deal with any continous or other odd combo rules
        ComboHandlers.Invoke(elementName, count);
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
        if(!comboElements.ContainsKey(element.Name))
        {
            comboElements.Add(element.Name, element);
        }
        else
        {
            Debug.LogWarning("ComboElement " + element.Name + " already exists!");
        }
    }
}
