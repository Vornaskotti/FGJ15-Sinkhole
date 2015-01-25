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
	
	public void letGo(){
		print ("letGo" + transform.parent.name + ", " + transform.name);
			if(transform.GetComponents<HingeJoint2D>() != null){
			print ("has joints");
				foreach(HingeJoint2D h in transform.GetComponents<HingeJoint2D>()){
				if(h.connectedBody == grabbedWith.rigidbody2D){
						print (transform.name + " hinge deactivated with " + h.connectedBody.name);
						transform.GetComponent<Grabable>().grabable = true;
						h.connectedBody.GetComponent<Grabable>().grabable = true;
						h.enabled = false;
						Destroy(h);
					}
				}
			}
	}
}
