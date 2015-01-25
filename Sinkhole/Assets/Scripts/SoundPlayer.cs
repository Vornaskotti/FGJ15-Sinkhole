using UnityEngine;
using System.Collections;

public class SoundPlayer : MonoBehaviour {
	
	public AudioClip[] clips;
	
	// Use this for initialization
	void Start () {
		AudioSource audioSource = gameObject.AddComponent<AudioSource>();
		int clipID = Random.Range(0, clips.Length);
		AudioClip clip = clips[clipID];
		audioSource.clip = clip;
		audioSource.Play ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
