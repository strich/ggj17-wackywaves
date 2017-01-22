using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    const string TAG_CLIFF = "Cliff";
    const string TAG_NPC = "NPC";

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
		else if (collider.gameObject.CompareTag("NPC-Wave"))
		{
			WaveCollision(collider);
		}
		else if (collider.gameObject.CompareTag(TAG_NPC))
        {
            var npcController = collider.attachedRigidbody.GetComponent<NPCController>();
            npcController.TriggerDestroyed();
        }
    }

	void WaveCollision(Collider collider)
	{
		if (collider.name.Contains("Front"))
		{
			_PlayerController.AddBuff("Wave Frontal Hit", new DecreasingBuff(-5f, 0.99f));
		}
		else if (collider.name.Contains("Back"))
		{
			_PlayerController.AddBuff("Wave Behind Hit", new IncreasingBuff(2f, 0.99f, 4f));
		}

		var npcController = collider.attachedRigidbody.GetComponent<NPCController>();
		npcController.TriggerDestroyed(false);
	}
}