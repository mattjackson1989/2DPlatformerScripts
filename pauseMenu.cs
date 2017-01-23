
using UnityEngine;

using System.Collections;
using UnityEngine.SceneManagement;
public class pauseMenu : MonoBehaviour {

	public GameObject PauseUI;

	public static bool paused = false;
	public static bool bypass;
	void Start(){

		// disable the canvas
		PauseUI.SetActive (false);
		bypass = false;
	}

	void Update(){
		if(Input.GetButtonDown("Pause")){
			paused = !paused;
		}
		if(paused){
			if (bypass == false) {
				PauseUI.SetActive (true);
			}
			Time.timeScale = 0;
		}
		if(!paused){

			PauseUI.SetActive(false);
			Time.timeScale = 1;

		}

	}

	public void Resume(){

		paused = false;

	}

	public void Restart(){
		SceneManager.LoadScene ("level001", LoadSceneMode.Additive);
	}
	public void MainMenu(){

		// TODO: Make Main Menu

	}

	public void Quit(){

		SceneManager.LoadScene ("start", LoadSceneMode.Additive);
	}
}
