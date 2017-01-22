using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrindHandler : MonoBehaviour {
    public const string GRIND_START = "GRIND_START";
    public const string GRIND_OVER  = "GRIND_OVER";

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

    // Use this for initialization
    void Start () {
        ComboManager.Instance.ComboHandlers += HandleGrind;
        ComboManager.ComboElement GrindCombo = new ComboManager.ComboElement();
        GrindCombo.Name = "Grind";
        GrindCombo.Instant = false;
        GrindCombo.Points = 1;
        ComboManager.Instance.CreateComboElement(GrindCombo);
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
            case GRIND_START:
                    Debug.Log(GRIND_START);
                if (!inGrind)
                {
                    inGrind = true;
                }
                else
                {
                    Debug.LogWarning("already in grind!");
                }
                break;
            case GRIND_OVER:
                Debug.Log(GRIND_OVER);
                // end grind
                // Add a GrindCombo in Combo Manager 
                break;
            default:
                Debug.Log("Not for Grinds Handler");
                break;

        }
    }
}
