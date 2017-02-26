using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour {
	public void OnStartButtonBlick() {
		SceneManager.LoadScene ("Game");
	}

	public void OnQuitButtonClick() {
		GameState.QuitApp ();
	}

	public void OnQuitGameButtonClick() {
		GameState.Quit ();
		SceneManager.LoadScene ("MainMenu");
	}

	public void OnPauseButtonClick() 	{
		GameState.PauseResume ();
	}
}
