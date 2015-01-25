using UnityEngine;
using System.Collections;

public class Cow : MonoBehaviour {
	
	public float range = 10f;
	public AudioClip[] clips;

	public AudioClip cowHitPoeple;

	// Use this for initialization
	void Start () {
		this.rigidbody2D.angularVelocity = Random.Range (-range, range);

		AudioSource audioSource = gameObject.AddComponent<AudioSource>();
		audioSource.minDistance = 500;
		audioSource.volume = 1.0f;
		int clipID = Random.Range(0, clips.Length);
		AudioClip clip = clips[clipID];
		audioSource.clip = clip;
		audioSource.Play ();
	}


	void OnCollisionEnter2D(Collision2D collider) {
		if (collider.gameObject.name.Contains ("torso")) {
			AudioSource cowSource = gameObject.AddComponent<AudioSource>();
			cowSource.minDistance = 500;
			cowSource.volume = 1.0f;
			cowSource.clip = cowHitPoeple;
			cowSource.Play();
		}
	}



}
