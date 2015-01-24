using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {

		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");
		Rigidbody2D body = gameObject.GetComponent<Rigidbody2D> ();
		Vector2 movement = new Vector2 (h,v) ;
		body.velocity += movement;
	}
}
