using UnityEngine;
using System.Collections;

public class DeadZone : MonoBehaviour {

	public GameObject DeathParticles;

	//void OnTriggerEnter (Collider col)
	//{
	//	GM.instance.LoseLife();
	//}

	void OnTriggerEnter (Collider col)
	{
		Instantiate(DeathParticles, transform.position, Quaternion.identity);
		GM.instance.LoseLife();

	
		if(col.gameObject.name.Contains("Ball"))
		{
			// Destroys Game Object
			Destroy (col.gameObject, 0f); // Wait = 0 seconds
		}
	
	}





}