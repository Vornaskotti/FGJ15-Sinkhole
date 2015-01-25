using UnityEngine;
using System.Collections;

public class WaveGenerator : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	public double checkPeriod;
	
	public double waveTimer;
	
	public Wave[] waves;
	
	public float waveProbability;
	
	private int checkCounter;
	
	// Update is called once per frame
	void Update () {
		waveTimer += Time.deltaTime;
		
		if (waveTimer > checkPeriod * checkPeriod) {
			checkCounter++;
			
		}
	}
	
	void spawnRandomWave() {
		float r = Random.Range(0.0f, 1.0f);
		if (r <= waveProbability) {
			int rWave = Random.Range(0, waves.Length);
			Instantiate(waves[rWave]);
		}
	}
}
