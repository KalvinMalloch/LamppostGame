using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class MenuManager : MonoBehaviour
{
	public GameObject MainMenu;
	public GameObject WinMenu;
	public GameObject CreditsPanel;
	public GameObject player;
    public GameObject PauseMenu;
    public Text timeText;
	public float timer;

	void Awake() {
		timer = 0f;
    }

	void Update() {
		PlayerScore();
        if (Input.GetKey(KeyCode.Escape) == true)
        {
            Pause();
        }
    }

	public void PlayerScore() {
        MovementScript playerScripts = player.GetComponent<MovementScript>();
        if (playerScripts.depression <= 0) {
			Time.timeScale = 0;
			WinMenu.SetActive (true);
			player.SetActive (false);
            timer = Mathf.Round(timer * 100f) / 100f;
            timeText.text = "You survived for " + timer.ToString() + " seconds.";
		} else {
			timer += Time.deltaTime;
		}
	}

	public void Start() {
		MainMenu.SetActive (true);
		CreditsPanel.SetActive (false);
	}

	public void LoadLevel (int name) {
		SceneManager.LoadScene(name);
	}

	public void MainMenuReturn(){
		MainMenu.SetActive (true);
		CreditsPanel.SetActive (false);
	}
	
	public void WinReturn(){
		WinMenu.SetActive (true);
		CreditsPanel.SetActive (false);
	}

    public void Pause()
    {
        MovementScript playerScripts = player.GetComponent<MovementScript>();
        playerScripts.moveControls = false;
        PauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void LoadCredits(){
		MainMenu.SetActive (false);
		CreditsPanel.SetActive (true);
	}
	
	public void LoadCreditsDeath(){
		WinMenu.SetActive (false);
		CreditsPanel.SetActive (true);
	}

	public void Exit() {
		Application.Quit();
		Debug.Log ("Game is exiting.");
	}
}
