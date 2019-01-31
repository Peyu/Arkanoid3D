using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{

    public float ballInitialVelocity = 600f;


    private Rigidbody rb;
    private bool ballInPlay;
    public Vector3 vel;

    void Awake() //se llama antes que el start
    {

        rb = GetComponent<Rigidbody>();
        
    }

    //Se usa update y no fixedupdate porque no se desea que se updatee la velocidad todo el tiempo.
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && ballInPlay == false)
        {
            transform.parent = null; //la paleta deja de ser el padre para que pueda moverse en libertad
            ballInPlay = true;
            rb.isKinematic = false;
            rb.AddForce(new Vector3(ballInitialVelocity, ballInitialVelocity, 0));
        }
    
        if (ballInPlay == true) {
            vel = rb.velocity;    
        }

    }
}