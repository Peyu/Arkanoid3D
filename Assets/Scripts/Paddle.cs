using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    public float paddleSpeed = 1f;
    public GameObject paddlePos;

	private Vector3 playerPos = new Vector3(0, -9.5f, 0);

	public void SetPlayerPosY(float y){
		playerPos.y = y;
	}


    void Update()
    {
        float xPos = transform.position.x + (Input.GetAxis("Horizontal") * paddleSpeed);
        //Mathf.Clamp setea un valor entre un minimo y un maximo, en este caso la plaeta no va a poder ir mas alla de 8 y -8
        //new vector (x,y,z).  EN este caso no quiero que se mueva sobre ejes Y ni Z, siempre tendran esos valores
        playerPos = new Vector3(Mathf.Clamp(xPos, -8.5f, 8.5f), playerPos.y, 0f);
        transform.position = playerPos;
					
	}


}
