using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour {


	// Use this for initialization
	void Start () {
		GameState.OnScoreChanged += ScoreChangedHandler;
	}

	private void ScoreChangedHandler(int score)  {
		GetComponent<Text>().text = score.ToString();
	}

	public void OnDestroy() {
		GameState.OnScoreChanged -= ScoreChangedHandler;
	}

	// Update is called once per frame
	void Update () {
		
	}
}
