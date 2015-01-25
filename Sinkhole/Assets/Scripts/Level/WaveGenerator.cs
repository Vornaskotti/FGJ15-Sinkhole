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
  
  public float levelWidth;
	
	// Update is called once per frame
	void Update () {
		waveTimer += Time.deltaTime;
		
		if (waveTimer > checkCounter * checkPeriod) {
			checkCounter++;
			spawnRandomWave();
		}
	}
	
	void spawnRandomWave() {
		float r = Random.Range(0.0f, 1.0f);
		if (r <= waveProbability) {
			int rWave = Random.Range(0, waves.Length);
			Wave wave = Instantiate(waves[rWave]) as Wave;
      wave.follow = this.transform;
//      float x = Random.Range(-levelWidth/2.0f + 1.0f, levelWidth/2.0f - 1.0f);
//      wave.offset = new Vector3(x, 0, 0);
		}
	}
}
