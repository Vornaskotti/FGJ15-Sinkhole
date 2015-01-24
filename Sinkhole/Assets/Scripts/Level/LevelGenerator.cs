using UnityEngine;
using System.Collections;

public class LevelGenerator : MonoBehaviour {
	
	public GameObject wall;
  
  public GameObject rockA;
  public GameObject rockB;
  public GameObject rockC;
	
	public int levelHeight;
  
  public float levelWidth;
  
  public int numRocks;
  
  public int minRockDistance;
  public int maxRockDistance;
  
  public int curveSteps;
  public int maxCurveOffset;
  
//  public Curve curve;
	
	// Use this for initialization
	void Start () {
    Curve curve = new Curve(levelHeight, curveSteps, maxCurveOffset);
    int wallHeight = wall.GetComponent<WallGenerator>().height;
    float halfWidth = levelWidth / 2;
		for (int i = 0; i < levelHeight; i += wallHeight) {
      GameObject leftWall = Instantiate(wall, new Vector3(-halfWidth, i, 0.0f), Quaternion.identity) as GameObject;
      WallGenerator leftWallGen = leftWall.GetComponent<WallGenerator>();
      leftWallGen.createLeftWall(wallHeight, curve);
      
      GameObject rightWall = Instantiate(wall, new Vector3(halfWidth, i, 0.0f), Quaternion.identity) as GameObject;
      WallGenerator rightWallGen = rightWall.GetComponent<WallGenerator>();
      rightWallGen.createRightWall(wallHeight, curve);
    }
    
    float previousCoordinateY = 0.0f;
    
    while (previousCoordinateY < levelHeight - wallHeight) {
      previousCoordinateY = addRock(previousCoordinateY, curve);
    }
    previousCoordinateY = 0.0f;
    while (previousCoordinateY < levelHeight - wallHeight) {
      previousCoordinateY = addRock(previousCoordinateY, curve);
    }
	}
  
  float addRock(float previousCoordinateY, Curve curve) {
    int r = Random.Range(0, 3);
    GameObject rock;
    if (r == 0) {
      rock = rockA;
    } else if (r == 1) {
      rock = rockB;
    } else {
      rock = rockC;
    }
    int x = Random.Range(2, (int)levelWidth - 2) - (int)(levelWidth / 2.0f);
    int y = Random.Range(minRockDistance, maxRockDistance);
    
    Quaternion rotation = Quaternion.AngleAxis(Random.Range (0, 360), Vector3.forward);
    
    GameObject rockObj = Instantiate(
      rock, 
      new Vector3(x + curve.getOffset(previousCoordinateY + y), previousCoordinateY + y, 100.0f),
      rotation) as GameObject;
    previousCoordinateY = previousCoordinateY + y;    
    PolygonCollider2D rockCollider = rockObj.GetComponent<PolygonCollider2D>();
    Vector2[] pointsRockCollider = rockCollider.points;
    for (int j = 0; j < pointsRockCollider.Length; j++) {
      float randX = Random.Range(0, 10) / 10.0f - 0.5f;
      float randY = Random.Range(0, 10) / 10.0f - 0.5f;
      pointsRockCollider[j] = pointsRockCollider[j] + new Vector2(randX, randY);
    }
    rockCollider.points = pointsRockCollider;
    return previousCoordinateY;  
  }
    
    // Update is called once per frame
	void Update () {
	}
	
}
