using UnityEngine;
using System.Collections;

public class Cow : MonoBehaviour {
	
	public float range = 10f;
	
	// Use this for initialization
	void Start () {
		this.rigidbody2D.angularVelocity = Random.Range (-range, range);
		Debug.Log(Random.Range (-range, range));
	}
}
