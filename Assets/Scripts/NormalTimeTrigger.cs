using UnityEngine;
using System.Collections;

public class NormalTimeTrigger : MonoBehaviour {

	void OnTriggerEnter (Collider col)
	{
		
		if(col.gameObject.name.Contains("Ball"))
		{
		
			Time.timeScale = 1f;
			Destroy (gameObject);
		}
		
	}
}
