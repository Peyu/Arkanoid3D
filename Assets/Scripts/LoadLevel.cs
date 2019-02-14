using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour {



	public void Level01(){
		
		Application.LoadLevel("Scene01");
	}

	public void Level02(){
		
		Application.LoadLevel("Scene02");
	}
	public void End(){
		
		Application.Quit();
	}


}
