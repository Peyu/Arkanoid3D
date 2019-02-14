using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{

    public float ballInitialVelocity = 1200f;


    private Rigidbody rb;
    private bool ballInPlay;
	[Range(0f,100f)]
	public float speed; 

    void Awake() //se llama antes que el start
    {

        rb = GetComponent<Rigidbody>();
		speed = 15;
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

			rb.velocity = speed * (rb.velocity.normalized);

    }

	void OnCollisionEnter (Collision other)
	{
		if (other.gameObject.tag == "Brick") {
			FindObjectOfType<AudioManager>().Play("Pong");
		}
	
		if (other.gameObject.tag == "Paddle") {
			FindObjectOfType<AudioManager>().Play("Ping");
		}

		if (other.gameObject.tag == "Wall") {
			FindObjectOfType<AudioManager>().Play("Pong");
		}

				
	}




}