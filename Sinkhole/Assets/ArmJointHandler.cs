using UnityEngine;
using System.Collections;

public class ArmJointHandler : MonoBehaviour {
	public float maxForce = 10f;
	public HingeJoint2D joint;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(hingeJoint != null){
			if(joint.constantForce > maxForce){
				joint.enabled = false;
			}
		}
	}
}
