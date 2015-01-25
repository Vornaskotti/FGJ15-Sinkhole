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
	
	void OnTriggerEnter2D() {
    gameState.hasWon = true;
	}
}
