using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_Menu : MonoBehaviour
{
	public static bool isPaused = false;
	public GameObject pauseMenuUI;

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.P))
		{
			if (isPaused)
			{
				Resume();
			}
			else
			{
				Pause();
			}
		}
	}

	public void Resume()
	{
		pauseMenuUI.SetActive(false);
		Time.timeScale = 1f;
		isPaused = false;

	}

	void Pause()
    {
		pauseMenuUI.SetActive(true);
		Time.timeScale = 0f;
		isPaused = true;
    }
	
	public void RestartLevel(){
		Debug.Log("Restarting Level...");
		Time.timeScale = 1f;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void LoadMenu()
    {
		Debug.Log("Loading Main Menu...");
		Time.timeScale = 1f;
		SceneManager.LoadScene("Main_Menu");
    }

	public void QuitGame()
    {
		Debug.Log("Quiting Game...");
		Application.Quit();
    }
}
