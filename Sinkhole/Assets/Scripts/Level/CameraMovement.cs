using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

  public LevelGenerator levelGenerator;
  private GameState gameState;

  public float camSpeed;
  public float camMin;
  public float followRate;
  
  public Transform endBall1;
  public Transform endBall2;
	// Use this for initialization
	void Start () {
		gameState = GameObject.Find("GameState").GetComponent<GameState>();
	}
	
	// Update is called once per frame
	void Update () {
		if (gameState.currentGrab == null) {
      Curve curve = levelGenerator.curve;
      float delta = Time.deltaTime;
      float y = Input.GetAxis("Vertical");
      
      Vector3 chainmiddle = endBall2.position + (endBall1.position - endBall2.position)/2.0f;
      
      float newY = chainmiddle.y;
      newY = Mathf.Max(newY, camMin);
      float x = curve.getOffset(newY);
      x = 0.0f;
      transform.position = Vector3.Lerp(transform.position, new Vector3(x, newY, transform.position.z), Time.deltaTime * followRate);
    }
	}
}
