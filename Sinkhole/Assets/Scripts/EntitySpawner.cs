using UnityEngine;
using System.Collections;

public class EntitySpawner : MonoBehaviour {

	public float levelWidth;
	
	public GameObject entity;
  
  public Transform follow;
	
	// Timer
	float time = 0f;
	public float timeLimit = 3f;
	
	// Use this for initialization
	void Start () {
//		LevelGenerator levelGenerator = lvlGen.GetComponent<LevelGenerator>();
//		curve = levelGenerator.curve;
//		levelWidth = levelGenerator.levelWidth;
	}
	
  private bool isDone = false;
	// Update is called once per frame
	void Update () {
		if(timeLimit > 0f && !isDone){
			if(time < timeLimit){
				time += Time.deltaTime;
			} else {
				this.spawn ();
        isDone = true;
			}
		}
    if (isDone) {
    Destroy(gameObject);
    }
	}
	
	void spawn () {
    if (follow != null) {
      transform.position = new Vector3(transform.position.x, follow.position.y, transform.position.z);
    } else {
    }
		float y = this.transform.position.y;
//		LevelGenerator levelGenerator = lvlGen.GetComponent<LevelGenerator>();
//		Curve curve = levelGenerator.curve;
		float x = Random.Range (-levelWidth/2f, levelWidth/2f) + transform.position.x;
		Instantiate(entity, new Vector3(x, y, 0f), Quaternion.identity);
	}
	
//	float getOffset(float y) {
//		return curve.getOffset(y);
//	}
}
