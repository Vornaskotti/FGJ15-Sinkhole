using UnityEngine;
using System.Collections;

public class RandomizeBackground : MonoBehaviour {

	// Use this for initialization
	void Start () {
		MeshRenderer meshRend = GetComponent<MeshRenderer>();
		int r = Random.Range(0, 4);
		meshRend.materials = new Material[] {meshRend.materials[r]};
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
