using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour {
	public Rigidbody2D linkEnd1;
	public Rigidbody2D linkEnd2;
	
	private Rigidbody2D currentGrab;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Space) && currentGrab == null){
			grab();
		}
		else if(!Input.GetKey(KeyCode.Space) && currentGrab != null){
			releaseGrab();
		}	
	}
	
	void releaseGrab(){
		currentGrab = null;
		linkEnd1.isKinematic = false;
		linkEnd2.isKinematic = false;
	}
	
	void grab(){ // Grabs with higher link end
			if(linkEnd1.transform.position.y > linkEnd2.transform.position.y){
				linkEnd1.isKinematic = true;
				currentGrab = linkEnd1;
			}
			else{
				linkEnd2.isKinematic = true;
				currentGrab = linkEnd2;
			}
		}
}
