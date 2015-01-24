using UnityEngine;
using System.Collections;

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
				Destroy(joint);
				joint.connectedBody.GetComponent<Grabable>().grabbedWith = null;
				joint.rigidbody2D.GetComponent<Grabable>().grabbedWith = null;
				handleBreak();
			}
		}
	}
	
	void handleBreak(){
		if(gameState.currentGrab != null){
			handleBreakGrabbed();
		} else{
			
		}
		
	}
	
	Transform getNext(Transform t, Transform last){
		if(t.GetComponent<Grabable>().grabbedWith != null && t.GetComponent<Grabable>().grabbedWith.transform != last) 
			return t.GetComponent<Grabable>().grabbedWith.transform;
		else if(t.GetComponent<Grabable>().pairObject.transform != last)
			return t.GetComponent<Grabable>().pairObject.transform;
		else
			return null;
	}
	
	Transform getNextEnd(Transform t){
		if(t.GetComponent<Grabable>().grabbedWith == null) return null;
		else return t.GetComponent<Grabable>().grabbedWith.GetComponent<Grabable>().pairObject;
		
	}
	
	void handleBreakGrabbed(){
		Transform holdHandPair = 
			gameState.currentGrab.GetComponent<HingeJoint2D>().connectedBody.GetComponent<Grabable>().pairObject;
		print (holdHandPair);
		
		Transform nextEnd = holdHandPair;
		while(getNextEnd(nextEnd) != null){
			nextEnd = getNextEnd(nextEnd);
		}
		// Move another ball to current
		Transform freeEnd = gameState.getFree().transform;
		freeEnd.position = nextEnd.transform.position;
		freeEnd.GetComponent<HingeJoint2D>().connectedBody = nextEnd.rigidbody2D;
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