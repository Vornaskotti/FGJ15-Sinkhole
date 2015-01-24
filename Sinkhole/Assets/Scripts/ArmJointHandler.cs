using UnityEngine;
using System.Collections;

public class ArmJointHandler : MonoBehaviour {
	public float maxForce = 1000f;
	public HingeJoint2D joint = null;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(joint != null){
			float force = joint.GetReactionForce(Time.deltaTime).magnitude;
			if(joint.GetReactionForce(Time.deltaTime).magnitude > maxForce){
				print ("joit broke with force " + force + " max is " + maxForce);
				Destroy(joint);
			}
		}
	}
}
