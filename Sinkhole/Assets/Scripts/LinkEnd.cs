using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LinkEnd : MonoBehaviour {
	// Use this for initialization
	private Rigidbody2D currentParent;
	private HingeJoint2D joint;
	
	void Start () {
		joint = this.GetComponent<HingeJoint2D>();
		currentParent = joint.connectedBody;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		Grabable otherGrab = other.GetComponent<Grabable>();
		if(otherGrab != null && otherGrab.grabable){ // Grab and move link end to link's new end
		
			HingeJoint2D newJoint = currentParent.gameObject.AddComponent("HingeJoint2D") as HingeJoint2D;
	
			Grabable parentGrab = currentParent.GetComponent<Grabable>();
			
			currentParent.GetComponent<Grabable>().grabbedWith = other.transform;
			other.GetComponent<Grabable>().grabbedWith = currentParent.transform;
			
			currentParent.GetComponent<ArmJointHandler>().joint = newJoint;
			
			newJoint.anchor = parentGrab.grabPoint;
			newJoint.connectedBody = other.rigidbody2D;
			newJoint.connectedAnchor = other.gameObject.GetComponent<Grabable>().grabPoint;
			
			Transform otherHand = getOtherHand(other.transform);
			joint.connectedBody = otherHand.rigidbody2D;
			joint.connectedAnchor = otherHand.GetComponent<Grabable>().grabPoint;
			transform.position = otherHand.transform.position;
			
			currentParent = otherHand.rigidbody2D;
			
			disableGrabbable(other.transform);
			
		}
	}
	
	Transform getOtherHand(Transform hand){
		return hand.GetComponent<Grabable>().pairObject;
	}
	
	void disableGrabbable(Transform hand){
		foreach(Transform t in hand.parent){
			if(t.GetComponent<Grabable>()!= null){
				t.GetComponent<Grabable>().grabable = false;
			}
		}
	}


}
