﻿using UnityEngine;
using System.Collections;

public class LavaForce : MonoBehaviour {

	public AudioClip cowHitLava;
	public AudioClip scream;

	void OnTriggerEnter2D(Collider2D collider) {
		Rigidbody2D rb = collider.GetComponent<Rigidbody2D>();
		rb.AddForce(new Vector2(0.0f, -8000.0f));

		if (collider.gameObject.name.Contains ("Cow")) {
			AudioSource audioSource = gameObject.AddComponent<AudioSource> ();
			audioSource.minDistance = 500;
			audioSource.volume = 1.0f;
			audioSource.clip = cowHitLava;
			audioSource.Play ();
		}
		if (collider.gameObject.name.Contains ("torso")) {
						AudioSource audioSource = gameObject.AddComponent<AudioSource> ();
						audioSource.minDistance = 500;
						audioSource.volume = 1.0f;
						audioSource.clip = scream;
						audioSource.Play ();
            
				}
        }
        
        
        void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.name.Contains ("Cow")) {
						AudioSource audioSource = gameObject.AddComponent<AudioSource> ();
						audioSource.minDistance = 500;
						audioSource.volume = 1.0f;
						audioSource.clip = cowHitLava;
						audioSource.Play ();
				}
		if (col.gameObject.name.Contains ("torso")) {
			AudioSource audioSource = gameObject.AddComponent<AudioSource> ();
			audioSource.minDistance = 500;
			audioSource.volume = 1.0f;
			audioSource.clip = scream;
			audioSource.Play ();
        }
    }
}
