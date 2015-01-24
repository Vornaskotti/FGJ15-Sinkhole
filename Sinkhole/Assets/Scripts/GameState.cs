using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour {
	public Rigidbody2D linkEnd1;
	public Rigidbody2D linkEnd2;
	
	public Rigidbody2D currentGrab;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Space)) {
      if (currentGrab == null)
			  grab();
		} else {
      releaseGrab();
//      print("release");
    }
//		else if(!Input.GetKey(KeyCode.Space) && currentGrab != null){
//			releaseGrab();
//		}
	}
	
	public Rigidbody2D getFree(){
		if(currentGrab == linkEnd1) return linkEnd2;
		else return linkEnd1;
	}
	
	void releaseGrab(){
		currentGrab = null;
		linkEnd1.isKinematic = false;
		linkEnd2.isKinematic = false;
	}
	
	void grab(){ // Grabs with higher link end
    LinkEnd l1 = linkEnd1.GetComponent<LinkEnd>();
    LinkEnd l2 = linkEnd2.GetComponent<LinkEnd>();
			if(linkEnd1.transform.position.y > linkEnd2.transform.position.y && l1.canGrab) {
				linkEnd1.isKinematic = true;
				currentGrab = linkEnd1;
			}
			else if (l2.canGrab) { 
				linkEnd2.isKinematic = true;
				currentGrab = linkEnd2;
			}
		}
		
}