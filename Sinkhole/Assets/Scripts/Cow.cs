using UnityEngine;
using System.Collections;

public class Cow : MonoBehaviour {
	
	public float range = 10f;
	public Vector2 velocityRange = new Vector2(10f, 10f);
	
	// Use this for initialization
	void Start () {
		this.rigidbody2D.angularVelocity = Random.Range(-range, range);
	}
}
