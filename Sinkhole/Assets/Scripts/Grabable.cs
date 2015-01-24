using UnityEngine;
using System.Collections;

public class Grabable : MonoBehaviour {
	public bool grabable = true;
	public Vector2 grabPoint = Vector2.zero;
	public Transform pairObject;
	public Transform grabbedWith;
	
	// Use this for initialization
	void Start () {
		foreach(Transform t in transform.parent){
			if(t != transform && t.GetComponent<Grabable>() != null){
				pairObject =  t;
			}
		}
		if(pairObject == null){
			print ("No pair object found!");
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
