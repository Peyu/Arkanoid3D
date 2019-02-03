using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GM : MonoBehaviour {
	
	public int lives = 3;
	public int bricks = 24;
	public float resetDelay = 1f;
	public Text livesText;
	public GameObject gameOver;
	public GameObject youWon;
	public GameObject bricksPrefab;
	public GameObject paddle;
	public GameObject deathParticles;
	public static GM instance = null;
	
	private GameObject clonePaddle;
	
	// Use this for initialization
	void Awake () 
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);
		
		Setup();
		
	}
	
	public void Setup()
	{
		//Se inicializa la paleta en transform.positin del GM, es decir 0,0,0.  Quaterinon identity significa
		//que no puede rotar
		clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;
		Instantiate(bricksPrefab, new Vector3(-0.1f,1f,0f), Quaternion.identity);


	}
	
	void CheckGameOver()
	{
		if (bricks < 1)
		{
			youWon.SetActive(true);
			//Esto va a generar un efecto de slowMotion
			Time.timeScale = .25f;
			Invoke ("Reset", resetDelay);
		}
		
		if (lives < 1)
		{
			gameOver.SetActive(true);
			//Esto va a generar un efecto de slowMotion
			Time.timeScale = .25f;
			Invoke ("Reset", resetDelay);
		}
		
	}
	
	void Reset()
	{
		Time.timeScale = 1f;
		//Cuando se termine el nivel se va a volver a lodear
		Application.LoadLevel(Application.loadedLevel);
	}
	
	public void LoseLife()
	{
		lives--;
		livesText.text = "Lives: " + lives;
		Instantiate(deathParticles, clonePaddle.transform.position, Quaternion.identity);
		Destroy(clonePaddle);
		Invoke ("SetupPaddle", resetDelay);
		CheckGameOver();
	}
	
	void SetupPaddle()
	{
		clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;
	}
	
	public void DestroyBrick()
	{
		bricks--;
		CheckGameOver();
	}
} 
