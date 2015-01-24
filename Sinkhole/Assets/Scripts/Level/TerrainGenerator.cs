using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class TerrainGenerator : MonoBehaviour {

  public float textureScale;

  PolygonCollider2D collider;
	// Use this for initialization
  void Start() {
    collider = GetComponent<PolygonCollider2D>();
    
    MeshFilter meshFilter = GetComponent<MeshFilter>();
    MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
    
    meshFilter.mesh = createMesh(collider.points);
	}
	
	// Update is called once per frame 
  void Update () {
	
	}
  
  void generateSection() {
  
  }
  
  Mesh createMesh(Vector2[] points) {
  	Mesh mesh = new Mesh();
  	
  	Vector3[] vertices = new Vector3[points.Length];
    Vector3[] normals = new Vector3[points.Length];
    
    Vector2[] uvs = new Vector2[points.Length];
    
  	
  	for (int i = 0; i < points.Length; i++) {
  		vertices[i] = new Vector3(points[i].x, points[i].y, 0.0f);
      uvs[i] = new Vector2(points[i].x / textureScale, points[i].y / textureScale);
      normals[i] = new Vector3(0, 0, -1);
  	}
  	
		
	  Triangulator tr = new Triangulator(points);
	  int[] tris = tr.Triangulate();
  	
  	mesh.vertices = vertices;
    mesh.uv = uvs;
    mesh.normals = normals;
  	mesh.triangles = tris;
  	
  	return mesh;
  }
}
