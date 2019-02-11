using UnityEngine;
using System.Collections;

public class InGameZone : MonoBehaviour {

	public GameObject cam;
	public GameObject newCameraPos;
	//private float step;
	public float gateSpeed = 1f;
	//Posicion de Paleta
	private GameObject clonePaddle;
	public GameObject paddle;
	public GameObject water;
	public GameObject GameManag;
	public GameObject paddlePos;


	void Awake(){
		//step = gateSpeed * Time.deltaTime;

	}


	void OnTriggerEnter (Collider col)
	{
		
		if(col.gameObject.name.Contains("Ball"))
		{
			Time.timeScale = .25f;
			cam.transform.position = new Vector3(newCameraPos.transform.position.x, newCameraPos.transform.position.y, newCameraPos.transform.position.z);
			water.transform.position = new Vector3(water.transform.position.x, 9f,0f);
			paddlePos.transform.position = new Vector3(0f,11.5f,0f);


			clonePaddle = GameObject.FindGameObjectsWithTag("Paddle")[0];
			Paddle paddleScript = (Paddle) clonePaddle.GetComponent(typeof(Paddle));	
			paddleScript.SetPlayerPosY(paddlePos.transform.position.y);
			GM.instance.setPaddlePos(paddlePos.transform.position.y);
			//water = GameObject.FindGameObjectsWithTag("Water")[0];
			//DeadZone waterScript = (DeadZone) water.GetComponent(typeof(DeadZone));	
			//waterScript.SetPositionY(-1f);



			Destroy( gameObject);


		}
		
	}
}
