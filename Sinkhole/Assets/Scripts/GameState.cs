using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour {
	public Rigidbody2D linkEnd1;
	public Rigidbody2D linkEnd2;
	
	public Rigidbody2D currentGrab;
	
	public bool hasWon = false;
  private bool victoryDisplayed = false;
  
  public GameObject victoryText;
  
  public AudioSource jumpAudio;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.R)) {  
			Application.LoadLevel (0);  
		}  
		
		if(Input.GetKey(KeyCode.Space)) {
	    if (currentGrab == null)
			grab();
		} else {
	    releaseGrab();
    }
    if (hasWon && !victoryDisplayed) {
      Instantiate (victoryText);
      victoryDisplayed = true;
    }
	}
	
	public Rigidbody2D getFree(){
		if(currentGrab == linkEnd1) return linkEnd2;
		else return linkEnd1;
	}
	
	void releaseGrab(){
		if (currentGrab != null) {
			//audio.Play();
		}
		currentGrab = null;
		linkEnd1.isKinematic = false;
		linkEnd2.isKinematic = false;
	}
	
	public Transform getHigher(){
		if(linkEnd1.transform.position.y > linkEnd2.transform.position.y) {
			return linkEnd1.transform;
		} else return linkEnd2.transform;
	}
	
	public Transform getAnother(Transform t){
		if(t == linkEnd1.transform) return linkEnd2.transform;
		else return linkEnd1.transform;
	}
	
	public bool isBall(Transform t){
		return t == linkEnd1.transform || t == linkEnd2.transform;
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
			else if(l1.canGrab){
				linkEnd1.isKinematic = true;
				currentGrab = linkEnd1;
			}
		}
		
}