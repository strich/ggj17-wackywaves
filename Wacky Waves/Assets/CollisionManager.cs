using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
	public bool IsWave = false;

	void Start ()
	{
		
	}
	
	void Update () {
		
	}

	void OnTriggerEnter(Collider collider)
	{
		//if(collider.name.Contains("Front")) Debug.Log("We hit the front!");
		//if(collider.name.Contains("Back")) Debug.Log("We hit the back!");

		// Mother of god what am i doing. Will fix...need dinner
		var npcController = collider.attachedRigidbody.transform.parent.GetComponent<NPCController>();
		npcController.TriggerDestroyed();
	}

	void OnTriggerExit(Collider collider)
	{
		//Debug.Log("OnTriggerExit");
	}

	
}
