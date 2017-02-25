using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour {
	
	public void OnStartButtonBlick() {
		SceneManager.LoadScene ("game");
	}

	public void OnQuitButtonClick() {
#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#else
		Application.Quit ();
#endif
	}

	public void OnQuitGameButtonClick() {
		SceneManager.LoadScene ("MainMenu");
	}
}
