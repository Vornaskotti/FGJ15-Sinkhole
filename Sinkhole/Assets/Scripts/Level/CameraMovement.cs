using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

  public float camSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
    float delta = Time.deltaTime;
    float y = Input.GetAxis("Vertical");
    float x = Input.GetAxis("Horizontal");
    transform.position += new Vector3(x * delta * camSpeed, y * delta * camSpeed, 0.0f);
    
	}
}
