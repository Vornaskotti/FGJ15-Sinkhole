using UnityEngine;
using System.Collections;

public class Curve {
  
  public int height;
  public int steps;
  public int maxOffset;
	// Use this for initialization
  public float[] points;
  private float stepSize;
  
  public Curve(int aHeight, int aSteps, int aMaxOffset) {
    height = aHeight;
    steps = aSteps;
    maxOffset = aMaxOffset;
    stepSize = height / (float)steps;
    points = createCurveAnchors(steps + 2, -maxOffset/2.0f, maxOffset/2.0f);
  }

  public float getOffset(float y) {
    float yStep = y / stepSize;
    int lowerIndex = (int)Mathf.Floor(yStep);
    int upperIndex = lowerIndex + 1;
    if (lowerIndex >= points.Length - 1) {
    	lowerIndex = points.Length - 2;
    	upperIndex = points.Length - 1;
    }
    float a = points[lowerIndex];
    float b = points[upperIndex];
    float mu = yStep - lowerIndex;
    return 0.0f;
//    return cosineInterpolate(a, b, mu);
  }
	
	float[] createCurveAnchors(int length, float min, float max) {
		float[] anchors = new float[length];
		for (int i = 0; i < length; i++) {
			anchors[i] = Random.Range(min, max);
		}
		return anchors;
  }
  
//  float interpolate(float a, float b, float mu) {
//    return a * Mathf.Cos(mu * Mathf.PI) + b * Mathf.Cos((1 - mu) * Mathf.PI);
//  }
  
  float cosineInterpolate(float f, float c, float mu) {
    float mu2 = (1.0f - Mathf.Cos(mu * Mathf.PI)) * 0.5f;
    return (f * (1.0f - mu2) + c * mu2);
  }
  
}
