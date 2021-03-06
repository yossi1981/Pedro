using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameState {

	private const int INITIAL_SCORE = 0;
	private const int INITIAL_SCORE_INCREMENT = 1;
	private const bool INITAL_PAUSE_STATE = false;
	private const int INITIAL_TIME_SCALE = 1;
	private const int PAUSED_TIME_SCALE = 0;

	public static bool paused;
	public static int score;
	public static int scoreIncrement;

	public delegate void ScoreChangeDelegate(int Score);
	public delegate void ResetDelegate();

	public static event ScoreChangeDelegate OnScoreChanged;

	static GameState() {
		Reset ();
	}

	static public void Reset() {
		paused = INITAL_PAUSE_STATE;
		score = INITIAL_SCORE;
		scoreIncrement = INITIAL_SCORE_INCREMENT;
		Resume ();
	}

	static public void Quit() {
		Reset();
	}

	static public void QuitApp() {
		Reset();
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#else
		Application.Quit ();
		#endif
	}

	static public void PickStar() {
		score += scoreIncrement;
		OnScoreChanged (score);
	}

	static public void PauseResume() {
		paused = !paused;

		if (paused)
			Pause ();
		else
			Resume ();
	}

	static public void Pause() {
		Time.timeScale = PAUSED_TIME_SCALE;
	}

	static public void Resume() {
		Time.timeScale = INITIAL_TIME_SCALE;
	}
}