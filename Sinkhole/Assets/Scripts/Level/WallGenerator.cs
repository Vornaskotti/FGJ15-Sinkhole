using UnityEngine;
using System.Collections;

public class WallGenerator : MonoBehaviour {
  
  public float minWidth;
  public int height;
  public int stepSize;
  public int roughness;
	// Use this for initialization
	void Start () {
//		createWall(height);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void createLeftWall(int height, Curve curve) {    
    PolygonCollider2D collider2D = GetComponent<PolygonCollider2D>();
		if (stepSize < 1) {
			stepSize = 1;
		}	
    int steps = height / stepSize;
    Vector2[] points = new Vector2[steps + 3];
    
    points[0] = new Vector2(-100.0f, 0.0f);
  
    for (int i = 0; i <= steps; i++) {
      int rand = Random.Range(0, 10) * roughness;
      points[i + 1] = new Vector2(minWidth + rand / 10.0f + curve.getOffset((float)(i * stepSize + transform.position.y)), i * stepSize);
    }
    points[steps + 2] = new Vector2(-100.0f, height);
    collider2D.points = points;
	}
  
	public void createRightWall(int height, Curve curve) {    
		PolygonCollider2D collider2D = GetComponent<PolygonCollider2D>();
		if (stepSize < 1) {
			stepSize = 1;
		}	
		int steps = height / stepSize;
		Vector2[] points = new Vector2[steps + 3];
		
		points[0] = new Vector2(100.0f, 0.0f);
		
		for (int i = 0; i <= steps; i++) {
			int rand = Random.Range(0, 10) * roughness;
			points[i + 1] = new Vector2(minWidth + rand / 10.0f + curve.getOffset((float)(i * stepSize + transform.position.y)), i * stepSize);
		}
		points[steps + 2] = new Vector2(100.0f, height);
        collider2D.points = points;
  }
}
