using UnityEngine;
using System.Collections;

public class LightDiminish : MonoBehaviour {

	public float startDiminish;
	public float stopDiminish;
	public float intensity;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float y = transform.position.y;
		if (y > startDiminish) {
			Light light = GetComponent<Light>();
			light.intensity = intensity *  (1.0f - (y - startDiminish) / (stopDiminish - startDiminish));
			
		}
	}
}
