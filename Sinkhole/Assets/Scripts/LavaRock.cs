using UnityEngine;
using System.Collections;

public class LavaRock : MonoBehaviour {
	
	public Vector2 startSpeed;
	public int collisions = 1;
	
	// Use this for initialization
	void Start () {
		this.rigidbody2D.velocity = startSpeed;
	}
	
	void OnCollisionEnter2D(Collision2D other){
		if(--collisions < 0){
			GameObject.Destroy(this.gameObject, 1f);
		}
	}
}
