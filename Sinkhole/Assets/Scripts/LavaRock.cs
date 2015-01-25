using UnityEngine;
using System.Collections;

public class LavaRock : MonoBehaviour {
	
	public Vector2 startSpeed;
	public int collisions = 1;
	public GameObject particleSystem;
	public GameObject explosionParticles;
	
	GameObject particles;
	GameObject explosion;
	
	// Use this for initialization
	void Start () {
		this.rigidbody2D.velocity = new Vector2(Random.Range(-startSpeed.x, startSpeed.x),
		                                        Random.Range(startSpeed.y*0.8f, startSpeed.y));
		this.rigidbody2D.angularVelocity = Random.Range(-300f, 300f);
		this.rigidbody2D.rotation = Random.Range(0, 359);
		
		particles = Instantiate(particleSystem, new Vector3(0f, 0f, 1f), Quaternion.identity) as GameObject;
	}
	
	void Update () {
		particles.transform.position = new Vector2(this.transform.position.x, this.transform.position.y);
	}
	
	void OnCollisionEnter2D(Collision2D other){
		if(--collisions < 0){
			particles.GetComponent<ParticleSystem>().enableEmission = false;
			explosion = Instantiate(explosionParticles, this.transform.position, Quaternion.identity) as GameObject;
			GameObject.Destroy(particles, 5f);
			GameObject.Destroy(this.gameObject, 0.1f);
		}
	}
}
