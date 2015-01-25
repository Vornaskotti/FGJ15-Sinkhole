using UnityEngine;
using System.Collections;

public class EntitySpawner : MonoBehaviour {

	private float levelWidth;
	private Curve curve;
	public GameObject lvlGen;
	
	public GameObject cow;
	
	// Timer
	float time = 0f;
	float timeLimit = 3f;
	
	// Use this for initialization
	void Start () {
		LevelGenerator levelGenerator = lvlGen.GetComponent<LevelGenerator>();
		curve = levelGenerator.curve;
		levelWidth = levelGenerator.levelWidth;
	}
	
	// Update is called once per frame
	void Update () {
		if(timeLimit > 0f){
			if(time < timeLimit){
				time += Time.deltaTime;
			} else {
				this.spawn ();
				time = 0f;
			}
		}
	}
	
	void spawn () {
		float y = this.transform.position.y;
		LevelGenerator levelGenerator = lvlGen.GetComponent<LevelGenerator>();
		Curve curve = levelGenerator.curve;
		float x = Random.Range (-levelWidth/2f, levelWidth/2f) + curve.getOffset(y);
		Instantiate(cow, new Vector3(x, y, 0f), Quaternion.identity);
		Debug.Log("Cow Spawned!");
	}
	
	float getOffset(float y) {
		return curve.getOffset(y);
	}
}
