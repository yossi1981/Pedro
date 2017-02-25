using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

	public GameObject Obstacle;
	public int SpawnRate;
	private int LastSpawnTime;
	private Vector2 lastPos;

	// Use this for initialization
	void Start () {
		this.gameObject.GetComponent<Animator>().Play ("Run_01");
		lastPos = transform.position;

	}

	// Update is called once per frame
	void Update () {
		var currentSecond = (int)Time.time;
		if (currentSecond - LastSpawnTime >= SpawnRate) {	
			GameObject obstacle = Instantiate(Obstacle,Obstacle.transform.position, Quaternion.identity);
			LastSpawnTime = currentSecond;
		}

		if (Input.GetMouseButtonDown (0)) {
			this.gameObject.GetComponent<Animator>().Play ("Jump_01");
			this.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 8.0f, ForceMode2D.Impulse);
		}




		lastPos = transform.position;

	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (transform.position.y != lastPos.y) {
			this.gameObject.GetComponent<Animator>().Play ("Run_01");
			AudioSource audio = GetComponent<AudioSource> ();
			audio.Play ();
		}
	}
}
