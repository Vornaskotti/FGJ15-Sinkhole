using UnityEngine;
using System.Collections;

public class LavaParticleWave : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
//	void Update () {
//	
//	}
	
	public int numParticles = 0;
	
	void Update() {
	
		Particle[] particles = particleEmitter.particles;
		int i = 0;
		numParticles = particles.Length;
		while (i < particles.Length) {
			float xPosition = Mathf.Sin(Time.time);
			particles[i].position += new Vector3(xPosition * 100.0f, 0, 0);
			particles[i].color = Color.red;
			particles[i].size = Mathf.Sin(Time.time) * 0.2F;
			i++;
		}
		particleEmitter.particles = particles;
	}
}
