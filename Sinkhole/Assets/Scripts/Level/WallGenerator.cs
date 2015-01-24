using UnityEngine;
using System.Collections;

public class WallGenerator : MonoBehaviour {
  
  public float minWidth;
  public int height;
	// Use this for initialization
	void Start () {
//		createWall(height);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void createLeftWall(int height, Curve curve) {    
    PolygonCollider2D collider2D = GetComponent<PolygonCollider2D>();
    Vector2[] points = new Vector2[height + 3];
    
    points[0] = new Vector2(-100.0f, 0.0f);
//    points[1] = new Vector2(minWidth, 0.0f);
    for (int i = 0; i <= height; i++) {
      int rand = Random.Range(0, 10);
//      rand = 0;
      print("Offset for: " + (float)i);
      points[i + 1] = new Vector2(minWidth + rand / 10.0f + curve.getOffset((float)(i + transform.position.y)), i);
    }
//    points[height + 1] = new Vector2(minWidth, height);
    points[height + 2] = new Vector2(-100.0f, height);
    collider2D.points = points;
	}
  
  public void createRightWall(int height, Curve curve) {    
    PolygonCollider2D collider2D = GetComponent<PolygonCollider2D>();
    Vector2[] points = new Vector2[height + 3];
    
    points[0] = new Vector2(100.0f, 0.0f);
    for (int i = 0; i <= height; i++) {
      int rand = Random.Range(0, 10);
      print("Offset for: " + (float)i);
      points[i + 1] = new Vector2(minWidth + rand / 10.0f + curve.getOffset((float)(i + transform.position.y)), i);
    }
    points[height + 2] = new Vector2(100.0f, height);
    collider2D.points = points;
  }
}
