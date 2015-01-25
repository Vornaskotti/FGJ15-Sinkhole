using UnityEngine;
using System.Collections;

public class CharacterOutfit : MonoBehaviour {
	
	public Sprite[] legs;
	public Sprite[] arms;
	public Sprite[] torsos;
	
	// Use this for initialization
	void Start () {
		SpriteRenderer[] sr = gameObject.GetComponentsInChildren<SpriteRenderer>();
		
		/*
			0 - torso
			1 - left leg
			2 - right leg
			3 - left arm
			4 - right arm
		*/
		
		// Randomize parts
		int rdm = Random.Range(0, legs.Length);
		// Legs
		sr[1].sprite = legs[rdm];
		sr[2].sprite = legs[rdm];
		
		// Torso
		sr[0].sprite = torsos[Random.Range(0, torsos.Length)];
		
		// Arms
		rdm = Random.Range(0, arms.Length);
		sr[3].sprite = arms[rdm];
		sr[4].sprite = arms[rdm];
	}
}
