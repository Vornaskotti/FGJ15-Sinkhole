using UnityEngine;
using System.Collections;

public class DrumRollManager : MonoBehaviour {

	AudioSource drumRoll;

	// Use this for initialization
	void Awake () {
		drumRoll = GetComponent <AudioSource> ();
	}

	void playDrumroll () {
		Debug.Log ("drumroll");
		drumRoll.Play ();
	}

}
