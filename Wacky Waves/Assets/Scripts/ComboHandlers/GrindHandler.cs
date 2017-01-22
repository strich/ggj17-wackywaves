using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrindHandler : MonoBehaviour {
    public const string DRY_GRIND = "DRY_GRIND";
    public const string WET_GRIND = "WET_GRIND";
    public const string BAR_GRIND = "BAR_GRIND";
    public const string GRIND_COMBO = "GRIND_COMBO";

    private static GrindHandler instance;
    public static GrindHandler Instance
    {
        get
        {
            if (!instance)
            {
                instance = new GameObject("GrindHandler").AddComponent<GrindHandler>();
            }
            return instance;
        }
        private set { instance = value; }
    }

    void Awake()
    {
        ComboManager.Instance.ComboHandlers += HandleGrind;
        ComboManager.ComboElement DryGrind = new ComboManager.ComboElement();
        DryGrind.Name = DRY_GRIND;
        DryGrind.Multiplier = 0;
        DryGrind.Points = 1;
        ComboManager.Instance.CreateComboElement(DryGrind);
        ComboManager.ComboElement WetGrind = new ComboManager.ComboElement();
        WetGrind.Name = WET_GRIND;
        WetGrind.Multiplier = 0;
        WetGrind.Points = 1;
        ComboManager.Instance.CreateComboElement(WetGrind);
        ComboManager.ComboElement BarGrind = new ComboManager.ComboElement();
        BarGrind.Name = BAR_GRIND;
        BarGrind.Multiplier = 0;
        BarGrind.Points = 1;
        ComboManager.Instance.CreateComboElement(BarGrind);
    }

    // Use this for initialization
    void Start () {
        //ComboManager.Instance.ComboHandlers += HandleGrind;
        //ComboManager.ComboElement GrindStart = new ComboManager.ComboElement();
        //GrindStart.Name = GRIND_START;
        //GrindStart.Instant = false;
        //GrindStart.Points = 1;
        //ComboManager.Instance.CreateComboElement(GrindStart);
        //ComboManager.ComboElement GrindOver = new ComboManager.ComboElement();
        //GrindOver.Name = GRIND_OVER;
        //GrindOver.Instant = false;
        //GrindOver.Points = 1;
        //ComboManager.Instance.CreateComboElement(GrindOver);
        //ComboManager.ComboElement GrindCombo = new ComboManager.ComboElement();
        //GrindCombo.Name = GRIND_COMBO;
        //GrindCombo.Instant = true;
        //GrindCombo.Points = 10;
        //ComboManager.Instance.CreateComboElement(GrindCombo);
    }
	
	// Update is called once per frame
	void Update () {
		// Display Points for every deltatime in grind
	}

    bool inGrind;

    void HandleGrind(string tag, int quantity)
    {
        switch (tag)
        {
            case DRY_GRIND:
                    Debug.Log(DRY_GRIND + " x "+quantity);
                break;
            case WET_GRIND:
                Debug.Log(WET_GRIND + " x " + quantity);
                break;
            case BAR_GRIND:
                Debug.Log(BAR_GRIND + " x " + quantity);
                break;
            default:
                //Debug.Log("Not for Grinds Handler");
                break;

        }
    }
}
