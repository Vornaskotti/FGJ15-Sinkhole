using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ArmJointHandler : MonoBehaviour {

	private GameState gameState;
	
	public float maxForce = 1000f;
	public HingeJoint2D joint = null;
	
	// Use this for initialization
	void Start () {
		gameState = GameObject.Find("GameState").GetComponent<GameState>();
	}
	
	// Update is called once per frame
	void Update () {
		if(joint != null){
			float force = joint.GetReactionForce(Time.deltaTime).magnitude;
			if(joint.GetReactionForce(Time.deltaTime).magnitude > maxForce){
				print ("joit broke with force " + force + " max is " + maxForce);
				
				Transform split1 = joint.connectedBody.GetComponent<Grabable>().grabbedWith;
				Transform split2 = joint.rigidbody2D.GetComponent<Grabable>().grabbedWith;
				
				joint.connectedBody.GetComponent<Grabable>().grabbedWith = null;
				joint.rigidbody2D.GetComponent<Grabable>().grabbedWith = null;
				
				handleBreak();
				Destroy(joint);
				Transform sp1End = getLastEnd(split1.GetComponent<Grabable>().pairObject);
				Transform sp2End = getLastEnd(split2.GetComponent<Grabable>().pairObject);
				if(gameState.linkEnd1.GetComponent<HingeJoint2D>().connectedBody.transform == sp1End && 
				   gameState.linkEnd2.GetComponent<HingeJoint2D>().connectedBody.transform == split1){
				   // sp2End is free one
					//print ("sp1End is not free " + sp1End.parent.name + split1.parent.name);
					//print ("sp2End is FREE " + sp2End.parent.name + split2.parent.name);
					deactivatePersonsRecursive(sp2End.parent);
				 } else {
					// sp1End is free one
					//print ("sp2End is not free " + sp2End.parent.name + split2.parent.name);
					//print ("sp1End is FREE " + sp1End.parent.name + split1.parent.name);
					deactivatePersonsRecursive(sp1End.parent);
				 }
				//print ("sp1End " + sp1End.parent.name);
				//print ("sp2End " + sp2End.parent.name);
			}
		}
	}
	
	void deactivatePersonsRecursive(Transform torso){
		print ("deactivating "  + torso.name);
		if(torso.GetComponent<Swinging>().enabled){
			torso.GetComponent<Swinging>().enabled = false;
			Transform leftHand = torso.transform.FindChild("left_arm");
			Transform rightHand = torso.transform.FindChild("right_arm");
			
			if(getNextEnd(leftHand) != null){
				Transform leftTorso = getNextEnd(leftHand).parent;
				if(leftHand.GetComponent<Grabable>() != null)
					leftHand.GetComponent<Grabable>().letGo();
				//print ("leftTorso" + leftTorso.name);
				deactivatePersonsRecursive(leftTorso);
				
			}
			if(getNextEnd(rightHand) != null){
				Transform rightTorso = getNextEnd(rightHand).parent;
				if (rightHand.GetComponent<Grabable>() != null)
					rightHand.GetComponent<Grabable>().letGo();
				//print ("rightTorso" + rightTorso.name);
				deactivatePersonsRecursive(rightTorso);
			}
		}
	} 
	
	void handleBreak(){
		handleBreakGrabbed();
	}
	
	Transform getTorsosFrom(Transform t){
		t.parent.GetComponent<Swinging>().enabled = false;
		Transform nextEnd = t;
		
		while(getNextEnd(nextEnd) != null){
			nextEnd = getNextEnd(nextEnd);
			
			// Disable
			nextEnd.parent.GetComponent<Swinging>().enabled = false;
						
		}
		return nextEnd;
	}
	
	Transform getNextEnd(Transform t){
		if(t.GetComponent<Grabable>().grabbedWith == null) return null;
   		else return t.GetComponent<Grabable>().grabbedWith.GetComponent<Grabable>().pairObject;
		
	}
	
	Transform getLastEnd(Transform t){
		Transform nextEnd = t;
		while(getNextEnd(nextEnd) != null){
			nextEnd = getNextEnd(nextEnd);
		}
		return nextEnd;
	}
	
	void handleBreakGrabbed(){
		Transform holdHandPair;
		if(gameState.currentGrab != null){
			holdHandPair = gameState.currentGrab.GetComponent<HingeJoint2D>().connectedBody.GetComponent<Grabable>().pairObject;
		}else{
			holdHandPair = gameState.getHigher().GetComponent<HingeJoint2D>().connectedBody.GetComponent<Grabable>().pairObject;
		}
		
		Transform nextEnd = getLastEnd(holdHandPair);
		// Move another ball to current
		Transform freeBall = gameState.getFree().transform;
		
		if(gameState.currentGrab == null){
			print ("nongrab break");
			freeBall = gameState.getAnother(holdHandPair).transform;
		}
		
		freeBall.position = nextEnd.transform.position;
		freeBall.GetComponent<HingeJoint2D>().connectedBody = nextEnd.rigidbody2D;
	}
	
	HingeJoint2D getRightHinge(HingeJoint2D[] hinges){
		foreach(HingeJoint2D h in hinges) {
			if(h.connectedBody.GetComponent<Grabable>() != null){	 // is the right one
				return h;
			}
		}
		return null;
	}
	
}