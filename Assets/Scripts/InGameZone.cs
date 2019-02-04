using UnityEngine;
using System.Collections;

public class InGameZone : MonoBehaviour {

	public GameObject cam;
	public GameObject newCameraPos;
	private float step;
	public float gateSpeed = 1f;
	public bool dentro = false;

	void Awake(){
		step = gateSpeed * Time.deltaTime;
	}


	void OnTriggerEnter (Collider col)
	{
		
		if(col.gameObject.name.Contains("Ball"))
		{
			//camera.transform.position = Vector3.MoveTowards (camera.transform.position, newCameraPos.transform.position, step);
			//cam.transform.position.Set (0f,21f,0f);
			dentro = true;
		}
		
	}
}
