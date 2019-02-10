using UnityEngine;
using System.Collections;

public class BlueBrick : MonoBehaviour {
	
	public GameObject brickParticle;
	
	
	void OnCollisionEnter (Collision other)
	{
		if (GM.instance.bricks == 1) {
			Instantiate (brickParticle, transform.position, Quaternion.identity);
			GM.instance.DestroyBrick ();
			Destroy (gameObject);
		}
	}
}