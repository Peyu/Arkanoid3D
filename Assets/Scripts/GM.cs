using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GM : MonoBehaviour {

	//Control de ladrillos
	public int bricks = 1;
	public int bricksToOpen;
	public GameObject brickPos1;
	public GameObject brickPos2;
	public GameObject bricksPrefab;
	public GameObject bricksPrefab2;

	//Control de canvas
	private int lives;
	public Text livesText;
	public GameObject gameOver;
	public GameObject youWon;

	//Control de paleta
	public GameObject paddle;
	public GameObject deathParticles;
	private GameObject clonePaddle;
	public GameObject paddlePos;

	//Control del gate1
	public GameObject roof1_R;
	public GameObject roof1_L;
	public GameObject roof1_R_Stop;
	public GameObject roof1_L_Stop;
	private float step;
	public float gateSpeed = 1f;
	private bool open = false;

	//Control general del juego
	public float resetDelay = 1f;
	public static GM instance = null;


	// Use this for initialization
	void Awake () 
	{
		step = gateSpeed * Time.deltaTime;

		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);
		
		Setup();
		Time.timeScale = 1f;
		paddlePos.transform.position = new Vector3 (0f, -9.5f, 0f);


	}

	void Start(){
		lives = StoredVar.lives;
		livesText.text = "Lives: " + lives;
		FindObjectOfType<AudioManager>().Play("Theme");
	
	}


	public void setPaddlePos(float y){
		paddlePos.transform.position = new Vector3 (0f, y, 0f);
		
	}


	public void Setup()
	{
		//Se inicializa la paleta en transform.positin del GM, es decir 0,0,0.  Quaterinon identity significa
		//que no puede rotar

		clonePaddle = Instantiate(paddle, paddlePos.transform.position, Quaternion.identity) as GameObject;
		Instantiate(bricksPrefab, brickPos1.transform.position, Quaternion.identity);
		clonePaddle.name = "paleta";
		//paddlePos = clonePaddle.transform.position;
	}


	void Update(){
		if (open) {
			roof1_R.transform.localPosition = Vector3.MoveTowards (roof1_R.transform.localPosition, roof1_R_Stop.transform.localPosition, step);
			roof1_L.transform.localPosition = Vector3.MoveTowards (roof1_L.transform.localPosition, roof1_L_Stop.transform.localPosition, step);
		}

	}

	
	void CheckGameOver()
	{
		//  HingeJoint[] hinges = GetComponents<HingeJoint>();
		
		if (bricks == bricksToOpen )
		{
			open = true;
			Instantiate(bricksPrefab2, brickPos2.transform.position, Quaternion.identity);

		}
		if (bricks < 1)
		{
			youWon.SetActive(true);
			//Esto va a generar un efecto de slowMotion
			Time.timeScale = .25f;
			//Invoke ("Reset", resetDelay);

			if(Application.loadedLevelName == "Scene01"  )
				Invoke ("LoadLevel02", resetDelay);		
			if(Application.loadedLevelName == "Scene02"  )
				Invoke ("LoadLevel00", resetDelay);

		}

		
		if (StoredVar.lives < 1)
		{
			gameOver.SetActive(true);
			//Esto va a generar un efecto de slowMotion
			Time.timeScale = .25f;
			Invoke ("Reset", resetDelay);
		}
		
	}

	void LoadLevel00(){
		Application.LoadLevel("Scene00");
	}

	void LoadLevel02(){
		Application.LoadLevel("Scene02");
	}

	void Reset()
	{
		Time.timeScale = 1f;
		//Cuando se termine el nivel se va a volver a lodear
		StoredVar.lives = 5;
		Application.LoadLevel("Scene00");
	}
	
	public void LoseLife()
	{
		lives--;
		StoredVar.lives --;
		livesText.text = "Lives: " + lives;
		Instantiate(deathParticles, clonePaddle.transform.position, Quaternion.identity);
		Destroy(clonePaddle);
		Invoke ("SetupPaddle", resetDelay);
		CheckGameOver();
		FindObjectOfType<AudioManager>().Play("Destroyed");

	}

	void SetupPaddle()
	{
		clonePaddle = Instantiate(paddle, paddlePos.transform.position, Quaternion.identity) as GameObject;

		clonePaddle = GameObject.FindGameObjectsWithTag("Paddle")[0];
		Paddle paddleScript = (Paddle) clonePaddle.GetComponent(typeof(Paddle));	
		paddleScript.SetPlayerPosY(paddlePos.transform.position.y);

	}
	
	public void DestroyBrick()
	{
		bricks--;
		CheckGameOver();
	}
} 
