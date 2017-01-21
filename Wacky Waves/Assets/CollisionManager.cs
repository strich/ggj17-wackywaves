using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider collider)
	{
		if(collider.name.Contains("Front")) Debug.Log("We hit the front!");
		if(collider.name.Contains("Back")) Debug.Log("We hit the back!");

		// Mother of god what am i doing. Will fix...need dinner
		collider.transform.parent.parent.GetComponent<NPCController>().TriggerDestroyed();
	}

	void OnTriggerExit(Collider collider)
	{
		Debug.Log("OnTriggerExit");
	}
}
