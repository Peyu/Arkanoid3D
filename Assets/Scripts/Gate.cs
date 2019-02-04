using UnityEngine;
using System.Collections;

public class Gate : MonoBehaviour {

	public GameObject roof_R;
	public GameObject roof_R_Stop;
	public float gateSpeed = 1.0f;
	public bool open = false;
	private float step;

	// Use this for initialization
	void Awake () {
		step = gateSpeed * Time.deltaTime;

	}

	void Start(){


	}
	
	// Update is called once per frame
	void Update () {
		if (open) {
			transform.localPosition = Vector3.MoveTowards (transform.localPosition, roof_R_Stop.transform.localPosition, step);
		}

	}

	public void StartOpening(){
		open = true;

	}


}
