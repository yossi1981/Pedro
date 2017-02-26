using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Character : MonoBehaviour {

	public GameObject Obstacle;
	public GameObject Star;

	private float ObstacleSpawnRate;
	private int StarSpawnRate;

	private int LastObstacleSpawnTime;
	private int LastStarSpawnTime;

	private Vector2 lastPos;
	GameObject gameOverPanel;
	GameObject pauseMaskPanel;

	private int jumpLevel;

	public void Reset() {
		GameState.Reset ();
		ObstacleSpawnRate = 5;
		StarSpawnRate = 3;
		jumpLevel = 0;

		this.gameObject.GetComponent<Animator>().Play ("Run_01");
		lastPos = transform.position;

		gameOverPanel = GameObject.FindWithTag("GameOverPanel");
		gameOverPanel.SetActive (false);

		pauseMaskPanel = GameObject.FindWithTag("PauseMaskPanel");
		pauseMaskPanel.SetActive (false);
	}

	void Start () {
		Reset ();
	}

	void Update () {
		pauseMaskPanel.SetActive (GameState.paused);
		var currentSecond = (int)Time.time;

		float effectiveObstacleSpawnRate = (float)ObstacleSpawnRate - GameState.score / 10.0f;
		if (currentSecond - LastObstacleSpawnTime >= effectiveObstacleSpawnRate) {	
			GameObject obstacle = Instantiate(Obstacle, Obstacle.transform.position, Quaternion.identity);
			obstacle.transform.position = obstacle.transform.position + Vector3.left * ((float)Random.Range (-300, 300) / 100.0f) ;
			LastObstacleSpawnTime = currentSecond;
		}


		if (currentSecond - LastStarSpawnTime >= StarSpawnRate) {	
			GameObject star = Instantiate(Star, Star.transform.position, Quaternion.identity);
			star.transform.position = star.transform.position + Vector3.up * ((float)Random.Range (-200, 200) / 100.0f) ;
			LastStarSpawnTime = currentSecond;
		}
			
		if (Input.GetMouseButtonDown (0)) {
			if (!EventSystem.current.IsPointerOverGameObject()) {
				if (GameState.paused == false && jumpLevel < 2) {
					jumpLevel++;
					this.gameObject.GetComponent<Animator> ().Play ("Jump_01");
					this.GetComponent<Rigidbody2D> ().AddForce (Vector2.up * 400.0f, ForceMode2D.Force);
				}
			}
		}
			
		lastPos = transform.position;
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag.Equals("Obstacle")) {
			GameState.Pause ();
			gameOverPanel.SetActive (true);
		}

		if (coll.gameObject.tag.Equals ("Star")) {
			GameState.PickStar ();
			GameObject.Find ("PickupStar").GetComponent<AudioSource> ().Play ();
			GameObject.Destroy (coll.gameObject);
		} else {
			if (transform.position.y != lastPos.y) {
				this.gameObject.GetComponent<Animator>().Play ("Run_01");
				jumpLevel = 0;
				AudioSource audio = GetComponent<AudioSource> ();
				audio.Play ();
			}
		}
			

	}
}
