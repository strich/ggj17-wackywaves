using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    const string TAG_CLIFF = "Cliff";
    const string TAG_NPC = "NPC";
    const string TAG_NPCWAVE = "NPC-Wave";

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
		else if (collider.gameObject.CompareTag(TAG_NPCWAVE))
		{
			WaveCollision(collider);
		}
		else if (collider.gameObject.CompareTag(TAG_NPC))
        {
            var npcController = collider.attachedRigidbody.GetComponent<NPCController>();
            npcController.TriggerDestroyed(10f);
        }
    }

	void WaveCollision(Collider collider)
	{
		if (collider.name.Contains("Front"))
		{
			_PlayerController.AddBuff(BuffManager.KEY_GLOBAL_SPEED, new IncreasingBuff(0.2f, 1.02f, 1f));
		}
		else if (collider.name.Contains("Back"))
		{
			_PlayerController.AddBuff(BuffManager.KEY_GLOBAL_SPEED, new DecreasingBuff(2.0f, 0.995f));
		}

		var npcController = collider.attachedRigidbody.GetComponent<NPCController>();
		npcController.TriggerDestroyed(0f, false);
	}
}