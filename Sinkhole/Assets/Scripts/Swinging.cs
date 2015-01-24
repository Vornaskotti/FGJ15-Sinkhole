using UnityEngine;
using System.Collections;

public class Swinging : MonoBehaviour {

	private float speed = 4f;
	private bool incVelocity = true;

	// Update is called once per frame
	void Update () {
		if(GameState.currentGrab != null){
			float ix = Input.GetAxis("Horizontal");
	
			Vector3 vec = this.transform.position - GameState.currentGrab.transform.position;
			float r = vec.magnitude;
	
			Vector3 tangent = (Vector3.Cross(vec, Vector3.back)).normalized;
	
			this.rigidbody2D.AddForce(new Vector2(tangent.x, tangent.y) * ix * speed * r * ((tangent.x > 0 ? tangent.x : 0)+ 0.2f));
			incVelocity = true;
		} else {
			if(incVelocity){
				this.rigidbody2D.velocity *= 1;
				incVelocity = false;
			}
		}
	}


}
