using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour {

	public Sound[] sounds;

	// Use this for initialization
	void Awake () {
	
		foreach (var s in sounds) {
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.Clip;
			s.source.volume = s.volume;
			s.source.pitch= s.pitch;
			s.source.loop = s.loop;
		}


	}

	public void Start(){
	
		//Play ("Theme");
	}


	public void Play(string name){
		Sound s = Array.Find (sounds, x => x.name == name);
		s.source.Play ();

				
	}


}
