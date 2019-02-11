using UnityEngine;
using System.Collections;

public class OrangeBrick : MonoBehaviour {

	public GameObject brickParticle;
	private int hits=0;

	void OnCollisionEnter (Collision other)
	{
		hits++;
		if (hits == 3) {
			Instantiate(brickParticle, transform.position, Quaternion.identity);
			GM.instance.DestroyBrick();
			Destroy(gameObject);
		
		}


	}
}
