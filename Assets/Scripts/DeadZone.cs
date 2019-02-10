using UnityEngine;
using System.Collections;

public class DeadZone : MonoBehaviour {

	public GameObject DeathParticles;

	//void OnTriggerEnter (Collider col)
	//{
	//	GM.instance.LoseLife();
	//}

	public void SetPositionY(float y){
		gameObject.transform.position.Set(gameObject.transform.position.x, y, 0f);

	}



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