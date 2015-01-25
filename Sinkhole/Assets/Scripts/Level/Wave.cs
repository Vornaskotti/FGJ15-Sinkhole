using UnityEngine;
using System.Collections;

public class Wave : MonoBehaviour {
  
  public int numSpawns;
	public GameObject alertMessage;
  public EntitySpawner entitySpawner;
  public Transform follow;
  public float maxTimeLimit;
  public float minTimeLimit;
//  public Vector3 offset;
  public float levelWidth;
  
  public double waveLife;
  
  public Vector3 offset;
  
//  private float[] points;

	// Use this for initialization
	void Start () {
//    points = new float[numSpawns];
	  for (int i = 0; i < numSpawns; i++) {
      float x = Random.Range(-levelWidth/2.0f + 1.0f, levelWidth/2.0f - 1.0f);
      EntitySpawner spawner = Instantiate(entitySpawner, new Vector3(x, this.transform.position.y, 0.0f), Quaternion.identity) as EntitySpawner;
      spawner.follow = this.transform;
      spawner.timeLimit = Random.Range(minTimeLimit, maxTimeLimit);
    }
	}
  
  private double lifeTimer = 0.0;
	
	// Update is called once per frame
	void Update () {
    lifeTimer += Time.deltaTime;
    if (follow != null) {
      transform.position = follow.position + offset;
    }
    if (lifeTimer > waveLife) {
      Destroy(gameObject);
    }
	}
}
