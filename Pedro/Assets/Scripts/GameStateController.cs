using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateController : MonoBehaviour {
	private bool paused;

	void Start () {
		paused = false;
	}

	void Update () {
		
	}

	public void PauseResume() {
		paused = !paused;

		if (paused)
			Pause ();
		else
			Resume ();
	}

	public void Pause() {
		Time.timeScale = 0;
	}

	public void Resume() {
		Time.timeScale = 1;
	}
}
