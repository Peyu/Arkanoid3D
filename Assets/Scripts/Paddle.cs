using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    public float paddleSpeed = 1f;
    
    private Vector3 playerPos = new Vector3(0, -9.5f, 0);

    void Update()
    {
        float xPos = transform.position.x + (Input.GetAxis("Horizontal") * paddleSpeed);
        //Mathf.Clamp setea un valor entre un minimo y un maximo, en este caso la plaeta no va a poder ir mas alla de 8 y -8
        //new vector (x,y,z).  EN este caso no quiero que se mueva sobre ejes Y ni Z, siempre tendran esos valores
        playerPos = new Vector3(Mathf.Clamp(xPos, -7.5f, 7.5f), -9.5f, 0f);
        transform.position = playerPos;

    }
}
