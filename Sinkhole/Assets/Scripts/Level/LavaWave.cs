using UnityEngine;
using System.Collections;

public class LavaWave : MonoBehaviour {

	public int resolutionX;
	public int resolutionY;
  
  public int width;
  public int height;
  
  private float stepWidth;
  private float stepHeight;
  
  public float waveHeight;
  
  public Transform camera;
	
	private ParticleSystem.Particle[] points;
  
	// Use this for initialization
	void Start () {
		points = new ParticleSystem.Particle[resolutionX * resolutionY];
    stepWidth = width / (float)resolutionX;
    stepHeight = height / (float)resolutionY;
	}
	
	// Update is called once per frame
	void Update () {
    transform.position = new Vector3(Mathf.Floor(camera.position.x), transform.position.y, transform.position.z);
    for (int x = 0; x < resolutionX; x++) {
      for (int y = 0; y < resolutionY; y++) {
        points[x + y * resolutionX].position = 
          new Vector3(
            (x - resolutionX/2) * stepWidth, 
            -(y + Mathf.Sin(Mathf.Floor(camera.position.x) + x*stepWidth + Time.time) * waveHeight + 
			      Mathf.Cos(-0.5f*(x*stepWidth + Mathf.Floor(camera.position.x)) + Time.time) * waveHeight) * stepHeight - 2.0f * waveHeight,
             1);
        points[x + y * resolutionX].color = new Color(1f, 0f, 0f);
        points[x + y * resolutionX].size = 3.0f;
      }
    }
		particleSystem.SetParticles(points, points.Length);
	}
}
