using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{

	public AudioClip Clip;
	public string name;
	[Range(0f,1f)]
	public float volume;
	//[Range(0.1f,3f)]
	[HideInInspector]
	public float pitch;
	[HideInInspector]
	public AudioSource source;
	public bool loop;

}
