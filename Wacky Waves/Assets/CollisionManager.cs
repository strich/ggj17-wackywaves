using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    const string TAG_CLIFF = "Cliff";
    const string TAG_NPC = "NPC";

	public bool IsWave = false;

    PlayerController _PlayerController;

	void Start ()
	{
        _PlayerController = GetComponentInParent<PlayerController>();
	}
	
	void Update () {
		
	}

	void OnTriggerEnter(Collider collider)
	{
        //if(collider.name.Contains("Front")) Debug.Log("We hit the front!");
        //if(collider.name.Contains("Back")) Debug.Log("We hit the back!");

        if (collider.gameObject.CompareTag(TAG_CLIFF))
        {
            _PlayerController.HitCliff(collider);
        }
        else if (collider.gameObject.CompareTag(TAG_NPC))
        {
            var npcController = collider.attachedRigidbody.GetComponent<NPCController>();
            npcController.TriggerDestroyed();
        }
    }

	void OnTriggerExit(Collider collider)
	{
		//Debug.Log("OnTriggerExit");
	}

	
}
