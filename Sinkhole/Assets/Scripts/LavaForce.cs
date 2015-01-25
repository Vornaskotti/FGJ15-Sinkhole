using UnityEngine;
using System.Collections;

public class LavaForce : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter2D(Collider2D collider) {
		Rigidbody2D rb = collider.GetComponent<Rigidbody2D>();
		rb.AddForce(new Vector2(0.0f, -8000.0f));
	}
}
