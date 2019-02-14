	using UnityEngine;
using System.Collections;

public class StoredVar : MonoBehaviour {
	public static int lives = 5;
	public static int points= 0;

	// Use this for initialization
	void Awake () {
		DontDestroyOnLoad(this);

	}
	

}
