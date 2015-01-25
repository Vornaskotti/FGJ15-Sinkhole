using UnityEngine;
using System.Collections;

public class Victory : MonoBehaviour {

  public GameState gameState;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter2D(Collider2D t) {
		if(t.transform == gameState.linkEnd1.transform || t.transform == gameState.linkEnd2.transform){
			gameState.hasWon = true;
		}

	}
}
